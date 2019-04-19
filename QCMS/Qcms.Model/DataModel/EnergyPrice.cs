using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class EnergyPrice : Qcms.Core.Entities.AggregateRoot
    {
        public int EnergyPriceId { get; set; }
        public int EnergyId { get; set; }
        public int EnergyPropertyId { get; set; }
        public int WorkCenterId { get; set; }
        public int SupplierId { get; set; }
        public decimal Price { get; set; }
        public bool IsEnable { get; set; }
        public DateTime EnableDateTime { get; set; }
        public int MakerId { get; set; }
        public DateTime MakeDateTime { get; set; }
        public string Description { get; set; }

        public virtual Energy Energy { get; set; }
        public virtual EnergyProperty EnergyProperty { get; set; }
        public virtual User Maker { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual WorkCenter WorkCenter { get; set; }
    }
}