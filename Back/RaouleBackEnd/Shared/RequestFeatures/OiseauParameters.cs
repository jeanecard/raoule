namespace Shared.RequestFeatures
{
    public sealed class OiseauParameters : RequestParameters
    {
        private readonly string _NOM_FIELD = "Nom";
        public OiseauParameters() 
        {
            OrderBy = _NOM_FIELD;
        }

        public string? NomVernaculaireLike { get; set; }
        public string? NomLike { get; set; }

    }
}
