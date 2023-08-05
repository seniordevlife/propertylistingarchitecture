namespace PropertyListing.ApplicationCore.Entities
{
    public class PropertyLocationAmenity
    {
        public Guid? PropertyId { get; set; }

        public Guid? LocationAmenityId { get; set; }

        public Property? Property { get; set; }

        public LocationAmenity? LocationAmenity { get; set; }
    }
}
