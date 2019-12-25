
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// BrandServices
	/// </summary>	
	public class BrandServices : BaseServices<Brand>, IBrandServices
    {
	
        IBrandRepository repository;
        public BrandServices(IBrandRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	