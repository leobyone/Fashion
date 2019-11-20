using AutoMapper;
using Fashion.IRepositoty;
using Fashion.IServices;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Services
{
	public class RoleServices : BaseServices<Role>, IRoleServices
	{
		private IRoleRepository repository;
		private IMapper _mapper;

		public RoleServices(IRoleRepository repository, IMapper mapper)
		{
			this.repository = repository;
			baseRepository = repository;
			_mapper = mapper;
		}

		public async Task<RoleDto> GetRoleById(int id)
		{
			var model = await baseRepository.QueryById(id);
			var dto = _mapper.Map<RoleDto>(model);
			return dto;
		}

		public async Task<PageModel<RoleDto>> GetPageList(int page, int size, string keyword)
		{
			var pageModel = await QueryPage(t => t.IsDeleted == false && (t.Name != null && t.Name.Contains(keyword)), page, size, "Id desc");
			var mapList = _mapper.Map<List<Role>, List<RoleDto>>(pageModel.data);

			return new PageModel<RoleDto>()
			{
				page = pageModel.page,
				dataCount = pageModel.dataCount,
				pageCount = pageModel.pageCount,
				PageSize =  pageModel.page,
				data = mapList
			};
		}
	}
}
