
    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// ProductRepository
	/// </summary>	
	public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
		public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

	}
}

	