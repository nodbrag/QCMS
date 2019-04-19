using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class DictionaryIndex : Qcms.Core.Entities.AggregateRoot
    {
        public DictionaryIndex()
        {
            Dictionary = new HashSet<Dictionary>();
        }

        public int DictionaryIndexId { get; set; }
        public string DictionaryIndexCode { get; set; }
        public string DictionaryIndexName { get; set; }
        public string DictionaryGrade { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Dictionary> Dictionary { get; set; }
    }
}