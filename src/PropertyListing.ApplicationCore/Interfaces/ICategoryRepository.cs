using PropertyListing.ApplicationCore.DTOs;

namespace PropertyListing.ApplicationCore.Interfaces
{
    public interface ICategoryRepository
    {
        List<CategoryResponse> GetCategories();

        CategoryResponse GetCategoryById(Guid categoryId);

        void DeleteCategoryById(Guid categoryId);

        CategoryResponse CreateCategory(CreateCategoryRequest request);

        CategoryResponse UpdateCategory(Guid categoryId, UpdateCategoryRequest request);
    }
}
