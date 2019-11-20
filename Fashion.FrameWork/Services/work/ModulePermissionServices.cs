
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// ModulePermissionServices
	/// </summary>	
	public class ModulePermissionServices : BaseServices<ModulePermission>, IModulePermissionServices
    {
	
        IModulePermissionRepository repository;
        public ModulePermissionServices(IModulePermissionRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	