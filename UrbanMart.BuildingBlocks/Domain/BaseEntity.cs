using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanMart.BuildingBlocks.Domain
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }
    }

    public class BaseEntityWithDelete<TKey> : BaseEntity<TKey>
    {
        public bool IsDeleted { get; set; }
    }
}