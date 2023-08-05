using AutoMapper;
using PropertyListing.ApplicationCore.DTOs;
using PropertyListing.ApplicationCore.Entities;
using PropertyListing.ApplicationCore.Exceptions;
using PropertyListing.ApplicationCore.Interfaces;
using PropertyListing.Infrastructure.Persistence.Contexts;

namespace PropertyListing.Infrastructure.Persistence.Repositories
{
    public class LocationAmenityRepository : ILocationAmenityRepository
    {
        private readonly PropertyListingContext listingContext;
        private readonly IMapper mapper;

        public LocationAmenityRepository(PropertyListingContext listingContext, IMapper mapper)
        {
            this.listingContext = listingContext;
            this.mapper = mapper;
        }

        public LocationAmenityResponse CreateLocationAmenity(CreateLocationAmenityRequest request)
        {
            var locationAmenity = this.mapper.Map<LocationAmenity>(request);
            locationAmenity.AmenityType = request.AmenityType;
            locationAmenity.Name = request.Name;
            locationAmenity.Lat = request.Lat;
            locationAmenity.Lng = request.Lng;

            this.listingContext.LocationAmenities.Add(locationAmenity);
            this.listingContext.SaveChanges();

            return this.mapper.Map<LocationAmenityResponse>(locationAmenity);
        }

        public void DeleteLocationAmenityById(Guid locationAmenityId)
        {
            var locationAmenity = listingContext.LocationAmenities.Find(locationAmenityId);
            if (locationAmenity != null)
            {
                this.listingContext.LocationAmenities.Remove(locationAmenity);
                this.listingContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public List<LocationAmenityResponse> GetLocationAmenities()
        {
            return this.listingContext.LocationAmenities.Select(a => this.mapper.Map<LocationAmenityResponse>(a)).ToList();
        }

        public LocationAmenityResponse GetLocationAmenityById(Guid locationAmenityId)
        {
            var locationAmenity = listingContext.LocationAmenities.Find(locationAmenityId);
            if (locationAmenity != null)
            {
                return this.mapper.Map<LocationAmenityResponse>(locationAmenity);
            }
            throw new NotFoundException();
        }

        public LocationAmenityResponse UpdateLocationAmenity(Guid locationAmenityId, UpdateLocationAmenityRequest request)
        {
            var locationAmenity = listingContext.LocationAmenities.Find(locationAmenityId);
            if (locationAmenity != null)
            {
                locationAmenity.AmenityType = request.AmenityType;
                locationAmenity.Name = request.Name;
                locationAmenity.Lat = request.Lat;
                locationAmenity.Lng = request.Lng;

                this.listingContext.LocationAmenities.Update(locationAmenity);
                this.listingContext.SaveChanges();

                return this.mapper.Map<LocationAmenityResponse>(locationAmenity);
            }

            throw new NotFoundException();
        }
    }
}
