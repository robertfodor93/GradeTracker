using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.EducationTypeGoal
{
    public class CreateEducationTypeGoalDTO : BaseEducationTypeGoalDTO
    {
        public int EducationTypeId { get; set; }
        public int UserId { get; set; }
    }
}
