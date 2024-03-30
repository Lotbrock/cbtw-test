using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Responses
{
    public class ReceiptResponse
    {
        public string FullName { get; set; }

        public int DocumentNumber { get; set; }
        public int PhoneNumber { get; set; }
        public int ProductsAmount { get; set; }
        public double Total { get; set; }

    }
}
