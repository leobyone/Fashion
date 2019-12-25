
    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// ProductSkuRepository
	/// </summary>	
	public class ProductSkuRepository : BaseRepository<ProductSku>, IProductSkuRepository
    {
		public ProductSkuRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}

	