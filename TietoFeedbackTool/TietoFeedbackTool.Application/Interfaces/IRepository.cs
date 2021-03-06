using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class 
	{
		//Geting
		TEntity Get(int id);
		TEntity GetByString(string key);
        IEnumerable<TEntity> GetAll();
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

		TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

		//Adding
		void Add(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);

		//Removing
		void Remove(TEntity entity);
		void RemoveRange(IEnumerable<TEntity> entities);
	}
}
