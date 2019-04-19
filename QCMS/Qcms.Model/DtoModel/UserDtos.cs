using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qcms.Model.DtoModel
{
    public class UserDtos
    {
        public class UserDto
        {
            /// <summary>
            /// 用户编号
            /// </summary>
            public int UserId { get; set; }
            /// <summary>
            /// 用户号
            /// </summary>
            public string UserCode { get; set; }
            /// <summary>
            /// 用户名称
            /// </summary>
            public string UserName { get; set; }
            /// <summary>
            /// 电话号码
            /// </summary>
            public string Telephone { get; set; }
            /// <summary>
            /// 移动电话
            /// </summary>
            public string MobilePhone { get; set; }
            /// <summary>
            /// 电子邮件
            /// </summary>
            public string Email { get; set; }
            /// <summary>
            /// 是否使用
            /// </summary>
            public bool IsUsed { get; set; }
            /// <summary>
            /// 描述
            /// </summary>
            public string Description { get; set; }
        }
        public class UserFilterDto
        {
            /// <summary>
            /// 用户真姓名
            /// </summary>
            public string UserName { get; set; }
            /// <summary>
            /// 用户号
            /// </summary>
            public string UserCode { get; set; }
        }
    }
}
