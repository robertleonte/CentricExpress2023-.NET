using Microsoft.AspNetCore.Mvc;
using RoomWithAView.WebApi.Models;

namespace RoomWithAView.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private static List<Reservation> _reservations = new()
        {
            new Reservation(new Guid("9792f414-7cd9-42dd-9677-8f5b17de9b8d"), new Guid("03255768-996d-4dde-9dd4-567b70d08b53"), new DateTime(2023, 3, 6, 12, 0, 0), new DateTime(2023, 3, 13, 12, 0, 0), 3500),
            new Reservation(new Guid("33e38cea-1c86-4cce-999e-5316b6b4b5b4"), new Guid("bf55a8e3-6b4a-4c57-942d-ea3e904043e0"), new DateTime(2023, 3, 6, 12, 0, 0), new DateTime(2023, 3, 10, 12, 0, 0), 1600),
            new Reservation(new Guid("732b6742-f003-4148-a742-db5c4b90e086"), new Guid("4246f3a8-afa9-492c-8048-b17c244b8c12"), new DateTime(2023, 3, 10, 12, 0, 0), new DateTime(2023, 3, 12, 14, 0, 0), 1200)
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_reservations);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            var reservation = _reservations.FirstOrDefault(existingReservation => existingReservation.Id == id);
            return Ok(reservation);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(Guid id, [FromBody] Reservation reservation)
        {
            var reservationToUpdate = _reservations.FirstOrDefault(existingReservation => existingReservation.Id == id);

            if (reservationToUpdate != null)
            {
                reservation.Update(
                    reservationToUpdate.RoomId,
                    reservationToUpdate.CheckIn,
                    reservationToUpdate.CheckOut,
                    reservationToUpdate.TotalPayment);
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Add([FromBody] Reservation reservation)
        {
            _reservations.Add(reservation);
            return Ok(reservation);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            var reservationToDelete = _reservations.FirstOrDefault(reservation => reservation.Id == id);

            if (reservationToDelete != null)
            {
                _reservations.Remove(reservationToDelete);
            }

            return Ok();
        }
    }
}
