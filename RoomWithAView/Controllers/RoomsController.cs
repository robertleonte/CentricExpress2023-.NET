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
            var rooms = roomBusiness.GetAll();
            return Ok(rooms);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            var room = roomBusiness.GetById(id);
            return Ok(room);
        }

        [HttpGet]
        [Route("price")]
        public IActionResult FilterByPrice([FromQuery] int priceMin, [FromQuery] int priceMax)
        {
            var roomsFiltered = roomBusiness.FilterByPrice(priceMin, priceMax);
            return Ok(roomsFiltered);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(Guid id, [FromBody] RoomDto room)
        {
            roomBusiness.Update(id, room);
            return Ok(room);
        }

        [HttpPost]
        public IActionResult Add([FromBody] RoomDto room)
        {
            roomBusiness.Add(room);
            return Ok(room);
        }

        [HttpDelete]
        public IActionResult Delete(Guid roomId)
        {
            roomBusiness.Delete(roomId);
            return Ok();
        }
    }
}