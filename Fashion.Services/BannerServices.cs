


using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;
using Fashion.Model;
using Fashion.Model.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;
using Fashion.Common;
using Fashion.Common.Helper;
using AutoMapper;

namespace Fashion.Services
{	
	/// <summary>
	/// BannerServices
	/// </summary>	
	public class BannerServices : BaseServices<Banner>, IBannerServices
    {
		private IBannerRepository repository;
		private IMapper _mapper;

		public BannerServices(IBannerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            baseRepository = repository;
			_mapper = mapper;
        }

		public async Task<PageModel<BannerDto>> GetPageListAsync(int page, int size, string conditions, string sorts)
		{
			List<Condition> conditionList = Util.ConvertCodiontions(conditions);
			string sort = Util.GetSortString(sorts);
			var where = PredicateBuilder.GetWherePredicate<Banner>(conditionList);
			var pageModel = await baseRepository.QueryPage(where, page, size, sort);
			var mapList = _mapper.Map<List<Banner>, List<BannerDto>>(pageModel.data);

			return new PageModel<BannerDto>()
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

	