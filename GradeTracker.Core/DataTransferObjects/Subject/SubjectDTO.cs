using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.Subject
{
    public class SubjectDTO : BaseSubjectDTO, IBaseDTO
    {
        public int Id { get; set; }
        public List<BaseGradeDTO> Grades { get; set; }
        public BaseTeacherDTO Teacher { get; set; }
    }
}
