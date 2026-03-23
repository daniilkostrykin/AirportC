using Airport.Entities;
namespace Airport.Repositories;
public interface IFlightRepository {
    void Add(Flight flight);
    Flight? GetById(int id);
    IReadOnlyList<Flight> GetAll();
}
