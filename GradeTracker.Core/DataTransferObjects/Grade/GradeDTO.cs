using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.Grade
{
    public class GradeDTO : BaseGradeDTO, IBaseDTO
    {
        public int Id { get; set; }
        public BaseSubjectDTO Subject { get; set; }
    }
}
