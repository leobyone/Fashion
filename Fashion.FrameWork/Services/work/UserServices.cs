
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// UserServices
	/// </summary>	
	public class UserServices : BaseServices<User>, IUserServices
    {
	
        IUserRepository repository;
        public UserServices(IUserRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	