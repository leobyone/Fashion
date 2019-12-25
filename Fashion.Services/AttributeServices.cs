
    

using System;
using Fashion.IServices;
using Fashion.IRepository;
using Fashion.Model.Models;

namespace Fashion.Services
{	
	/// <summary>
	/// AttributeServices
	/// </summary>	
	public class AttributeServices : BaseServices<Model.Models.Attribute>, IAttributeServices
    {
	
        IAttributeRepository repository;
        public AttributeServices(IAttributeRepository repository)
        {
            this.repository = repository;
            baseRepository = repository;
        }
       
    }
}

	