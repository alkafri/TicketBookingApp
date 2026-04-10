namespace TicketBookingCore;

public class TicketBookingRequestProcessor
{
    private readonly ITicketBookingRepository _ticketBookingRepository;

    // Constructor: tell the processor not to work without DB
    public TicketBookingRequestProcessor(ITicketBookingRepository ticketBookingRepository)
    {
        _ticketBookingRepository = ticketBookingRepository;
    }

    public TicketBookingResponse Book(TicketBookingRequest request)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));

        // Create save entity
        var ticketBooking = new TicketBooking
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Date = request.Date
        };

        // Save in DB (moq)
        _ticketBookingRepository.Save(ticketBooking);

        return new TicketBookingResponse
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Date = request.Date
        };
    }
}