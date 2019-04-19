using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class Energy : Qcms.Core.Entities.AggregateRoot
    {
        public Energy()
        {
            EnergyPrice = new HashSet<EnergyPrice>();
            EnergyProperty = new HashSet<EnergyProperty>();
            GaugeParam = new HashSet<GaugeParam>();
            ProductEnergyConsumption = new HashSet<ProductEnergyConsumption>();
            ProductEnergyKpi = new HashSet<ProductEnergyKpi>();
            WebScada = new HashSet<WebScada>();
            WorkCenterEnergyKpi = new HashSet<WorkCenterEnergyKpi>();
        }

        public int EnergyId { get; set; }
        public int EnergyUnitGroupId { get; set; }
        public int EnergyUnitId { get; set; }
        public string EnergyName { get; set; }
        public string Description { get; set; }
        public decimal StandardCoalRate { get; set; }

        public virtual Unit EnergyUnit { get; set; }
        public virtual UnitGroup EnergyUnitGroup { get; set; }
        public virtual ICollection<EnergyPrice> EnergyPrice { get; set; }
        public virtual ICollection<EnergyProperty> EnergyProperty { get; set; }
        public virtual ICollection<GaugeParam> GaugeParam { get; set; }
        public virtual ICollection<ProductEnergyConsumption> ProductEnergyConsumption { get; set; }
        public virtual ICollection<ProductEnergyKpi> ProductEnergyKpi { get; set; }
        public virtual ICollection<WebScada> WebScada { get; set; }
        public virtual ICollection<WorkCenterEnergyKpi> WorkCenterEnergyKpi { get; set; }
    }
}