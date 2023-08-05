using System;

namespace PropertyListing.ApplicationCore.Entities
{
    public class PropertyCategory
    {
        public Guid? PropertyId { get; set; }

        public Guid? CategoryId { get; set; }

        public Property? Property { get; set; }

        public Category? Category { get; set; }
    }
}
