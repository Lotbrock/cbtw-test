using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.DbSet
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Value { get; set; }
        [JsonIgnore]
        public virtual ICollection<ProductReceipt>? ProductReceipt { get; set; }
    }
}
