using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTracker.Infrastructure.Repositories
{
    public class AuthRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private User _user;

        public AuthRepository(IMapper mapper, UserManager<User> userManager)
        {
            this._mapper = mapper;
            this._userManager = userManager;
        }
    }

}
