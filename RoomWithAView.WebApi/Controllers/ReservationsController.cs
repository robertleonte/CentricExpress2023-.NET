using Microsoft.AspNetCore.Mvc;
using RoomWithAView.Business.Dto;
using RoomWithAView.Business.Reservations;

namespace RoomWithAView.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationBusiness _reservationBusiness;

        public ReservationsController(IReservationBusiness reservationBusiness)
        {
            _reservationBusiness = reservationBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var reservations = _reservationBusiness.GetAll();
            return Ok(reservations);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            var reservation = _reservationBusiness.GetById(id);
            return Ok(reservation);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(Guid id, [FromBody] ReservationDto reservationDto)
        {
            _reservationBusiness.Update(id, reservationDto);
            return Ok(reservationDto);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ReservationDto reservationDto)
        {
            _reservationBusiness.Add(reservationDto);
            return Ok(reservationDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            _reservationBusiness.Delete(id);
            return Ok();
        }
    }
}
