using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public byte[] PasswordHash { get; set; } = new byte[32];
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
        public virtual IList<EducationTypeGoal>? EducationTypeGoals { get; set; }
        public virtual IList<Subject>? Subjects { get; set; }
    }
}
