using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class WorkCenterInventory : Qcms.Core.Entities.AggregateRoot
    {
        public int WorkCenterInventoryId { get; set; }
        public int WorkCenterId { get; set; }
        public int InventoryId { get; set; }

        public virtual WorkCenter WorkCenter { get; set; }
    }
}