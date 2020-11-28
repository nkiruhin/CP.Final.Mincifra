using CP.Final.Mincifra.Core.Entities;

namespace CP.Final.Mincifra.Web.ApiModels
{
    public class LinkDTO
    {
        public string From_field { get; set; } = "id";
        public string From_model { get; set; }
        public string To_field { get; set; } = "id";
        public string To_model { get; set; }

        public static LinkDTO FromLink(Link item)
        {
            return new LinkDTO()
            {
                From_model = item.FromEntityId.ToString(),
                To_model = item.ToEntityId.ToString()
            };
        }
    }
}
