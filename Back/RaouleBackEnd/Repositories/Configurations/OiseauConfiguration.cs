using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations
{
    public class OiseauConfiguration : IEntityTypeConfiguration<Oiseau>
    {
        private static readonly Guid _ID1 = Guid.Parse("3990c71a-5dff-4b11-8664-256e00646741");
        private static readonly Guid _ID2 = Guid.Parse("3990c71a-5dff-4b11-8664-256e00646742");
        private static readonly Guid _ID3 = Guid.Parse("3990c71a-5dff-4b11-8664-256e00646743");


        public void Configure(EntityTypeBuilder<Oiseau> builder)
        {
            var oiseaux = new List<Oiseau>()
            {
            new Oiseau()
            {
                Id = _ID1,
                Caption = "Turdus merula"
            },
            new Oiseau()
            {
                Id = _ID2,
                Caption = "Psitacus erithacus"
            },
            new Oiseau()
            {
                Id = _ID3,
                Caption = "Turdus philomelos"
            }
            };
            builder.HasData(oiseaux);
        }
    }
}
