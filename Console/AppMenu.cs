using Airport.Services;
using Airport.Entities;
namespace Airport.Console;
public class AppMenu {
    private readonly IAirportService _service;
    public AppMenu(IAirportService service) => _service = service;

    public void Run() {
        while (true) {
            System.Console.WriteLine("\n=== Меню Аэропорта ===");
            System.Console.WriteLine("1 - Показать запланированные рейсы");
            System.Console.WriteLine("2 - Купить билет");
            System.Console.WriteLine("3 - Отчет по выручке");
            System.Console.WriteLine("4 - Показать все рейсы");
            System.Console.WriteLine("5 - Показать рейсы в статусе 'Посадка'");
            System.Console.WriteLine("6 - Показать рейсы в статусе 'В полете'");
            System.Console.WriteLine("7 - Показать рейсы в статусе 'Прибыл'");
            System.Console.WriteLine("8 - Показать рейсы в статусе 'Отменен'");
            System.Console.WriteLine("9 - Показать топ самых прибыльных рейсов"); 
            System.Console.WriteLine("0 - Выход");
            System.Console.Write("Выберите действие: ");
            
            var input = System.Console.ReadLine();
            
            switch (input) {
                case "0":
                    System.Console.WriteLine("Работа программы завершена.");
                    return;
                case "1":
                    ShowScheduledFlights();
                    break;
                case "2":
                    BuyTicket();
                    break;
                case "3":
                    ShowRevenueReport();
                    break;
                case "4":
                    ShowAllFlights();
                    break;
                case "5":
                    ShowFlightsByStatus(FlightStatus.Boarding);
                    break;
                case "6":
                    ShowFlightsByStatus(FlightStatus.InFlight);
                    break;
                case "7":
                    ShowFlightsByStatus(FlightStatus.Landed);
                    break;
                case "8":
                    ShowFlightsByStatus(FlightStatus.Cancelled);
                    break;
                case "9":
                    ShowTopProfitableFlights();
                    break;
                default:
                    System.Console.WriteLine("Неверный выбор. Пожалуйста, введите число от 0 до 8.");
                    break;
            }
        }
    }

    private void ShowScheduledFlights() {
        System.Console.WriteLine("\n--- Запланированные рейсы ---");
        var flights = _service.GetFlightsByStatus(FlightStatus.Scheduled);
        if (flights.Any()) {
            foreach(var f in flights)
                System.Console.WriteLine($"#{f.Id} {f.Destination} {f.DepartureTime} (Статус: {f.Status})");
        } else {
            System.Console.WriteLine("Нет запланированных рейсов.");
        }
    }

    private void ShowAllFlights() {
        System.Console.WriteLine("\n--- Все рейсы ---");
        var flights = _service.GetAllFlights();
        if (flights.Any()) {
            foreach(var f in flights)
                System.Console.WriteLine($"#{f.Id} {f.Destination} {f.DepartureTime} (Статус: {f.Status})");
        } else {
            System.Console.WriteLine("Нет доступных рейсов.");
        }
    }

    private void ShowFlightsByStatus(FlightStatus status) {
        System.Console.WriteLine($"\n--- Рейсы со статусом '{status}' ---");
        var flights = _service.GetFlightsByStatus(status);
        if (flights.Any()) {
            foreach(var f in flights)
                System.Console.WriteLine($"#{f.Id} {f.Destination} {f.DepartureTime} (Статус: {f.Status})");
        } else {
            System.Console.WriteLine($"Нет рейсов со статусом '{status}'.");
        }
    }

    private void BuyTicket() {
        System.Console.Write("Введите ID рейса: ");
        if (int.TryParse(System.Console.ReadLine(), out int flightId)) {
            System.Console.Write("Введите ID пассажира: ");
            if (int.TryParse(System.Console.ReadLine(), out int passengerId)) {
                bool success = _service.BuyTicket(flightId, passengerId);
                if (success) {
                    System.Console.WriteLine("Билет успешно куплен!");
                } else {
                    System.Console.WriteLine("Ошибка при покупке билета. Возможно, нет свободных мест.");
                }
            } else {
                System.Console.WriteLine("Неверный ID пассажира.");
            }
        } else {
            System.Console.WriteLine("Неверный ID рейса.");
        }
    }

    private void ShowRevenueReport() {
        System.Console.WriteLine("\n--- Отчет по выручке ---");
        var report = _service.GetRevenueReport();
        if (report.Any()) {
            foreach(var r in report)
                System.Console.WriteLine($"{r.Destination}: {r.TicketsSold} билетов, {r.TotalRevenue:C} выручка");
        } else {
            System.Console.WriteLine("Нет данных для отчета.");
        }
    }
    private void ShowTopProfitableFlights()
    {
        System.Console.Write("Введите количество рейсов для топа (нажми Enter для топ-3): ");
        var input = System.Console.ReadLine();
        
        int count = int.TryParse(input, out int parsed) && parsed > 0 ? parsed : 3;
        
        var revenueReport = _service.GetRevenueReport();
        var topFlights = revenueReport.OrderByDescending(r => r.TotalRevenue).Take(count);

        System.Console.WriteLine($"\n--- ТОП-{count} ПРИБЫЛЬНЫХ РЕЙСОВ ---");
        foreach (var stat in topFlights)
        {
            System.Console.WriteLine($"Направление: {stat.Destination} | Продано: {stat.TicketsSold} | Выручка: {stat.TotalRevenue:C}");
        }
    }
}
