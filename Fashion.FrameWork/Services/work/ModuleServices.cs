
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// ModuleServices
	/// </summary>	
	public class ModuleServices : BaseServices<Module>, IModuleServices
    {
	
        IModuleRepository repository;
        public ModuleServices(IModuleRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	