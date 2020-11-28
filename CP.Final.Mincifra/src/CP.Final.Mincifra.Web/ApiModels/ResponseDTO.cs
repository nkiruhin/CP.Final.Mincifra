using System.Collections.Generic;

namespace CP.Final.Mincifra.Web.ApiModels
{
    public class ResponseDTO
    {
        public ResponseDTO(List<LinkDTO> relations, List<EntityDTO> tables)
        {
            Relations = relations;
            Tables = tables;
        }

        public List<LinkDTO> Relations { get; set; }
        public List<EntityDTO> Tables { get; set; }
    }
}
