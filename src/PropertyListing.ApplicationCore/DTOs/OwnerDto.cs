using System;
using System.ComponentModel.DataAnnotations;

namespace PropertyListing.ApplicationCore.DTOs
{
    public class CreateOwnerRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Userid { get; set; } = string.Empty;
    }

    public class UpdateOwnerRequest : CreateOwnerRequest
    {
    }

    public class OwnerResponse
    {
        public Guid Id { get; set; }
        public string Userid { get; set; } = string.Empty;
    }
}
