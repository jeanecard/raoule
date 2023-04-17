namespace Shared.Dto
{
    public record OiseauDto
    {
        public Guid Id { get; init; }
        public string Nom { get; init; } = string.Empty;
        public string NomVernaculaire { get; init; } = string.Empty;
    }
}