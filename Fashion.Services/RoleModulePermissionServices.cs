


using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fashion.IRepositoty;
using System.Linq;

namespace Fashion.Services
{	
	/// <summary>
	/// RoleModulePermissionServices
	/// </summary>	
	public class RoleModulePermissionServices : BaseServices<RoleModulePermission>, IRoleModulePermissionServices
    {
        IRoleModulePermissionRepository repository;
		IRoleRepository _roleRepository;
		IModuleRepository _moduleRepository;

		public RoleModulePermissionServices(IRoleModulePermissionRepository repository, IRoleRepository roleRepository, IModuleRepository moduleRepository)
        {
            this.repository = repository;
            baseRepository = repository;
			_roleRepository = roleRepository;
			_moduleRepository = moduleRepository;
        }

		/// <summary>
		/// 获取全部 角色接口(按钮)关系数据
		/// </summary>
		/// <returns></returns>
		public async Task<List<RoleModulePermission>> GetRoleModule()
		{
			var roleModulePermissions = await base.Query(a => a.IsDeleted == false);
			var roles = await _roleRepository.Query(a => a.IsDeleted == false);
			var modules = await _moduleRepository.Query(a => a.IsDeleted == false);

			//var roleModulePermissionsAsync = base.Query(a => a.IsDeleted == false);
			//var rolesAsync = _roleRepository.Query(a => a.IsDeleted == false);
			//var modulesAsync = _moduleRepository.Query(a => a.IsDeleted == false);

			//var roleModulePermissions = await roleModulePermissionsAsync;
			//var roles = await rolesAsync;
			//var modules = await modulesAsync;


			if (roleModulePermissions.Count > 0)
			{
				foreach (var item in roleModulePermissions)
				{
					item.Role = roles.FirstOrDefault(d => d.Id == item.RoleId);
					item.Module = modules.FirstOrDefault(d => d.Id == item.ModuleId);
				}

			}
			return roleModulePermissions;
		}
	}
}

	