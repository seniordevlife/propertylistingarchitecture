namespace PropertyListing.BlazorServer.Data
{
    public class Property
    {
        public Guid Id { get; set; }
        public string PropertyName { get; set; } = string.Empty;
        public string NearestTown { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Rooms { get; set; }
        public int Bedrooms { get; set; }
        public int TotalBathrooms { get; set; }
        public int EnsuiteBathrooms { get; set; }
        public bool IsOpenKitchen { get; set; }
        public bool IsFurnished { get; set; }
        public int YearBuilt { get; set; }
        public bool ForRent { get; set; }
        public double Rent { get; set; }
        public double SaleValue { get; set; }
    }
}
