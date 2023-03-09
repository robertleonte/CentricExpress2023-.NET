﻿using RoomWithAView.Data.Entities;

namespace RoomWithAView.Data
{
    public static class Database
    {
        public static List<Reservation> Reservations = new()
        {
           new Reservation(Guid.NewGuid(), new DateTime(2023, 3, 6, 12, 0, 0), new DateTime(2023, 3, 13, 12, 0, 0), 3500),
           new Reservation(Guid.NewGuid(), new DateTime(2023, 3, 6, 12, 0, 0), new DateTime(2023, 3, 10, 12, 0, 0), 1600),
           new Reservation(Guid.NewGuid(), new DateTime(2023, 3, 10, 12, 0, 0), new DateTime(2023, 3, 12, 14, 0, 0), 1200),
        };

        public static List<Room> Rooms = new()
        {
            new Room(
                100,
                "Suite",
                5,
                "Beautiful relaxing place for your tired feet",
                500,
                "Wi-Fi, TV, Air conditioner, Mini playground"
                ),
            new Room(
                101,
                "Single",
                1,
                "A perfect recharging space",
                200,
                 "Wi-Fi, TV, Air conditioner, Mini bar"
                ),
            new Room(
                102,
                "Double",
                2,
                "Let yourself be spoiled by the comfort",
                400,
                "Wi-Fi, TV, Air conditioner, Bath tub"
                ),
            new Room(
                200,
                "Double",
                2,
                "Let yourself be spoiled by the comfort",
                400,
                "Wi-Fi, TV, Air conditioner, Bath tub"
                ),
            new Room(
                201,
                "Deluxe",
                4,
                "Enter the oasis of a calm and peaceful stay",
                600,
                "Wi-Fi, TV, Air conditioner, Bath tub, Mini bar, Daily snacks, Ocean view"
                )
        };
}
}
