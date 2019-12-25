
    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// AttributeValueRepository
	/// </summary>	
	public class AttributeValueRepository : BaseRepository<AttributeValue>, IAttributeValueRepository
    {
		public AttributeValueRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}

	}
}

	