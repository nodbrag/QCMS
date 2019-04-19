using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class OperationLog : Qcms.Core.Entities.AggregateRoot
    {
        public int OperationLogId { get; set; }
        public string LogType { get; set; }
        public string SourceType { get; set; }
        public string SourceId { get; set; }
        public string OperatorName { get; set; }
        public DateTime OperatingTime { get; set; }
        public string OperationType { get; set; }
        public string Operation { get; set; }
        public string OperationContent { get; set; }
        public string OperatingSystem { get; set; }
        public string TerminalName { get; set; }
        public string Ipaddress { get; set; }
    }
}