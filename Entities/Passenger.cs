namespace Airport.Entities;


public class Passenger {
    public Passenger(int id, string name, string passport) { 
        Id = id; 
        Name = name; 
        Passport = passport; 
    }
    
    /// <summary>
    /// Уникальный идентификатор пассажира.
    /// </summary>
    public int Id { get; }
    
    /// <summary>
    /// Имя пассажира.
    /// </summary>
    public string Name { get; set; } = "";
    
    /// <summary>
    /// Номер паспорта пассажира.
    /// </summary>
    public string Passport { get; set; } = "";
}
