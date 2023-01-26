using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.Subject
{
    public class BaseSubjectDTO
    {
        public string? Name { get; set; }
        public double? AverageDesiredMark { get; set; }
    }
}
