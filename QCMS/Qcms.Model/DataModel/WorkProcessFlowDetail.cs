using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class WorkProcessFlowDetail : Qcms.Core.Entities.AggregateRoot
    {
        public int WorkProcessFlowDetailId { get; set; }
        public int WorkProcessFlowId { get; set; }
        public int WorkProcessId { get; set; }
        public decimal ProductionRadio { get; set; }

        public virtual WorkProcess WorkProcess { get; set; }
        public virtual WorkProcessFlow WorkProcessFlow { get; set; }
    }
}