using RoomWithAView.Business.Dto;

namespace RoomWithAView.Business.Reservations
{
    public interface IReservationBusiness
    {
        List<ReservationDto> GetAll();

        ReservationDto? GetById(Guid id);

        List<ReservationDto> FilterByDates(DateTime checkIn, DateTime checkOut);

        void Add(ReservationDto reservationDto);

        void Update(Guid id, ReservationDto reservationDto);
    }
}
