using Microsoft.EntityFrameworkCore;
using Rooms.Data;
using Rooms.Data.Entities;

namespace RoomWithAView.Data
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DatabaseContext _databaseContext;

        public RoomRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IEnumerable<Room> Get()
        {
            return _databaseContext.Rooms.AsNoTracking().Include(r => r.Reservations);
        }

        public Room GetById(Guid id)
        {
            return _databaseContext.Rooms.Include(r => r.Reservations).SingleOrDefault(r => r.Id == id);
        }

        public void Add(Room room)
        {
            _databaseContext.Rooms.Add(room);
            _databaseContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var room = _databaseContext.Set<Room>().FirstOrDefault(r => r.Id == id);
            if (room != null) _databaseContext.Rooms.Remove(room);
            _databaseContext.SaveChanges();
        }

        public void Edit(Room room)
        {
            _databaseContext.SaveChanges();
        }
    }
}
