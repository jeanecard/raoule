using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public sealed class Observation
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Caption is a required field.")]
        public Oiseau? Oiseau { get; set;}
        public Guid OiseauId { get; set; }
        [Required(ErrorMessage = "Caption is a required field.")]
        public LieuObservation? Lieu { get; set;}
        public Guid LieuId { get; set; }
    }
}
