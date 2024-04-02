using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Responses
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    }
}
