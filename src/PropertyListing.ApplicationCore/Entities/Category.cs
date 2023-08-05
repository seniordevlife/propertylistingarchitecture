using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyListing.ApplicationCore.Entities
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(15)]
        public string Name { get; set; } = string.Empty;

        public ICollection<PropertyCategory>? PropertyCategories { get; set; }
    }
}
