using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Domain.Models
{
    public class Order : DomainObject
    {
        public Customer Customer { get; set; }

        public DateTime OderDate { get; set; }
        public double TotalPrice { get; set; }
    }
}
