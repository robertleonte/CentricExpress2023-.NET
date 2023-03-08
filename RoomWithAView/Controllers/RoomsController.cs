using Microsoft.AspNetCore.Mvc;
using RoomWithAView.Business.Rooms;
using RoomWithAView.Business.Dto;

namespace RoomWithAView.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomBusiness roomBusiness;

        public RoomsController(IRoomBusiness roomBusiness)
        {
            this.roomBusiness = roomBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var rooms = this.roomBusiness.GetAll();
            return Ok(rooms);
        }

        [HttpGet]
        [Route("{number}")]
        public IActionResult GetByNumber(int number)
        {
            var room = this.roomBusiness.GetByNumber(number);
            return Ok(room);
        }

        [HttpGet]
        [Route("price")]
        public IActionResult FilterByPrice([FromQuery] int priceMin, [FromQuery] int priceMax)
        {
            var roomsFiltered = this.roomBusiness.FilterByPrice(priceMin, priceMax);
            return Ok(roomsFiltered);
        }

        [HttpGet]
        [Route("category")]
        public IActionResult FilterByCategory([FromQuery] string category)
        {
            var roomsFiltered = this.roomBusiness.FilterByCategory(category);
            return Ok(roomsFiltered);
        }

        [HttpPut]
        [Route("{number}")]
        public IActionResult Put(int number, [FromBody] RoomDto room)
        {
            this.roomBusiness.Update(number, room);
            return Ok(room);
        }

        [HttpPost]
        public IActionResult Add([FromBody] RoomDto room)
        {
            this.roomBusiness.Add(room);
            return Ok(room);
        }
    }
}