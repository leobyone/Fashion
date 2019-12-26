
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// RegionServices
	/// </summary>	
	public class RegionServices : BaseServices<Region>, IRegionServices
    {
	
        IRegionRepository repository;
        public RegionServices(IRegionRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	