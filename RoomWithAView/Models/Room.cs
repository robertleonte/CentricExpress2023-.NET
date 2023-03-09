namespace RoomWithAView.Models
{
    public class Room
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public string Category { get; set; }

        public int Capacity { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Facilities { get; set; }

        public Room()
        {
            Id = Guid.NewGuid();
        }
    }
}
