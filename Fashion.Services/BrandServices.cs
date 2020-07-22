using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;
using Fashion.Model;
using Fashion.Model.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Fashion.Common;
using Fashion.Common.Helper;

namespace Fashion.Services
{	
	/// <summary>
	/// BrandServices
	/// </summary>	
	public class BrandServices : BaseServices<Brand>, IBrandServices
    {
        IBrandRepository repository;
		private IMapper _mapper;

		public BrandServices(IBrandRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }

		public async Task<BrandDto> GetBrandById(int id)
		{
			var model = await baseRepository.QueryById(id);
			var dto = _mapper.Map<BrandDto>(model);
			return dto;
		}

		public async Task<List<BrandDto>> GetList(string conditions, string sorts)
		{
			List<Condition> conditionList = Util.ConvertCodiontions(conditions);
			string sort = Util.GetSortString(sorts);
			var where = PredicateBuilder.GetWherePredicate<Brand>(conditionList);
			var list = await baseRepository.Query(where);
			return _mapper.Map<List<Brand>, List<BrandDto>>(list);
		}

		public async Task<PageModel<BrandDto>> GetPageList(int page, int size, string conditions, string sorts)
		{
			List<Condition> conditionList = Util.ConvertCodiontions(conditions);
			string sort = Util.GetSortString(sorts);
			var where = PredicateBuilder.GetWherePredicate<Brand>(conditionList);
			var pageModel = await baseRepository.QueryPage(where, page, size, sort);
			var mapList = _mapper.Map<List<Brand>, List<BrandDto>>(pageModel.data);

			return new PageModel<BrandDto>()
			{
				page = pageModel.page,
				dataCount = pageModel.dataCount,
				pageCount = pageModel.pageCount,
				PageSize = pageModel.page,
				data = mapList
			};
		}
	}
}

	