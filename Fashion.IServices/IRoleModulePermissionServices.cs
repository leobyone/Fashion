using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fashion.Model.Models;

namespace Fashion.IServices
{	
	/// <summary>
	/// RoleModulePermissionServices
	/// </summary>	
    public interface IRoleModulePermissionServices :IBaseServices<RoleModulePermission>
	{
		Task<List<RoleModulePermission>> GetRoleModule();
	}
}

	