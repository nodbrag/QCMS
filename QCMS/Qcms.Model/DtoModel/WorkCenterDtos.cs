using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qcms.Model.DtoModel
{
    public class WorkCenterDtos
    {
        public class WorkCenterDto
        {
            /// <summary>
            /// 主键号
            /// </summary>
            public int WorkCenterId { get; set; }
            /// <summary>
            /// 编号
            /// </summary>
            public string WorkCenterCode { get; set; }
            /// <summary>
            /// 名称
            /// </summary>
            public string WorkCenterName { get; set; }
            /// <summary>
            /// 描述
            /// </summary>
            public string Description { get; set; }
        }
        public class WorkCenterFilterDto
        {
            /// <summary>
            /// 区域名称
            /// </summary>
            public string WorkCenterName { get; set; }

        }
    }
}
