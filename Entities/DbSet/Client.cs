using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.DbSet
{
    public class Client : BaseEntity
    {
        public Client() 
        {
            Receipts = new HashSet<Receipt>();    
        }

        public int DocumentNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }

        [JsonIgnore]
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
