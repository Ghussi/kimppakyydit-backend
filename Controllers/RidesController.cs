using Kimppakyydit.Api.Data;
using Kimppakyydit.Api.DTOs;
using Kimppakyydit.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kimppakyydit.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RidesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public RidesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_db.Rides.OrderByDescending(r => r.CreatedAt).ToList());
        }

        [HttpPost]
public async Task<IActionResult> Create([FromBody] CreateRideDto dto)
{
    var ride = new Ride
    {
        FromCity = dto.FromCity.Trim(),
        ToCity = dto.ToCity.Trim(),
        DepartureTime = dto.Departure,   // IMPORTANT
        Seats = dto.Seats,
        Price = dto.Price ?? 0,
        CreatedAt = DateTime.UtcNow
    };

    _db.Rides.Add(ride);
    await _db.SaveChangesAsync();

    return Ok(ride);
}


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ride = await _db.Rides.FindAsync(id);
            if (ride == null) return NotFound();

            _db.Rides.Remove(ride);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
