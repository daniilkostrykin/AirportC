using Airport.Entities;
namespace Airport.Repositories;

public class FlightRepository : IFlightRepository {
    private readonly List<Flight> _flights = [];
    public void Add(Flight flight) => _flights.Add(flight);
    public Flight? GetById(int id) => _flights.FirstOrDefault(f => f.Id == id);
    public IReadOnlyList<Flight> GetAll() => _flights;
}
