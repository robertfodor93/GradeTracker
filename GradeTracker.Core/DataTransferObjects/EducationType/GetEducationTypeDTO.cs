using GradeTracker.Core.DataTransferObjects.CompetenceArea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.EducationType
{
    public class GetEducationTypeDTO : BaseEducationTypeDTO, IBaseDTO
    {
        public int Id { get; set; }
        public IList<GetCompetenceAreaDTO> CompetenceAreas { get; set; }
    }
}
