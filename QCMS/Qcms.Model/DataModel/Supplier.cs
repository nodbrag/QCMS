using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class Supplier : Qcms.Core.Entities.AggregateRoot
    {
        public Supplier()
        {
            EnergyPrice = new HashSet<EnergyPrice>();
        }

        public int SupplierId { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string SupplierShortName { get; set; }
        public string SupplierAddress { get; set; }
        public string Memo { get; set; }

        public virtual ICollection<EnergyPrice> EnergyPrice { get; set; }
    }
}