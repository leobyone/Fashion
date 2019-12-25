
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// AttributeValueServices
	/// </summary>	
	public class AttributeValueServices : BaseServices<AttributeValue>, IAttributeValueServices
    {
	
        IAttributeValueRepository repository;
        public AttributeValueServices(IAttributeValueRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	