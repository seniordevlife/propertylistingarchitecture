using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyListing.ApplicationCore.Entities
{
    public class LocationAmenity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(20)]
        public string AmenityType { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        public double? Lat { get; set; }

        public double? Lng { get; set; }

        public ICollection<PropertyAmenity>? PropertyAmenities { get; set; }

        public ICollection<PropertyLocationAmenity>? PropertyLocationAmenities { get; set; }
    }

}
