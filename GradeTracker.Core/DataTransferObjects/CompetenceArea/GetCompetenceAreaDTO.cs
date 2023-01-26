using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.CompetenceArea
{
    public class GetCompetenceAreaDTO : BaseCompetenceAreaDTO, IBaseDTO
    {
        public int Id { get; set; }
        public virtual List<GetSubjectDTO> Subjects { get; set; }
        public int EducationTypeId { get; set; }
        [JsonIgnore]
        public virtual GetEducationTypeDTO EducationType { get; set; }
    }
}
