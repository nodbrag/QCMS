using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class TechnologyImprovement : Qcms.Core.Entities.AggregateRoot
    {
        public TechnologyImprovement()
        {
            TechnologyImprovementGauge = new HashSet<TechnologyImprovementGauge>();
        }

        public int TechnologyImprovementId { get; set; }
        public string TechnologyImprovementType { get; set; }
        public string TechnologyImprovementTitle { get; set; }
        public decimal TechnologyImprovementProgress { get; set; }
        public DateTime TechnologyImprovementDateTime { get; set; }
        public decimal EconomizeEnergyQuantity { get; set; }
        public decimal EconomizeWaterQuantity { get; set; }
        public decimal SavingCost { get; set; }
        public decimal InvestmentAmount { get; set; }
        public decimal PaybackPeriod { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TechnologyImprovementGauge> TechnologyImprovementGauge { get; set; }
    }
}