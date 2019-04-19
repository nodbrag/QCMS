using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class Inventory : Qcms.Core.Entities.AggregateRoot
    {
        public int InventoryId { get; set; }
        public string InventoryCode { get; set; }
        public string InventoryName { get; set; }
        public bool IsEnable { get; set; }
        public string Description { get; set; }
    }
}