namespace Shared.RequestFeatures
{
    public sealed class OiseauParameters : RequestParameters
    {
        private readonly string _NOM_FIELD = "Nom";
        public OiseauParameters() 
        {
            OrderBy = _NOM_FIELD;
        }

        public string NomVernaculaireLike { get; init; } = String.Empty;
        public string NomLike { get; init; } = String.Empty;

    }
}
