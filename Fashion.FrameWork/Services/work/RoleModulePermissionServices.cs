
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// RoleModulePermissionServices
	/// </summary>	
	public class RoleModulePermissionServices : BaseServices<RoleModulePermission>, IRoleModulePermissionServices
    {
	
        IRoleModulePermissionRepository repository;
        public RoleModulePermissionServices(IRoleModulePermissionRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	