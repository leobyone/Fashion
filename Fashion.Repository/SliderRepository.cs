
    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// SliderRepository
	/// </summary>	
	public class SliderRepository : BaseRepository<Slider>, ISliderRepository
    {
       	public SliderRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}
    }
}

	