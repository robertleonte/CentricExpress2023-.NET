using RoomWithAView.Data.Entities;

namespace RoomWithAView.Data
{
    public static class Database
    {
        public static List<Reservation> Reservations = new()
        {
            new Reservation(new Guid("9792f414-7cd9-42dd-9677-8f5b17de9b8d"), new Guid("03255768-996d-4dde-9dd4-567b70d08b53"), new DateTime(2023, 3, 6, 12, 0, 0), new DateTime(2023, 3, 13, 12, 0, 0), 3500),
            new Reservation(new Guid("33e38cea-1c86-4cce-999e-5316b6b4b5b4"), new Guid("bf55a8e3-6b4a-4c57-942d-ea3e904043e0"), new DateTime(2023, 3, 6, 12, 0, 0), new DateTime(2023, 3, 10, 12, 0, 0), 1600),
            new Reservation(new Guid("732b6742-f003-4148-a742-db5c4b90e086"), new Guid("4246f3a8-afa9-492c-8048-b17c244b8c12"), new DateTime(2023, 3, 10, 12, 0, 0), new DateTime(2023, 3, 12, 14, 0, 0), 1200)
        };

        public static List<Room> Rooms = new()
        {
            new Room(new Guid("03255768-996d-4dde-9dd4-567b70d08b53"), 100, "Suite", 5, "Beautiful relaxing place for your tired feet", 500, "Wi-Fi, TV, Air conditioner, Mini playground"),
            new Room(new Guid("c0a4c4a4-d7c2-43d3-b024-05fa6e32e0d9"), 101, "Single", 1, "A perfect recharging space", 200, "Wi-Fi, TV, Air conditioner, Mini bar"),
            new Room(new Guid("bf55a8e3-6b4a-4c57-942d-ea3e904043e0"), 102, "Double", 2, "Let yourself be spoiled by the comfort", 400, "Wi-Fi, TV, Air conditioner, Bath tub"),
            new Room(new Guid("1d1079a7-fa2d-4b9c-baac-843ada9e6df5"), 200, "Double", 2, "Let yourself be spoiled by the comfort", 400, "Wi-Fi, TV, Air conditioner, Bath tub"),
            new Room(new Guid("4246f3a8-afa9-492c-8048-b17c244b8c12"), 201, "Deluxe", 4, "Enter the oasis of a calm and peaceful stay", 600, "Wi-Fi, TV, Air conditioner, Bath tub,Mini bar, Daily snacks, Ocean view")
        };
}
}
