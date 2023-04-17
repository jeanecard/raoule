using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public sealed class Oiseau
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nom est un champ obligatoire.")]
        [MaxLength(60, ErrorMessage = "Longueur maximale pour le champ Nom : 60.")]
        public string? Nom { get; set; }
        public string? NomVernaculaire{ get; set; }


    }
}
