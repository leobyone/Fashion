
    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// AttributeGroupRepository
	/// </summary>	
	public class AttributeGroupRepository : BaseRepository<AttributeGroup>, IAttributeGroupRepository
    {
		public AttributeGroupRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}

	}
}

	