
    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// RoleModulePermissionRepository
	/// </summary>	
	public class RoleModulePermissionRepository : BaseRepository<RoleModulePermission>, IRoleModulePermissionRepository
    {
		public RoleModulePermissionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
	}
}

	