using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class EnergyExceptionRecord : Qcms.Core.Entities.AggregateRoot
    {
        public int EnergyExceptionRecordId { get; set; }
        public string ExceptionTitle { get; set; }
        public string ExceptionContent { get; set; }
        public DateTime ExceptionDateTime { get; set; }
        public int RecorderId { get; set; }
        public DateTime RecordDateTime { get; set; }
        public string HandleContent { get; set; }
        public DateTime HandleDateTime { get; set; }
        public string Description { get; set; }

        public virtual User Recorder { get; set; }
    }
}