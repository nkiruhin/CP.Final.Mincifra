using CP.Final.Mincifra.SharedKernel;
using System;

namespace CP.Final.Mincifra.Core.Entities
{
    public class MetaData : BaseEntity
    {
        public Guid EntityId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
