
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// ProductServices
	/// </summary>	
	public class ProductServices : BaseServices<Product>, IProductServices
    {
	
        IProductRepository repository;
        public ProductServices(IProductRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	