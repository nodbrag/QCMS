using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Qcms.Model.DataModel;
using Qcms.Model.DtoModel;
using Qcms.IService;
using Qcms.Core.Dtos;


namespace Qcms.Api.Controllers
{
    /// <summary>
    /// 用户模块接口
    /// </summary>
    public class UsersController: BaseController<UserDtos.UserDto,UserDtos.UserFilterDto,User>
    {
        public readonly IUserService _userAppService;
        public UsersController(IUserService userAppService) :base(userAppService)
        {
            _userAppService = userAppService;
        }
        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public  async Task<IExecResult> GetUserRole()
        {
            return new OkOpResult(await _userAppService.getUserRole());
        }


    }
}
