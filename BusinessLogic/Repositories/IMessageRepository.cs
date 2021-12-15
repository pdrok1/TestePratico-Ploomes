using BusinessLogic.Abstract;
using BusinessLogic.Entities;
using BusinessLogic.Entities.Contacts;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Repositories
{
    public interface IMessageRepository : IRepository<Message>
    {
        public Task<IQueryable<Message>> GetAllMessagesBy(int clientId); // 10.
        public Task<IQueryable<Message>> GetAllMessagesBy(int clientId, TypeEnum type); // 11.
        public Task<IQueryable<Message>> GetAllMessagesBy(string title); // 12.
        public Task<IQueryable<Message>> GetAllMessagesWithSubString(string titleSubString); // 13.
    }
}
