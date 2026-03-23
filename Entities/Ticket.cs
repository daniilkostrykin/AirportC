namespace Airport.Entities;

public class Ticket {
    public Ticket(int id, int flightId, int passengerId, decimal pricePaid) {
        Id = id; 
        FlightId = flightId; 
        PassengerId = passengerId; 
        PricePaid = pricePaid; 
        PurchaseDate = DateTime.Now;
    }
    
    /// <summary>
    /// Уникальный идентификатор билета.
    /// </summary>
    public int Id { get; }
    
    /// <summary>
    /// Идентификатор рейса, на который приобретен билет.
    /// </summary>
    public int FlightId { get; }
    
    /// <summary>
    /// Идентификатор пассажира, которому принадлежит билет.
    /// </summary>
    public int PassengerId { get; }
    
    /// <summary>
    /// Цена, уплаченная за билет.
    /// </summary>
    public decimal PricePaid { get; }
    
    /// <summary>
    /// Дата и время покупки билета.
    /// </summary>
    public DateTime PurchaseDate { get; }
}
