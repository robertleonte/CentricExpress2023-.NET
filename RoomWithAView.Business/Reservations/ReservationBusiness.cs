using RoomWithAView.Business.Dto;
using RoomWithAView.Data;
using RoomWithAView.Data.Entities;

namespace RoomWithAView.Business.Reservations
{
    public class ReservationBusiness : IReservationBusiness
    {
        public List<ReservationDto> GetAll()
        {
            return Database.Reservations.Select(reservation => MapReservationToDto(reservation)).ToList();
        }

        public ReservationDto? GetById(Guid id)
        {
            return Database.Reservations.Where(reservation => reservation.Id == id)
                .Select(reservation => MapReservationToDto(reservation)).FirstOrDefault();
        }

        public void Add(ReservationDto reservationDto)
        {
            var newReservation = new Reservation(
                reservationDto.Id,
                reservationDto.RoomId,
                reservationDto.CheckIn,
                reservationDto.CheckOut,
                reservationDto.TotalPayment);
            Database.Reservations.Add(newReservation);
        }

        public void Update(Guid id, ReservationDto reservationDto)
        {
            var reservationToUpdate = Database.Reservations.SingleOrDefault(reservation => reservation.Id == id);
            reservationToUpdate?.Update(
                reservationDto.RoomId,
                reservationDto.CheckIn,
                reservationDto.CheckOut,
                reservationDto.TotalPayment);
        }

        public void Delete(Guid id)
        {
            var reservationToDelete = Database.Reservations.SingleOrDefault(reservation => reservation.Id == id);
            Database.Reservations.Remove(reservationToDelete);
        }

        private static ReservationDto MapReservationToDto(Reservation reservation)
        {
            return new ReservationDto(
                reservation.Id,
                reservation.RoomId,
                reservation.CheckIn,
                reservation.CheckOut,
                reservation.TotalPayment);
        }
    }
}
