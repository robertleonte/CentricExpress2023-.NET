using Microsoft.AspNetCore.Mvc;
using RoomWithAView.Business.Dto;
using RoomWithAView.Business.Reservations;

namespace RoomWithAView.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationBusiness reservationBusiness;

        public ReservationsController(IReservationBusiness reservationBusiness)
        {
            this.reservationBusiness = reservationBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var reservations = reservationBusiness.GetAll();
            return Ok(reservations);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            var reservation = reservationBusiness.GetById(id);
            return Ok(reservation);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(Guid id, [FromBody] ReservationDto reservationDto)
        {
            reservationBusiness.Update(id, reservationDto);
            return Ok(reservationDto);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ReservationDto reservationDto)
        {
            reservationBusiness.Add(reservationDto);
            return Ok(reservationDto);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            reservationBusiness.Delete(id);
            return Ok();
        }
    }
}
