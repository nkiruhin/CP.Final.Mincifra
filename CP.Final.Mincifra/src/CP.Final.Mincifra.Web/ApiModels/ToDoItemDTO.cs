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
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<MetaData> MetaDatas { get; set; }

        public static EntityDTO FromEntity(Entity item)
        {
            return new EntityDTO()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                CreationDate = item.CreationDate,
                LastEditDate = item.LastEditDate,
                IsDeleted = item.IsDeleted,
                MetaDatas = item.MetaDatas,
                ClassName = item.ClassName
            };
        }

        public static IEnumerable<EntityDTO> GetDTOs(IEnumerable<Entity> entities)
        {
            var r = new List<EntityDTO>();

            foreach (var e in entities) r.Add(FromEntity(e));

            return r;
        }
    }
    public class LinkDTO
    {
        public Guid Id { get; set; }
        [Required]
        public Guid From { get; set; }
        public Guid To { get; set; }
        public LinkType Type { get; set; }

        public static LinkDTO FromLink(Link item)
        {
            return new LinkDTO()
            {
                Id = item.Id,
                From = item.FromEntityId,
                To = item.ToEntityId,
                Type = item.Type
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
        public List<LinkDTO> Links { get; set; }
        public List<EntityDTO> Nodes { get; set; }
    }
}
