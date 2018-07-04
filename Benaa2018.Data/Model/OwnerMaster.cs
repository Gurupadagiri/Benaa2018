using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benaa2018.Data.Model
{
    [Table("Owner_Master")]
    public class OwnerMaster : BaseModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Owner_ID { get; set; }
        public int Org_ID { get; set; }
        public int Project_ID { get; set; }
        public string Owner_Name { get; set; }
        public string Profile_Picture { get; set; }
        public string Mobile_No { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Zip { get; set; }
        public string OwnerInformation { get; set; }
        public string OwnerActivation { get; set; }
        public string AccessMethod { get; set; }
        public string OwnerCalendar { get; set; }
        public bool ShowProjectPrice { get; set; }
        public bool ShowBudgetPurchaseOrders { get; set; }
        public bool AllowOrderRequests { get; set; }
        public bool AllowLockedSelections { get; set; }
        public bool AllowWarrantyClaims { get; set; }
        public bool AllowPaymentsTab { get; set; }
    }
}
