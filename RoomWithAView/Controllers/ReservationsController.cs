using Microsoft.AspNetCore.Mvc;
using RoomWithAView.Models;

namespace RoomWithAView.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private static List<Reservation> _reservations = new()
        {
            new Reservation
            {
                Id = Guid.NewGuid(),
                RoomNumber = 100,
                CheckIn = new DateTime(2023, 3, 6, 12, 0, 0),
                CheckOut = new DateTime(2023, 3, 13, 12, 0, 0),
                TotalPayment = 3500
            },
            new Reservation
            {
                Id = Guid.NewGuid(),
                RoomNumber = 102,
                CheckIn = new DateTime(2023, 3, 6, 12, 0, 0),
                CheckOut = new DateTime(2023, 3, 10, 12, 0, 0),
                TotalPayment = 1600
            },
            new Reservation
            {
                Id = Guid.NewGuid(),
                RoomNumber = 201,
                CheckIn = new DateTime(2023, 3, 10, 12, 0, 0),
                CheckOut = new DateTime(2023, 3, 12, 14, 0, 0),
                TotalPayment = 1200
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_reservations);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Reservation reservation)
        {
            _reservations.Add(reservation);
            return Ok(reservation);
        }
    }
}
