namespace Airport.Entities;


public enum FlightStatus 
{
    /// <summary>
    /// Рейс запланирован.
    /// </summary>
    Scheduled = 0,
    
    /// <summary>
    /// Идет посадка на рейс.
    /// </summary>
    Boarding = 1,
    
    /// <summary>
    /// Рейс в полете.
    /// </summary>
    InFlight = 2,
    
    /// <summary>
    /// Рейс прибыл.
    /// </summary>
    Landed = 3,
    
    /// <summary>
    /// Рейс отменен.
    /// </summary>
    Cancelled = 4
}
