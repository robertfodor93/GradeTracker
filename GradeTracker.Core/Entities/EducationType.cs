using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.Entities
{
    public class EducationType : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public double? Calculation { get; set; }
        public virtual IList<CompetenceArea> CompetenceAreas { get; set; }
        public virtual IList<EducationTypeGoal> EducationTypeGoals { get; set; }
    }
}
