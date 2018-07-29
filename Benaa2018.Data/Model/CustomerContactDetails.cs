using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Benaa2018.Data.Model
{
    [Table("Customer_Contact_Details")]
    public class CustomerContactDetails
    {
        [Key]
        public int CustomerContactId { get; set; }
        public int CompanyId { get; set; }
        public string CustomerName { get; set; }
        public string StreetAddress { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public string CellEmail { get; set; }
        public string Name { get; set; }
    }
}
