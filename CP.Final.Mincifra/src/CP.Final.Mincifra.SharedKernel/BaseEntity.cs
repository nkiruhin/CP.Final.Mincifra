using System;
using System.Collections.Generic;

namespace CP.Final.Mincifra.SharedKernel
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}