using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class GaugeSnapshot : Qcms.Core.Entities.AggregateRoot
    {
        public long GaugeSnapshotId { get; set; }
        public int GaugeId { get; set; }
        public int GaugeParamTagId { get; set; }
        public int WorkShiftId { get; set; }
        public int EnergyId { get; set; }
        public int EnergyPropertyId { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime BeginDateTime { get; set; }
        public decimal BeginValue { get; set; }
        public DateTime EndDateTime { get; set; }
        public decimal EndValue { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public virtual Gauge Gauge { get; set; }
        public virtual GaugeParamTag GaugeParamTag { get; set; }
    }
}