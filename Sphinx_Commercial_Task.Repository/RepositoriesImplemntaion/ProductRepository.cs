using Sphinx_Commercial_Task.Data.Context;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository.Base;
using Sphinx_Commercial_Task.Repository.IRepository;

namespace Sphinx_Commercial_Task.Repository.RepositoriesImplemntaion
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDatabaseContext _dbContext) : base(_dbContext)
        {
        }
    }
}
