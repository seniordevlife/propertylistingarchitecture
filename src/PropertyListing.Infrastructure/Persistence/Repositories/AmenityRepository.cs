using AutoMapper;
using PropertyListing.ApplicationCore.DTOs;
using PropertyListing.ApplicationCore.Entities;
using PropertyListing.ApplicationCore.Exceptions;
using PropertyListing.ApplicationCore.Interfaces;
using PropertyListing.Infrastructure.Persistence.Contexts;

namespace PropertyListing.Infrastructure.Persistence.Repositories
{
    public class AmenityRepository : IAmenityRepository
    {
        private readonly PropertyListingContext listingContext;
        private readonly IMapper mapper;

        public AmenityRepository(PropertyListingContext listingContext, IMapper mapper)
        {
            this.listingContext = listingContext;
            this.mapper = mapper;
        }
            
        public AmenityResponse CreateAmenity(CreateAmenityRequest request)
        {
            var amenity = this.mapper.Map<Amenity>(request);
            amenity.AmenityType = request.AmenityType;
            amenity.Name = request.Name;

            this.listingContext.Amenities.Add(amenity);
            this.listingContext.SaveChanges();

            return this.mapper.Map<AmenityResponse>(amenity);
        }

        public void DeleteAmenityById(Guid amenityId)
        {
            var amenity = listingContext.Amenities.Find(amenityId);
            if (amenity != null)
            {
                this.listingContext.Amenities.Remove(amenity);
                this.listingContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public List<AmenityResponse> GetAmenities()
        {
            return this.listingContext.Amenities.Select(a => this.mapper.Map<AmenityResponse>(a)).ToList();
        }

        public AmenityResponse GetAmenityById(Guid amenityId)
        {
            var amenity = listingContext.Amenities.Find(amenityId);
            if (amenity != null)
            {
                return this.mapper.Map<AmenityResponse>(amenity);
            }
            throw new NotFoundException();
        }

        public AmenityResponse UpdateAmenity(Guid amenityId, UpdateAmenityRequest request)
        {
            var amenity = listingContext.Amenities.Find(amenityId);
            if (amenity != null)
            {
                amenity.AmenityType = request.AmenityType;
                amenity.Name = request.Name;

                this.listingContext.Amenities.Update(amenity);
                this.listingContext.SaveChanges();

                return this.mapper.Map<AmenityResponse>(amenity);
            }

            throw new NotFoundException();
        }
    }
}
