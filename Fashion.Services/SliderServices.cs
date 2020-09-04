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
	/// SliderServices
	/// </summary>	
	public class SliderServices : BaseServices<Slider>, ISliderServices
    {
		private ISliderRepository repository;
		private IMapper _mapper;

		public SliderServices(ISliderRepository repository, IMapper mapper)
        {
            this.repository = repository;
            baseRepository = repository;
			_mapper = mapper;
        }

		public async Task<PageModel<SliderDto>> GetPageList(int page, int size, string conditions, string sorts)
		{
			List<Condition> conditionList = Util.ConvertCodiontions(conditions);
			string sort = Util.GetSortString(sorts);
			var where = PredicateBuilder.GetWherePredicate<Slider>(conditionList);
			var pageModel = await baseRepository.QueryPage(where, page, size, sort);
			var mapList = _mapper.Map<List<Slider>, List<SliderDto>>(pageModel.data);

			return new PageModel<SliderDto>()
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

	