
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// RoleServices
	/// </summary>	
	public class RoleServices : BaseServices<Role>, IRoleServices
    {
	
        IRoleRepository repository;
        public RoleServices(IRoleRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	