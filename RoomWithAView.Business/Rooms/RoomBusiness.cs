using Rooms.Data;
using Rooms.Data.Entities;
using RoomWithAView.Business.Dto;

namespace RoomWithAView.Business.Rooms
{
    public class RoomBusiness : IRoomBusiness
    {
        public List<RoomDto> GetAll()
        {
            return Database.Rooms.Select(r => MapRoomToDto(r)).ToList();
        }

        public RoomDto? GetByNumber(int number)
        {
            return Database.Rooms.Where(r => r.Number == number)
                .Select(r => MapRoomToDto(r)).FirstOrDefault();
        }

        public List<RoomDto> FilterByPrice(int priceMin, int priceMax)
        {
            return Database.Rooms.FindAll(r => r.Price >= priceMin && r.Price <= priceMax)
                .Select(r => MapRoomToDto(r)).ToList();
        }

        public List<RoomDto> FilterByCategory(string category)
        {
            return Database.Rooms.FindAll(r => r.Category == category)
                .Select(r => MapRoomToDto(r)).ToList();
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

        public void Update(int number, RoomDto roomDto)
        {
            var room = Database.Rooms.SingleOrDefault(r => r.Number == number);
            room?.Update(roomDto.Price, roomDto.Capacity, roomDto.Description, roomDto.Facilities);
        }

        private static RoomDto MapRoomToDto(Room r)
        {
            return new RoomDto(
                r.Id,
                r.Number,
                r.Category,
                r.Capacity,
                r.Description,
                r.Price,
                r.Facilities);
        }
    }
}
