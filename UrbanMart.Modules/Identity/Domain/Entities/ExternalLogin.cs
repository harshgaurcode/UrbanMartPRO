using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanMart.BuildingBlocks.Domain;

namespace UrbanMart.Modules.Identity.Domain.Entities
{
    public class ExternalLogin : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public string Provider { get; set; } = null!;

        public string ProviderKey { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}