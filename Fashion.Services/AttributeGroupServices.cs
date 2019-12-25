
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// AttributeGroupServices
	/// </summary>	
	public class AttributeGroupServices : BaseServices<AttributeGroup>, IAttributeGroupServices
    {
	
        IAttributeGroupRepository repository;
        public AttributeGroupServices(IAttributeGroupRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	