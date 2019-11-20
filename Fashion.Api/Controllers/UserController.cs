using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fashion.Common.Helper;
using Fashion.IServices;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class UserController : ControllerBase
	{
		private IUserServices _userServices;

		public UserController(IUserServices userServices)
		{
			_userServices = userServices;
		}

		[HttpGet]
		public async Task<MessageModel<UserDto>> Get(int id)
		{
			var data = new MessageModel<UserDto>();
			var user = await _userServices.GetUserById(id);

			if (user != null)
			{
				data.data = user;
				data.success = true;
				data.msg = "获取成功";
			}

			return data;
		}

		[HttpGet]
		[Route("pagelist")]
		public async Task<MessageModel<PageModel<UserDto>>> GetPageList(int page, int size, string keyword = "")
		{
			if (string.IsNullOrEmpty(keyword) || string.IsNullOrWhiteSpace(keyword))
			{
				keyword = "";
			}

			var list = await _userServices.GetPageList(page, size, keyword);
			return new MessageModel<PageModel<UserDto>>()
			{
				msg = "获取成功",
				success = true,
				data = list
			};
		}

		[HttpPost]
		public async Task<MessageModel<int>> Post([FromBody] User user)
		{
			var data = new MessageModel<int>();

			user.Password = MD5Helper.MD5Encrypt32(user.Password);
			var id = (await _userServices.AddUser(user));
			data.success = id > 0;
			if (data.success)
			{
				data.msg = "添加成功";
				data.data = id;
			}

			return data;
		}

		[HttpPut]
		public async Task<MessageModel<string>> Update([FromBody] UserDto user)
		{
			var data = new MessageModel<string>();
			if (user != null && user.Id > 0)
			{
				data.success = await _userServices.UpdateUser(user);
				if (data.success)
				{
					data.msg = "更新成功";
				}
			}

			return data;
		}

		[HttpDelete]
		public async Task<MessageModel<string>> Delete(int id)
		{
			var data = new MessageModel<string>();
			if (id > 0)
			{
				data.success = await _userServices.DeleteUser(id);
				if (data.success)
				{
					data.msg = "删除成功";
				}
			}

			return data;
		}

		[HttpGet]
		[Route("getbytoken")]
		public async Task<MessageModel<UserDto>> GetUserByToken(string token)
		{
			var data = new MessageModel<UserDto>();
			if (!string.IsNullOrEmpty(token))
			{
				var tokenModel = JwtHelper.SerializeJwt(token);
				if (tokenModel != null && tokenModel.UserId > 0)
				{
					var user = await _userServices.GetUserById(tokenModel.UserId);
					if (user != null)
					{
						data.data = user;
						data.success = true;
						data.msg = "获取成功";
					}
				}

			}
			return data;
		}
	}
}