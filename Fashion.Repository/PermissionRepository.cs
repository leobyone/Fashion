


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;
using SqlSugar;

namespace Fashion.Repository
{
	/// <summary>
	/// PermissionRepository
	/// </summary>	
	public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
	{
		public PermissionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}

		public async Task<PageModel<PermissionDto>> QueryMuchPage(string keyword, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null)
		{
			return await QueryMuchPage<Permission, Permission, PermissionDto>(
				(a, b) => new object[] {
					JoinType.Left, a.ParentId == b.Id
				},
				(a, b) => new PermissionDto()
				{
					Id = a.Id,
					Code = a.Code,
					Name = a.Name,
					ParentName = string.IsNullOrEmpty(b.Name) ? "¸ù½Úµã" : b.Name,
					IsButton = a.IsButton,
					IsHide = a.IsHide,
					ParentId = a.ParentId,
					ModuleId = a.ModuleId,
					OrderSort = a.OrderSort,
					Icon = a.Icon,
					Description = a.Description,
					Enabled = a.Enabled
				},
				(a, b) => a.IsDeleted == false && (a.Name != null && a.Name.Contains(keyword)), intPageIndex, intPageSize, strOrderByFileds
				);
		}

	}
}

