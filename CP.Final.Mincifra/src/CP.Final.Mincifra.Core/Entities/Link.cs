using CP.Final.Mincifra.SharedKernel;
using System;

namespace CP.Final.Mincifra.Core.Entities
{
    public class Link : BaseEntity
    {
        public Guid FromEntityId { get; set; }
        public Guid ToEntityId { get; set; }
        public LinkType Type { get; set; }
    }
}
