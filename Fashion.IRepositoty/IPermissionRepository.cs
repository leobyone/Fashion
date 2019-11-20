
    
	
using System;
using System.Threading.Tasks;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;
namespace Fashion.IRepository
{	
	/// <summary>
	/// IPermissionRepository
	/// </summary>	
	public interface IPermissionRepository : IBaseRepository<Permission>
    {
		Task<PageModel<PermissionDto>> QueryMuchPage(string keyword, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);
	}
}

	