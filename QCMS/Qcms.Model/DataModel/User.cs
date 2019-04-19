using System;
using System.Collections.Generic;

namespace Qcms.Model.DataModel
{
    public partial class User : Qcms.Core.Entities.AggregateRoot
    {
        public User()
        {
            EnergyExceptionRecord = new HashSet<EnergyExceptionRecord>();
            EnergyPrice = new HashSet<EnergyPrice>();
            GaugeChangeRecord = new HashSet<GaugeChangeRecord>();
            GaugeManualRecord = new HashSet<GaugeManualRecord>();
            ProductionRecord = new HashSet<ProductionRecord>();
            UserRole = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public bool IsUsed { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EnergyExceptionRecord> EnergyExceptionRecord { get; set; }
        public virtual ICollection<EnergyPrice> EnergyPrice { get; set; }
        public virtual ICollection<GaugeChangeRecord> GaugeChangeRecord { get; set; }
        public virtual ICollection<GaugeManualRecord> GaugeManualRecord { get; set; }
        public virtual ICollection<ProductionRecord> ProductionRecord { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}