using System;
using System.Collections.Generic;
using System.Text;

namespace Qcms.Core.Dtos
{
    public class OpPageResult<TData> :ExcePageResult<TData>
    {
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

    }
    public class OpPageResult : ExcePageResult<object>
    {
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

    }
}
