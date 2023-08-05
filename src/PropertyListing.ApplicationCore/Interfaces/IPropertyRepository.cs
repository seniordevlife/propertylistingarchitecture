using PropertyListing.ApplicationCore.DTOs;

namespace PropertyListing.ApplicationCore.Interfaces
{
    public interface IPropertyRepository
    {
        List<PropertyResponse> GetProperties();

        List<PropertyResponse> GetPropertiesByOwner(Guid ownerId);

        List<PropertyResponse> GetPropertiesByAmenity(Guid amenityId);

        List<PropertyResponse> GetPropertiesByCategory(Guid categoryId);

        PropertyResponse GetPropertyById(Guid propertyId);

        PropertyResponse CreateProperty(Guid ownerId, CreatePropertyRequest createPropertyRequest, Guid[]? amenityIds = null, Guid[]? categoryIds = null);

        PropertyResponse UpdateProperty(Guid propertyId, UpdatePropertyRequest updatePropertyRequest, Guid[]? amenityIds = null, Guid[]? categoryIds = null);

        void DeletePropertyById(Guid propertyId);
    }
}
