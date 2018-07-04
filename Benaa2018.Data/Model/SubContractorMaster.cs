using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benaa2018.Data.Model
{
    [Table("SubContractor_Master")]
    public class SubContractorMaster : BaseModel
    {
        [Key]
        public int SubContractor_ID { get; set; }
        public int Org_ID { get; set; }
        public string Name { get; set; }
        public string CR_NO { get; set; }
        public string Contact_Persion { get; set; }
        public string Beneficiary { get; set; }
        public string Mobile { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int Country_ID { get; set; }
        public string Address { get; set; }
        public decimal Catogery_ID { get; set; }
    }
}
