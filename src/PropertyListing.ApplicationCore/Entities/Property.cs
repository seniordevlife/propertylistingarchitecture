using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyListing.ApplicationCore.Entities
{
    public class Property
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string PropertyName { get; set; } = string.Empty;

        public string NearestTown { get; set; } = string.Empty;

        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;

        public double? FloorArea { get; set; }

        public double? LandArea { get; set; }

        public int? Rooms { get; set; }

        public int? Bedrooms { get; set; }

        public int? TotalBathrooms { get; set; }

        public int? Ensuite { get; set; }

        public bool IsOpenKitchen { get; set; }

        public bool IsFurnished { get; set; }

        public int? YearBuilt { get; set; }

        public bool ForRent { get; set; }

        public double? Rent { get; set; }

        public double? SaleValue { get; set; }

        public bool IsFeatured { get; set; }

        public Owner? Owner { get; set; }

        public ICollection<Image>? Images { get; set; }

        public ICollection<PropertyAmenity>? PropertyAmenities { get; set; }

        public ICollection<PropertyLocationAmenity>? PropertyLocationAmenities { get; set; }

        public ICollection<PropertyCategory>? PropertyCategories { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
