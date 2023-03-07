namespace RoomWithAView.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }

        public int RoomNumber { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int TotalPayment { get; set; }

        public Reservation()
        {
            Id = Guid.NewGuid();
        }
    }
}
