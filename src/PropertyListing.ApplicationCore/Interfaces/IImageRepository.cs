using PropertyListing.ApplicationCore.DTOs;

namespace PropertyListing.ApplicationCore.Interfaces
{
    public interface IImageRepository
    {
        ImageResponse GetImageById(Guid imageId);

        ImageResponse GetImageCoverByProperty(Guid propertyId, string isCover);

        List<ImageResponse> GetImagesByProperty(Guid propertyId);

        void DeleteImageById(Guid imageId);

        ImageResponse CreateImage(Guid propertyId, CreateImageRequest request);

        ImageResponse UpdateImage(Guid imageId, UpdateImageRequest request);
    }
}
