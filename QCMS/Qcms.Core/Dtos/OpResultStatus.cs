using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Qcms.Core.Dtos
{
    public enum OpResultStatus
    {
        /// <summary>
        /// 操作没有引发任何变化，提交取消。
        /// </summary>
        [Description("操作没有引发任何变化，提交取消!")]
        NoChanged = 0,

        /// <summary>
        /// 操作成功。
        /// </summary>
        [Description("操作成功!")]
        Success = 1,

        /// <summary>
        /// 操作引发错误。
        /// </summary>
        [Description("操作引发错误!")]
        Error = 2,

        
        /// <summary>
        /// 指定参数的数据不存在。
        /// </summary>
        [Description("数据不存在！")]
        NotExist = 3,

        /// <summary>
        /// 指定参数的数据不存在。
        /// </summary>
        [Description("数据已存在！")]
        Exist = 4,

        /// <summary>
        /// 输入信息验证失败。
        /// </summary>
        [Description("输入信息验证失败!")]
        ValidError = 5,

        /// <summary>
        /// 登录失效。
        /// </summary>
        [Description("登录失效!")]
        LoginInvalid = 6,

        /// <summary>
        /// 身份认证信息错误。
        /// </summary>
        [Description("身份认证信息错误!")]
        AuthInvalid = 7,

        /// <summary>
        /// 未登录。
        /// </summary>
        [Description("未登录!")]
        NotLoggedIn = 8,
       /// <summary>
       /// 新增错误
       /// </summary>
        [Description("新增失败!")]
        InsertError =9,
        /// <summary>
        /// 修改错误
        /// </summary>
        [Description("修改失败!")]
        UpdateError = 10,
        /// <summary>
        /// 删除失败
        /// </summary>
        [Description("删除失败!")]
        DeleteError = 11
    }
}
