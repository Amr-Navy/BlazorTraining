using GenericDataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericDataManager.Repositories
{
	public class MemoryDataManager<TEntity> : IRepository<TEntity> where TEntity : EntityBase
	{
		Dictionary<int, TEntity> data;

		public MemoryDataManager()
		{
			data = new Dictionary<int, TEntity>();
		}
		public async Task<bool> Delete(TEntity entityToDelete)
		{
			return await Task.Run(() =>
			{
				if (data.TryGetValue(entityToDelete.Id, out TEntity exiting))
				{
					data.Remove(entityToDelete.Id);
				}

				return true;
			});
		}

		public async Task<bool> Delete(object id)
		{
			return await Task.Run(() =>
			{
				if (id is int @int && data.TryGetValue(@int, out TEntity exiting))
				{
					data.Remove(@int);
				}

				return true;
			});
		}

		public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, 
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
		{
			return await Task.Run(() =>
			{
				try
				{
					// Get the dbSet from the Entity passed in                
					IQueryable<TEntity> query = data.Values.AsQueryable<TEntity>();

					// Apply the filter
					if (filter != null)
					{
						query = query.Where(filter);
					}

					// Sort
					if (orderBy != null)
					{
						return orderBy(query).ToList();
					}
					else
					{
						return query.ToList();
					}
				}
				catch (Exception ex)
				{
					var msg = ex.Message;
					return null;
				}

			});
		}

		public async Task<TEntity> GetByID(object id)
		{
			return await Task.Run(() =>
			{
				if (id is int @int && data.TryGetValue(@int, out TEntity exiting))
				{
					return exiting;
				}

				return null;
			});
		}

		public async Task<TEntity> Insert(TEntity entity)
		{
			return await Task.Run(() =>
			{
				if (entity.Id <= 1)
				{
					entity.Id = data.Count + 1;
				}
				if (data.TryGetValue(entity.Id, out TEntity exiting))
				{
					return exiting;
				}
				else
				{
					data[entity.Id] = entity;
					return entity;
				}
			});
		}

		public async Task<TEntity> Update(TEntity entityToUpdate)
		{
			return await Task.Run(() =>
			{
				if (data.TryGetValue(entityToUpdate.Id, out TEntity exiting))
				{
					data[entityToUpdate.Id] = entityToUpdate;
				}

				return entityToUpdate;
			});
		}
	}
}
