using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benaa2018.Data.Model
{
    [Table("Calendar_Phase")]
    public class CalendarPhase : BaseModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PhaseId { get; set; }
        public int CompanyId { get; set; }
        public int ProjectId { get; set; }
        public string PhaseName { get; set; }
        public int DisplayOrder { get; set; }
    }
}
