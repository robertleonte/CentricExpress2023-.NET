using RoomWithAView.Data.Entities;

namespace RoomWithAView.Data
{
    public interface IRoomRepository
    {
        IEnumerable<Room> Get();
        Room GetById(Guid id);
        void Add(Room room);
        void Delete(Guid id);
        void Edit(Room room);
    }
}
