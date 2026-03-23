using Airport.Entities;
namespace Airport.Repositories;

public class PassengerRepository : IPassengerRepository {
    private readonly Dictionary<int, Passenger> _passengers = [];

    public void Add(Passenger passenger) => _passengers[passenger.Id] = passenger;

    public Passenger? GetById(int id) => _passengers.TryGetValue(id, out var p) ? p : null;

    public IReadOnlyList<Passenger> GetAll() => _passengers.Values.ToList();
}