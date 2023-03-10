using Microsoft.AspNetCore.Mvc;
using RoomWithAView.WebApi.Models;

namespace RoomWithAView.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private static List<Room> _rooms = new()
        {
            new Room(new Guid("03255768-996d-4dde-9dd4-567b70d08b53"), 100, "Suite", 5, "Beautiful relaxing place for your tired feet", 500, "Wi-Fi, TV, Air conditioner, Mini playground"),
            new Room(new Guid("c0a4c4a4-d7c2-43d3-b024-05fa6e32e0d9"), 101, "Single", 1, "A perfect recharging space", 200, "Wi-Fi, TV, Air conditioner, Mini bar"),
            new Room(new Guid("bf55a8e3-6b4a-4c57-942d-ea3e904043e0"), 102, "Double", 2, "Let yourself be spoiled by the comfort", 400, "Wi-Fi, TV, Air conditioner, Bath tub"),
            new Room(new Guid("1d1079a7-fa2d-4b9c-baac-843ada9e6df5"), 200, "Double", 2, "Let yourself be spoiled by the comfort", 400, "Wi-Fi, TV, Air conditioner, Bath tub"),
            new Room(new Guid("4246f3a8-afa9-492c-8048-b17c244b8c12"), 201, "Deluxe", 4, "Enter the oasis of a calm and peaceful stay", 600, "Wi-Fi, TV, Air conditioner, Bath tub,Mini bar, Daily snacks, Ocean view")
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_rooms);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            var room = _rooms.FirstOrDefault(existingRoom => existingRoom.Id == id);
            return Ok(room);
        }

        [HttpGet]
        [Route("price")]
        public IActionResult FilterByPrice([FromQuery] int priceMin, [FromQuery] int priceMax)
        {
            var roomsFiltered = _rooms.Where(existingRoom => existingRoom.Price >= priceMin && existingRoom.Price <= priceMax);
            return Ok(roomsFiltered);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(Guid id, [FromBody] Room room)
        {
            var roomToUpdate = _rooms.FirstOrDefault(existingRoom => existingRoom.Id == id);

            if (roomToUpdate != null)
            {
                room.Update(roomToUpdate.Number, roomToUpdate.Category, roomToUpdate.Price, roomToUpdate.Capacity, roomToUpdate.Description, roomToUpdate.Facilities);
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Add([FromBody] Room room)
        {
            _rooms.Add(room);
            return Ok(room);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            var roomToDelete = _rooms.FirstOrDefault(room => room.Id == id);

            if (roomToDelete != null)
            {
                _rooms.Remove(roomToDelete);
            }

            return Ok();
        }
    }
}