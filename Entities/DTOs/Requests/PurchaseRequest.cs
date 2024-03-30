using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Requests
{
    public  class PurchaseRequest
    {
        public Guid ClientId {  get; set; }
        public  List<ProductPurchaseRequest> Products { get; set; }
    }
    
    public class ProductPurchaseRequest
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }

}
