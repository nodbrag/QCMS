using System;
using System.Collections.Generic;
using System.Text;
using Qcms.Model;
using Qcms.IRepository;
using Qcms.IService;
using System.Threading.Tasks;
using Qcms.Model.DataModel;

namespace Qcms.Service
{
    public class UserService:BaseService<User>,IUserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) :base(userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> getUserRole()
        {
          return  _userRepository.GetRoleUser();
        }
    }
}
