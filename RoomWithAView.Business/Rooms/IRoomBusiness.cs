using RoomWithAView.Business.Dto;

namespace RoomWithAView.Business.Rooms
{
    public interface IRoomBusiness
    {
        List<RoomDto> GetAll();

        RoomDto? GetByNumber(int number);

        List<RoomDto> FilterByPrice(int priceMin, int priceMax);

        List<RoomDto> FilterByCategory(string category);

        void Add(RoomDto roomDto);

        void Update(int number, RoomDto roomDto);
    }
}
