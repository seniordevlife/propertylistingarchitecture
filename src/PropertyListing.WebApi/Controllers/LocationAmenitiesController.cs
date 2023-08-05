using Microsoft.AspNetCore.Mvc;
using PropertyListing.ApplicationCore.DTOs;
using PropertyListing.ApplicationCore.Exceptions;
using PropertyListing.ApplicationCore.Interfaces;

namespace PropertyListing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationAmenitiesController : Controller
    {
        private readonly ILocationAmenityRepository locationAmenityRepository;
        public LocationAmenitiesController(ILocationAmenityRepository locationAmenityRepository)
        {
            this.locationAmenityRepository = locationAmenityRepository;
        }

        [HttpGet("")]
        public ActionResult <List<LocationAmenityResponse>> GetLocationAmenities([FromQuery] Guid amenityId )
        {
            if (amenityId != new Guid())
            {
                try
                {
                    var locationAmenity = this.locationAmenityRepository.GetLocationAmenityById(amenityId);
                    return Ok(locationAmenity);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }
            else
            {
                return Ok(this.locationAmenityRepository.GetLocationAmenities());
            }
        }

        [HttpPost()]
        public ActionResult Create(CreateLocationAmenityRequest request)
        {
            var locationAmenity = this.locationAmenityRepository.CreateLocationAmenity(request);
            return Ok(locationAmenity);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, UpdateLocationAmenityRequest request)
        {
            try
            {
                var locationAmenity = this.locationAmenityRepository.UpdateLocationAmenity(id, request);
                return Ok(locationAmenity);
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
                this.locationAmenityRepository.DeleteLocationAmenityById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
