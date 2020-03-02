
    

using System;
using System.Threading.Tasks;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;

namespace Fashion.IServices
{	
	/// <summary>
	/// BannerServices
	/// </summary>	
    public interface IBannerServices :IBaseServices<Banner>
	{
		Task<PageModel<BannerDto>> GetPageListAsync(int page, int size, string conditions, string sorts);
	}
}

	