using RoomWithAView.Business.Dto;

namespace RoomWithAView.Business.Reservations
{
    public interface IReservationBusiness
    {
        List<ReservationDto> GetAll();

        ReservationDto? GetById(Guid id);

        void Add(ReservationDto reservationDto);

        void Update(Guid id, ReservationDto reservationDto);
    }
}
