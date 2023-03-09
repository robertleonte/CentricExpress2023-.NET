namespace RoomWithAView.Business.Dto
{
    public class ReservationDto
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int TotalPayment { get; set; }

        public ReservationDto(
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
    }
}
