using CP.Final.Mincifra.Core.Entities;
using System;

namespace CP.Final.Mincifra.Web.ApiModels
{
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
}
