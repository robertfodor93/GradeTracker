using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.Subject
{
    public class GetSubjectDTO : BaseSubjectDTO, IBaseDTO
    {
        public int Id { get; set; }
        public GetTeacherDTO Teacher { get; set; }
        public GetCompetenceAreaDTO CompetenceArea { get; set; }
        public List<GetGradeDTO> Grades { get; set; }
        public GetUserDTO User { get; set; }
    }
}
