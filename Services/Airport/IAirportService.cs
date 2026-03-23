using Airport.Entities;
using Airport.Dto;
namespace Airport.Services;
public interface IAirportService {
    void AddPassenger(int id, string name, string passport);
    void AddFlight(int id, string dest, DateTime time, decimal price, int seats);
    bool BuyTicket(int flightId, int passId);
    IReadOnlyList<Flight> GetFlightsByStatus(FlightStatus status);
    IReadOnlyList<Flight> GetAllFlights();
    IEnumerable<FlightStatResult> GetRevenueReport();
    IEnumerable<FlightStatResult> GetTopProfitableFlights(int count = 3);
}
