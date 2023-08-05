using PropertyListing.ApplicationCore.DTOs;

namespace PropertyListing.ApplicationCore.Interfaces
{
    public interface ILocationAmenityRepository
    {
        List<LocationAmenityResponse> GetLocationAmenities();

        LocationAmenityResponse GetLocationAmenityById(Guid locationAmenityId);

        void DeleteLocationAmenityById(Guid locationAmenityId);

        LocationAmenityResponse CreateLocationAmenity(CreateLocationAmenityRequest request);

        LocationAmenityResponse UpdateLocationAmenity(Guid locationAmenityId, UpdateLocationAmenityRequest request);
    }
}
