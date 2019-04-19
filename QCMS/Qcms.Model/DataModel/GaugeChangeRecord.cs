using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class GaugeChangeRecord : Qcms.Core.Entities.AggregateRoot
    {
        public int GaugeChangeRecordId { get; set; }
        public int GaugeId { get; set; }
        public string OldSerialNo { get; set; }
        public string NewSerialNo { get; set; }
        public decimal OriginalValue { get; set; }
        public decimal InitialValue { get; set; }
        public int RecorderId { get; set; }
        public DateTime RecordDateTime { get; set; }
        public string Description { get; set; }

        public virtual Gauge Gauge { get; set; }
        public virtual User Recorder { get; set; }
    }
}