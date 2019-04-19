using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qcms.Model.DtoModel
{
    public class WorkAreaDtos
    {
        public class WorkAreaDto
        {
            /// <summary>
            /// 区域主键号
            /// </summary>
            public int WorkAreaId { get; set; }
            /// <summary>
            /// 工作中心编号
            /// </summary>
            public int WorkCenterId { get; set; }
            /// <summary>
            /// 区域编码
            /// </summary>
            public string WorkAreaCode { get; set; }
            /// <summary>
            /// 区域名称
            /// </summary>
            public string WorkAreaName { get; set; }
            /// <summary>
            /// 父编码
            /// </summary>
            public int? ParentId { get; set; }
            /// <summary>
            /// 区域描述
            /// </summary>
            public string Description { get; set; }
        }
        public class WorkAreaFilterDto
        {
            public string WorkAreaName { get; set; }
        }
    }
}
