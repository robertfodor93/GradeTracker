using GradeTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> Register(UserDTO userDTO);
        Task<AuthResponseDTO> Login(LoginUserDTO loginUserDTO);
        Task<AuthResponseDTO> RefreshToken();
    }
}
