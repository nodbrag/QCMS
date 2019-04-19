using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class ProductionRecord : Qcms.Core.Entities.AggregateRoot
    {
        public int ProductionRecordId { get; set; }
        public int WorkCenterId { get; set; }
        public int WorkShiftId { get; set; }
        public int InventoryId { get; set; }
        public DateTime PlanningDate { get; set; }
        public decimal PlanningQuantity { get; set; }
        public DateTime CompletionDate { get; set; }
        public decimal CompletionQuantity { get; set; }
        public int RecorderId { get; set; }
        public DateTime RecordDateTime { get; set; }
        public string Description { get; set; }

        public virtual User Recorder { get; set; }
        public virtual WorkCenter WorkCenter { get; set; }
        public virtual WorkShift WorkShift { get; set; }
    }
}