using System;
using System.Collections.Generic;
using System.Text;
using Qcms.Model;
using Qcms.IRepository;
using Qcms.IService;
using System.Threading.Tasks;
using Qcms.Model.DataModel;
using Microsoft.EntityFrameworkCore.Storage;

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
            string message = string.Empty;
            using (IDbContextTransaction transaction = _userRepository.context.Database.BeginTransaction())
            {
                try
                {
                    User user = new User();
                    user.UserId = 0;
                    user.UserCode = "testxxx333";
                    user.UserName = "testname333";
                    user.Telephone = "13774362545";
                    user.MobilePhone = "0210000000";
                    user.Email = "sfdsf@qq.com";
                    user.Description = "s";
                    user.IsUsed = true;
                    user.Password = "123455";
                    _userRepository.Insert(user);
                    // 第一个SaveChanges()方法后抛出异常
                    throw new Exception();
                    transaction.Commit();
                }

                catch (Exception ex)
                {
                    transaction.Rollback();
                    //Console.WriteLine("Error occurred.");
                }
            }
            return  _userRepository.GetRoleUser();
        }
    }
}
