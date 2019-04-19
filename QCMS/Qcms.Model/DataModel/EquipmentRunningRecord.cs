using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class EquipmentRunningRecord : Qcms.Core.Entities.AggregateRoot
    {
        public EquipmentRunningRecord()
        {
            EquipmentRunningRecordDetail = new HashSet<EquipmentRunningRecordDetail>();
        }

        public int EquipmentRunningRecordId { get; set; }
        public int EquipmentId { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Digest { get; set; }
        public string Description { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual ICollection<EquipmentRunningRecordDetail> EquipmentRunningRecordDetail { get; set; }
    }
}