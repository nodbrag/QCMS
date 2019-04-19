using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qcms.Core.Dtos
{
    public class FiterConditionBase<T>
    {
        /// <summary>
        /// 分页条件
        /// </summary>
        public int MaxResultCount { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        public int SkipCount { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string Sorting { get; set; }

        /// <summary>
        /// 过滤
        /// </summary>
        public T Filter;

         
    }
    
}
