using System.ComponentModel.DataAnnotations.Schema;

namespace PropertyListing.ApplicationCore.Entities
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Path { get; set; } = string.Empty;

        public bool IsCover { get; set; }

        public Property? Property { get; set; }
    }
}
