using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class GaugeParamTag : Qcms.Core.Entities.AggregateRoot
    {
        public GaugeParamTag()
        {
            GaugeAlarmSetting = new HashSet<GaugeAlarmSetting>();
            GaugeSnapshot = new HashSet<GaugeSnapshot>();
        }

        public int GaugeParamTagId { get; set; }
        public int GaugeId { get; set; }
        public int IndicatedEnergyId { get; set; }
        public int? GaugeParamId { get; set; }
        public int TagItemId { get; set; }
        public bool IsVirtual { get; set; }
        public string GaugeValueExpression { get; set; }

        public virtual Gauge Gauge { get; set; }
        public virtual TagItem TagItem { get; set; }
        public virtual ICollection<GaugeAlarmSetting> GaugeAlarmSetting { get; set; }
        public virtual ICollection<GaugeSnapshot> GaugeSnapshot { get; set; }
    }
}