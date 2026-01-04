using System;
using System.ComponentModel.DataAnnotations;

namespace Kimppakyydit.Api.DTOs
{
    public class CreateRideDto
    {
        [Required]
        public string FromCity { get; set; } = "";

        [Required]
        public string ToCity { get; set; } = "";

        [Required]
        public DateTime Departure { get; set; }   // matches mobile/app JSON: "departure"

        [Range(1, 20)]
        public int Seats { get; set; }

        public decimal? Price { get; set; }
    }
}
