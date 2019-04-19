using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class WorkCenterEnergyKpi : Qcms.Core.Entities.AggregateRoot
    {
        public int WorkCenterEnergyKpiid { get; set; }
        public int EnergyId { get; set; }
        public int WorkCenterId { get; set; }
        public decimal LocalKpivalue { get; set; }
        public decimal InternalKpivalue { get; set; }
        public decimal InternationalKpivalue { get; set; }

        public virtual Energy Energy { get; set; }
        public virtual WorkCenter WorkCenter { get; set; }
    }
}