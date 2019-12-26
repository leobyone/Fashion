
    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// RegionRepository
	/// </summary>	
	public class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
       	public RegionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}
    }
}

	