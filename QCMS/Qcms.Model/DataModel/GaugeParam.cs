using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class GaugeParam : Qcms.Core.Entities.AggregateRoot
    {
        public int GaugeParamId { get; set; }
        public int EnergyId { get; set; }
        public string GaugeParamName { get; set; }
        public string GaugeParamSymbol { get; set; }
        public string Description { get; set; }
        public int RelatedEnergyId { get; set; }

        public virtual Energy Energy { get; set; }
    }
}