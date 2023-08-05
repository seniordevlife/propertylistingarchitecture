using PropertyListing.ApplicationCore.DTOs;

namespace PropertyListing.ApplicationCore.Interfaces
{
    public interface IAmenityRepository
    {
        List<AmenityResponse> GetAmenities();

        AmenityResponse GetAmenityById(Guid amenityId);

        void DeleteAmenityById(Guid amenityId);

        AmenityResponse CreateAmenity(CreateAmenityRequest request);

        AmenityResponse UpdateAmenity(Guid amenityId, UpdateAmenityRequest request);
    }
}
