namespace RoomWithAView.Business.Dto
{
    public class ReservationDto
    {
        public Guid Id { get; set; }

        public int RoomNumber { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int TotalPayment { get; set; }

        public ReservationDto(
            Guid id,
            int roomNumber,
            DateTime checkIn,
            DateTime checkOut,
            int totalPayment)
        {
            Id = id;
            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
            TotalPayment = totalPayment;
        }
    }
}
