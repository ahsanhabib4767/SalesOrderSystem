using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySales.Models
{
    public class Data
    {
        public System.Guid OrderId { get; set; }
        public int CustomerId { get; set; }
        public virtual tblBrand tblBrand { get; set; }
        public virtual tblCustomer tblCustomer { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}