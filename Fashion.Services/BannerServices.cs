
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// BannerServices
	/// </summary>	
	public class BannerServices : BaseServices<Banner>, IBannerServices
    {
	
        IBannerRepository repository;
        public BannerServices(IBannerRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	