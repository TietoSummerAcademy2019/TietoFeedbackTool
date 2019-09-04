using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace TietoFeedbackTool.Application.Interfaces
{
	public interface IRepository<TEntity> where TEntity : class
	{
		//Geting
		TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

		// This method was not in the videos, but I thought it would be useful to add.
		TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

		//Adding
		void Add(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);

		//Removing
		void Remove(TEntity entity);
		void RemoveRange(IEnumerable<TEntity> entities);
	}
}
