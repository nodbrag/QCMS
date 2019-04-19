using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class WorkProcess : Qcms.Core.Entities.AggregateRoot
    {
        public WorkProcess()
        {
            ProductEnergyConsumption = new HashSet<ProductEnergyConsumption>();
            WorkProcessEquipment = new HashSet<WorkProcessEquipment>();
            WorkProcessFlowDetail = new HashSet<WorkProcessFlowDetail>();
        }

        public int WorkProcessId { get; set; }
        public string WorkProcessCode { get; set; }
        public string WorkProcessName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProductEnergyConsumption> ProductEnergyConsumption { get; set; }
        public virtual ICollection<WorkProcessEquipment> WorkProcessEquipment { get; set; }
        public virtual ICollection<WorkProcessFlowDetail> WorkProcessFlowDetail { get; set; }
    }
}