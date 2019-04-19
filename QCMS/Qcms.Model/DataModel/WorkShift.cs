using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class WorkShift : Qcms.Core.Entities.AggregateRoot
    {
        public WorkShift()
        {
            ProductionRecord = new HashSet<ProductionRecord>();
        }

        public int WorkShiftId { get; set; }
        public string WorkShiftCode { get; set; }
        public string WorkShiftName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int IsCrossDay { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ProductionRecord> ProductionRecord { get; set; }
    }
}