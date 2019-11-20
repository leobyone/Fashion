using Fashion.IRepository;
using Fashion.Model.Dtos;
using Fashion.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.IRepositoty
{
	public interface IRoleRepository : IBaseRepository<Role>
	{
		Task<List<RoleDto>> GetRoleListByUserId(int userId);
	}
}
