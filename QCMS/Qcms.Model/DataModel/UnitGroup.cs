using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class UnitGroup : Qcms.Core.Entities.AggregateRoot
    {
        public UnitGroup()
        {
            Energy = new HashSet<Energy>();
            Unit = new HashSet<Unit>();
        }

        public int UnitGroupId { get; set; }
        public string UnitGroupCode { get; set; }
        public string UnitGroupName { get; set; }
        public bool IsFixedExchangeRate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Energy> Energy { get; set; }
        public virtual ICollection<Unit> Unit { get; set; }
    }
}