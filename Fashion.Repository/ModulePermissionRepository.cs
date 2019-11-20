
    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// ModulePermissionRepository
	/// </summary>	
	public class ModulePermissionRepository : BaseRepository<ModulePermission>, IModulePermissionRepository
    {
		public ModulePermissionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}

	