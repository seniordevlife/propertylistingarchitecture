using AutoMapper;
using PropertyListing.ApplicationCore.DTOs;
using PropertyListing.ApplicationCore.Entities;
using PropertyListing.ApplicationCore.Exceptions;
using PropertyListing.ApplicationCore.Interfaces;
using PropertyListing.ApplicationCore.Utils;
using PropertyListing.Infrastructure.Persistence.Contexts;

namespace PropertyListing.Infrastructure.Persistence.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PropertyListingContext listingContext;
        private readonly IMapper mapper;

        public OwnerRepository(PropertyListingContext listingContext, IMapper mapper)
        {
            this.listingContext = listingContext;
            this.mapper = mapper;
        }

        public OwnerResponse CreateOwner(CreateOwnerRequest request)
        {
            var owner = this.mapper.Map<Owner>(request);
            owner.Userid = request.Userid;
            owner.CreatedAt = owner.UpdatedAt = DateUtil.GetCurrentDate();

            this.listingContext.Owners.Add(owner);
            this.listingContext.SaveChanges();

            return this.mapper.Map<OwnerResponse>(owner);
        }

        public OwnerResponse GetOwnerById(Guid ownerId)
        {
            var owner = this.listingContext.Owners.Find(ownerId);
            if (owner != null)
            {
                return this.mapper.Map<OwnerResponse>(owner);
            }
            throw new NotFoundException();
        }

        public OwnerResponse GetOwnerByUid(string ownerUid)
        {
            var owner = this.listingContext.Owners.SingleOrDefault(x => x.Userid == ownerUid);
            if (owner != null)
            {
                return this.mapper.Map<OwnerResponse>(owner);
            }
            throw new NotFoundException();
        }

        public List<OwnerResponse> GetOwners()
        {
            return this.listingContext.Owners.Select(o => this.mapper.Map<OwnerResponse>(o)).ToList();
        }

        public OwnerResponse UpdateOwner(Guid ownerId, UpdateOwnerRequest request)
        {
            var owner = this.listingContext.Owners.Find(ownerId);
            if (owner != null)
            {
                owner.Userid = request.Userid;
                owner.UpdatedAt = DateUtil.GetCurrentDate();

                this.listingContext.Owners.Update(owner);
                this.listingContext.SaveChanges();

                return this.mapper.Map<OwnerResponse>(owner);
            }

            throw new NotFoundException();
        }

        public void DeleteOwnerById(Guid ownerId)
        {
            var owner = listingContext.Owners.Find(ownerId);
            if (owner != null)
            {
                this.listingContext.Owners.Remove(owner);
                this.listingContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
