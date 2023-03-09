using Rooms.Data.Entities;

namespace RoomWithAView.Data
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> Get();
        Reservation GetById(Guid id);
        void Add(Reservation reservation);
        void Delete(Guid id);
        void Edit(Reservation reservation);
    }
}
