using Microsoft.AspNetCore.Mvc;
using PropertyListing.ApplicationCore.DTOs;
using PropertyListing.ApplicationCore.Exceptions;
using PropertyListing.ApplicationCore.Interfaces;

namespace PropertyListing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : Controller
    {
        private readonly IAmenityRepository amenityRepository;
        public AmenitiesController(IAmenityRepository amenityRepository)
        {
            this.amenityRepository = amenityRepository;
        }

        [HttpGet("")]
        public ActionResult <List<AmenityResponse>> GetAmenities([FromQuery] Guid amenityId)
        {
            if (amenityId != new Guid())
            {
                try
                {
                    var amenity = this.amenityRepository.GetAmenityById(amenityId);
                    return Ok(amenity);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }
            else
            {
                return Ok(this.amenityRepository.GetAmenities());
            }
        }

        [HttpPost()]
        public ActionResult Create(CreateAmenityRequest request)
        {
            var amenity = this.amenityRepository.CreateAmenity(request);
            return Ok(amenity);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, UpdateAmenityRequest request)
        {
            try
            {
                var amenity = this.amenityRepository.UpdateAmenity(id, request);
                return Ok(amenity);
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
                this.amenityRepository.DeleteAmenityById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
