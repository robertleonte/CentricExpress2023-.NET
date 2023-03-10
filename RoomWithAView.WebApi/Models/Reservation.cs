namespace RoomWithAView.WebApi.Models
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


        public Guid Id { get; private set; }

        public Guid RoomId { get; private set; }

        public DateTime CheckIn { get; private set; }

        public DateTime CheckOut { get; private set; }

        public int TotalPayment { get; private set; }

        public void Update(Guid roomId, DateTime checkIn, DateTime checkOut, int totalPayment)
        {
            RoomId = roomId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            TotalPayment = totalPayment;
        }
    }
}
