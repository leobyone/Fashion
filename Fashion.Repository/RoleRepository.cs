using Fashion.IRepositoty;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Dtos;
using Fashion.Model.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Repository
{
	public class RoleRepository : BaseRepository<Role>, IRoleRepository
	{
		public RoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public async Task<List<RoleDto>> GetRoleListByUserId(int userId)
		{
			return await QueryMuch<UserRole, Role, RoleDto>(
				(a, b) => new object[] {
					JoinType.Left, a.RoleId == b.Id
				},
				(a, b) => new RoleDto()
				{
					Id = b.Id,
					Name = b.Name,
					Description = b.Description
				},
				(a, b) => a.IsDeleted == false && b.IsDeleted == false && b.Enabled == true
				);
		}
	}
}
