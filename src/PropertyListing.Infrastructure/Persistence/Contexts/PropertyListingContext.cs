using Microsoft.EntityFrameworkCore;
using PropertyListing.ApplicationCore.Entities;

namespace PropertyListing.Infrastructure.Persistence.Contexts
{
    public class PropertyListingContext: DbContext
    {
        public PropertyListingContext(DbContextOptions<PropertyListingContext> options) : base(options)
        {}

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<LocationAmenity> LocationAmenities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PropertyAmenity> PropertyAmenities { get; set; }
        public DbSet<PropertyLocationAmenity> PropertyLocationAmenities { get; set; }
        public DbSet<PropertyCategory> PropertyCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyCategory>()
                .HasKey(propertyCat => new { propertyCat.PropertyId, propertyCat.CategoryId });
            modelBuilder.Entity<PropertyCategory>()
                .HasOne(property => property.Property)
                .WithMany(propertyCat => propertyCat.PropertyCategories)
                .HasForeignKey(property => property.PropertyId);
            modelBuilder.Entity<PropertyCategory>()
                .HasOne(property => property.Category)
                .WithMany(propertyCat => propertyCat.PropertyCategories)
                .HasForeignKey(property => property.CategoryId);

            modelBuilder.Entity<PropertyAmenity>()
                .HasKey(propertyAm => new { propertyAm.PropertyId, propertyAm.AmenityId });
            modelBuilder.Entity<PropertyAmenity>()
                .HasOne(property => property.Property)
                .WithMany(propertyAm => propertyAm.PropertyAmenities)
                .HasForeignKey(property => property.PropertyId);
            modelBuilder.Entity<PropertyAmenity>()
                .HasOne(property => property.Amenity)
                .WithMany(propertyAm => propertyAm.PropertyAmenities)
                .HasForeignKey(property => property.AmenityId);

            modelBuilder.Entity<PropertyLocationAmenity>()
                .HasKey(propertyLocAm => new { propertyLocAm.PropertyId, propertyLocAm.LocationAmenityId });
            modelBuilder.Entity<PropertyLocationAmenity>()
                .HasOne(property => property.Property)
                .WithMany(propertyLocAm => propertyLocAm.PropertyLocationAmenities)
                .HasForeignKey(property => property.PropertyId);
            modelBuilder.Entity<PropertyLocationAmenity>()
                .HasOne(property => property.LocationAmenity)
                .WithMany(propertyLocAm => propertyLocAm.PropertyLocationAmenities)
                .HasForeignKey(property => property.LocationAmenityId);
        }


    }
}
