using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class WorkProcessEquipment : Qcms.Core.Entities.AggregateRoot
    {
        public int WorkProcessEquipmentId { get; set; }
        public int WorkProcessId { get; set; }
        public int EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual WorkProcess WorkProcess { get; set; }
    }
}