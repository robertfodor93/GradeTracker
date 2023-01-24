using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public string? CreateBy { get; set; } = string.Empty;
        public bool? IsActive { get; set; } = true;
        public DateTime? ModifiedAt { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; } = string.Empty;

    }
}
