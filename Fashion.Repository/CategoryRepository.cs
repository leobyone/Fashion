
    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// CategoryRepository
	/// </summary>	
	public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

		public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}
	}
}

	