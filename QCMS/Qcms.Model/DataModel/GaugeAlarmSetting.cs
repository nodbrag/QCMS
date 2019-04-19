using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class GaugeAlarmSetting : Qcms.Core.Entities.AggregateRoot
    {
        public int GaugeAlarmSettingId { get; set; }
        public int GaugeId { get; set; }
        public int GaugeParamTagId { get; set; }
        public int AlarmLevel { get; set; }
        public decimal MaximumRange { get; set; }
        public decimal MinimumRange { get; set; }
        public string Description { get; set; }

        public virtual Gauge Gauge { get; set; }
        public virtual GaugeParamTag GaugeParamTag { get; set; }
    }
}