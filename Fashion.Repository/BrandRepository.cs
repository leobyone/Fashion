
    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// BrandRepository
	/// </summary>	
	public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
		public BrandRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}
	}
}

	