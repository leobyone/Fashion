using AutoMapper;
using Fashion.Common;
using Fashion.Common.Helper;
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

		public async Task<PageModel<RoleDto>> GetPageList(int page, int size, string conditions, string sorts)
		{
			List<Condition> conditionList = Util.ConvertCodiontions(conditions);
			string sort = Util.GetSortString(sorts);
			var where = PredicateBuilder.GetWherePredicate<Role>(conditionList);
			var pageModel = await baseRepository.QueryPage(where, page, size, sort);
			var mapList = _mapper.Map<List<Role>, List<RoleDto>>(pageModel.data);

			return new PageModel<RoleDto>()
			{
				page = pageModel.page,
				dataCount = pageModel.dataCount,
				pageCount = pageModel.pageCount,
				PageSize = pageModel.page,
				data = mapList
			};
		}

		public async Task<List<RoleDto>> GetList(string conditions, string sorts)
		{
			List<Condition> conditionList = Util.ConvertCodiontions(conditions);
			string sort = Util.GetSortString(sorts);
			var where = PredicateBuilder.GetWherePredicate<Role>(conditionList);
			var list = await baseRepository.Query(where);
			return _mapper.Map<List<Role>, List<RoleDto>>(list);
		}
	}
}
