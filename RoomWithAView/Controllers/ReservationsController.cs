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
            var reservations = this.reservationBusiness.GetAll();
            return Ok(reservations);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            var reservation = this.reservationBusiness.GetById(id);
            return Ok(reservation);
        }

        [HttpGet]
        [Route("dates")]
        public IActionResult FilterByDates([FromQuery] DateTime checkIn, [FromQuery] DateTime checkOut)
        {
            var reservationsFiltered = this.reservationBusiness.FilterByDates(checkIn, checkOut);
            return Ok(reservationsFiltered);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(Guid id, [FromBody] ReservationDto reservationDto)
        {
            this.reservationBusiness.Update(id, reservationDto);
            return Ok(reservationDto);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ReservationDto reservationDto)
        {
            this.reservationBusiness.Add(reservationDto);
            return Ok(reservationDto);
        }
    }
}
