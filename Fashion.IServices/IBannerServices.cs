
    

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
		Task<PageModel<BannerDto>> GetPageList(int page, int size, string conditions, string sorts);
	}
}

	