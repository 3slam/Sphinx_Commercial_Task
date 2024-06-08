using Sphinx_Commercial_Task.Repository.IRepository;

namespace Sphinx_Commercial_Task.Repository
{
	public interface IUnitOfWork : IDisposable
	{
		public IClientRepository Client { get; }
		public IProductRepository Product { get; }

		public IClientProductRepository ClientProduct { get; }

		public Task SaveChangesAsync();
	}
}
