using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fashion.IServices;
using Fashion.Model;
using Fashion.Model.Dtos;
using Fashion.Model.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fashion.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BannerController : ControllerBase
	{
		private IBannerServices _bannerServices;
		private IMapper _mapper;

		public BannerController(IBannerServices bannerServices, IMapper mapper)
		{
			_bannerServices = bannerServices;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<MessageModel<BannerDto>> Get(int id)
		{
			var data = new MessageModel<BannerDto>();
			var banner = await _bannerServices.QueryById(id);

			if (banner != null)
			{
				data.data = _mapper.Map<Banner, BannerDto>(banner);
				data.success = true;
				data.msg = "获取成功";
			}

			return data;
		}

		[HttpPost]
		public async Task<MessageModel<string>> Post([FromBody] Banner banner)
		{
			var data = new MessageModel<string>();

			var id = (await _bannerServices.Add(banner));
			data.success = id > 0;
			if (data.success)
			{
				data.msg = "添加成功";
				data.data = id.ObjToString();
			}

			return data;
		}

		[HttpPut]
		public async Task<MessageModel<string>> Update([FromBody] Banner banner)
		{
			var data = new MessageModel<string>();
			if (banner != null && banner.Id > 0)
			{
				data.success = await _bannerServices.Update(banner);
				if (data.success)
				{
					data.msg = "更新成功";
					data.data = banner?.Id.ObjToString();
				}
			}

			return data;
		}

		[HttpDelete]
		public async Task<MessageModel<string>> Delete(int id)
		{
			var data = new MessageModel<string>();
			if (id > 0)
			{
				var banner = await _bannerServices.QueryById(id);
				banner.IsDeleted = true;
				data.success = await _bannerServices.Update(banner);
				if (data.success)
				{
					data.msg = "删除成功";
					data.data = banner?.Id.ObjToString();
				}
			}

			return data;
		}

		[HttpGet]
		[Route("pagelist")]
		public async Task<MessageModel<PageModel<BannerDto>>> GetPageList(int page, int size, string conditions, string sorts)
		{
			var list = await _bannerServices.GetPageListAsync(page, size, conditions, sorts);
			return new MessageModel<PageModel<BannerDto>>()
			{
				msg = "获取成功",
				success = true,
				data = list
			};
		}
	}
}