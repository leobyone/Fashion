using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;

namespace Fashion.IServices
{	
	/// <summary>
	/// BrandServices
	/// </summary>	
    public interface IBrandServices :IBaseServices<Brand>
	{
		Task<BrandDto> GetBrandById(int id);
		Task<List<BrandDto>> GetList(string conditions, string sorts);
		Task<PageModel<BrandDto>> GetPageList(int page, int size, string conditions, string sorts);
	}
}

	