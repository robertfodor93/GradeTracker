using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.Entities
{
    public class Teacher : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public virtual IReadOnlyList<Subject>? Subjects { get; set; }
    }
}
