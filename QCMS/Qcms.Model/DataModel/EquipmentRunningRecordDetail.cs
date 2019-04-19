using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class EquipmentRunningRecordDetail : Qcms.Core.Entities.AggregateRoot
    {
        public int EquipmentRunningRecordDetailId { get; set; }
        public int EquipmentRunningRecordId { get; set; }
        public string Phase { get; set; }
        public DateTime PhaseBeginTime { get; set; }
        public DateTime PhaseEndTime { get; set; }
        public string Digest { get; set; }
        public string Description { get; set; }

        public virtual EquipmentRunningRecord EquipmentRunningRecord { get; set; }
    }
}