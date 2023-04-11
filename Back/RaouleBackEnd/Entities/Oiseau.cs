using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public sealed class Oiseau
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Caption is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Caption is 60 characters.")]
        public string? Caption { get; set; }
    }
}
