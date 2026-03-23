using Airport.Entities;
namespace Airport.Repositories;
public interface IPassengerRepository {
    void Add(Passenger passenger);
    Passenger? GetById(int id);
    IReadOnlyList<Passenger> GetAll();
}
