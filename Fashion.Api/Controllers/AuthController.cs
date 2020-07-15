using Fashion.Api.Auth;
using Fashion.Common.Helper;
using Fashion.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fashion.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private IUserServices _userServices;
		private PermissionRequirement _requirement;

		public AuthController(IUserServices userServices, PermissionRequirement requirement)
		{
			_requirement = requirement;
			_userServices = userServices;
		}

		[HttpGet]
		[Route("token")]
		public async Task<object> Token(string username, string password)
		{
			string jwtStr = string.Empty;

			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				return new JsonResult(new
				{
					Status = false,
					message = "用户名或密码不能为空"
				});
			}

			password = MD5Helper.MD5Encrypt32(password);
			var user = await _userServices.GetUsersByNameAndPwd(username, password);
			if (user.Count > 0)
			{
				var userRoles = await _userServices.GetRoleNames(username, password);
				//如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
				var claims = new List<Claim> {
					new Claim(ClaimTypes.Name, username),
					new Claim(JwtRegisteredClaimNames.Jti, user.FirstOrDefault().Id.ToString()),
					new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(_requirement.Expiration.TotalSeconds).ToString()) };
				claims.AddRange(userRoles.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));

				//用户标识
				var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
				identity.AddClaims(claims);

				var token = JwtToken.BuildJwtToken(claims.ToArray(), _requirement);
				return new JsonResult(token);
			}
			else
			{
				return new JsonResult(new
				{
					success = false,
					message = "用户名或密码不正确"
				});
			}
		}

		/// <summary>
		/// 请求刷新Token（以旧换新）
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("refreshToken")]
		public async Task<object> RefreshToken(string token = "")
		{
			string jwtStr = string.Empty;

			if (string.IsNullOrEmpty(token))
			{
				return new JsonResult(new
				{
					Status = false,
					message = "token无效，请重新登录！"
				});
			}
			var tokenModel = JwtHelper.SerializeJwt(token);
			if (tokenModel != null && tokenModel.UserId > 0)
			{
				var user = await _userServices.QueryById(tokenModel.UserId);
				if (user != null)
				{
					var userRoles = await _userServices.GetRoleNames(user.LoginName, user.Password);
					//如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
					var claims = new List<Claim> {
					new Claim(ClaimTypes.Name, user.LoginName),
					new Claim(JwtRegisteredClaimNames.Jti, tokenModel.UserId.ObjToString()),
					new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(_requirement.Expiration.TotalSeconds).ToString()) };
					claims.AddRange(userRoles.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));

					//用户标识
					var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
					identity.AddClaims(claims);

					var refreshToken = JwtToken.BuildJwtToken(claims.ToArray(), _requirement);
					return new JsonResult(refreshToken);
				}
			}

			return new JsonResult(new
			{
				success = false,
				message = "认证失败"
			});
		}
	}
}