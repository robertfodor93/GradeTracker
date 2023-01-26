using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.Subject
{
    public class UpdateSubjectDTO : IBaseDTO
    {
        public int Id { get; set; }
        public double? AverageDesiredMark { get; set; }
    }
}
