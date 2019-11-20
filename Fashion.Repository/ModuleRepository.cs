using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// ModuleRepository
	/// </summary>	
	public class ModuleRepository : BaseRepository<Module>, IModuleRepository
    {
		public ModuleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

	}
}

	