using Moq;
using SlotMachine.Services.Implementations;
using SlotMachine.Services.Interfaces;
using Xunit;

namespace SlotMachine.UnitTests
{
    public class SlotMachineServiceTests
    {
        private readonly Mock<IBoardService> _boardServiceMock;
        private readonly SlotMachineService _service;

        public SlotMachineServiceTests()
        {
            _boardServiceMock = new Mock<IBoardService>();
            _service = new SlotMachineService(_boardServiceMock.Object);
        }

        [Fact]
        public void Start_ShouldSetIsPlayingToTrue()
        {
            // Act
            _service.Start();

            // Assert
            Assert.True(_service.IsPlaying);
        }

        [Theory]
        [InlineData(10, 1, 2)]
        [InlineData(100, 2.5, 5)]
        [InlineData(20, 0.5, 1)]
        [InlineData(1000, 0.1, 0.2)]
        public void Spin_ShouldReturnCorrectWinAmountAndBalance(decimal balance, decimal stakeAmount, decimal expectedWinAmount)
        {
            // Arrange
            // Set up mock data for the Board
            var boardMock = new Board();
            boardMock.symbols = new Symbol[,]
            {
                { new Symbol(SymbolType.Apple, 0.4m), new Symbol(SymbolType.Apple, 0.4m), new Symbol(SymbolType.Apple, 0.4m) },
                { new Symbol(SymbolType.Apple, 0.4m), new Symbol(SymbolType.Banana, 0.6m), new Symbol(SymbolType.Pineapple, 0.8m) },
                { new Symbol(SymbolType.Apple, 0.4m), new Symbol(SymbolType.Wildcard, 0), new Symbol(SymbolType.Apple, 0.4m) },
                { new Symbol(SymbolType.Apple, 0.4m), new Symbol(SymbolType.Wildcard, 0), new Symbol(SymbolType.Pineapple, 0.8m) }
            };

            _boardServiceMock.Setup(x => x.Board).Returns(boardMock);

            decimal initialBalance = balance;

            // Act
            var result = _service.Spin(balance, stakeAmount);

            // Assert
            Assert.Equal(expectedWinAmount, result.Item1);
            Assert.Equal(initialBalance - stakeAmount + expectedWinAmount, result.Item2);
        }
    }
}
