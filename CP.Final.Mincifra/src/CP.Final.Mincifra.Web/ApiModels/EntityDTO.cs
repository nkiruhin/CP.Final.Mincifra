using CP.Final.Mincifra.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CP.Final.Mincifra.Web.ApiModels
{
    // Note: doesn't expose events or behavior

    public class EntityDTO
    {        
        public Guid Name { get; set; }
        public string Title { get; set; } 
        public string Api_description { get; set; }
        public List<MetadataDto> Fields { get; set; }

        public static EntityDTO FromEntity(Entity item)
        {
            var entity = new EntityDTO()
            {
                Name = item.Id,
                Title = item.Name,
                Api_description = item.Description,
                Fields = item.MetaDatas.Any() ? item.MetaDatas.Select((x, Index) => new MetadataDto
                {
                    Id = Index + 1,
                    Table_name = item.Id.ToString(),
                    Name = x.Id.ToString(),
                    Label = x.Key,
                    Type = x.Type
                }).ToList() : new List<MetadataDto>
                {
                    new MetadataDto
                    {
                        Id = 0,
                        Table_name = item.Id.ToString(),
                        Name = "id",
                        Label = string.Empty,
                        Type = "INTEGER"
                    }
                }
            };
            if(!entity.Fields.Any(x => x.Name == "id"))
            {
                entity.Fields.Add(
                    new MetadataDto
                    {
                        Id = 0,
                        Table_name = item.Id.ToString(),
                        Name = "id",
                        Label = string.Empty,
                        Type = "INTEGER"
                    });
            }
            return entity;
        }

        public static List<EntityDTO> GetDTOs(IEnumerable<Entity> entities)
        {
            var r = new List<EntityDTO>();

            foreach (var e in entities) r.Add(FromEntity(e));

            return r;
        }
    }
}
