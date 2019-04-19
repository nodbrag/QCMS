using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class EquipmentProperty : Qcms.Core.Entities.AggregateRoot
    {
        public int EquipmentPropertyId { get; set; }
        public int EquipmentId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }

        public virtual Equipment Equipment { get; set; }
    }
}