
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// ProductSkuServices
	/// </summary>	
	public class ProductSkuServices : BaseServices<ProductSku>, IProductSkuServices
    {
	
        IProductSkuRepository repository;
        public ProductSkuServices(IProductSkuRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	