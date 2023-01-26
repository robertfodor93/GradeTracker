using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.EducationType
{
    public class UpdateEducationTypeDTO : BaseEducationTypeDTO, IBaseDTO
    {
        public int Id { get; set; }
    }
}
