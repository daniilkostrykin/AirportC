using Airport.Entities;
namespace Airport.Repositories;
public interface ITicketRepository {
    void Add(Ticket ticket);
    IReadOnlyList<Ticket> GetAll();
}
