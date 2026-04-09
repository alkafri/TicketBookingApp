using Xunit;
using TicketBookingCore;

namespace TicketBookingCore.Tests;

public class TicketBookingRequestProcessorTests
{
    [Fact]
    public void ShouldReturnTicketBookingResultWithRequestValues()
    {
        // 1. Arrange
        var processor = new TicketBookingRequestProcessor();
        var request = new TicketBookingRequest
        {
            FirstName = "Ahmed",
            LastName = "Alkafri",
            Email = "ahmed@example.com",
            Date = DateTime.Now
        };

        // 2. Act
        TicketBookingResponse response = processor.Book(request);

        // 3. Assert
        Assert.NotNull(response);
        Assert.Equal(request.FirstName, response.FirstName);
        Assert.Equal(request.LastName, response.LastName);
        Assert.Equal(request.Email, response.Email);
    }
}