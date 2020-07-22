using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;

namespace Fashion.IServices
{	
	/// <summary>
	/// CategoryServices
	/// </summary>	
    public interface ICategoryServices :IBaseServices<Category>
	{
		Task<CategoryDto> GetCategoryById(int id);
		Task<List<CategoryDto>> GetList(string conditions, string sorts);
		Task<PageModel<CategoryDto>> GetPageList(int page, int size, string conditions, string sorts);
	}
}

	