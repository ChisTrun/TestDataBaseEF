using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Domain.Models
{
    public class Customer : DomainObject
    {
        public string Name { get; set; }

        public double MonneyForProtion { get; set; }

        public List<Coupon> Coupons { get; set; } = new List<Coupon>();
    }
}
