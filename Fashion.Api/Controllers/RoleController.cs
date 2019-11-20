using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
	public class RoleController : ControllerBase
	{
		private IRoleServices _roleServices;
		private IMapper _mapper;

		public RoleController(IRoleServices roleServices, IMapper mapper)
		{
			_roleServices = roleServices;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<MessageModel<RoleDto>> Get(int id)
		{
			var data = new MessageModel<RoleDto>();
			var role = await _roleServices.GetRoleById(id);

			if (role != null)
			{
				data.data = role;
				data.success = true;
				data.msg = "获取成功";
			}

			return data;
		}

		[HttpPost]
		public async Task<MessageModel<string>> Post([FromBody] Role role)
		{
			var data = new MessageModel<string>();

			var id = (await _roleServices.Add(role));
			data.success = id > 0;
			if (data.success)
			{
				data.msg = "添加成功";
				data.data = id.ObjToString();
			}

			return data;
		}

		[HttpPut]
		public async Task<MessageModel<string>> Update([FromBody] Role role)
		{
			var data = new MessageModel<string>();
			if (role != null && role.Id > 0)
			{
				data.success = await _roleServices.Update(role);
				if (data.success)
				{
					data.msg = "更新成功";
					data.data = role?.Id.ObjToString();
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
				var role = await _roleServices.QueryById(id);
				role.IsDeleted = true;
				data.success = await _roleServices.Update(role);
				if (data.success)
				{
					data.msg = "删除成功";
					data.data = role?.Id.ObjToString();
				}
			}

			return data;
		}

		[HttpDelete]
		[Route("deleteall")]
		public async Task<MessageModel<string>> DeleteAll(string ids)
		{
			var data = new MessageModel<string>();
			if (!string.IsNullOrEmpty(ids))
			{
				var arr = ids.Split(",");
				data.success = await _roleServices.DeleteByIds(arr);
				if (data.success)
				{
					data.msg = "删除成功";
				}
			}

			return data;
		}

		[HttpGet]
		[Route("list")]
		public async Task<MessageModel<List<Role>>> GetList()
		{
			var list = await _roleServices.Query(t => t.IsDeleted == false && t.Enabled);
			return new MessageModel<List<Role>>()
			{
				msg = "获取成功",
				success = true,
				data = list
			};
		}

		[HttpGet]
		[Route("pagelist")]
		public async Task<MessageModel<PageModel<RoleDto>>> GetPageList(int page, int size, string keyword = "")
		{
			if (string.IsNullOrEmpty(keyword) || string.IsNullOrWhiteSpace(keyword))
			{
				keyword = "";
			}

			var list = await _roleServices.GetPageList(page, size, keyword);
			return new MessageModel<PageModel<RoleDto>>()
			{
				msg = "获取成功",
				success = true,
				data = list
			};
		}
	}
}