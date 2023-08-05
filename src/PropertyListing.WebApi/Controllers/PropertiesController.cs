using Microsoft.AspNetCore.Mvc;
using PropertyListing.ApplicationCore.DTOs;
using PropertyListing.ApplicationCore.Exceptions;
using PropertyListing.ApplicationCore.Interfaces;

namespace PropertyListing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : Controller
    {
        private readonly IPropertyRepository propertyRepository;
        private readonly IOwnerRepository ownerRepository;
        private readonly IAmenityRepository amenityRepository;
        private readonly ICategoryRepository categoryRepository;

        public PropertiesController(IPropertyRepository propertyRepository, IOwnerRepository ownerRepository, IAmenityRepository amenityRepository, ICategoryRepository categoryRepository)
        {
            this.propertyRepository = propertyRepository;
            this.ownerRepository = ownerRepository;
            this.amenityRepository = amenityRepository;
            this.categoryRepository = categoryRepository;
        }

        // GET PROPERTIES
        [HttpGet("")]
        public ActionResult<List<PropertyResponse>> GetProperties([FromQuery] Guid propertyId, [FromQuery] Guid ownerId, [FromQuery] Guid amenityId, [FromQuery] Guid categoryId)
        {
            if (propertyId != new Guid() && ownerId == new Guid() && amenityId == new Guid() && categoryId == new Guid())
            {
                try
                {
                    var property = this.propertyRepository.GetPropertyById(propertyId);
                    return Ok(property);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }
            else if (ownerId != new Guid() && amenityId == new Guid() && categoryId == new Guid())
            {
                try
                {
                    var owner = this.ownerRepository.GetOwnerById(ownerId);
                    return Ok(this.propertyRepository.GetPropertiesByOwner(ownerId));
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }
            else if (ownerId == new Guid() && amenityId != new Guid() && categoryId == new Guid())
            {
                return Ok(this.propertyRepository.GetPropertiesByAmenity(amenityId));
            }
            else if (ownerId == new Guid() && amenityId == new Guid() && categoryId != new Guid())
            {
                return Ok(this.propertyRepository.GetPropertiesByCategory(amenityId));
            }
            else
            {
                return Ok(this.propertyRepository.GetProperties());
            }

        }

        // CREATE PROPERTY
        [HttpPost("")]
        public ActionResult Create([FromQuery] Guid ownerId, CreatePropertyRequest request, [FromQuery] Guid[] amenityIds, [FromQuery] Guid[] categoryIds)
        {
            if (amenityIds.Length != 0 && categoryIds.Length == 0)
            {
                foreach (Guid amenityId in amenityIds)
                {
                    try
                    {
                        var amenity = this.amenityRepository.GetAmenityById(amenityId);
                    }
                    catch (NotFoundException)
                    {
                        return NotFound();
                    }
                }

                try
                {
                    var owner = this.ownerRepository.GetOwnerById(ownerId);
                    var property = this.propertyRepository.CreateProperty(ownerId, request, amenityIds);
                    return Ok(property);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }
            else if (categoryIds.Length != 0 && amenityIds.Length == 0)
            {
                foreach (Guid categoryId in categoryIds)
                {
                    try
                    {
                        var category = this.categoryRepository.GetCategoryById(categoryId);
                    }
                    catch (NotFoundException)
                    {
                        return NotFound();
                    }
                }

                try
                {
                    var owner = this.ownerRepository.GetOwnerById(ownerId);
                    var property = this.propertyRepository.CreateProperty(ownerId, request, categoryIds);
                    return Ok(property);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }
            else if (categoryIds.Length != 0 && amenityIds.Length != 0)
            {
                foreach (Guid categoryId in categoryIds)
                {
                    try
                    {
                        var category = this.categoryRepository.GetCategoryById(categoryId);
                    }
                    catch (NotFoundException)
                    {
                        return NotFound();
                    }
                }

                foreach (Guid amenityId in amenityIds)
                {
                    try
                    {
                        var amenity = this.amenityRepository.GetAmenityById(amenityId);
                    }
                    catch (NotFoundException)
                    {
                        return NotFound();
                    }
                }

                try
                {
                    var owner = this.ownerRepository.GetOwnerById(ownerId);
                    var property = this.propertyRepository.CreateProperty(ownerId, request, amenityIds, categoryIds);
                    return Ok(property);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }
            else
            {
                try
                {
                    var owner = this.ownerRepository.GetOwnerById(ownerId);
                    var property = this.propertyRepository.CreateProperty(ownerId, request);
                    return Ok(property);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }
        }


        [HttpPut("")]
        public ActionResult Update([FromQuery]Guid propertyId, UpdatePropertyRequest request,[FromQuery] Guid[]? amenityIds,[FromQuery] Guid[]? categoryIds)
        {
            if (amenityIds?.Length != 0 && categoryIds?.Length == 0)
                {
                foreach (Guid amenityId in amenityIds)
                {
                    try
                    {
                        var amenity = this.amenityRepository.GetAmenityById(amenityId);
                    }
                    catch (NotFoundException)
                    {
                        return NotFound();
                    }
                }

                try
                {
                    var property = this.propertyRepository.UpdateProperty(propertyId, request, amenityIds);
                    return Ok(property);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }

            }

            else if (categoryIds?.Length != 0 && amenityIds?.Length == 0)
            {
                foreach (Guid categoryId in categoryIds)
                {
                    try
                    {
                        var category = this.amenityRepository.GetAmenityById(categoryId);
                    }
                    catch (NotFoundException)
                    {
                        return NotFound();
                    }
                }

                try
                {
                    var property = this.propertyRepository.UpdateProperty(propertyId, request, categoryIds);
                    return Ok(property);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }

            else if (categoryIds.Length != 0 && amenityIds.Length != 0)
            {
                foreach (Guid categoryId in categoryIds)
                {
                    try
                    {
                        var category = this.amenityRepository.GetAmenityById(categoryId);
                    }
                    catch (NotFoundException)
                    {
                        return NotFound();
                    }
                }

                foreach (Guid amenityId in amenityIds)
                {
                    try
                    {
                        var amenity = this.amenityRepository.GetAmenityById(amenityId);
                    }
                    catch (NotFoundException)
                    {
                        return NotFound();
                    }
                }

                try
                {
                    var property = this.propertyRepository.UpdateProperty(propertyId, request, amenityIds, categoryIds);
                    return Ok(property);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }

            else
            {
                try
                {
                    var property = this.propertyRepository.UpdateProperty(propertyId, request);
                    return Ok(property);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }
        }

        [HttpDelete("{propertyId}")]
        public ActionResult Delete(Guid propertyId)
        {
            try
            {
                this.propertyRepository.DeletePropertyById(propertyId);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
