using System;
using System.Collections.Generic;
using System.Text;

namespace Qcms.Model.DtoModel
{
    public class OperationLogDtos
    {
        public class OperationLogDto
        {
            /// <summary>
            /// 主键号
            /// </summary>
            public int OperationLogId { get; set; }
            /// <summary>
            /// 日志类型
            /// </summary>
            public string LogType { get; set; }
            /// <summary>
            /// 源类型
            /// </summary>
            public string SourceType { get; set; }
            /// <summary>
            /// 源编号
            /// </summary>
            public string SourceId { get; set; }
            /// <summary>
            /// 操作名称
            /// </summary>
            public string OperatorName { get; set; }
            /// <summary>
            /// 操作时间
            /// </summary>
            public DateTime OperatingTime { get; set; }
            /// <summary>
            /// 操作类型
            /// </summary>
            public string OperationType { get; set; }
           /// <summary>
           /// 操作人
           /// </summary>
            public string Operation { get; set; }
             /// <summary>
             /// 操作内容
             /// </summary>
            public string OperationContent { get; set; }
            /// <summary>
            /// 操作系统
            /// </summary>
            public string OperatingSystem { get; set; }
            public string TerminalName { get; set; }
            public string Ipaddress { get; set; }
        }
        public class OperationLogFilterDto
        {
            /// <summary>
            /// 操作名称
            /// </summary>
            public string OperatorName { get; set; }
            /// <summary>
            /// 操作时间
            /// </summary>
            public string OperatingTime { get; set; }
        }
    }
}
