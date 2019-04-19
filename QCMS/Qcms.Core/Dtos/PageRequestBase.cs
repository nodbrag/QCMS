using System;
using System.Collections.Generic;
using System.Text;

namespace JIME.Model.DtoModel
{
    public class PageRequestBase<TFilter>
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
        public TFilter Filter;
    }
}
