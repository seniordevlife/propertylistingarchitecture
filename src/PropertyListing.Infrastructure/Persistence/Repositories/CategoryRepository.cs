using AutoMapper;
using PropertyListing.ApplicationCore.DTOs;
using PropertyListing.ApplicationCore.Entities;
using PropertyListing.ApplicationCore.Exceptions;
using PropertyListing.ApplicationCore.Interfaces;
using PropertyListing.Infrastructure.Persistence.Contexts;

namespace PropertyListing.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PropertyListingContext listingContext;
        private readonly IMapper mapper;

        public CategoryRepository(PropertyListingContext listingContext, IMapper mapper)
        {
            this.listingContext = listingContext;
            this.mapper = mapper;
        }

        public CategoryResponse CreateCategory(CreateCategoryRequest request)
        {
            var category = this.mapper.Map<Category>(request);
            category.Name = request.Name;

            this.listingContext.Categories.Add(category);
            this.listingContext.SaveChanges();

            return this.mapper.Map<CategoryResponse>(category);
        }

        public void DeleteCategoryById(Guid categoryId)
        {
            var category = listingContext.Categories.Find(categoryId);
            if (category != null)
            {
                this.listingContext.Categories.Remove(category);
                this.listingContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public List<CategoryResponse> GetCategories()
        {
            return this.listingContext.Categories.Select(c => this.mapper.Map<CategoryResponse>(c)).ToList();
        }

        public CategoryResponse GetCategoryById(Guid categoryId)
        {
            var category = listingContext.Categories.Find(categoryId);
            if (category != null)
            {
                return this.mapper.Map<CategoryResponse>(category);
            }
            throw new NotFoundException();
        }

        public CategoryResponse UpdateCategory(Guid categoryId, UpdateCategoryRequest request)
        {
            var category = this.listingContext.Categories.Find(categoryId);
            if (category != null)
            {
                category.Name = request.Name;

                this.listingContext.Categories.Update(category);
                this.listingContext.SaveChanges();

                return this.mapper.Map<CategoryResponse>(category);
            }

            throw new NotFoundException();
        }
    }
}
