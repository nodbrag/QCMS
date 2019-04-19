using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class ProductEnergyConsumption : Qcms.Core.Entities.AggregateRoot
    {
        public int ProductEnergyConsumptionId { get; set; }
        public int WorkProcessId { get; set; }
        public int InventoryId { get; set; }
        public int EnergyId { get; set; }
        public decimal EnergyRatio { get; set; }
        public string Expression { get; set; }

        public virtual Energy Energy { get; set; }
        public virtual WorkProcess WorkProcess { get; set; }
    }
}