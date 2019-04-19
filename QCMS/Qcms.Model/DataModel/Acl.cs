using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class Acl:Qcms.Core.Entities.AggregateRoot
    {
        public int Aclid { get; set; }
        public string VisitorType { get; set; }
        public string VisitorId { get; set; }
        public string AccessRight { get; set; }
        public string AccessEntryType { get; set; }
        public string AccessEntryId { get; set; }
        public string AccessParams { get; set; }
    }
}