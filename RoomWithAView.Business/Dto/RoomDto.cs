namespace RoomWithAView.Business.Dto
{
    public class RoomDto
    {
        public RoomDto(
            Guid id,
            int number,
            string category,
            int capacity,
            string description,
            int price,
            string facilities)
        {
            Id = id;
            Number = number;
            Category = category;
            Capacity = capacity;
            Description = description;
            Price = price;
            Facilities = facilities;
        }

        public Guid Id { get; set; }

        public int Number { get; set; }

        public string Category { get; set; }

        public int Capacity { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Facilities { get; set; }
    }
}
