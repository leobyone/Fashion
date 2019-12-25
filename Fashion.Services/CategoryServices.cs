
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// CategoryServices
	/// </summary>	
	public class CategoryServices : BaseServices<Category>, ICategoryServices
    {
	
        ICategoryRepository repository;
        public CategoryServices(ICategoryRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	