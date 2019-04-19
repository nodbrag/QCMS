using System;
using System.Collections.Generic;
using System.Text;
using Qcms.Model.DataModel;
using System.Threading.Tasks;


namespace Qcms.IRepository
{
    public interface IUserRepository: IRepository<User,Int32>
    {
        Task<User> GetRoleUser();
    }
}
