using DomainModel.Models;

namespace DataAcessLayer.Contracts
{
    public interface IEventRepository
    {
        public event Action<string> OnError;

        public void AnErrorOccured(string errMsg);

        public Task AddEventToDB(Event _event);

        public Task<List<Event>> GetAllEvents(int accountId);

        public Task DeleteEvent(int eventId);
    }
}
