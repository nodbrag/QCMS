using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class Equipment : Qcms.Core.Entities.AggregateRoot
    {
        public Equipment()
        {
            EquipmentGauge = new HashSet<EquipmentGauge>();
            EquipmentProperty = new HashSet<EquipmentProperty>();
            EquipmentRunningRecord = new HashSet<EquipmentRunningRecord>();
            WorkProcessEquipment = new HashSet<WorkProcessEquipment>();
        }

        public int EquipmentId { get; set; }
        public int EquipmentClassId { get; set; }
        public int WorkCenterId { get; set; }
        public int WorkAreaId { get; set; }
        public string EquipmentType { get; set; }
        public string EquipmentCode { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentImagePath { get; set; }
        public string Description { get; set; }

        public virtual EquipmentClass EquipmentClass { get; set; }
        public virtual WorkArea WorkArea { get; set; }
        public virtual WorkCenter WorkCenter { get; set; }
        public virtual ICollection<EquipmentGauge> EquipmentGauge { get; set; }
        public virtual ICollection<EquipmentProperty> EquipmentProperty { get; set; }
        public virtual ICollection<EquipmentRunningRecord> EquipmentRunningRecord { get; set; }
        public virtual ICollection<WorkProcessEquipment> WorkProcessEquipment { get; set; }
    }
}