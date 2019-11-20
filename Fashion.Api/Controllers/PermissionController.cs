﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
	public class PermissionController : ControllerBase
	{
		IPermissionServices _permissionServices;
		IRoleModulePermissionServices _roleModulePermissionServices;

		public PermissionController(IPermissionServices permissionServices, IRoleModulePermissionServices roleModulePermissionServices)
		{
			_permissionServices = permissionServices;
			_roleModulePermissionServices = roleModulePermissionServices;
		}

		[HttpGet]
		public async Task<MessageModel<PermissionDto>> Get(int id)
		{
			var data = new MessageModel<PermissionDto>();
			var permission = await _permissionServices.GetPermissionById(id);

			if (permission != null)
			{
				data.data = permission;
				data.success = true;
				data.msg = "获取成功";
			}

			return data;
		}

		[HttpPost]
		public async Task<MessageModel<string>> Post([FromBody] Permission permission)
		{
			var data = new MessageModel<string>();

			var id = (await _permissionServices.Add(permission));
			data.success = id > 0;
			if (data.success)
			{
				data.msg = "添加成功";
				data.data = id.ObjToString();
			}

			return data;
		}

		[HttpPut]
		public async Task<MessageModel<string>> Update([FromBody] Permission permission)
		{
			var data = new MessageModel<string>();
			if (permission != null && permission.Id > 0)
			{
				data.success = await _permissionServices.Update(permission);
				if (data.success)
				{
					data.msg = "更新成功";
					data.data = permission?.Id.ObjToString();
				}
			}

			return data;
		}

		[HttpGet]
		[Route("list")]
		public async Task<MessageModel<List<Permission>>> GetList()
		{
			var list = await _permissionServices.Query(t => t.IsDeleted == false && t.Enabled);
			return new MessageModel<List<Permission>>()
			{
				msg = "获取成功",
				success = true,
				data = list
			};
		}

		[HttpDelete]
		public async Task<MessageModel<string>> Delete(int id)
		{
			var data = new MessageModel<string>();
			if (id > 0)
			{
				var permission = await _permissionServices.QueryById(id);
				permission.IsDeleted = true;
				data.success = await _permissionServices.Update(permission);
				if (data.success)
				{
					data.msg = "删除成功";
					data.data = permission?.Id.ObjToString();
				}
			}

			return data;
		}

		[HttpGet]
		[Route("pagelist")]
		public async Task<MessageModel<PageModel<PermissionDto>>> GetPageList(int page, int size, string keyword = "")
		{
			if (string.IsNullOrEmpty(keyword) || string.IsNullOrWhiteSpace(keyword))
			{
				keyword = "";
			}

			var list = await _permissionServices.GetPageList(page, size, keyword);
			return new MessageModel<PageModel<PermissionDto>>()
			{
				msg = "获取成功",
				success = true,
				data = list
			};
		}

		/// <summary>
		/// 通过角色获取菜单
		/// </summary>
		/// <param name="roleId"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("permissionidsbyroleid")]
		public async Task<MessageModel<AssignPermission>> GetPermissionIdsByRoleId(int roleId)
		{
			var data = await _permissionServices.GetPermissionIdsByRoleId(roleId);
			return new MessageModel<AssignPermission>()
			{
				msg = "获取成功",
				success = true,
				data = data
			};
		}

		/// <summary>
		/// 保存菜单权限分配
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("assign")]
		public async Task<MessageModel<string>> Assign([FromBody] AssignInput input)
		{
			var data = new MessageModel<string>();
			if (input.roleId > 0 && input.permissionIds.Count > 0)
			{
				data.success = await _permissionServices.Assign(input.roleId, input.permissionIds);
				data.msg = "授权成功";
			}
			else
			{
				data.success = false;
				data.msg = "授权失败";
			}

			return data;
		}

		/// <summary>
		/// 通过用户获取菜单
		/// </summary>
		/// <param name="userId"></param >
		/// <returns></returns>
		[HttpGet]
		[Route("permissionlistbyuserid")]
		public async Task<MessageModel<List<PermissionDto>>> GetPermissionListByUserId(int userId)
		{
			var data = await _permissionServices.GetPermissionListByUserId(userId);
			return new MessageModel<List<PermissionDto>>()
			{
				msg = "获取成功",
				success = true,
				data = data
			};
		}

	}
}