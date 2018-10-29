using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Benaa2018.Data.Model
{
    [Table("Project_Planing")]
    public class ProjectPlaning : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Project_Plan_ID { get; set; }
        public int Project_ID { get; set; }
        public int MainActivity_ID { get; set; }
        public int Org_ID { get; set; }
        public int Activity_ID { get; set; }
        public DateTime Plan_Start_Date { get; set; }
        public DateTime Plan_End_Date { get; set; }
        public string Description { get; set; }
        public float Duration { get; set; }
        public float Percentage_Complition { get; set; }
        public float Efforts { get; set; }

        //public string Tax_Value { get; set; }
        //public float Tax_Percentage { get; set; }
        //public float Tax_Unit { get; set; }
        //public float Tax_Cost { get; set; }
        //public float Total_Builder_Cost { get; set; }
        //public int Markup_ID { get; set; }
        //public float Markup_Value { get; set; }
        //public float Markup_Percentage { get; set; }
        //public float Total_Markup { get; set; }
        //public float steakholder_Price { get; set; }
        //public string Notes { get; set; }
        
        











        


    }
}
