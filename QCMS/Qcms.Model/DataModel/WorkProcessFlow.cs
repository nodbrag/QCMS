using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class WorkProcessFlow : Qcms.Core.Entities.AggregateRoot
    {
        public WorkProcessFlow()
        {
            WorkProcessFlowDetail = new HashSet<WorkProcessFlowDetail>();
        }

        public int WorkProcessFlowId { get; set; }
        public int InventoryId { get; set; }

        public virtual ICollection<WorkProcessFlowDetail> WorkProcessFlowDetail { get; set; }
    }
}