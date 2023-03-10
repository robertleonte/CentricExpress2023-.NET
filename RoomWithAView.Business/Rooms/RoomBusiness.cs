using RoomWithAView.Business.Dto;
using RoomWithAView.Data;
using RoomWithAView.Data.Entities;

namespace RoomWithAView.Business.Rooms
{
    public class RoomBusiness : IRoomBusiness
    {
        private readonly IRoomRepository _roomRepository;

        public RoomBusiness(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public List<RoomDto> GetAll()
        {
            return _roomRepository.Get().Select(room => MapRoomToDto(room)).ToList();
        }

        public RoomDto GetById(Guid id)
        {
             var room = _roomRepository.GetById(id);
            return MapRoomToDto(room);
        }

        public List<RoomDto> FilterByPrice(int priceMin, int priceMax)
        {
            if (priceMin > priceMax)
            {
                throw new InvalidDataException("Minimum price cannot be lower than maximum price");
            }

            return _roomRepository.Get().Where(room => room.Price >= priceMin && room.Price <= priceMax)
                .Select(room => MapRoomToDto(room)).ToList();
        }

        public void Add(RoomDto roomDto)
        {
            var newRoom = new Room(
                roomDto.Id,
                roomDto.Number,
                roomDto.Category,
                roomDto.Capacity,
                roomDto.Description,
                roomDto.Price,
                roomDto.Facilities);
            _roomRepository.Add(newRoom);
        }

        public void Update(Guid id, RoomDto roomDto)
        {
            var room = _roomRepository.GetById(id);
            room.Update(roomDto.Number, roomDto.Category, roomDto.Price, roomDto.Capacity, roomDto.Description, roomDto.Facilities);
            _roomRepository.Edit(room);
        }

        public void Delete(Guid id)
        {
            _roomRepository.Delete(id);
        }

        private static RoomDto MapRoomToDto(Room room)
        {
            return new RoomDto(
                room.Id,
                room.Number,
                room.Category,
                room.Capacity,
                room.Description,
                room.Price,
                room.Facilities,
                MapReservations(room));
        }

        private static List<ReservationDto> MapReservations(Room room)
        {
            if (room.Reservations != null && room.Reservations.Any())
            {
                return room.Reservations.Select(reservation =>
                    new ReservationDto(
                    reservation.Id,
                    reservation.RoomId,
                    reservation.CheckIn,
                    reservation.CheckOut,
                    reservation.TotalPayment)).ToList();
            }

            return new List<ReservationDto>();
        }
    }
}
