using System.ComponentModel.DataAnnotations;

namespace PropertyListing.ApplicationCore.DTOs
{
    public class CreatePropertyRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string PropertyName { get; set; } = string.Empty;

        [Required]
        public string NearestTown { get; set; } = string.Empty;

        [StringLength(300, MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public double FloorArea { get; set; }

        [Required]
        public double LandArea { get; set; }

        [Required]
        public int Rooms { get; set; }

        [Required]
        public int Bedrooms { get; set; }

        [Required]
        public int TotalBathrooms { get; set; }

        [Required]
        public int Ensuite { get; set; }

        [Required]
        public bool IsOpenKitchen { get; set; }

        [Required]
        public bool IsFurnished { get; set; }

        public int YearBuilt { get; set; }

        [Required]
        public bool ForRent { get; set; }

        public double Rent { get; set; }

        public double SaleValue { get; set; }

        public bool IsFeatured { get; set; }
    }

    public class UpdatePropertyRequest : CreatePropertyRequest
    {

    }

    public class PropertyResponse
    {
        public Guid Id { get; set; }
        public string PropertyName { get; set; } = string.Empty;
        public string NearestTown { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double FloorArea { get; set; }
        public double LandArea { get; set; }
        public int Rooms { get; set; }
        public int Bedrooms { get; set; }
        public int TotalBathrooms { get; set; }
        public int Ensuite { get; set; }
        public bool IsOpenKitchen { get; set; }
        public bool IsFurnished { get; set; }
        public int YearBuilt { get; set; }
        public bool ForRent { get; set; }
        public double Rent { get; set; }
        public double SaleValue { get; set; }
        public bool IsFeatured { get; set; }
    }
}
