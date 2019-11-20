
    
	
using System;
using Fashion.Model.Models;
using Fashion.IRepository;
namespace Fashion.Repository
{	
	/// <summary>
	/// IBaseRepository
	/// </summary>	
	 public  class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {

       
    }
}

	