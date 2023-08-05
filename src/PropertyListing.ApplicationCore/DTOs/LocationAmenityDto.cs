using System.ComponentModel.DataAnnotations;

namespace PropertyListing.ApplicationCore.DTOs
{
    public class CreateLocationAmenityRequest
    {
        [Required]
        public string AmenityType { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public double Lat { get; set; }

        [Required]
        public double Lng { get; set; }
    }

    public class UpdateLocationAmenityRequest : CreateLocationAmenityRequest
    {
    }

    public class LocationAmenityResponse
    {
        public Guid Id { get; set; }
        public string AmenityType { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
