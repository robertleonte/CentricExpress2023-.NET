using FluentAssertions;
using Moq;
using RoomWithAView.Business.Rooms;
using RoomWithAView.Data;
using RoomWithAView.Data.Entities;

namespace RoomWithAView.Tests
{
    public class RoomBusinessTests
    {
        private Mock<IRoomRepository> _mockRoomRepository;

        private readonly IRoomBusiness _systemUnderTest;

        private static readonly List<Room> Rooms = new()
        {
            new Room(new Guid("03255768-996d-4dde-9dd4-567b70d08b53"), 100, "Suite", 5,
                "Beautiful relaxing place for your tired feet", 500, "Wi-Fi, TV, Air conditioner, Mini playground"),
            new Room(new Guid("c0a4c4a4-d7c2-43d3-b024-05fa6e32e0d9"), 101, "Single", 1, "A perfect recharging space",
                200, "Wi-Fi, TV, Air conditioner, Mini bar"),
            new Room(new Guid("bf55a8e3-6b4a-4c57-942d-ea3e904043e0"), 102, "Double", 2,
                "Let yourself be spoiled by the comfort", 400, "Wi-Fi, TV, Air conditioner, Bath tub"),
            new Room(new Guid("1d1079a7-fa2d-4b9c-baac-843ada9e6df5"), 200, "Double", 2,
                "Let yourself be spoiled by the comfort", 400, "Wi-Fi, TV, Air conditioner, Bath tub"),
            new Room(new Guid("4246f3a8-afa9-492c-8048-b17c244b8c12"), 201, "Deluxe", 4,
                "Enter the oasis of a calm and peaceful stay", 600,
                "Wi-Fi, TV, Air conditioner, Bath tub,Mini bar, Daily snacks, Ocean view")
        };

        public RoomBusinessTests()
        {
            _mockRoomRepository = new Mock<IRoomRepository>();
            _systemUnderTest = new RoomBusiness(_mockRoomRepository.Object);
        }

        [Fact]
        public void When_FilterWithMinimumPriceLessThanMaximumPrice_Then_ShouldReturnRooms()
        {
            //Arrange
            _mockRoomRepository.Setup(x => x.Get()).Returns(Rooms);

            //Act
            var rooms = _systemUnderTest.FilterByPrice(500, 600);

            //Assert
            rooms.Should().HaveCount(2);
            rooms.Should().ContainSingle(room => room.Id == new Guid("03255768-996d-4dde-9dd4-567b70d08b53"));
            rooms.Should().ContainSingle(room => room.Id == new Guid("4246f3a8-afa9-492c-8048-b17c244b8c12"));
        }

        [Fact]
        public void When_FilterWithMinimumPriceEqualToMaximumPrice_Then_ShouldReturnSingleRoom()
        {
            //Arrange
            _mockRoomRepository.Setup(x => x.Get()).Returns(Rooms);

            //Act
            var rooms = _systemUnderTest.FilterByPrice(200, 200);

            //Assert
            rooms.Should().HaveCount(1);
            rooms.Should().ContainSingle(room => room.Id == new Guid("c0a4c4a4-d7c2-43d3-b024-05fa6e32e0d9"));
        }

        [Fact]
        public void When_FilterWithMinimumPriceGreaterThanMaximumPrice_Then_ShouldThrow ()
        {
            //Arrange
            _mockRoomRepository.Setup(x => x.Get()).Returns(Rooms);

            //Act
            Action action = () => _systemUnderTest.FilterByPrice(600, 200);

            //Assert
            action.Should().Throw<InvalidDataException>()
                .WithMessage("Minimum price cannot be lower than maximum price");
        }
    }
}