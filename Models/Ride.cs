namespace Kimppakyydit.Api.Models;

public class Ride
{
    public int Id { get; set; }
    public string FromCity { get; set; } = "";
    public decimal Price { get; set; }
    public string ToCity { get; set; } = "";
    public DateTime DepartureTime { get; set; }
    public int Seats { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
