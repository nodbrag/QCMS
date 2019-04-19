using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class EnergyPropertyRange : Qcms.Core.Entities.AggregateRoot
    {
        public int EnergyPropertyRangeId { get; set; }
        public int EnergyPropertyId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual EnergyProperty EnergyProperty { get; set; }
    }
}