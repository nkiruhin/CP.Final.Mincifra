using CP.Final.Mincifra.SharedKernel;
using System;
using System.Collections.Generic;

namespace CP.Final.Mincifra.Core.Entities
{
    public class Entity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<MetaData> MetaDatas { get; set; }
    }
}
