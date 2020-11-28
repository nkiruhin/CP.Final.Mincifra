using CP.Final.Mincifra.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CP.Final.Mincifra.Web.ApiModels
{
    // Note: doesn't expose events or behavior
    public class ToDoItemDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; private set; }

        public static ToDoItemDTO FromToDoItem(ToDoItem item)
        {
            return new ToDoItemDTO()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsDone = item.IsDone
            };
        }
    }

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

        public static IEnumerable<EntityDTO> GetDTOs(IEnumerable<Entity> entities)
        {
            var r = new List<EntityDTO>();

            foreach (var e in entities) r.Add(FromEntity(e));

            return r;
        }
    }
    public class MetadataDto
    {
        public long Id { get; set; }
        public string Table_name { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string Form_type { get; set; } = string.Empty;
        public string Type { get; set; }
        public bool Required { get; set; } = true;
        public int Primary { get; set; } = 1;
        public bool Is_foreign_key { get; set; } = false;
        public bool Auto_increment { get; set; } = false;
    }
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
    public class DataDTO
    {
        public Guid Id { get; set; }
        public Guid EntityId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }

        public static DataDTO FromData(MetaData item)
        {
            return new DataDTO()
            {
                Id = item.Id,
                EntityId = item.EntityId,
                Key = item.Key,
                Value = item.Value,
                Type = item.Type
            };
        }
    }
    public class ResponseDTO
    {
        public List<LinkDTO> Relations { get; set; }
        public List<EntityDTO> Tables { get; set; }
    }
}
