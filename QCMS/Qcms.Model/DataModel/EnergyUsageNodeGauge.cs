using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class EnergyUsageNodeGauge : Qcms.Core.Entities.AggregateRoot
    {
        public int EnergyUsageNodeGaugeId { get; set; }
        public int EnergyUsageNodeId { get; set; }
        public int GaugeId { get; set; }

        public virtual Gauge Gauge { get; set; }
    }
}