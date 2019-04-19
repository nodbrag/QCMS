using System;
using System.Collections.Generic;
using System.Text;

namespace Qcms.Core.Dtos
{
   
    /// <summary>
    /// 执行结果
    /// </summary>
    /// <typeparam name="TResultStatus">执行结果状态</typeparam>
    /// <typeparam name="TResultData">执行结果数据的类型</typeparam>
    public abstract class ExcePageResult<TResultData> : IExecPageResult<TResultData>
    {

        public virtual OpResultStatus Status { get; set; }

        /// <summary>
        /// 结果附带数据
        /// </summary>
        public virtual PageResult<TResultData> Result { get; set; }

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
        protected ExcePageResult()
            : this(default(OpResultStatus))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        protected ExcePageResult(OpResultStatus _type)
            : this(_type, null, default(PageResult<TResultData>))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        protected ExcePageResult(OpResultStatus _type, string _msg)
            : this(_type, _msg, default(PageResult<TResultData>))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        /// <param name="_data"></param>
        protected ExcePageResult(OpResultStatus _type, string _msg, PageResult<TResultData> _data)
        {
            Status = _type;
            Message = _msg;
            Result = _data;
        }
    }

    public abstract class ExcePageResult : IExecPageResult
    {

        public virtual OpResultStatus Status { get; set; }

        /// <summary>
        /// 结果附带数据
        /// </summary>
        public virtual PageResult<object> Result { get; set; }

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
        protected ExcePageResult()
            : this(default(OpResultStatus))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        protected ExcePageResult(OpResultStatus _type)
            : this(_type, null, default(PageResult<object>))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        protected ExcePageResult(OpResultStatus _type, string _msg)
            : this(_type, _msg, default(PageResult<object>))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        /// <param name="_data"></param>
        protected ExcePageResult(OpResultStatus _type, string _msg, PageResult<object> _data)
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
    public abstract class ExcePageResult<TResultStatus, TResultData> : IExecPageResult<TResultStatus, TResultData>
    {

        public virtual TResultStatus Status { get; set; }

        /// <summary>
        /// 结果附带数据
        /// </summary>
        public virtual PageResult<TResultData> Result { get; set; }

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
        protected ExcePageResult()
            : this(default(TResultStatus))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        protected ExcePageResult(TResultStatus _type)
            : this(_type, null, default(PageResult<TResultData>))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        protected ExcePageResult(TResultStatus _type, string _msg)
            : this(_type, _msg, default(PageResult<TResultData>))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_msg"></param>
        /// <param name="_data"></param>
        protected ExcePageResult(TResultStatus _type, string _msg, PageResult<TResultData> _data)
        {
            Status = _type;
            Message = _msg;
            Result = _data;
        }
    }
}
