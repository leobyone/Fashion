using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.IServices
{
	public interface IRoleServices : IBaseServices<Role>
	{
		Task<RoleDto> GetRoleById(int id);
		Task<List<RoleDto>> GetList(string conditions, string sorts);
		Task<PageModel<RoleDto>> GetPageList(int page, int size, string conditions, string sorts);
	}
}
