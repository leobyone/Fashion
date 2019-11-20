using Fashion.IRepositoty;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Repository
{
	public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
	{
		public UserRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}
