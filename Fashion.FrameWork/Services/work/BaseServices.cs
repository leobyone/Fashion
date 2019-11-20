
    
	
using System;
using Fashion.Model.Models;
using Fashion.IServices;
using Fashion.IRepository;
namespace Fashion.Services
{	
	/// <summary>
	/// BaseServices
	/// </summary>	
	public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
		public IBaseRepository<TEntity> baseRepository;
       
    }
}

	