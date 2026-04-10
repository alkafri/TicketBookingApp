using Moq;
using Xunit;
using TicketBookingCore;

namespace TicketBookingCore.Tests;

public class TicketBookingRequestProcessorTests
{
    private readonly TicketBookingRequestProcessor _processor;
    private readonly Mock<ITicketBookingRepository> _repositoryMock;

    public TicketBookingRequestProcessorTests()
    {
        // 1. Create DB (Mock)
        _repositoryMock = new Mock<ITicketBookingRepository>();

        // 2. Send it to processor
        _processor = new TicketBookingRequestProcessor(_repositoryMock.Object);
    }

    [Fact]
    public void ShouldSaveToDatabase()
    {
        // Arrange
        var request = new TicketBookingRequest { FirstName = "Ahmed", Email = "ahmed@test.com" };

        // Act
        _processor.Book(request);

        // Assert
        _repositoryMock.Verify(x => x.Save(It.IsAny<TicketBooking>()), Times.Once);
    }
}