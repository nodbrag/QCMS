using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class Unit : Qcms.Core.Entities.AggregateRoot
    {
        public Unit()
        {
            Energy = new HashSet<Energy>();
        }

        public int UnitId { get; set; }
        public int UnitGroupId { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public bool IsBasicUnit { get; set; }
        public decimal ExchangeRate { get; set; }
        public string Description { get; set; }

        public virtual UnitGroup UnitGroup { get; set; }
        public virtual ICollection<Energy> Energy { get; set; }
    }
}