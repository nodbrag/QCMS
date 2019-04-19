using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class WorkArea : Qcms.Core.Entities.AggregateRoot
    {
        public WorkArea()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int WorkAreaId { get; set; }
        public int WorkCenterId { get; set; }
        public string WorkAreaCode { get; set; }
        public string WorkAreaName { get; set; }
        public int? ParentId { get; set; }
        public string Description { get; set; }

        public virtual WorkCenter WorkCenter { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}