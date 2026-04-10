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
    public void ShouldReturnErrorForInvalidEmail()
    {
        // Arrange: Prepare wrong data
        var request = new TicketBookingRequest
        {
            FirstName = "Ahmed",
            LastName = "Alkafri",
            Email = "ahmed.hotmail.com"
        };

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => _processor.Book(request));

        // Confirm error message
        Assert.Equal("Invalid email address", exception.Message);

        // make sure nothing save on DB
        _repositoryMock.Verify(x => x.Save(It.IsAny<TicketBooking>()), Times.Never);
    }
}