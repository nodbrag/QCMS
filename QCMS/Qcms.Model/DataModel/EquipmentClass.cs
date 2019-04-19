using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class EquipmentClass : Qcms.Core.Entities.AggregateRoot
    {
        public EquipmentClass()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int EquipmentClassId { get; set; }
        public string EquipmentClassCode { get; set; }
        public string EquipmentClassName { get; set; }
        public int? ParentId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}