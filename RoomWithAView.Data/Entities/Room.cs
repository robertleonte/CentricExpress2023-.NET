using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomWithAView.Data.Entities
{
    public class Room
    {
        public Room(
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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int Number { get; set; }

        public string Category { get; set; }

        public int Capacity { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Facilities { get; set; }

        public List<Reservation> Reservations { get; set; }

        public void Update(int number, string category, int price, int capacity, string description, string facilities)
        {
            Number = number;
            Category = category;
            Price = price;
            Capacity = capacity;
            Description = description;
            Facilities = facilities;
        }
    }
}
