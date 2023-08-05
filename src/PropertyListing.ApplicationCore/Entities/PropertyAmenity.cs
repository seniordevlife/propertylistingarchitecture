namespace PropertyListing.ApplicationCore.Entities
{
    public class PropertyAmenity
    {
        public Guid? PropertyId { get; set; }

        public Guid? AmenityId { get; set; }

        public Property? Property { get; set; }

        public Amenity? Amenity { get; set; }
    }
}
