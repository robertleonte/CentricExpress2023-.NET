using Rooms.Data.Entities;
using RoomWithAView.Business.Dto;
using RoomWithAView.Data;

namespace RoomWithAView.Business.Reservations
{
    public class ReservationBusiness : IReservationBusiness
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationBusiness(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public List<ReservationDto> GetAll()
        {
            return _reservationRepository.Get().Select(reservation => MapReservationToDto(reservation)).ToList();
        }

        public ReservationDto GetById(Guid id)
        {
            var reservation = _reservationRepository.GetById(id);
            return MapReservationToDto(reservation);
        }

        public void Add(ReservationDto reservationDto)
        {
            var newReservation = new Reservation(reservationDto.Id, reservationDto.RoomId, reservationDto.CheckIn, reservationDto.CheckOut, reservationDto.TotalPayment);
            _reservationRepository.Add(newReservation);
        }

        public void Update(Guid id, ReservationDto reservationDto)
        {
            var reservation = _reservationRepository.GetById(id);
            reservation.Update(
                reservationDto.RoomId,
                reservationDto.CheckIn,
                reservationDto.CheckOut,
                reservationDto.TotalPayment);

            _reservationRepository.Edit(reservation);
        }

        public void Delete(Guid id)
        {
            _reservationRepository.Delete(id);
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
