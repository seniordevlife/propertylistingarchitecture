using Microsoft.AspNetCore.Mvc;
using PropertyListing.ApplicationCore.DTOs;
using PropertyListing.ApplicationCore.Exceptions;
using PropertyListing.ApplicationCore.Interfaces;

namespace PropertyListing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : Controller
    {
        private readonly IImageRepository imageRepository;
        private readonly IPropertyRepository propertyRepository;
        public ImagesController(IImageRepository imageRepository, IPropertyRepository propertyRepository)
        {
            this.imageRepository = imageRepository;
            this.propertyRepository = propertyRepository;
        }

        [HttpGet("{imageId}")]
        public ActionResult GetImageById(Guid imageId)
        {
            try
            {
                var image = this.imageRepository.GetImageById(imageId);
                return Ok(image);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // Get images by property
        [HttpGet("properties/{propertyId}")]
        public ActionResult<List<ImageResponse>> GetImagesByProperty(Guid propertyId, [FromQuery] string? isCover = null )
        {
            if (isCover != null)
            {
                try
                {
                    var image = this.imageRepository.GetImageCoverByProperty(propertyId, isCover);
                    return Ok(image);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }

            }
            try
            {
                var images = this.imageRepository.GetImagesByProperty(propertyId);
                return Ok(images);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("{propertyId}")]
        public ActionResult Create(Guid propertyId, CreateImageRequest request)
        {
            try
            {
                var property = this.propertyRepository.GetPropertyById(propertyId);
                var image = this.imageRepository.CreateImage(propertyId, request);
                return Ok(image);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, UpdateImageRequest request)
        {
            try
            {
                var image = this.imageRepository.UpdateImage(id, request);
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
                this.imageRepository.DeleteImageById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
