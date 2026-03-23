using Airport.Entities;
namespace Airport.Repositories;

public class TicketRepository : ITicketRepository {
    private readonly List<Ticket> _tickets = [];
    public void Add(Ticket ticket) => _tickets.Add(ticket);
    public IReadOnlyList<Ticket> GetAll() => _tickets;
}
