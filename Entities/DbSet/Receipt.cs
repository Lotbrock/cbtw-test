using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.DbSet
{
    public class Receipt : BaseEntity
    {
        public Guid ClientId { get; set; }
        public double Total { get; set; }

        [JsonIgnore]
        public virtual Client? Client { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProductReceipt>? ProductReceipt { get; set; }
    }
}
