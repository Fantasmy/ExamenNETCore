using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vueling.Infrastructure.Model
{
    [Table("Policies")]
    public partial class Policy
    {
        public Guid Id { get; set; }
        public double AmountInsured { get; set; }
        public string Email { get; set; }
        public DateTime InceptionDate { get; set; }
        public bool InstallmentPayment { get; set; }
        public Guid ClientId { get; set; }

        public Client Client { get; set; }
    }
}
