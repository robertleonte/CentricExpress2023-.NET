using Microsoft.EntityFrameworkCore;
using RoomWithAView.Data.Entities;

namespace RoomWithAView.Data
{
    public class ReservationRepository: IReservationRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ReservationRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<Reservation> Get()
        {
            return _databaseContext.Reservations.AsNoTracking();
        }

        public Reservation GetById(Guid id)
        {
            return _databaseContext.Reservations.SingleOrDefault(res => res.Id == id);
        }

        public void Add(Reservation reservation)
        {
            _databaseContext.Reservations.Add(reservation);
            _databaseContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var reservation = _databaseContext.Reservations.FirstOrDefault(res => res.Id == id);
            if (reservation != null) _databaseContext.Remove(reservation);
            _databaseContext.SaveChanges();
        }

        public void Edit(Reservation reservation)
        {
            _databaseContext.SaveChanges();
        }
    }
}
