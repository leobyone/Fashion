
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// NavigationServices
	/// </summary>	
	public class NavigationServices : BaseServices<Navigation>, INavigationServices
    {
	
        INavigationRepository repository;
        public NavigationServices(INavigationRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	