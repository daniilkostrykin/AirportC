namespace Airport.Dto;
/// <summary>
/// Результат отчета по выручке рейса (вместо кортежа).
/// </summary>
public class FlightStatResult {
    /// <summary>
    /// Пункт назначения рейса.
    /// </summary>
    public string Destination { get; set; } = "";

    /// <summary>
    /// Количество проданных билетов на рейс.
    /// </summary>
    public int TicketsSold { get; set; }

    /// <summary>
    /// Общая выручка от продажи билетов на рейс.
    /// </summary>
    public decimal TotalRevenue { get; set; }
}
