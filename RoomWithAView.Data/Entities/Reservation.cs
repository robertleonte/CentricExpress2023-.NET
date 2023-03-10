namespace RoomWithAView.Data.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int TotalPayment { get; set; }

        public Reservation(
            Guid roomId,
            DateTime checkIn,
            DateTime checkOut,
            int totalPayment)
        {
            Id = Guid.NewGuid();
            RoomId = roomId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            TotalPayment = totalPayment;
        }

        public void Update(Guid roomId, DateTime checkIn, DateTime checkOut, int totalPayment)
        {
            RoomId = roomId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            TotalPayment = totalPayment;
        }
    }
}
