using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.EducationTypeGoal
{
    public class GetEducationTypeGoalDTO : BaseEducationTypeGoalDTO, IBaseDTO
    {
        public int Id { get; set; }
        public int EducationTypeId { get; set; }
        public GetEducationTypeDTO EducationType { get; set; }
        public int UserId { get; set; }
        public GetUserDTO User { get; set; }
    }
}
