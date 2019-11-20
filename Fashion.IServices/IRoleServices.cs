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
		Task<PageModel<RoleDto>> GetPageList(int page, int size, string keyword);
	}
}
