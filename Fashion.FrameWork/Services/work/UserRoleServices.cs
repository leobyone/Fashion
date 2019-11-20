
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// UserRoleServices
	/// </summary>	
	public class UserRoleServices : BaseServices<UserRole>, IUserRoleServices
    {
	
        IUserRoleRepository repository;
        public UserRoleServices(IUserRoleRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	