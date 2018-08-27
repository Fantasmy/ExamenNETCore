using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vueling.Infrastructure.Model
{
    [Table("Clients")]
    public partial class Client
    {
        public Client()
        {
            Policies = new HashSet<Policy>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public ICollection<Policy> Policies { get; set; }
    }
}
