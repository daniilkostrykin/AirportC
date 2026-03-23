using Airport.Repositories;
using Airport.Services;
using Airport.Console;
using Airport.Entities;

var fRepo = new FlightRepository();
var pRepo = new PassengerRepository();
var tRepo = new TicketRepository();

IAirportService airportService = new AirportService(fRepo, pRepo, tRepo);

SeedData(airportService);

var menu = new AppMenu(airportService);
menu.Run();

static void SeedData(IAirportService airportService)
{
    airportService.AddPassenger(1, "Иван Иванов", "MP123456");
    airportService.AddPassenger(2, "Мария Смирнова", "MP789012");
    airportService.AddPassenger(3, "Алексей Петров", "MP345678");

    airportService.AddFlight(1, "Лондон", DateTime.Now.AddDays(2), 45000m, 150);
    airportService.AddFlight(2, "Париж", DateTime.Now.AddDays(3), 38000m, 120);
    airportService.AddFlight(3, "Нью-Йорк", DateTime.Now.AddDays(5), 75000m, 200);
    airportService.AddFlight(4, "Токио", DateTime.Now.AddDays(7), 95000m, 180);

    airportService.BuyTicket(1, 1); // Иван летит в Лондон
    airportService.BuyTicket(1, 2); // Мария летит в Лондон
    airportService.BuyTicket(2, 1); // Иван также летит в Париж
    airportService.BuyTicket(3, 3); // Алексей летит в Нью-Йорк
    airportService.BuyTicket(4, 2); // Мария летит в Токио
}
