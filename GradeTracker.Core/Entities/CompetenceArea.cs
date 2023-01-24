using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.Entities
{
    public class CompetenceArea : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public double? Weighting { get; set; }
        public virtual IReadOnlyList<Subject>? Subject { get; set; }
        [ForeignKey(nameof(EducationTypeId))]
        public int? EducationTypeId { get; set; }
        public virtual EducationType? EducationType { get; set; }
    }
}
