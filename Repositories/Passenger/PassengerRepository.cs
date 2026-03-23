using Airport.Entities;
namespace Airport.Repositories;

public class PassengerRepository : IPassengerRepository {
    private readonly List<Passenger> _passengers = [];
    public void Add(Passenger passenger) => _passengers.Add(passenger);
    public Passenger? GetById(int id) => _passengers.FirstOrDefault(p => p.Id == id);
    public IReadOnlyList<Passenger> GetAll() => _passengers;
}
