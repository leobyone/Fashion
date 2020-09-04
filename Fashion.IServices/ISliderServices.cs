
    

using System;
using System.Threading.Tasks;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;

namespace Fashion.IServices
{	
	/// <summary>
	/// SliderServices
	/// </summary>	
    public interface ISliderServices :IBaseServices<Slider>
	{
		Task<PageModel<SliderDto>> GetPageList(int page, int size, string conditions, string sorts);
	}
}

	