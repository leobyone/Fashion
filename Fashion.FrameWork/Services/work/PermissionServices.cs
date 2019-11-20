
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// PermissionServices
	/// </summary>	
	public class PermissionServices : BaseServices<Permission>, IPermissionServices
    {
	
        IPermissionRepository repository;
        public PermissionServices(IPermissionRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	