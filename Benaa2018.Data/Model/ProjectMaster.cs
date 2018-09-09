using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Model
{
    [Table("Project_Master")]
    public class ProjectMaster : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Project_ID { get; set; }
        public Int64 Org_ID { get; set; }
        public int User_ID { get; set; }
        public string Project_Type_ID { get; set; }
        public string Status_ID { get; set; }
        public string Project_Group_ID { get; set; }
        public string Project_Manager_id { get; set; }
        public string Project_Name { get; set; }
        public string Permit_No { get; set; }
        public float Project_land_Cost { get; set; }
        public float Built_Up_Area { get; set; }
        public int No_Of_Unit { get; set; }
        public string Group_No { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public decimal Country_ID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Lot_Info { get; set; }
        public Boolean Active { get; set; }
        public int Sequence { get; set; }
        public string Sub_Notes { get; set; }
        public string Internal_Notes { get; set; }
        public decimal Contract_Price { get; set; }
        public string Project_Prefix { get; set; }
    }
}
