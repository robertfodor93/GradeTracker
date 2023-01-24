using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.Entities
{
    public class Grade : BaseEntity
    {
        public double? Mark { get; set; }
        public string? Description { get; set; } = string.Empty;
        public double? Weighting { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        [ForeignKey(nameof(SubjectId))]
        public int SubjectId { get; set; }
        public virtual Subject? Suject { get; set; }
    }
}
