using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class EquipmentGauge : Qcms.Core.Entities.AggregateRoot
    {
        public int EquipmentGaugeId { get; set; }
        public int EquipmentId { get; set; }
        public int GaugeId { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual Gauge Gauge { get; set; }
    }
}