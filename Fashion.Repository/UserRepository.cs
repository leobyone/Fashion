using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Dtos;
using Fashion.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Repository
{
	public class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}
