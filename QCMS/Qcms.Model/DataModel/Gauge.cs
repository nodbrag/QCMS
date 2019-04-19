using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class Gauge : Qcms.Core.Entities.AggregateRoot
    {
        public Gauge()
        {
            EnergyUsageNodeGauge = new HashSet<EnergyUsageNodeGauge>();
            EquipmentGauge = new HashSet<EquipmentGauge>();
            GaugeAlarmSetting = new HashSet<GaugeAlarmSetting>();
            GaugeChangeRecord = new HashSet<GaugeChangeRecord>();
            GaugeManualRecord = new HashSet<GaugeManualRecord>();
            GaugeParamTag = new HashSet<GaugeParamTag>();
            GaugeSnapshot = new HashSet<GaugeSnapshot>();
            TechnologyImprovementGauge = new HashSet<TechnologyImprovementGauge>();
        }

        public int GaugeId { get; set; }
        public int WorkCenterId { get; set; }
        public int WorkAreaId { get; set; }
        public string GaugeCode { get; set; }
        public string GaugeName { get; set; }
        public string GaugeType { get; set; }
        public bool IsAuto { get; set; }
        public bool IsCalculable { get; set; }
        public bool IsPrimary { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EnergyUsageNodeGauge> EnergyUsageNodeGauge { get; set; }
        public virtual ICollection<EquipmentGauge> EquipmentGauge { get; set; }
        public virtual ICollection<GaugeAlarmSetting> GaugeAlarmSetting { get; set; }
        public virtual ICollection<GaugeChangeRecord> GaugeChangeRecord { get; set; }
        public virtual ICollection<GaugeManualRecord> GaugeManualRecord { get; set; }
        public virtual ICollection<GaugeParamTag> GaugeParamTag { get; set; }
        public virtual ICollection<GaugeSnapshot> GaugeSnapshot { get; set; }
        public virtual ICollection<TechnologyImprovementGauge> TechnologyImprovementGauge { get; set; }
    }
}