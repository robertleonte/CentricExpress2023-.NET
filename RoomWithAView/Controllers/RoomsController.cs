using Microsoft.AspNetCore.Mvc;
using RoomWithAView.Models;

namespace RoomWithAView.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private static List<Room> _rooms = new()
        {
            new Room
            {
                Id = Guid.NewGuid(),
                Description = "Beautiful relaxing place for your tired feet",
                Facilities = new List<string> { "Wi-Fi", "TV", "Air conditioner", "Mini playground" },
                Price = 500,
                Category = "Suite",
                Capacity = 5,
                Number = 100
            },
            new Room
            {
                Id = Guid.NewGuid(),
                Description = "A perfect recharging space",
                Facilities = new List<string> { "Wi-Fi", "TV", "Air conditioner", "Mini bar" },
                Price = 200,
                Category = "Single",
                Capacity = 1,
                Number = 101
            },
            new Room
            {
                Id = Guid.NewGuid(),
                Description = "Let yourself be spoiled by the comfort",
                Facilities = new List<string> { "Wi-Fi", "TV", "Air conditioner", "Bath tub" },
                Price = 400,
                Category = "Double",
                Capacity = 2,
                Number = 102
            },
            new Room
            {
                Id = Guid.NewGuid(),
                Description = "Let yourself be spoiled by the comfort",
                Facilities = new List<string> { "Wi-Fi", "TV", "Air conditioner", "Bath tub" },
                Price = 400,
                Category = "Double",
                Capacity = 2,
                Number = 200
            },
            new Room
            {
                Id = Guid.NewGuid(),
                Description = "Enter the oasis of a calm and peaceful stay",
                Facilities = new List<string> { "Wi-Fi", "TV", "Air conditioner", "Bath tub", "Mini bar", "Daily snacks", "Ocean view" },
                Price = 600,
                Category = "Deluxe",
                Capacity = 4,
                Number = 201
            },
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_rooms);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Room room)
        {
            _rooms.Add(room);
            return Ok(room);
        }
    }
}