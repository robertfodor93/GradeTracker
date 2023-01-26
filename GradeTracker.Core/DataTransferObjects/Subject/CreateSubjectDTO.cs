using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.Subject
{
    public class CreateSubjectDTO : BaseSubjectDTO
    {
        public BaseTeacherDTO? Teacher { get; set; }
        public int? CompetenceAreaId { get; set; }
        public int? UserId { get; set; }
    }
}
