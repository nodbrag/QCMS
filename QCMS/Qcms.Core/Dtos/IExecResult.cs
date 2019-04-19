using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Qcms.Core.Dtos
{
    /// <summary>
    /// 执行结果
    /// </summary>
    /// <typeparam name="TResultStatus">执行结果状态</typeparam>
    /// <typeparam name="TResultData">执行结果数据</typeparam>
    public interface IExecResult<TResultStatus, TResultData>
    {
        /// <summary>
        /// 执行状态
        /// </summary>
        TResultStatus Status { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string Message { get; set; }

        /// <summary>
        /// 执行结果数据
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        TResultData Result { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        bool Success { get; set; }
    }

    /// <summary>
    /// 执行结果
    /// </summary>
    /// <typeparam name="TResultStatus">执行结果状态</typeparam>
    /// <typeparam name="TResultData">执行结果数据</typeparam>
    public interface IExecResult<TResultData> : IExecResult<OpResultStatus, TResultData>
    {

    }

    public interface IExecResult : IExecResult<OpResultStatus, object>
    {

    }


}
