using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class TechnologyImprovementGauge : Qcms.Core.Entities.AggregateRoot
    {
        public int TechnologyImprovementGaugeId { get; set; }
        public int TechnologyImprovementId { get; set; }
        public int GaugeId { get; set; }

        public virtual Gauge Gauge { get; set; }
        public virtual TechnologyImprovement TechnologyImprovement { get; set; }
    }
}