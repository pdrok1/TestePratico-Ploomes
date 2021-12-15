using BusinessLogic.Abstract;
using BusinessLogic.Entities;
using BusinessLogic.Entities.Contacts;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        public Task<bool> Disable(int id); // 3.
        public Task<bool> Enable(int id); // 8.
        public Task<IQueryable<Client>> GetAll(bool includeDisabled = false); // 4. and 5.
        public Task<IQueryable<Client>> GetAllDisabled(); // 6
        public Task<IQueryable<Client>> GetAllWith(TypeEnum type); // 7.
    }
}
