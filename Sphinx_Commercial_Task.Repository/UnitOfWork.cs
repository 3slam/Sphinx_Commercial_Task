using Sphinx_Commercial_Task.Data.Context;
using Sphinx_Commercial_Task.Repository.IRepository;
using Sphinx_Commercial_Task.Repository.RepositoriesImplemntaion;

namespace Sphinx_Commercial_Task.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDatabaseContext _databaseContext;
		public IClientRepository Client { get; private set; }
		public IProductRepository Product { get; private set; }
		public IClientProductRepository ClientProduct { get; private set; }
		public UnitOfWork(ApplicationDatabaseContext _databaseContext)
		{
			this._databaseContext = _databaseContext;
			Client = new ClientRepository(_databaseContext);
			Product = new ProductRepository(_databaseContext);
			ClientProduct = new ClientProductRepository(_databaseContext);
		}

		public void Dispose() => _databaseContext.Dispose();
		public async Task SaveChangesAsync() => await _databaseContext.SaveChangesAsync();

	}
}
