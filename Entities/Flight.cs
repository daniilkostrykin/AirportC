namespace Airport.Entities;


public class Flight {
    public Flight(int id, string destination, DateTime departureTime, decimal basePrice, int totalSeats) {
        Id = id; 
        Destination = destination; 
        DepartureTime = departureTime; 
        BasePrice = basePrice; 
        TotalSeats = totalSeats;
    }
    
    /// <summary>
    /// Уникальный идентификатор рейса.
    /// </summary>
    public int Id { get; }
    
    /// <summary>
    /// Пункт назначения рейса.
    /// </summary>
    public string Destination { get; set; } = "";
    
    /// <summary>
    /// Время отправления рейса.
    /// </summary>
    public DateTime DepartureTime { get; set; }
    
    /// <summary>
    /// Базовая цена билета на рейс.
    /// </summary>
    public decimal BasePrice { get; set; }
    
    /// <summary>
    /// Общее количество мест на рейсе.
    /// </summary>
    public int TotalSeats { get; set; }
    
    /// <summary>
    /// Статус рейса.
    /// </summary>
    public FlightStatus Status { get; set; } = FlightStatus.Scheduled;
}
