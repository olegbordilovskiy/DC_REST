namespace DC_REST.Repositories
{
	public class InMemoryRepository<TEntity>: IRepository<TEntity>
	{
		private readonly Dictionary<int, TEntity> _data = new Dictionary<int, TEntity>();
		private int _currentId = 1;

		public TEntity GetById(int id)
		{
			return _data.ContainsKey(id) ? _data[id] : default;
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _data.Values.AsEnumerable();
		}

		public TEntity Add(TEntity entity)
		{
			var id = _currentId++;
			_data[id] = entity;
			return entity;
		}
		public TEntity Update(int id, TEntity entity)
		{
			if (_data.ContainsKey(id))
			{
				_data[id] = entity;
				return entity;
			}

			return default;
		}

		public bool Delete(int id)
		{
			return _data.Remove(id);
		}
	}
}
