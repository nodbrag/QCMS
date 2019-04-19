using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class Dictionary : Qcms.Core.Entities.AggregateRoot
    {
        public int DictionaryId { get; set; }
        public int DictionaryIndexId { get; set; }
        public string DictionaryKey { get; set; }
        public string DictionaryValue { get; set; }

        public virtual DictionaryIndex DictionaryIndex { get; set; }
    }
}