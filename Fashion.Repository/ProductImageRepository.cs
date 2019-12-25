
    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// ProductImageRepository
	/// </summary>	
	public class ProductImageRepository : BaseRepository<ProductImage>, IProductImageRepository
    {
		public ProductImageRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

	}
}

	