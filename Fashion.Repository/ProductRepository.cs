
    

using System;
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
	/// ProductRepository
	/// </summary>	
	public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
		public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

		public async Task<PageModel<ProductDto>> QueryMuchPage(string keyword, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null)
		{
			return await QueryMuchPage<Product, Product, ProductDto>(
				(a, b) => new object[] {
					JoinType.Left, a.BrandId == b.Id
				},
				(a, b) => new ProductDto()
				{
					Id = a.Id,
					Name = a.Name,
					PSN = a.PSN,
					CategoryId = a.CategoryId,
					BrandId = a.BrandId,
					BrandName = b.Name,
					SKUGid =a.SKUGid,
					ShopPrice = a.ShopPrice,
					MarketPrice = a.MarketPrice,
					CostPrice = a.CostPrice,
					Status = a.Status,
					IsBest = a.IsBest,
					IsHot = a.IsHot,
					IsNew = a.IsNew,
					OrderSort = a.OrderSort,
					ShowImg = a.ShowImg,
					Weight = a.Weight,
					SaleCount = a.SaleCount,
					VisitCount = a.VisitCount,
					ReviewCount = a.ReviewCount,
					Star1 = a.Star1,
					Star2 = a.Star2,
					Star3 = a.Star3,
					Star4 = a.Star4,
					Star5 = a.Star5,
					Description = a.Description
				},
				(a, b) => a.IsDeleted == false && (a.Name != null && a.Name.Contains(keyword)), intPageIndex, intPageSize, strOrderByFileds);
		}
	}
}

	