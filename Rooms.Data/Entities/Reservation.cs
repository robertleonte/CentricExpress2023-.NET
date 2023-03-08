namespace Rooms.Data.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }

        public int RoomNumber { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int TotalPayment { get; set; }

        public Reservation(
            int roomNumber,
            DateTime checkIn,
            DateTime checkOut,
            int totalPayment)
        {
            Id = Guid.NewGuid();
            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
            TotalPayment = totalPayment;
        }

        public void Update(int roomNumber, DateTime checkIn, DateTime checkOut, int totalPayment)
        {
            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
            TotalPayment = totalPayment;
        }
    }
}
