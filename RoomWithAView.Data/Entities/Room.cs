namespace RoomWithAView.Data.Entities
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

        public Room(
            int number,
            string category,
            int capacity,
            string description,
            int price,
            string facilities)
        {
            Id = Guid.NewGuid();
            Number = number;
            Category = category;
            Capacity = capacity;
            Description = description;
            Price = price;
            Facilities = facilities;
        }

        public void Update(int price, int capacity, string description, string facilities)
        {
            Price = price;
            Capacity = capacity;
            Description = description;
            Facilities = facilities;
        }
    }
}
