using System;
using System.Collections.Generic;
using System.Text;
using Qcms.Model.DataModel;
using Qcms.IRepository;
using System.Threading.Tasks;
using System.Linq;

namespace Qcms.Repository
{
    public class UserRepository: BaseRepository<User>,IUserRepository
    {
        public UserRepository(ModelBaseContext context):base(context)
        {

           
        }

        public async Task<User> GetRoleUser()
        {
          return   _context.User.Where(c => c.UserCode.Contains("Li")).FirstOrDefault();
        }
    }
}
