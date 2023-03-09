using RoomWithAView.Business.Dto;
using RoomWithAView.Data;
using RoomWithAView.Data.Entities;

namespace RoomWithAView.Business.Rooms
{
    public class RoomBusiness : IRoomBusiness
    {
        public List<RoomDto> GetAll()
        {
            return Database.Rooms.Select(room => MapRoomToDto(room)).ToList();
        }

        public RoomDto? GetById(Guid id)
        {
            return Database.Rooms.Where(room => room.Id == id)
                .Select(room => MapRoomToDto(room)).FirstOrDefault();
        }

        public List<RoomDto> FilterByPrice(int priceMin, int priceMax)
        {
            return Database.Rooms.FindAll(room => room.Price >= priceMin && room.Price <= priceMax)
                .Select(room => MapRoomToDto(room)).ToList();
        }

        public void Add(RoomDto roomDto)
        {
            var newRoom = new Room(
                roomDto.Number,
                roomDto.Category,
                roomDto.Capacity,
                roomDto.Description,
                roomDto.Price,
                roomDto.Facilities);
            Database.Rooms.Add(newRoom);
        }

        public void Update(Guid id, RoomDto roomDto)
        {
            var roomToUpdate = Database.Rooms.SingleOrDefault(room => room.Id == id);
            roomToUpdate?.Update(roomDto.Price, roomDto.Capacity, roomDto.Description, roomDto.Facilities);
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
                room.Facilities);
        }
    }
}
