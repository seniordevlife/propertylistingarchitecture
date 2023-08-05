using Microsoft.AspNetCore.Mvc;
using PropertyListing.ApplicationCore.DTOs;
using PropertyListing.ApplicationCore.Exceptions;
using PropertyListing.ApplicationCore.Interfaces;

namespace PropertyListing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : Controller
    {
        private readonly IOwnerRepository ownerRepository;
        public OwnersController(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }

        [HttpGet("")]
        public ActionResult<List<OwnerResponse>> GetOwners([FromQuery] Guid ownerId, [FromQuery] string? ownerUid)
        {
            if (ownerUid != null && ownerId == new Guid())
            {
                try
                {
                    var owner = this.ownerRepository.GetOwnerByUid(ownerUid);
                    return Ok(owner);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }

            }
            else if (ownerId != new Guid() && ownerUid == null)
            {
                try
                {
                    var owner = this.ownerRepository.GetOwnerById(ownerId);
                    return Ok(owner);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }

            }
            else
            {
                return Ok(this.ownerRepository.GetOwners());
            }
            
        }

        [HttpPost]
        public ActionResult Create(CreateOwnerRequest request)
        {
            var owner = this.ownerRepository.CreateOwner(request);
            return Ok(owner);
        }

        [HttpPut("{id}")]
        public ActionResult Update(Guid id, UpdateOwnerRequest request)
        {
            try
            {
                var owner = this.ownerRepository.UpdateOwner(id, request);
                return Ok(owner);
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
                this.ownerRepository.DeleteOwnerById(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
