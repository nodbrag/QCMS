using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class ProductEnergyKpi : Qcms.Core.Entities.AggregateRoot
    {
        public int ProductEnergyKpiid { get; set; }
        public int InventoryId { get; set; }
        public int EnergyId { get; set; }
        public decimal LocalKpi { get; set; }
        public decimal InternalKpi { get; set; }
        public decimal InternationalKpi { get; set; }
        public string Description { get; set; }

        public virtual Energy Energy { get; set; }
    }
}