using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.DataTransferObjects.Grade
{
    public class BaseGradeDTO
    {
        [Required]
        public double Mark { get; set; }
        public string Description { get; set; }
        public double Weighting { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int SubjectId { get; set; }
    }
}
