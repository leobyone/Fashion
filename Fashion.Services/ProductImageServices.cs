
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// ProductImageServices
	/// </summary>	
	public class ProductImageServices : BaseServices<ProductImage>, IProductImageServices
    {
	
        IProductImageRepository repository;
        public ProductImageServices(IProductImageRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	