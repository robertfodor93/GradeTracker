using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.Entities
{
    public class EducationTypeGoal : BaseEntity
    {
        [Column(TypeName = "decimal(3,2)")]
        public double? AverageDesiredMark { get; set; }
        [ForeignKey(nameof(EducationTypeId))]
        public int? EducationTypeId { get; set; }
        public virtual EducationType? EducationType { get; set; }
        [ForeignKey(nameof(UserId))]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
