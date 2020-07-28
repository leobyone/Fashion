using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;

namespace Fashion.IServices
{	
	/// <summary>
	/// ProductServices
	/// </summary>	
    public interface IProductServices :IBaseServices<Product>
	{
		Task<ProductDto> GetProductById(int id);
		Task<List<ProductDto>> GetList(string conditions, string sorts);
		Task<PageModel<ProductDto>> GetPageList(int page, int size, string conditions, string sorts);
	}
}

	