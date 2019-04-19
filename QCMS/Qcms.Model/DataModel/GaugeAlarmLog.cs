using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class GaugeAlarmLog : Qcms.Core.Entities.AggregateRoot
    {
        public int GaugeAlarmLogId { get; set; }
        public int GaugeId { get; set; }
        public int GaugeParamTagId { get; set; }
        public string AlarmType { get; set; }
        public int AlarmLevel { get; set; }
        public int AlarmValue { get; set; }
        public bool IsMaxRangeAlarm { get; set; }
        public bool IsMinRangeAlarm { get; set; }
        public DateTime RecordDateTime { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime? ProcessDateTime { get; set; }
    }
}