
    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// NavigationRepository
	/// </summary>	
	public class NavigationRepository : BaseRepository<Navigation>, INavigationRepository
    {
       	public NavigationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}
    }
}

	