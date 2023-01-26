using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.EducationTypeGoal
{
    public class UpdateEducationTypeGoalDTO : BaseEducationTypeGoalDTO, IBaseDTO
    {
        public int Id { get; set; }
    }
}
