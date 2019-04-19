using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Qcms.Core.Dtos
{
    /// <summary>
    /// 操作结果
    /// </summary>
    public class OpResult : ExecResult
    {
        /// <summary>
        /// 初始化一个<see cref="OpResult"/>类型的新实例
        /// </summary>
        public OpResult() { Status = OpResultStatus.NoChanged; }

        /// <summary>
        /// 初始化一个<see cref="OpResult"/>类型的新实例
        /// </summary>
        public OpResult(OpResultStatus resultType)
            : this(resultType, null, null)
        { }
        /// <summary>
        /// 初始化一个<see cref="OpResult{TData}"/>类型的新实例
        /// </summary>
        public OpResult(object data)
            : base(OpResultStatus.Success, null, data)
        { }
        /// <summary>
        /// 初始化一个<see cref="OpResult"/>类型的新实例
        /// </summary>
        public OpResult(OpResultStatus resultType, string message)
            : this(resultType, message, null)
        { }

        /// <summary>
        /// 初始化一个<see cref="OpResult"/>类型的新实例
        /// </summary>
        public OpResult(OpResultStatus resultType, string message, object data)
            : base(resultType, message, data)
        { }

        /// <summary>
        /// 是否操作成功
        /// </summary>
        public bool Success { get { return Status == OpResultStatus.Success; } }

        /// <summary>
        /// 返回消息字段
        /// </summary>
        private string _message;

        /// <summary>
        /// 返回消息属性
        /// </summary>
        public override string Message
        {
            get
            {
                if (string.IsNullOrEmpty(_message))
                {
                    Type type = Status.GetType();
                    MemberInfo member = type.GetMember(Status.ToString()).FirstOrDefault();
                    return member != null ? member.GetCustomAttribute<DescriptionAttribute>().Description : Status.ToString();
                }
                else
                {
                    return _message;
                }
            }
            set { _message = value; }
        }
    }

    /// <summary>
    /// 操作结果
    /// </summary>
    /// <typeparam name="TData">操作结果数据</typeparam>
    public class OpResult<TData> : ExecResult<TData>
    {
        /// <summary>
        /// 初始化一个<see cref="OpResult{TData}"/>类型的新实例
        /// </summary>
        public OpResult() { Status = OpResultStatus.NoChanged; }

        /// <summary>
        /// 初始化一个<see cref="OpResult{TData}"/>类型的新实例
        /// </summary>
        public OpResult(OpResultStatus resultType)
            : this(resultType, null, default(TData))
        { }

        /// <summary>
        /// 初始化一个<see cref="OpResult{TData}"/>类型的新实例
        /// </summary>
        public OpResult(OpResultStatus resultType, string message)
            : this(resultType, message, default(TData))
        { }
        /// <summary>
        /// 初始化一个<see cref="OpResult{TData}"/>类型的新实例
        /// </summary>
        public OpResult(TData data)
            : base(OpResultStatus.Success,null, data)
        { }

        /// <summary>
        /// 初始化一个<see cref="OpResult{TData}"/>类型的新实例
        /// </summary>
        public OpResult(OpResultStatus resultType, string message, TData data)
            : base(resultType, message, data)
        { }

        /// <summary>
        /// 是否操作成功
        /// </summary>
        public bool Success { get { return Status == OpResultStatus.Success; } }

        /// <summary>
        /// 返回消息字段
        /// </summary>
        private string _message;

        /// <summary>
        /// 返回消息属性
        /// </summary>
        public override string Message
        {
            get
            {
                if (string.IsNullOrEmpty(_message))
                {
                    Type type = Status.GetType();
                    MemberInfo member = type.GetMember(Status.ToString()).FirstOrDefault();
                    return member != null ? member.GetCustomAttribute<DescriptionAttribute>().Description : Status.ToString();
                }
                else
                {
                    return _message;
                }
            }
            set { _message = value; }
        }
    }
}
