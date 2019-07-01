using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySales.Models.ViewModel
{
    public class VMOrder
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
       
        public int CustomerId { get; set; }
        public int BrandID { get; set; }
        public int workOrderNo { get; set; }
        public int CriteriaID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string Place { get; set; }
        public string Heading { get; set; }
        public int ActivityId { get; set; }
        public int StateID { get; set; }
        public int UserId { get; set; }
        public int Wotype { get; set; }
        public string advance { get; set; }
        public string billsubmission { get; set; }
        public string warrenty { get; set; }
        public string cancel { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        public virtual Criteria Criteria { get; set; }
        public virtual tblBrand tblBrand { get; set; }
        public virtual tblCustomer tblCustomer { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }

    
}