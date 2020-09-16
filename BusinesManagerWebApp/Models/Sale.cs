using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinesManagerWebApp.Models
{
    public class Sale
    {
        public Guid Id { get; set; }
        public string Buyer { get; set; }
        public List<Products> Catalog { get; set; }
        public DateTime SaleDate { get; set; }
        public double TotalPrice { get; set; }
        public bool Deleted { get; set; }
    }
}
