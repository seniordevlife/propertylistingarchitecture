using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyListing.ApplicationCore.Entities
{
    public class Amenity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(20)]
        public string AmenityType { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;

        public ICollection<PropertyAmenity>? PropertyAmenities { get; set; }
    }
}
