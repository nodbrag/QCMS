using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using System.ComponentModel;

namespace Qcms.Core.Dtos
{
    public class OpPageResult<TData> :ExcePageResult<TData>
    {
        /// <summary>
        /// 是否操作成功
        /// </summary>
        public override bool Success { get { return Status == OpResultStatus.Success; } }
        /// <summary>
        /// 初始化一个<see cref="OpResult"/>类型的新实例
        /// </summary>
        public OpPageResult(IReadOnlyList<TData> data,int totalCount = 0)
            : this(OpResultStatus.Success, null, data,totalCount)
        { }
        /// <summary>
        /// 初始化一个<see cref="OpResult"/>类型的新实例
        /// </summary>
        public OpPageResult(OpResultStatus resultType)
            : this(resultType, null, new List<TData>())
        { }
        
        /// <summary>
        /// 初始化一个<see cref="OpResult"/>类型的新实例
        /// </summary>
        public OpPageResult(OpResultStatus resultType, string message)
            : this(resultType, message, new List<TData>())
        { }

        /// <summary>
        /// 初始化一个<see cref="OpResult"/>类型的新实例
        /// </summary>
        public OpPageResult(OpResultStatus resultType, string message, IReadOnlyList<TData> data,int totalCount=0)
            : base(resultType, message, new PageResult<TData>(data, totalCount) )
        { }
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
    public class OpPageResult : ExcePageResult<object>
    {
        /// <summary>
        /// 是否操作成功
        /// </summary>
        public override bool Success { get { return Status == OpResultStatus.Success; } }
        /// <summary>
        /// 初始化一个<see cref="OpResult"/>类型的新实例
        /// </summary>
        public OpPageResult(IReadOnlyList<object> data, int totalCount=0)
            : this(OpResultStatus.Success, null, data,totalCount)
        { }
        
        /// <summary>
        /// 初始化一个<see cref="OpResult"/>类型的新实例
        /// </summary>
        public OpPageResult(OpResultStatus resultType)
            : this(resultType, null, new List<object>())
        { }

        /// <summary>
        /// 初始化一个<see cref="OpResult"/>类型的新实例
        /// </summary>
        public OpPageResult(OpResultStatus resultType, string message)
            : this(resultType, message, new List<object>())
        { }

        /// <summary>
        /// 初始化一个<see cref="OpResult"/>类型的新实例
        /// </summary>
        public OpPageResult(OpResultStatus resultType, string message, IReadOnlyList<object> data, int totalCount=0)
            : base(resultType, message, new PageResult<object>(data, totalCount))
        { }
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
