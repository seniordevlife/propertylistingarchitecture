using System.ComponentModel.DataAnnotations;

namespace PropertyListing.ApplicationCore.DTOs
{
    public class CreateImageRequest
    {
        [Required]
        public string Path { get; set; } = string.Empty;

        public bool IsCover { get; set; }
    }

    public class UpdateImageRequest : CreateImageRequest
    {       
    }

    public class ImageResponse
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = string.Empty;
        public bool IsCover { get; set; }
    }
}
