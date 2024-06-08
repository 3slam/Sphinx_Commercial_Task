using Sphinx_Commercial_Task.Data.Context;
using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository.Base;
using Sphinx_Commercial_Task.Repository.IRepository;

namespace Sphinx_Commercial_Task.Repository.RepositoriesImplemntaion
{
    public class ClientProductRepository :
        BaseRepository<ClientProduct>, IClientProductRepository
    {
        public ClientProductRepository(ApplicationDatabaseContext _dbContext) : base(_dbContext)
        {
        }
    }
}
