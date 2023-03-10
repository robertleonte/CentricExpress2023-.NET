using Microsoft.AspNetCore.Mvc;
using RoomWithAView.Business.Dto;
using RoomWithAView.Business.Rooms;

namespace RoomWithAView.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomBusiness _roomBusiness;

        public RoomsController(IRoomBusiness roomBusiness)
        {
            this._roomBusiness = roomBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var rooms = this._roomBusiness.GetAll();
            return Ok(rooms);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            var room = this._roomBusiness.GetById(id);
            return Ok(room);
        }

        [HttpGet]
        [Route("price")]
        public IActionResult FilterByPrice([FromQuery] int priceMin, [FromQuery] int priceMax)
        {
            var roomsFiltered = this._roomBusiness.FilterByPrice(priceMin, priceMax);
            return Ok(roomsFiltered);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(Guid id, [FromBody] RoomDto room)
        {
            this._roomBusiness.Update(id, room);
            return Ok(room);
        }

        [HttpPost]
        public IActionResult Add([FromBody] RoomDto room)
        {
            this._roomBusiness.Add(room);
            return Ok(room);
        }
    }
}