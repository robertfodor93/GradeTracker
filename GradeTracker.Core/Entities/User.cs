using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.Entities
{
    public class User : IdentityUser
    {
        public virtual IList<EducationTypeGoal>? EducationTypeGoals { get; set; }
        public virtual IList<Subject>? Subjects { get; set; }
    }
}
