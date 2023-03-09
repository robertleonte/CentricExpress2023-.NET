using RoomWithAView.Business.Dto;

namespace RoomWithAView.Business.Rooms
{
    public interface IRoomBusiness
    {
        List<RoomDto> GetAll();

        RoomDto GetById(Guid id);

        List<RoomDto> FilterByPrice(int priceMin, int priceMax);

        void Add(RoomDto roomDto);

        void Update(Guid id, RoomDto roomDto);

        void Delete(Guid id);
    }
}
