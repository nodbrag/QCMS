using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class GaugeManualRecord : Qcms.Core.Entities.AggregateRoot
    {
        public int GaugeManualRecordId { get; set; }
        public int GaugeId { get; set; }
        public decimal AccumulateValue { get; set; }
        public int RecorderId { get; set; }
        public DateTime RecordDateTime { get; set; }
        public string Description { get; set; }

        public virtual Gauge Gauge { get; set; }
        public virtual User Recorder { get; set; }
    }
}