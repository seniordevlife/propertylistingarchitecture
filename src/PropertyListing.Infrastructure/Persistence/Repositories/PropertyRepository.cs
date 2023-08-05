using AutoMapper;
using PropertyListing.ApplicationCore.DTOs;
using PropertyListing.ApplicationCore.Entities;
using PropertyListing.ApplicationCore.Exceptions;
using PropertyListing.ApplicationCore.Interfaces;
using PropertyListing.ApplicationCore.Utils;
using PropertyListing.Infrastructure.Persistence.Contexts;

namespace PropertyListing.Infrastructure.Persistence.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly PropertyListingContext listingContext;
        private readonly IMapper mapper;

        public PropertyRepository(PropertyListingContext listingContext, IMapper mapper)
        {
            this.listingContext = listingContext;
            this.mapper = mapper;
        }

        public PropertyResponse CreateProperty(Guid ownerId, CreatePropertyRequest propertyRequest, Guid[]? amenityIds, Guid[]? categoryIds)
        {
            var owner = this.listingContext.Owners.Find(ownerId);

            var property = this.mapper.Map<Property>(propertyRequest);
            property.PropertyName = propertyRequest.PropertyName;
            property.NearestTown = propertyRequest.NearestTown;
            property.Description = propertyRequest.Description;
            property.FloorArea = propertyRequest.FloorArea;
            property.LandArea = propertyRequest.LandArea;
            property.Rooms = propertyRequest.Rooms;
            property.Bedrooms = propertyRequest.Bedrooms;
            property.TotalBathrooms = propertyRequest.TotalBathrooms;
            property.Ensuite = propertyRequest.Ensuite;
            property.IsOpenKitchen = propertyRequest.IsOpenKitchen;
            property.IsFurnished = propertyRequest.IsFurnished;
            property.YearBuilt = propertyRequest.YearBuilt;
            property.ForRent = propertyRequest.ForRent;
            property.Rent = propertyRequest.Rent;
            property.SaleValue = propertyRequest.SaleValue;
            property.IsFeatured = propertyRequest.IsFeatured;
            property.Owner = owner;
            property.CreatedAt = property.UpdatedAt = DateUtil.GetCurrentDate();

            if (amenityIds != null)
            {
                foreach (Guid amenityId in amenityIds)
                {
                    Amenity? amenity = this.listingContext.Amenities.Find(amenityId);
                    PropertyAmenity propertyAmenity = new() { PropertyId = property.Id, AmenityId = amenity?.Id, Property = property, Amenity = amenity };

                    this.listingContext.PropertyAmenities.Add(propertyAmenity);
                }
            }

            if (categoryIds != null)
            {
                foreach (Guid categoryId in categoryIds)
                {
                    Category? category = this.listingContext.Categories.Find(categoryId);
                    PropertyCategory propertyCategory = new() { PropertyId = property.Id, CategoryId = category.Id, Property = property, Category = category };

                    this.listingContext.PropertyCategories.Add(propertyCategory);
                }
            }

            this.listingContext.Properties.Add(property);
            this.listingContext.SaveChanges();

            return this.mapper.Map<PropertyResponse>(property);
        }

        public PropertyResponse GetPropertyById(Guid propertyId)
        {
            var property = this.listingContext.Properties.Find(propertyId);
            if (property != null)
            {
                return this.mapper.Map<PropertyResponse>(property);
            }
            throw new NotFoundException();
        }

        public List<PropertyResponse> GetProperties()
        {
            return this.listingContext.Properties.Select(p => this.mapper.Map<PropertyResponse>(p)).ToList();
        }

        public List<PropertyResponse> GetPropertiesByOwner(Guid ownerId)
        {
            var properties = this.listingContext.Properties.Where(p => p.Owner.Id == ownerId).ToList();
            return properties.Select(p => this.mapper.Map<PropertyResponse>(p)).ToList();
        }

        public List<PropertyResponse> GetPropertiesByAmenity(Guid amenityId)
        {
            var properties = this.listingContext.PropertyAmenities.Where(pa => pa.AmenityId == amenityId).Select(a => a.Property).ToList();
            return properties.Select(p => this.mapper.Map<PropertyResponse>(p)).ToList();
        }

        public List<PropertyResponse> GetPropertiesByCategory(Guid categoryId)
        {
            var properties = this.listingContext.PropertyCategories.Where(pa => pa.CategoryId == categoryId).Select(a => a.Property).ToList();
            return properties.Select(p => this.mapper.Map<PropertyResponse>(p)).ToList();
        }

        public PropertyResponse UpdateProperty(Guid propertyId, UpdatePropertyRequest request, Guid[]? amenityIds, Guid[]? categoryIds)
        {
            var property = this.listingContext.Properties.Find(propertyId);

            if (property != null)
            {
                property.PropertyName = request.PropertyName;
                property.NearestTown = request.NearestTown;
                property.Description = request.Description;
                property.Description = request.Description;
                property.FloorArea = request.FloorArea;
                property.Rooms = request.Rooms;
                property.Bedrooms = request.Bedrooms;
                property.TotalBathrooms = request.TotalBathrooms;
                property.Ensuite = request.Ensuite;
                property.IsOpenKitchen = request.IsOpenKitchen;
                property.IsFurnished = request.IsFurnished;
                property.YearBuilt = request.YearBuilt;
                property.ForRent = request.ForRent;
                property.Rent = request.Rent;
                property.SaleValue = request.SaleValue;
                property.IsFeatured = request.IsFeatured;
                property.UpdatedAt = DateUtil.GetCurrentDate();

                if (amenityIds != null)
                {
                    foreach (Guid amenityId in amenityIds)
                    {
                        Amenity? amenity = this.listingContext.Amenities.Find(amenityId);
                        PropertyAmenity propertyAmenity = new() { PropertyId = property.Id, AmenityId = amenity?.Id, Property = property, Amenity = amenity };

                        if (this.listingContext.PropertyAmenities.Any(pa => pa.AmenityId == propertyAmenity.AmenityId && pa.PropertyId == propertyAmenity.PropertyId))
                        {
                            this.listingContext.Update(propertyAmenity);
                        }
                        else
                        {
                            this.listingContext.Add(propertyAmenity);
                        }
                    }
                }

                if (categoryIds != null)
                    
                {
                    foreach (Guid categoryId in categoryIds)
                    {
                        Category? category = this.listingContext.Categories.Find(categoryId);
                        PropertyCategory propertyCategory = new() { PropertyId = property.Id, CategoryId = category.Id, Property = property, Category = category };

                        if (this.listingContext.PropertyCategories.Any(pa => pa.CategoryId == propertyCategory.CategoryId && pa.PropertyId == propertyCategory.PropertyId))
                        {
                            this.listingContext.Update(propertyCategory);
                        }
                        else
                        {
                            this.listingContext.Add(propertyCategory);
                        }
                    }
                }

                this.listingContext.Properties.Update(property);
                this.listingContext.SaveChanges();

                return this.mapper.Map<PropertyResponse>(property);
            }

            throw new NotFoundException();
        }

        public void DeletePropertyById(Guid propertyId)
        {
            var property = listingContext.Properties.Find(propertyId);
            if (property != null)
            {
                this.listingContext.Properties.Remove(property);
                this.listingContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
