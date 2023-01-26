using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.EducationType
{
    public class BaseEducationTypeDTO
    {
        public string Name { get; set; } = string.Empty;
        public double Calculation { get; set; }
    }
}
