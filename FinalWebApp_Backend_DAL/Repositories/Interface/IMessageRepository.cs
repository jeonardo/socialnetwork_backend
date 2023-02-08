using FinalWebApp_Backend_DAL.Entities;

namespace FinalWebApp_Backend_DAL.Repositories.Interface
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetItems(int id);
        Task CreateItem(Message message);
    }
}
