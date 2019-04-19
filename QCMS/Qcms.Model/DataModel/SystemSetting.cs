using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class SystemSetting : Qcms.Core.Entities.AggregateRoot
    {
        public int SystemSettingId { get; set; }
        public string SystemSettingType { get; set; }
        public string SystemSettingName { get; set; }
        public string SystemSettingValue { get; set; }
        public string Description { get; set; }
    }
}