using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class WebScada : Qcms.Core.Entities.AggregateRoot
    {
        public int WebScadaId { get; set; }
        public string EquipmentType { get; set; }
        public int EnergyId { get; set; }
        public int WorkCenterId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Sort { get; set; }

        public virtual Energy Energy { get; set; }
        public virtual WorkCenter WorkCenter { get; set; }
    }
}