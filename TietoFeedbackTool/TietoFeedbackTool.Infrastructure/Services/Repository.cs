using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TietoFeedbackTool.Application.Interfaces;

namespace TietoFeedbackTool.Infrastructure.Services
{
	/// <summary>
	/// Repository contains basic method.
	/// </summary>
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected readonly ITietoFeedbackToolContext _context;
		public Repository(ITietoFeedbackToolContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Basic method.
		/// Get object by int id.
		/// </summary>
		/// <param name="id">Int primary key</param>
		/// <returns>Object.</returns>
		public TEntity Get(int id)
		{
			return _context.Set<TEntity>().Find(id);
		}

		/// <summary>
		/// Basic method.
		/// Get object by string id.
		/// </summary>
		/// <param name="key">String primary key</param>
		/// <returns>Object.</returns>
		public TEntity GetByString(string key)
		{
			return _context.Set<TEntity>().Find(key);
		}

		/// <summary>
		/// Basic method.
		/// Get list of objects.
		/// </summary>
		/// <returns>List of objects</returns>
		public IEnumerable<TEntity> GetAll()
		{
			return _context.Set<TEntity>().ToList();
		}

		/// <summary>
		/// Basic method.
		/// Search for specific object in database.
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns>True if find object</returns>
		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
		{
			return _context.Set<TEntity>().Where(predicate);
		}

		public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
		{
			return _context.Set<TEntity>().SingleOrDefault(predicate);
		}

		/// <summary>
		/// Basic method.
		/// Add object to databse.
		/// </summary>
		public void Add(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
		}

		/// <summary>
		/// Basic method.
		/// Add list of objects to database.
		/// </summary>
		public void AddRange(IEnumerable<TEntity> entities)
		{
			_context.Set<TEntity>().AddRange(entities);
		}

		/// <summary>
		/// Basic method.
		/// Remove specific object from database.
		/// </summary>
		public void Remove(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
		}

		/// <summary>
		/// Basic method.
		/// Remove list of objects from databse.
		/// </summary>
		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			_context.Set<TEntity>().RemoveRange(entities);
		}
	}
}
