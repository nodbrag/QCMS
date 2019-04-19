using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Qcms.Core.Dtos
{
    /// <summary>
    /// 执行结果
    /// </summary>
    /// <typeparam name="TResultStatus">执行结果状态</typeparam>
    /// <typeparam name="TResultData">执行结果数据的类型</typeparam>
    public abstract class ExecResult<TResultData> : IExecResult<TResultData>
    {

        public virtual OpResultStatus Status { get; set; }

        /// <summary>
        /// 结果附带数据
        /// </summary>
        public virtual TResultData Result { get; set; }

        /// <summary>
        /// 结果信息
        /// </summary>
        public virtual string Message { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public virtual bool Success { get; set; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        protected ExecResult()
            : this(default(OpResultStatus))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        protected ExecResult(OpResultStatus _type)
            : this(_type, null, default(TResultData))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        protected ExecResult(OpResultStatus _type, string _msg)
            : this(_type, _msg, default(TResultData))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        /// <param name="_data"></param>
        protected ExecResult(OpResultStatus _type, string _msg, TResultData _data)
        {
            Status = _type;
            Message = _msg;
            Result = _data;
        }

        
    }

    public abstract class ExecResult : IExecResult
    {

        public virtual OpResultStatus Status { get; set; }

        /// <summary>
        /// 结果附带数据
        /// </summary>
        public virtual object Result { get; set; }

        /// <summary>
        /// 结果信息
        /// </summary>
        public virtual string Message { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public virtual bool Success { get; set; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        protected ExecResult()
            : this(default(OpResultStatus))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        protected ExecResult(OpResultStatus _type)
            : this(_type, null, default(object))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        protected ExecResult(OpResultStatus _type, string _msg)
            : this(_type, _msg, default(object))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        /// <param name="_data"></param>
        protected ExecResult(OpResultStatus _type, string _msg, object _data)
        {
            Status = _type;
            Message = _msg;
            Result = _data;
        }
    }
    /// <summary>
    /// 执行结果
    /// </summary>
    /// <typeparam name="TResultStatus">执行结果状态</typeparam>
    /// <typeparam name="TResultData">执行结果数据的类型</typeparam>
    public abstract class ExecResult<TResultStatus, TResultData> : IExecResult<TResultStatus, TResultData>
    {

        public virtual TResultStatus Status { get; set; }

        /// <summary>
        /// 结果附带数据
        /// </summary>
        public virtual TResultData Result { get; set; }

        /// <summary>
        /// 结果信息
        /// </summary>
        public virtual string Message { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public virtual bool Success { get; set; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        protected ExecResult()
            : this(default(TResultStatus))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        protected ExecResult(TResultStatus _type)
            : this(_type, null, default(TResultData))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        protected ExecResult(TResultStatus _type, string _msg)
            : this(_type, _msg, default(TResultData))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        /// <param name="_data"></param>
        protected ExecResult(TResultStatus _type, string _msg, TResultData _data)
        {
            Status = _type;
            Message = _msg;
            Result = _data;
        }
    }
}
