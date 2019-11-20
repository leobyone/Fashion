using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;
using AutoMapper;
using System.Threading.Tasks;
using Fashion.Model;
using System.Collections.Generic;
using Fashion.Model.Dtos;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Fashion.Common.Helper;
using Fashion.IRepositoty;
using Fashion.Common;

namespace Fashion.Services
{
	/// <summary>
	/// PermissionServices
	/// </summary>	
	public class PermissionServices : BaseServices<Permission>, IPermissionServices
	{
		IPermissionRepository repository;
		IUserRoleRepository _userRoleRepository;
		IRoleModulePermissionRepository _roleModulePermissionRepository;
		//IHttpContextAccessor _httpContext;
		IMapper _mapper;

		public PermissionServices(IPermissionRepository repository, IRoleModulePermissionRepository roleModulePermissionRepository,
			IMapper mapper, IUserRoleRepository userRoleRepository)
		{
			this.repository = repository;
			baseRepository = repository;
			_userRoleRepository = userRoleRepository;
			_roleModulePermissionRepository = roleModulePermissionRepository;
			_mapper = mapper;
			//_httpContext = httpContext;
		}

		public async Task<PermissionDto> GetPermissionById(int id)
		{
			var model = await baseRepository.QueryById(id);
			var dto = _mapper.Map<PermissionDto>(model);
			return dto;
		}

		public async Task<PageModel<PermissionDto>> GetPageList(int page, int size, string keyword)
		{
			var pageModel = await repository.QueryMuchPage(keyword, page, size, "a.Id desc");
			return pageModel;
		}

		/// <summary>
		/// 根据角色id获取授权信息
		/// </summary>
		/// <param name="rid"></param>
		/// <returns></returns>
		[UseTran]
		public async Task<AssignPermission> GetPermissionIdsByRoleId(int rid)
		{
			AssignPermission assignPermission = new AssignPermission();

			var roleModulePermissions = await _roleModulePermissionRepository.Query(d => d.IsDeleted == false && d.RoleId == rid);
			var permissionIds = (from item in roleModulePermissions
								 orderby item.Id
								 select item.PermissionId.ObjToInt()).ToList();

			var permissions = await repository.Query(t => t.IsDeleted == false);

			foreach (var item in permissionIds)
			{
				var permission = permissions.FirstOrDefault(t => t.Id == item);
				if (permission != null)
				{
					if (permission.IsButton)
					{
						Button btn = new Button();
						btn.Id = permission.Id;
						btn.Name = permission.Name;
						assignPermission.AssignBtns.Add(btn);
					}
					else
					{
						assignPermission.PermissionIds.Add(permission.Id);
					}
				}
			}

			return assignPermission;
		}

		/// <summary>
		/// 角色授权
		/// </summary>
		/// <param name="roleId"></param>
		/// <param name="permissionIds"></param>
		/// <returns></returns>
	    [UseTran]
		public async Task<bool> Assign(int roleId, List<int> permissionIds)
		{
			var roleModulePermissions = await _roleModulePermissionRepository.Query(t => t.RoleId == roleId);

			var removeIdList = roleModulePermissions.Where(t => !permissionIds.Contains(t.PermissionId.ObjToInt())).Select(c => (object)c.Id);
			await _roleModulePermissionRepository.DeleteByIds(removeIdList.ToArray());

			foreach (var item in permissionIds)
			{
				int pid = item.ObjToInt();
				var rmpitem = roleModulePermissions.Where(t => t.PermissionId == pid);
				if (!rmpitem.Any())
				{
					var moduleId = (await repository.Query(t => t.Id == pid)).FirstOrDefault()?.ModuleId;
					RoleModulePermission roleModulePermission = new RoleModulePermission()
					{
						IsDeleted = false,
						RoleId = roleId,
						ModuleId = moduleId.ObjToInt(),
						PermissionId = pid,
					};

					await _roleModulePermissionRepository.Add(roleModulePermission);

				}
			}

			return true;
		}

		/// <summary>
		/// 根据用户id获取权限
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		public async Task<List<PermissionDto>> GetPermissionListByUserId(int userId)
		{
			var dtos = new List<PermissionDto>();
			//// 两种方式获取 uid
			//var uidInHttpcontext1 = (from item in _httpContext.HttpContext.User.Claims
			//						 where item.Type == "jti"
			//						 select item.Value).FirstOrDefault().ObjToInt();

			//var uidInHttpcontext = (JwtHelper.SerializeJwt(_httpContext.HttpContext.Request.Headers["Authorization"].ObjToString().Replace("Bearer ", "")))?.UserId;

			if (userId > 0 /*&& userId == uidInHttpcontext*/)
			{
				//获取用户角色
				var roleIds = (await _userRoleRepository.Query(t => t.IsDeleted == false && t.UserId == userId)).Select(t => t.RoleId).ToList();
				if (roleIds.Count > 0)
				{
					//获取角色权限
					var pids = (await _roleModulePermissionRepository.Query(t => t.IsDeleted == false && roleIds.Contains(t.RoleId))).Select(t => t.PermissionId.ObjToInt()).Distinct();

					if (pids.Any())
					{
						var list = (await repository.Query(d => pids.Contains(d.Id))).OrderBy(c => c.OrderSort).ToList();
						dtos = _mapper.Map<List<PermissionDto>>(list);
					}
				}
			}
			return dtos;
		}
	}
}

