using Rooms.Data;
using Rooms.Data.Entities;
using RoomWithAView.Business.Dto;

namespace RoomWithAView.Business.Reservations
{
    public class ReservationBusiness : IReservationBusiness
    {
        public List<ReservationDto> GetAll()
        {
            return Database.Reservations.Select(r => MapReservationToDto(r)).ToList();
        }

        public ReservationDto? GetById(Guid id)
        {
            return Database.Reservations.Where(r => r.Id == id)
                .Select(r => MapReservationToDto(r)).FirstOrDefault();
        }

        public List<ReservationDto> FilterByDates(DateTime checkIn, DateTime checkOut)
        {
            return Database.Reservations.FindAll(r => (r.CheckIn >= checkIn && r.CheckIn <= checkOut) ||
                                                      (r.CheckOut >= checkIn && r.CheckOut <= checkOut))
                .Select(r => MapReservationToDto(r)).ToList();
        }

        public void Add(ReservationDto reservationDto)
        {
            var newReservation = new Reservation(
                reservationDto.RoomNumber,
                reservationDto.CheckIn,
                reservationDto.CheckOut,
                reservationDto.TotalPayment);
            Database.Reservations.Add(newReservation);
        }

        public void Update(Guid id, ReservationDto reservationDto)
        {
            var reservation = Database.Reservations.SingleOrDefault(r => r.Id == id);
            reservation?.Update(
                reservationDto.RoomNumber,
                reservationDto.CheckIn,
                reservationDto.CheckOut,
                reservationDto.TotalPayment);
        }

        private static ReservationDto MapReservationToDto(Reservation r)
        {
            return new ReservationDto(
                r.Id,
                r.RoomNumber,
                r.CheckIn,
                r.CheckOut,
                r.TotalPayment);
        }
    }
}
