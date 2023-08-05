using Microsoft.AspNetCore.Mvc;
using PropertyListing.ApplicationCore.DTOs;
using PropertyListing.ApplicationCore.Exceptions;
using PropertyListing.ApplicationCore.Interfaces;

namespace PropertyListing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet("")]
        public ActionResult<List<CategoryResponse>> GetCategories([FromQuery] Guid categoryId)
        {
            if (categoryId != new Guid())
            {
                try
                {
                    var category = this.categoryRepository.GetCategoryById(categoryId);
                    return Ok(category);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }
            
            return Ok(this.categoryRepository.GetCategories());
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryRequest request)
        {
            var category = this.categoryRepository.CreateCategory(request);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, UpdateCategoryRequest request)
        {
            try
            {
                var category = this.categoryRepository.UpdateCategory(id, request);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                this.categoryRepository.DeleteCategoryById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
