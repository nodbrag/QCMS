using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class EnergyUsagePhase : Qcms.Core.Entities.AggregateRoot
    {
        public int EnergyUsagePhaseId { get; set; }
        public string EnergyUsagePhaseName { get; set; }
        public string Description { get; set; }
    }
}