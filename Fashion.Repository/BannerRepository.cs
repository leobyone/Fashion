
    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// BannerRepository
	/// </summary>	
	public class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
       	public BannerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}
    }
}

	