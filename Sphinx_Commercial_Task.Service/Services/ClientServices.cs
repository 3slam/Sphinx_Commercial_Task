using Sphinx_Commercial_Task.Data.Entities;
using Sphinx_Commercial_Task.Repository.IRepository;
using Sphinx_Commercial_Task.Service.IServices;

namespace Sphinx_Commercial_Task.Service.Services
{
    public class ClientServices : IClientService
    {
        private readonly IClientRepository repository;

        public ClientServices(IClientRepository repository)
        {
            this.repository = repository;
        }

        public List<Client> GetClients()
        {
            return repository.GetTableNoTracking().ToList();
        }
    }
}
