using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rooms.Data.Entities
{
    public class Reservation
    {
        public Reservation(
            Guid id,
            Guid roomId,
            DateTime checkIn,
            DateTime checkOut,
            int totalPayment)
        {
            Id = id;
            RoomId = roomId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            TotalPayment = totalPayment;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int TotalPayment { get; set; }

        public void Update(Guid roomId, DateTime checkIn, DateTime checkOut, int totalPayment)
        {
            RoomId = roomId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            TotalPayment = totalPayment;
        }
    }
}
