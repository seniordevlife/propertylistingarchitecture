using PropertyListing.ApplicationCore.DTOs;

namespace PropertyListing.ApplicationCore.Interfaces
{
    public interface IOwnerRepository
    {
        List<OwnerResponse> GetOwners();

        OwnerResponse GetOwnerById(Guid ownerId);

        OwnerResponse GetOwnerByUid(string ownerUid);

        void DeleteOwnerById(Guid ownerId);

        OwnerResponse CreateOwner(CreateOwnerRequest request);

        OwnerResponse UpdateOwner(Guid ownerId, UpdateOwnerRequest request);
    }
}
