namespace PropertyListing.BlazorServer.Data
{
    public class PropertyListingService
    {
        private static List<Property> mockDb = new List<Property>()
        {
            new Property()
            {
                PropertyName= "5 Bedroom Villa",
                NearestTown = "Kisumu",
                Description = "A serene environment located on the shores of the lake",
                Rooms = 22,
                Bedrooms = 5,
                TotalBathrooms = 7,
                EnsuiteBathrooms = 5,
                IsOpenKitchen = true,
                IsFurnished = true,
                YearBuilt = 2017,
                ForRent = false,
                Rent = 0,
                SaleValue = 65000000
            }
        };

        public async Task<bool> AddPropertyAsync(Property property)
        {
            mockDb.Add(property);
            return true;
        }

        public async Task<List<Property>> GetProperties()
        {
            return mockDb;
        }
    }
}
