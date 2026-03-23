using Airport.Entities;
using Airport.Dto;
using Airport.Repositories;
namespace Airport.Services;

public class AirportService : IAirportService {
    private readonly IFlightRepository _flightRepo;
    private readonly IPassengerRepository _passRepo;
    private readonly ITicketRepository _ticketRepo;
    private int _ticketIdCounter = 1;

    public AirportService(IFlightRepository f, IPassengerRepository p, ITicketRepository t) {
        _flightRepo = f; _passRepo = p; _ticketRepo = t;
    }

    public void AddPassenger(int id, string name, string passport) => _passRepo.Add(new Passenger(id, name, passport));
    public void AddFlight(int id, string dest, DateTime time, decimal price, int seats) => _flightRepo.Add(new Flight(id, dest, time, price, seats));

    public bool BuyTicket(int flightId, int passId) {
        var flight = _flightRepo.GetById(flightId);
        if (flight == null || _ticketRepo.GetAll().Count(t => t.FlightId == flightId) >= flight.TotalSeats) return false;
        _ticketRepo.Add(new Ticket(_ticketIdCounter++, flightId, passId, flight.BasePrice));
        return true;
    }

    public IReadOnlyList<Flight> GetFlightsByStatus(FlightStatus s) => _flightRepo.GetAll().Where(f => f.Status == s).ToList();

    public IReadOnlyList<Flight> GetAllFlights() => _flightRepo.GetAll();

    public IEnumerable<FlightStatResult> GetRevenueReport() {
        return _ticketRepo.GetAll()
            .GroupBy(t => t.FlightId)
            .Select(g => {
                var f = _flightRepo.GetById(g.Key);
                return new FlightStatResult { Destination = f?.Destination ?? "?", TicketsSold = g.Count(), TotalRevenue = g.Sum(t => t.PricePaid) };
            });
    }

    public IEnumerable<FlightStatResult> GetTopProfitableFlights(int count = 3) {
        return GetRevenueReport()
            .OrderByDescending(r => r.TotalRevenue)
            .Take(count);
    }
}
