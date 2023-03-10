using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Rooms.Data.Entities
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
        public Guid Id { get; private set; }

        public int Number { get; private set; }

        public string Category { get; private set; }

        public int Capacity { get; private set; }

        public string Description { get; private set; }

        public int Price { get; private set; }

        public string Facilities { get; private set; }

        public List<Reservation> Reservations { get; private set; }

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
