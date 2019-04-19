using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class EnergyProperty : Qcms.Core.Entities.AggregateRoot
    {
        public EnergyProperty()
        {
            EnergyPrice = new HashSet<EnergyPrice>();
            EnergyPropertyRange = new HashSet<EnergyPropertyRange>();
        }

        public int EnergyPropertyId { get; set; }
        public int EnergyId { get; set; }
        public string EnergyPropertyName { get; set; }
        public bool HasTimeRange { get; set; }
        public string Description { get; set; }

        public virtual Energy Energy { get; set; }
        public virtual ICollection<EnergyPrice> EnergyPrice { get; set; }
        public virtual ICollection<EnergyPropertyRange> EnergyPropertyRange { get; set; }
    }
}