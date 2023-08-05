using System.ComponentModel.DataAnnotations;

namespace PropertyListing.ApplicationCore.DTOs
{
    public class CreateCategoryRequest
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateCategoryRequest : CreateCategoryRequest
    { }

    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
