using System;
using System.Collections.Generic;
using System.Text;
using Qcms.Model.DataModel;
using System.Threading.Tasks;

namespace Qcms.IService
{
    public interface IUserService : Qcms.IService.IService<User>
    {

        Task<User> getUserRole();
    }
}
