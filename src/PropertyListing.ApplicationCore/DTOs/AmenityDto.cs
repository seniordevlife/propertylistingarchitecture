using System;
using System.ComponentModel.DataAnnotations;

namespace PropertyListing.ApplicationCore.DTOs
{
    public class CreateAmenityRequest
    {
        [Required]
        public string AmenityType { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateAmenityRequest : CreateAmenityRequest
    { 
    }

    public class AmenityResponse
    {
        public Guid Id { get; set; }
        public string AmenityType { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
