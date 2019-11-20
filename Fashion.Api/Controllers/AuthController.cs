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
		[Route("Token")]
		public async Task<object> Token(string name, string pwd)
		{
			string jwtStr = string.Empty;

			if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd))
			{
				return new JsonResult(new
				{
					Status = false,
					message = "用户名或密码不能为空"
				});
			}

			pwd = MD5Helper.MD5Encrypt32(pwd);
			var user = await _userServices.GetUsersByNameAndPwd(name, pwd);
			if (user.Count > 0)
			{
				var userRoles = await _userServices.GetRoleNames(name, pwd);
				//如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
				var claims = new List<Claim> {
					new Claim(ClaimTypes.Name, name),
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
					message = "认证失败"
				});
			}
		}
	}
}