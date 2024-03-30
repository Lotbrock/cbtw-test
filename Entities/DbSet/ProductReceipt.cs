using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DbSet
{
    public class ProductReceipt : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid ReceiptId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Receipt Receipt { get; set; }
    }
}
