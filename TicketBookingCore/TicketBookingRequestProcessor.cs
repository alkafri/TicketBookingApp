namespace TicketBookingCore;

public class TicketBookingRequestProcessor
{
    private readonly ITicketBookingRepository _ticketBookingRepository;

    public TicketBookingRequestProcessor(ITicketBookingRepository ticketBookingRepository)
    {
        _ticketBookingRepository = ticketBookingRepository;
    }

    public TicketBookingResponse Book(TicketBookingRequest request)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));

        // Use function for validation
        if (!IsValidEmail(request.Email))
        {
            throw new ArgumentException("Invalid email address");
        }

        var ticketBooking = Create<TicketBooking>(request);
        _ticketBookingRepository.Save(ticketBooking);

        return Create<TicketBookingResponse>(request);
    }

    // Validation function
    private bool IsValidEmail(string email)
    {
        return !string.IsNullOrWhiteSpace(email) && email.Contains("@");
    }

    // Refactor
    private static T Create<T>(TicketBookingRequest request) where T : TicketBookingBase, new()
    {
        return new T
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Date = request.Date
        };
    }
}