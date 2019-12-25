
    

using System;
using Fashion.IRepository;
using Fashion.IRepositoty.UnitOfWork;
using Fashion.Model.Models;

namespace Fashion.Repository
{	
	/// <summary>
	/// AttributeRepository
	/// </summary>	
	public class AttributeRepository : BaseRepository<Model.Models.Attribute>, IAttributeRepository
    {

		public AttributeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
		{

		}
	}
}

	