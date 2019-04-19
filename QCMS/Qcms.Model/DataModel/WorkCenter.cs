using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class WorkCenter : Qcms.Core.Entities.AggregateRoot
    {
        public WorkCenter()
        {
            EnergyPrice = new HashSet<EnergyPrice>();
            Equipment = new HashSet<Equipment>();
            ProductionRecord = new HashSet<ProductionRecord>();
            WebScada = new HashSet<WebScada>();
            WorkArea = new HashSet<WorkArea>();
            WorkCenterEnergyKpi = new HashSet<WorkCenterEnergyKpi>();
            WorkCenterInventory = new HashSet<WorkCenterInventory>();
        }

        public int WorkCenterId { get; set; }
        public string WorkCenterCode { get; set; }
        public string WorkCenterName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EnergyPrice> EnergyPrice { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<ProductionRecord> ProductionRecord { get; set; }
        public virtual ICollection<WebScada> WebScada { get; set; }
        public virtual ICollection<WorkArea> WorkArea { get; set; }
        public virtual ICollection<WorkCenterEnergyKpi> WorkCenterEnergyKpi { get; set; }
        public virtual ICollection<WorkCenterInventory> WorkCenterInventory { get; set; }
    }
}