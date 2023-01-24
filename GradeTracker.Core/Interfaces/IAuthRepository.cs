using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<IEnumerable<IdentityError>> Register(User user);
        Task<AuthResponseDTO> Login(User user);
    }
}
