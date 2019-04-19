using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Qcms.Model.DataModel
{
    public partial class ModelBaseContext : DbContext
    {
        public ModelBaseContext()
        {
        }

        public ModelBaseContext(DbContextOptions<ModelBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acl> Acl { get; set; }
        public virtual DbSet<Attachment> Attachment { get; set; }
        public virtual DbSet<Dictionary> Dictionary { get; set; }
        public virtual DbSet<DictionaryIndex> DictionaryIndex { get; set; }
        public virtual DbSet<Energy> Energy { get; set; }
        public virtual DbSet<EnergyExceptionRecord> EnergyExceptionRecord { get; set; }
        public virtual DbSet<EnergyPrice> EnergyPrice { get; set; }
        public virtual DbSet<EnergyProperty> EnergyProperty { get; set; }
        public virtual DbSet<EnergyPropertyRange> EnergyPropertyRange { get; set; }
        public virtual DbSet<EnergyUsageNodeGauge> EnergyUsageNodeGauge { get; set; }
        public virtual DbSet<EnergyUsagePhase> EnergyUsagePhase { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentClass> EquipmentClass { get; set; }
        public virtual DbSet<EquipmentGauge> EquipmentGauge { get; set; }
        public virtual DbSet<EquipmentProperty> EquipmentProperty { get; set; }
        public virtual DbSet<EquipmentRunningRecord> EquipmentRunningRecord { get; set; }
        public virtual DbSet<EquipmentRunningRecordDetail> EquipmentRunningRecordDetail { get; set; }
        public virtual DbSet<Gauge> Gauge { get; set; }
        public virtual DbSet<GaugeAlarmLog> GaugeAlarmLog { get; set; }
        public virtual DbSet<GaugeAlarmSetting> GaugeAlarmSetting { get; set; }
        public virtual DbSet<GaugeChangeRecord> GaugeChangeRecord { get; set; }
        public virtual DbSet<GaugeManualRecord> GaugeManualRecord { get; set; }
        public virtual DbSet<GaugeParam> GaugeParam { get; set; }
        public virtual DbSet<GaugeParamTag> GaugeParamTag { get; set; }
        public virtual DbSet<GaugeSnapshot> GaugeSnapshot { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<NavigationItem> NavigationItem { get; set; }
        public virtual DbSet<OperationLog> OperationLog { get; set; }
        public virtual DbSet<ProductEnergyConsumption> ProductEnergyConsumption { get; set; }
        public virtual DbSet<ProductEnergyKpi> ProductEnergyKpi { get; set; }
        public virtual DbSet<ProductionRecord> ProductionRecord { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SystemSetting> SystemSetting { get; set; }
        public virtual DbSet<TagItem> TagItem { get; set; }
        public virtual DbSet<TechnologyImprovement> TechnologyImprovement { get; set; }
        public virtual DbSet<TechnologyImprovementGauge> TechnologyImprovementGauge { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<UnitGroup> UnitGroup { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<WebScada> WebScada { get; set; }
        public virtual DbSet<WorkArea> WorkArea { get; set; }
        public virtual DbSet<WorkCenter> WorkCenter { get; set; }
        public virtual DbSet<WorkCenterEnergyKpi> WorkCenterEnergyKpi { get; set; }
        public virtual DbSet<WorkCenterInventory> WorkCenterInventory { get; set; }
        public virtual DbSet<WorkProcess> WorkProcess { get; set; }
        public virtual DbSet<WorkProcessEquipment> WorkProcessEquipment { get; set; }
        public virtual DbSet<WorkProcessFlow> WorkProcessFlow { get; set; }
        public virtual DbSet<WorkProcessFlowDetail> WorkProcessFlowDetail { get; set; }
        public virtual DbSet<WorkShift> WorkShift { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EnergyV2;Persist Security Info=True;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Acl>(entity =>
            {
                entity.ToTable("ACL");

                entity.Property(e => e.Aclid).HasColumnName("ACLID");

                entity.Property(e => e.AccessEntryId)
                    .IsRequired()
                    .HasColumnName("AccessEntryID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AccessEntryType)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.AccessParams)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AccessRight)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.VisitorId)
                    .IsRequired()
                    .HasColumnName("VisitorID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VisitorType)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Attachment>(entity =>
            {
                entity.HasIndex(e => new { e.SourceType, e.SourceId })
                    .HasName("IX_Att_Src");

                entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FileType)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Md5digest)
                    .IsRequired()
                    .HasColumnName("MD5Digest")
                    .HasMaxLength(50);

                entity.Property(e => e.ServerFileName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ServerPath)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.SourceId)
                    .IsRequired()
                    .HasColumnName("SourceID")
                    .HasMaxLength(10);

                entity.Property(e => e.SourceType)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UploadDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.HasKey(e => e.DictionaryId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.DictionaryId).HasColumnName("DictionaryID");

                entity.Property(e => e.DictionaryIndexId).HasColumnName("DictionaryIndexID");

                entity.Property(e => e.DictionaryKey)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.DictionaryValue)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.DictionaryIndex)
                    .WithMany(p => p.Dictionary)
                    .HasForeignKey(d => d.DictionaryIndexId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dic_DicIndex");
            });

            modelBuilder.Entity<DictionaryIndex>(entity =>
            {
                entity.HasKey(e => e.DictionaryIndexId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.DictionaryIndexId).HasColumnName("DictionaryIndexID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DictionaryGrade)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DictionaryIndexCode)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.DictionaryIndexName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Energy>(entity =>
            {
                entity.Property(e => e.EnergyId).HasColumnName("EnergyID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EnergyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EnergyUnitGroupId).HasColumnName("EnergyUnitGroupID");

                entity.Property(e => e.EnergyUnitId).HasColumnName("EnergyUnitID");

                entity.Property(e => e.StandardCoalRate).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.EnergyUnitGroup)
                    .WithMany(p => p.Energy)
                    .HasForeignKey(d => d.EnergyUnitGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eng_UnitGroup");

                entity.HasOne(d => d.EnergyUnit)
                    .WithMany(p => p.Energy)
                    .HasForeignKey(d => d.EnergyUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eng_Unit");
            });

            modelBuilder.Entity<EnergyExceptionRecord>(entity =>
            {
                entity.Property(e => e.EnergyExceptionRecordId).HasColumnName("EnergyExceptionRecordID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ExceptionContent)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ExceptionDateTime).HasColumnType("datetime");

                entity.Property(e => e.ExceptionTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HandleContent)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.HandleDateTime).HasColumnType("datetime");

                entity.Property(e => e.RecordDateTime).HasColumnType("datetime");

                entity.Property(e => e.RecorderId).HasColumnName("RecorderID");

                entity.HasOne(d => d.Recorder)
                    .WithMany(p => p.EnergyExceptionRecord)
                    .HasForeignKey(d => d.RecorderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EngExpRcd_User");
            });

            modelBuilder.Entity<EnergyPrice>(entity =>
            {
                entity.Property(e => e.EnergyPriceId).HasColumnName("EnergyPriceID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EnableDateTime).HasColumnType("datetime");

                entity.Property(e => e.EnergyId).HasColumnName("EnergyID");

                entity.Property(e => e.EnergyPropertyId).HasColumnName("EnergyPropertyID");

                entity.Property(e => e.MakeDateTime).HasColumnType("datetime");

                entity.Property(e => e.MakerId).HasColumnName("MakerID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");

                entity.HasOne(d => d.Energy)
                    .WithMany(p => p.EnergyPrice)
                    .HasForeignKey(d => d.EnergyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EngPrice_Eng");

                entity.HasOne(d => d.EnergyProperty)
                    .WithMany(p => p.EnergyPrice)
                    .HasForeignKey(d => d.EnergyPropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EngPrice_EngProp");

                entity.HasOne(d => d.Maker)
                    .WithMany(p => p.EnergyPrice)
                    .HasForeignKey(d => d.MakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EngPrice_User");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.EnergyPrice)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EngPrice_Supplier");

                entity.HasOne(d => d.WorkCenter)
                    .WithMany(p => p.EnergyPrice)
                    .HasForeignKey(d => d.WorkCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EngPrice_WorkCenter");
            });

            modelBuilder.Entity<EnergyProperty>(entity =>
            {
                entity.Property(e => e.EnergyPropertyId).HasColumnName("EnergyPropertyID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EnergyId).HasColumnName("EnergyID");

                entity.Property(e => e.EnergyPropertyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Energy)
                    .WithMany(p => p.EnergyProperty)
                    .HasForeignKey(d => d.EnergyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EngProp_Eng");
            });

            modelBuilder.Entity<EnergyPropertyRange>(entity =>
            {
                entity.Property(e => e.EnergyPropertyRangeId).HasColumnName("EnergyPropertyRangeID");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.EnergyPropertyId).HasColumnName("EnergyPropertyID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.EnergyProperty)
                    .WithMany(p => p.EnergyPropertyRange)
                    .HasForeignKey(d => d.EnergyPropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EngPropRange_EngProp");
            });

            modelBuilder.Entity<EnergyUsageNodeGauge>(entity =>
            {
                entity.Property(e => e.EnergyUsageNodeGaugeId).HasColumnName("EnergyUsageNodeGaugeID");

                entity.Property(e => e.EnergyUsageNodeId).HasColumnName("EnergyUsageNodeID");

                entity.Property(e => e.GaugeId).HasColumnName("GaugeID");

                entity.HasOne(d => d.Gauge)
                    .WithMany(p => p.EnergyUsageNodeGauge)
                    .HasForeignKey(d => d.GaugeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EngUsageNodeGge_Gge");
            });

            modelBuilder.Entity<EnergyUsagePhase>(entity =>
            {
                entity.Property(e => e.EnergyUsagePhaseId).HasColumnName("EnergyUsagePhaseID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EnergyUsagePhaseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EquipmentClassId).HasColumnName("EquipmentClassID");

                entity.Property(e => e.EquipmentCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EquipmentImagePath)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EquipmentName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EquipmentType)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.WorkAreaId).HasColumnName("WorkAreaID");

                entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");

                entity.HasOne(d => d.EquipmentClass)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.EquipmentClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eqp_EqpCls");

                entity.HasOne(d => d.WorkArea)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.WorkAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eqp_WorkArea");

                entity.HasOne(d => d.WorkCenter)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.WorkCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eqp_WorkCenter");
            });

            modelBuilder.Entity<EquipmentClass>(entity =>
            {
                entity.Property(e => e.EquipmentClassId).HasColumnName("EquipmentClassID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EquipmentClassCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EquipmentClassName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<EquipmentGauge>(entity =>
            {
                entity.Property(e => e.EquipmentGaugeId).HasColumnName("EquipmentGaugeID");

                entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");

                entity.Property(e => e.GaugeId).HasColumnName("GaugeID");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentGauge)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EqpGge_Eqp");

                entity.HasOne(d => d.Gauge)
                    .WithMany(p => p.EquipmentGauge)
                    .HasForeignKey(d => d.GaugeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EqpGge_Gge");
            });

            modelBuilder.Entity<EquipmentProperty>(entity =>
            {
                entity.Property(e => e.EquipmentPropertyId).HasColumnName("EquipmentPropertyID");

                entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");

                entity.Property(e => e.PropertyName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PropertyValue)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentProperty)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EqpProp_Eqp");
            });

            modelBuilder.Entity<EquipmentRunningRecord>(entity =>
            {
                entity.Property(e => e.EquipmentRunningRecordId).HasColumnName("EquipmentRunningRecordID");

                entity.Property(e => e.BeginTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Digest)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentRunningRecord)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eqp_EqpRunningRcd");
            });

            modelBuilder.Entity<EquipmentRunningRecordDetail>(entity =>
            {
                entity.Property(e => e.EquipmentRunningRecordDetailId).HasColumnName("EquipmentRunningRecordDetailID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Digest)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EquipmentRunningRecordId).HasColumnName("EquipmentRunningRecordID");

                entity.Property(e => e.Phase)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.PhaseBeginTime).HasColumnType("datetime");

                entity.Property(e => e.PhaseEndTime).HasColumnType("datetime");

                entity.HasOne(d => d.EquipmentRunningRecord)
                    .WithMany(p => p.EquipmentRunningRecordDetail)
                    .HasForeignKey(d => d.EquipmentRunningRecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EqpRunRcd_Detail");
            });

            modelBuilder.Entity<Gauge>(entity =>
            {
                entity.Property(e => e.GaugeId).HasColumnName("GaugeID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.GaugeCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.GaugeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GaugeType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.WorkAreaId).HasColumnName("WorkAreaID");

                entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");
            });

            modelBuilder.Entity<GaugeAlarmLog>(entity =>
            {
                entity.Property(e => e.GaugeAlarmLogId).HasColumnName("GaugeAlarmLogID");

                entity.Property(e => e.AlarmType)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.GaugeId).HasColumnName("GaugeID");

                entity.Property(e => e.GaugeParamTagId).HasColumnName("GaugeParamTagID");

                entity.Property(e => e.ProcessDateTime).HasColumnType("datetime");

                entity.Property(e => e.RecordDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<GaugeAlarmSetting>(entity =>
            {
                entity.Property(e => e.GaugeAlarmSettingId).HasColumnName("GaugeAlarmSettingID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.GaugeId).HasColumnName("GaugeID");

                entity.Property(e => e.GaugeParamTagId).HasColumnName("GaugeParamTagID");

                entity.Property(e => e.MaximumRange).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.MinimumRange).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.Gauge)
                    .WithMany(p => p.GaugeAlarmSetting)
                    .HasForeignKey(d => d.GaugeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GgeAlarmDef_Gge");

                entity.HasOne(d => d.GaugeParamTag)
                    .WithMany(p => p.GaugeAlarmSetting)
                    .HasForeignKey(d => d.GaugeParamTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GgeAlarmSetting_GgeParamTag");
            });

            modelBuilder.Entity<GaugeChangeRecord>(entity =>
            {
                entity.Property(e => e.GaugeChangeRecordId).HasColumnName("GaugeChangeRecordID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.GaugeId).HasColumnName("GaugeID");

                entity.Property(e => e.InitialValue).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.NewSerialNo)
                    .IsRequired()
                    .HasColumnName("NewSerialNO")
                    .HasMaxLength(50);

                entity.Property(e => e.OldSerialNo)
                    .IsRequired()
                    .HasColumnName("OldSerialNO")
                    .HasMaxLength(50);

                entity.Property(e => e.OriginalValue).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.RecordDateTime).HasColumnType("datetime");

                entity.Property(e => e.RecorderId).HasColumnName("RecorderID");

                entity.HasOne(d => d.Gauge)
                    .WithMany(p => p.GaugeChangeRecord)
                    .HasForeignKey(d => d.GaugeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GgeChgRcd_Gge");

                entity.HasOne(d => d.Recorder)
                    .WithMany(p => p.GaugeChangeRecord)
                    .HasForeignKey(d => d.RecorderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GgeChgRcd_User");
            });

            modelBuilder.Entity<GaugeManualRecord>(entity =>
            {
                entity.Property(e => e.GaugeManualRecordId).HasColumnName("GaugeManualRecordID");

                entity.Property(e => e.AccumulateValue).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.GaugeId).HasColumnName("GaugeID");

                entity.Property(e => e.RecordDateTime).HasColumnType("datetime");

                entity.Property(e => e.RecorderId).HasColumnName("RecorderID");

                entity.HasOne(d => d.Gauge)
                    .WithMany(p => p.GaugeManualRecord)
                    .HasForeignKey(d => d.GaugeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GgeMnuRcd_Gge");

                entity.HasOne(d => d.Recorder)
                    .WithMany(p => p.GaugeManualRecord)
                    .HasForeignKey(d => d.RecorderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GgeMnuRcd_User");
            });

            modelBuilder.Entity<GaugeParam>(entity =>
            {
                entity.Property(e => e.GaugeParamId).HasColumnName("GaugeParamID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EnergyId).HasColumnName("EnergyID");

                entity.Property(e => e.GaugeParamName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GaugeParamSymbol)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.RelatedEnergyId).HasColumnName("RelatedEnergyID");

                entity.HasOne(d => d.Energy)
                    .WithMany(p => p.GaugeParam)
                    .HasForeignKey(d => d.EnergyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GgeParam_Eng");
            });

            modelBuilder.Entity<GaugeParamTag>(entity =>
            {
                entity.Property(e => e.GaugeParamTagId).HasColumnName("GaugeParamTagID");

                entity.Property(e => e.GaugeId).HasColumnName("GaugeID");

                entity.Property(e => e.GaugeParamId).HasColumnName("GaugeParamID");

                entity.Property(e => e.GaugeValueExpression)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.IndicatedEnergyId).HasColumnName("IndicatedEnergyID");

                entity.Property(e => e.TagItemId).HasColumnName("TagItemID");

                entity.HasOne(d => d.Gauge)
                    .WithMany(p => p.GaugeParamTag)
                    .HasForeignKey(d => d.GaugeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GgeParamTag_Gge");

                entity.HasOne(d => d.TagItem)
                    .WithMany(p => p.GaugeParamTag)
                    .HasForeignKey(d => d.TagItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GgeParamTag_TagItem");
            });

            modelBuilder.Entity<GaugeSnapshot>(entity =>
            {
                entity.Property(e => e.GaugeSnapshotId).HasColumnName("GaugeSnapshotID");

                entity.Property(e => e.BeginDateTime).HasColumnType("datetime");

                entity.Property(e => e.BeginValue).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CurrentPrice).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.EndValue).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.EnergyId).HasColumnName("EnergyID");

                entity.Property(e => e.EnergyPropertyId).HasColumnName("EnergyPropertyID");

                entity.Property(e => e.GaugeId).HasColumnName("GaugeID");

                entity.Property(e => e.GaugeParamTagId).HasColumnName("GaugeParamTagID");

                entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WorkShiftId).HasColumnName("WorkShiftID");

                entity.HasOne(d => d.Gauge)
                    .WithMany(p => p.GaugeSnapshot)
                    .HasForeignKey(d => d.GaugeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GaugeSnapshot_Gauge");

                entity.HasOne(d => d.GaugeParamTag)
                    .WithMany(p => p.GaugeSnapshot)
                    .HasForeignKey(d => d.GaugeParamTagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GaugeSnapshot_GaugeParamTag");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.InventoryCode)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.InventoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NavigationItem>(entity =>
            {
                entity.Property(e => e.NavigationItemId).HasColumnName("NavigationItemID");

                entity.Property(e => e.ClassType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NavigationItemCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NavigationItemName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.NavigationItemSn).HasColumnName("NavigationItemSN");

                entity.Property(e => e.NavigationItemType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Params)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ParentId)
                    .IsRequired()
                    .HasColumnName("ParentID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SourceImageName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OperationLog>(entity =>
            {
                entity.HasIndex(e => e.Operation)
                    .HasName("IX_OptLog_Opt");

                entity.HasIndex(e => e.OperationType)
                    .HasName("IX_OptLog_OptType");

                entity.Property(e => e.OperationLogId).HasColumnName("OperationLogID");

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(25);

                entity.Property(e => e.LogType)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.OperatingSystem)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.OperatingTime).HasColumnType("datetime");

                entity.Property(e => e.Operation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OperationContent)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.OperatorName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SourceId)
                    .IsRequired()
                    .HasColumnName("SourceID")
                    .HasMaxLength(10);

                entity.Property(e => e.SourceType)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.TerminalName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductEnergyConsumption>(entity =>
            {
                entity.Property(e => e.ProductEnergyConsumptionId).HasColumnName("ProductEnergyConsumptionID");

                entity.Property(e => e.EnergyId).HasColumnName("EnergyID");

                entity.Property(e => e.EnergyRatio).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Expression)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.WorkProcessId).HasColumnName("WorkProcessID");

                entity.HasOne(d => d.Energy)
                    .WithMany(p => p.ProductEnergyConsumption)
                    .HasForeignKey(d => d.EnergyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrdEngCsp_Eng");

                entity.HasOne(d => d.WorkProcess)
                    .WithMany(p => p.ProductEnergyConsumption)
                    .HasForeignKey(d => d.WorkProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrdEngCsp_WorkPrc");
            });

            modelBuilder.Entity<ProductEnergyKpi>(entity =>
            {
                entity.ToTable("ProductEnergyKPI");

                entity.Property(e => e.ProductEnergyKpiid).HasColumnName("ProductEnergyKPIID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EnergyId).HasColumnName("EnergyID");

                entity.Property(e => e.InternalKpi)
                    .HasColumnName("InternalKPI")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.InternationalKpi)
                    .HasColumnName("InternationalKPI")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.LocalKpi)
                    .HasColumnName("LocalKPI")
                    .HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.Energy)
                    .WithMany(p => p.ProductEnergyKpi)
                    .HasForeignKey(d => d.EnergyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrdEngKPI_Eng");
            });

            modelBuilder.Entity<ProductionRecord>(entity =>
            {
                entity.Property(e => e.ProductionRecordId).HasColumnName("ProductionRecordID");

                entity.Property(e => e.CompletionDate).HasColumnType("datetime");

                entity.Property(e => e.CompletionQuantity).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.PlanningDate).HasColumnType("datetime");

                entity.Property(e => e.PlanningQuantity).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.RecordDateTime).HasColumnType("datetime");

                entity.Property(e => e.RecorderId).HasColumnName("RecorderID");

                entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");

                entity.Property(e => e.WorkShiftId).HasColumnName("WorkShiftID");

                entity.HasOne(d => d.Recorder)
                    .WithMany(p => p.ProductionRecord)
                    .HasForeignKey(d => d.RecorderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrdRcd_User");

                entity.HasOne(d => d.WorkCenter)
                    .WithMany(p => p.ProductionRecord)
                    .HasForeignKey(d => d.WorkCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrdRcd_WorkCtr");

                entity.HasOne(d => d.WorkShift)
                    .WithMany(p => p.ProductionRecord)
                    .HasForeignKey(d => d.WorkShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrdRcd_WorkShift");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK_SUPPLIER")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SupplierAddress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SupplierCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SupplierShortName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SystemSetting>(entity =>
            {
                entity.HasIndex(e => e.SystemSettingName)
                    .HasName("IX_Sys_Name");

                entity.HasIndex(e => e.SystemSettingType)
                    .HasName("IX_Sys_Type");

                entity.Property(e => e.SystemSettingId).HasColumnName("SystemSettingID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SystemSettingName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SystemSettingType)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.SystemSettingValue)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<TagItem>(entity =>
            {
                entity.Property(e => e.TagItemId).HasColumnName("TagItemID");

                entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TagTopic)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TagValue)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TechnologyImprovement>(entity =>
            {
                entity.Property(e => e.TechnologyImprovementId).HasColumnName("TechnologyImprovementID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EconomizeEnergyQuantity).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.EconomizeWaterQuantity).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.InvestmentAmount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.PaybackPeriod).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.SavingCost).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TechnologyImprovementDateTime).HasColumnType("datetime");

                entity.Property(e => e.TechnologyImprovementProgress).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TechnologyImprovementTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TechnologyImprovementType)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TechnologyImprovementGauge>(entity =>
            {
                entity.Property(e => e.TechnologyImprovementGaugeId).HasColumnName("TechnologyImprovementGaugeID");

                entity.Property(e => e.GaugeId).HasColumnName("GaugeID");

                entity.Property(e => e.TechnologyImprovementId).HasColumnName("TechnologyImprovementID");

                entity.HasOne(d => d.Gauge)
                    .WithMany(p => p.TechnologyImprovementGauge)
                    .HasForeignKey(d => d.GaugeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechImpGge_Gge");

                entity.HasOne(d => d.TechnologyImprovement)
                    .WithMany(p => p.TechnologyImprovementGauge)
                    .HasForeignKey(d => d.TechnologyImprovementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechImpGge_TechImp");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.UnitId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ExchangeRate).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.UnitCode)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UnitGroupId).HasColumnName("UnitGroupID");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.UnitGroup)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.UnitGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unit_UnitGroup");
            });

            modelBuilder.Entity<UnitGroup>(entity =>
            {
                entity.Property(e => e.UnitGroupId).HasColumnName("UnitGroupID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UnitGroupCode)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UnitGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.UserCode)
                    .HasName("IX_User_Code")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMail")
                    .HasMaxLength(50);

                entity.Property(e => e.MobilePhone)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRole_User");
            });

            modelBuilder.Entity<WebScada>(entity =>
            {
                entity.Property(e => e.WebScadaId).HasColumnName("WebScadaID");

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.EnergyId).HasColumnName("EnergyID");

                entity.Property(e => e.EquipmentType)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");

                entity.HasOne(d => d.Energy)
                    .WithMany(p => p.WebScada)
                    .HasForeignKey(d => d.EnergyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Scada_Eng");

                entity.HasOne(d => d.WorkCenter)
                    .WithMany(p => p.WebScada)
                    .HasForeignKey(d => d.WorkCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Scada_WorkCtr");
            });

            modelBuilder.Entity<WorkArea>(entity =>
            {
                entity.Property(e => e.WorkAreaId).HasColumnName("WorkAreaID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.WorkAreaCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.WorkAreaName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");

                entity.HasOne(d => d.WorkCenter)
                    .WithMany(p => p.WorkArea)
                    .HasForeignKey(d => d.WorkCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkArea_WorkCenter");
            });

            modelBuilder.Entity<WorkCenter>(entity =>
            {
                entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.WorkCenterCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.WorkCenterName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WorkCenterEnergyKpi>(entity =>
            {
                entity.ToTable("WorkCenterEnergyKPI");

                entity.Property(e => e.WorkCenterEnergyKpiid).HasColumnName("WorkCenterEnergyKPIID");

                entity.Property(e => e.EnergyId).HasColumnName("EnergyID");

                entity.Property(e => e.InternalKpivalue)
                    .HasColumnName("InternalKPIValue")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.InternationalKpivalue)
                    .HasColumnName("InternationalKPIValue")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.LocalKpivalue)
                    .HasColumnName("LocalKPIValue")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");

                entity.HasOne(d => d.Energy)
                    .WithMany(p => p.WorkCenterEnergyKpi)
                    .HasForeignKey(d => d.EnergyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkCtrEngKPI_Eng");

                entity.HasOne(d => d.WorkCenter)
                    .WithMany(p => p.WorkCenterEnergyKpi)
                    .HasForeignKey(d => d.WorkCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkCtrEngKPI_WorkCtr");
            });

            modelBuilder.Entity<WorkCenterInventory>(entity =>
            {
                entity.Property(e => e.WorkCenterInventoryId).HasColumnName("WorkCenterInventoryID");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");

                entity.Property(e => e.WorkCenterId).HasColumnName("WorkCenterID");

                entity.HasOne(d => d.WorkCenter)
                    .WithMany(p => p.WorkCenterInventory)
                    .HasForeignKey(d => d.WorkCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkCtrInv_WorkCtr");
            });

            modelBuilder.Entity<WorkProcess>(entity =>
            {
                entity.Property(e => e.WorkProcessId).HasColumnName("WorkProcessID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.WorkProcessCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.WorkProcessName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WorkProcessEquipment>(entity =>
            {
                entity.Property(e => e.WorkProcessEquipmentId).HasColumnName("WorkProcessEquipmentID");

                entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");

                entity.Property(e => e.WorkProcessId).HasColumnName("WorkProcessID");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.WorkProcessEquipment)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkPrcEqp_Eqp");

                entity.HasOne(d => d.WorkProcess)
                    .WithMany(p => p.WorkProcessEquipment)
                    .HasForeignKey(d => d.WorkProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkPrcEqp_WorkPrc");
            });

            modelBuilder.Entity<WorkProcessFlow>(entity =>
            {
                entity.Property(e => e.WorkProcessFlowId).HasColumnName("WorkProcessFlowID");

                entity.Property(e => e.InventoryId).HasColumnName("InventoryID");
            });

            modelBuilder.Entity<WorkProcessFlowDetail>(entity =>
            {
                entity.Property(e => e.WorkProcessFlowDetailId).HasColumnName("WorkProcessFlowDetailID");

                entity.Property(e => e.ProductionRadio).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.WorkProcessFlowId).HasColumnName("WorkProcessFlowID");

                entity.Property(e => e.WorkProcessId).HasColumnName("WorkProcessID");

                entity.HasOne(d => d.WorkProcessFlow)
                    .WithMany(p => p.WorkProcessFlowDetail)
                    .HasForeignKey(d => d.WorkProcessFlowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkPrcFlowDetail_WorkPrcFlow");

                entity.HasOne(d => d.WorkProcess)
                    .WithMany(p => p.WorkProcessFlowDetail)
                    .HasForeignKey(d => d.WorkProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkPrcFlowDetail_Inv");
            });

            modelBuilder.Entity<WorkShift>(entity =>
            {
                entity.Property(e => e.WorkShiftId).HasColumnName("WorkShiftID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.WorkShiftCode)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.WorkShiftName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}