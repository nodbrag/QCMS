using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class NavigationItem : Qcms.Core.Entities.AggregateRoot
    {
        public int NavigationItemId { get; set; }
        public string NavigationItemType { get; set; }
        public int NavigationItemSn { get; set; }
        public string NavigationItemCode { get; set; }
        public string NavigationItemName { get; set; }
        public string SourceImageName { get; set; }
        public string ClassType { get; set; }
        public string Params { get; set; }
        public bool Enable { get; set; }
        public bool Visible { get; set; }
        public string ParentId { get; set; }
    }
}