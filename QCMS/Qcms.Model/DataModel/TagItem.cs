using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class TagItem : Qcms.Core.Entities.AggregateRoot
    {
        public TagItem()
        {
            GaugeParamTag = new HashSet<GaugeParamTag>();
        }

        public int TagItemId { get; set; }
        public string TagTopic { get; set; }
        public string TagName { get; set; }
        public string TagValue { get; set; }
        public int TagValueQuality { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public virtual ICollection<GaugeParamTag> GaugeParamTag { get; set; }
    }
}