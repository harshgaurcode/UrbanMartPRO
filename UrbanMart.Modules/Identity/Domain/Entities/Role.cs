using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanMart.BuildingBlocks.Domain;

namespace UrbanMart.Modules.Identity.Domain.Entities
{
    public class Role : BaseEntity<Guid>
    {
        public string Name
        {
            get; set;
        }

        public bool IsActive
        {
            get; set;
        }

        public string Description { get; set; }
    }
}