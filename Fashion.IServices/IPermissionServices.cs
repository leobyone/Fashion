using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;

namespace Fashion.IServices
{	
	/// <summary>
	/// PermissionServices
	/// </summary>	
    public interface IPermissionServices :IBaseServices<Permission>
	{
		Task<PermissionDto> GetPermissionById(int id);
		Task<PageModel<PermissionDto>> GetPageList(int page, int size, string keyword);
		Task<AssignPermission> GetPermissionIdsByRoleId(int rid = 0);
		Task<bool> Assign(int roleId, List<int> permissionIds);
		Task<List<PermissionDto>> GetPermissionListByUserId(int userId);
	}
}

	