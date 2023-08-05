using AutoMapper;
using PropertyListing.ApplicationCore.DTOs;
using PropertyListing.ApplicationCore.Entities;
using PropertyListing.ApplicationCore.Exceptions;
using PropertyListing.ApplicationCore.Interfaces;
using PropertyListing.Infrastructure.Persistence.Contexts;

namespace PropertyListing.Infrastructure.Persistence.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly PropertyListingContext listingContext;
        private readonly IMapper mapper;

        public ImageRepository(PropertyListingContext listingContext, IMapper mapper)
        {
            this.listingContext = listingContext;
            this.mapper = mapper;
        }

        public ImageResponse CreateImage(Guid propertyId, CreateImageRequest request)
        {
            var property = this.listingContext.Properties.Find(propertyId);
            var image = this.mapper.Map<Image>(request);
            image.Path = request.Path;
            image.IsCover = request.IsCover;    
            image.Property = property;

            this.listingContext.Images.Add(image);
            this.listingContext.SaveChanges();

            return this.mapper.Map<ImageResponse>(image);
        }


        public ImageResponse GetImageById(Guid imageId)
        {
            var image = listingContext.Images.Find(imageId);
            if (image != null)
            {
                return this.mapper.Map<ImageResponse>(image);
            }
            throw new NotFoundException();
        }

        public ImageResponse GetImageCoverByProperty(Guid propertyId, string? isCover)
        {
            if (isCover != null && isCover == "true")
            {
                var image = this.listingContext.Images.FirstOrDefault(i => i.Property.Id == propertyId && i.IsCover == true);
                if (image != null)
                {
                    return this.mapper.Map<ImageResponse>(image);
                }
                throw new NotFoundException();
            }
            throw new NotFoundException();
        }

        public List<ImageResponse> GetImagesByProperty(Guid propertyId)
        {
            var images = this.listingContext.Images.Where(i => i.Property.Id == propertyId);
            return images.Select(i => this.mapper.Map<ImageResponse>(i)).ToList();
        }

        public ImageResponse UpdateImage(Guid imageId, UpdateImageRequest request)
        {
            var image = listingContext.Images.Find(imageId);
            if (image != null)
            {
                image.Path = request.Path;
                image.IsCover = request.IsCover;

                this.listingContext.Images.Update(image);
                this.listingContext.SaveChanges();

                return this.mapper.Map<ImageResponse>(image);
            }

            throw new NotFoundException();
        }

        public void DeleteImageById(Guid imageId)
        {
            var image = listingContext.Images.Find(imageId);
            if (image != null)
            {
                this.listingContext.Images.Remove(image);
                this.listingContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
