using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.Entities
{
    public class Subject : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public bool? ShowOnDashboard { get; set; } = false;
        public double? AverageDesiredMark { get; set; }
        public virtual IList<Grade>? Grades { get; set; }
        [ForeignKey(nameof(CompetenceAreaId))]
        public int? CompetenceAreaId { get; set; }
        public virtual CompetenceArea? CompetenceArea { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public int TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        [ForeignKey(nameof(UserId))]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
