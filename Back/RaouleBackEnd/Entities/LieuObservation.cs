using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public sealed class LieuObservation
    {
        public LieuObservation () 
        {
            TypePaysages = new List<TypePaysage> ();
            //var truc = new GeometryFactory();
            //Localisations = truc.CreateGeometryCollection();
            //Npgsql.EntityFrameworkCore.PostgreSQL.NetTopologySuite
        }
        [Column("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Caption is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Caption is 60 characters.")]
        public string? Caption { get; set; }

        public ICollection<TypePaysage> TypePaysages { get; set; }

        [Required(ErrorMessage = "localisations are mandatory")]
        public GeometryCollection? Localisations { get; set; }
    }
}
