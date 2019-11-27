using System;
using Colipu.BasicData.API.Core.BSystemDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Colipu.BasicData.API.EntityFrameworkCore.BSystemDB
{
    public partial class BSystemDBContext : DbContext
    {

        #region origin 
        public BSystemDBContext()
        {
        }

        public BSystemDBContext(DbContextOptions<BSystemDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Tbranch { get; set; }
        public virtual DbSet<City> Tcity { get; set; }
        public virtual DbSet<District> Tdistrict { get; set; }
        public virtual DbSet<Ecsite> Tecsite { get; set; }
        public virtual DbSet<EcsiteBranch> TecsiteBranch { get; set; }
        public virtual DbSet<Holiday> Tholiday { get; set; }
        public virtual DbSet<PayType> TpayType { get; set; }
        public virtual DbSet<PayTypeRelationSite> TpayTypeRelationSite { get; set; }
        public virtual DbSet<Province> Tprovince { get; set; }
        public virtual DbSet<ShipType> TshipType { get; set; }
        public virtual DbSet<ShipTypeUnDistrib> TshipTypeUnDistrib { get; set; }
        public virtual DbSet<ShipTypeUnPay> TshipTypeUnPay { get; set; }
        public virtual DbSet<Warehouse> Twarehouse { get; set; }
        public virtual DbSet<WarehouseDeliveryArea> TwarehouseDeliveryArea { get; set; }
        public virtual DbSet<WarehouseShipType> TwarehouseShipType { get; set; }

        public virtual DbSet<Channel> Tchannel { get; set; }


        // Unable to generate entity type for table 'dbo.TCity_test'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TDistrict_test'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TProvince_test'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=10.10.4.201;User ID=sa;Password=colipu;Database=BSystemDB;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(e => e.BranchId)
                    .HasName("PK_TBRANCH");

                entity.ToTable("TBranch");

                entity.Property(e => e.AuthorizationCode).HasMaxLength(50);

                entity.Property(e => e.BranchAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BranchBank)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BranchBankCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.BranchEnglishName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BranchFaxNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BranchFullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BranchPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BranchPostcode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FhruserId)
                    .HasColumnName("FHRUserId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsSupportElecInvoice)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.Keys).HasMaxLength(100);

                entity.Property(e => e.KpyuserId)
                    .HasColumnName("KPYUserId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SellerAddress).HasMaxLength(100);

                entity.Property(e => e.SellerBankCode).HasMaxLength(50);

                entity.Property(e => e.SellerBankName).HasMaxLength(50);

                entity.Property(e => e.SellerPhone).HasMaxLength(50);

                entity.Property(e => e.SkyuserId)
                    .HasColumnName("SKYUserId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.TaxpayerId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.Version).HasMaxLength(3);
            });


            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK_TCITY");

                entity.ToTable("TCity");

                entity.Property(e => e.CityId).ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.PhoneticizeFullName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PhoneticizeShortName)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });


            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.DistrictId)
                    .HasName("PK_TDISTRICT");

                entity.ToTable("TDistrict");

                entity.Property(e => e.DistrictId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneticizeFullName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PhoneticizeShortName)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });


            modelBuilder.Entity<Ecsite>(entity =>
            {
                entity.HasKey(e => e.SiteId)
                    .HasName("PK_TECSITE");

                entity.ToTable("TECSite");

                entity.Property(e => e.SiteId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SiteName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<EcsiteBranch>(entity =>
            {
                entity.HasKey(e => new { e.SiteId, e.BranchId })
                    .HasName("PK_TECSITEBRANCH");

                entity.ToTable("TECSiteBranch");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });



            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasKey(e => e.HolidayId)
                    .HasName("PK_THOLIDAY");

                entity.ToTable("THoliday");

                entity.Property(e => e.HolidayId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });


            //modelBuilder.Entity<LogicalWarehouse>(entity =>
            //{
            //    entity.HasKey(e => e.LogicalWarehouseId)
            //        .HasName("PK_TLOGICALWAREHOUSE");

            //    entity.ToTable("TLogicalWarehouse");

            //    entity.HasIndex(e => e.LogicalWarehouseCode)
            //        .HasName("idx_TLogicalWarehouse_LogicalWarehouseCode");

            //    entity.Property(e => e.LogicalWarehouseId).ValueGeneratedNever();

            //    entity.Property(e => e.Address)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.Contact)
            //        .IsRequired()
            //        .HasMaxLength(20);

            //    entity.Property(e => e.CreateTime).HasColumnType("datetime");

            //    entity.Property(e => e.IsAutomaticAudit)
            //        .IsRequired()
            //        .HasMaxLength(1);

            //    entity.Property(e => e.IsDefault)
            //        .IsRequired()
            //        .HasMaxLength(1);

            //    entity.Property(e => e.IsSyncWms)
            //        .IsRequired()
            //        .HasMaxLength(1);

            //    entity.Property(e => e.LogicalWarehouseCode)
            //        .IsRequired()
            //        .HasMaxLength(20);

            //    entity.Property(e => e.LogicalWarehouseFlag)
            //        .IsRequired()
            //        .HasMaxLength(1)
            //        .HasDefaultValueSql("('')");

            //    entity.Property(e => e.LogicalWarehouseName)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.LogicalWarehouseType)
            //        .IsRequired()
            //        .HasMaxLength(1);

            //    entity.Property(e => e.Phone)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.Postalcode)
            //        .IsRequired()
            //        .HasMaxLength(10);

            //    entity.Property(e => e.Region)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.Status)
            //        .IsRequired()
            //        .HasMaxLength(1);

            //    entity.Property(e => e.UpdateTime).HasColumnType("datetime");

            //    entity.Property(e => e.WmsWarehouseId)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});

            modelBuilder.Entity<PayType>(entity =>
            {
                entity.HasKey(e => e.PayTypeId)
                    .HasName("PK_TPAYTYPE");

                entity.ToTable("TPayType");

                entity.Property(e => e.PayTypeId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.IsWebsiteShow)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.PayClass)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.PayPageUrl)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PayTypeCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PayTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<PayTypeRelationSite>(entity =>
            {
                entity.HasKey(e => e.RelationId);

                entity.ToTable("TPayTypeRelationSite");

                entity.Property(e => e.RelationId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.IsShow)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });



            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.ProvinceId)
                    .HasName("PK_TPROVINCE");

                entity.ToTable("TProvince");

                entity.Property(e => e.ProvinceId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.PhoneticizeFullName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PhoneticizeShortName)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });



            modelBuilder.Entity<ShipType>(entity =>
            {
                entity.HasKey(e => e.ShipTypeId)
                    .HasName("PK_TSHIPTYPE");

                entity.ToTable("TShipType");

                entity.Property(e => e.ShipTypeId).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.FreeShipBase).HasColumnType("decimal(19, 6)");

                entity.Property(e => e.IsSendInvoice)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.IsShipLarge)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.IsSynTms)
                    .IsRequired()
                    .HasColumnName("IsSynTMS")
                    .HasMaxLength(1);

                entity.Property(e => e.ServiceLevel)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.ShipTypeCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ShipTypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });


            modelBuilder.Entity<ShipTypeUnDistrib>(entity =>
            {
                entity.HasKey(e => e.UnDistribId)
                    .HasName("PK__TShipTyp__5B41E2EFB5AACFC5");

                entity.ToTable("TShipTypeUnDistrib");

                entity.HasIndex(e => new { e.ShipTypeId, e.AreaId })
                    .HasName("UQ__TShipTyp__E5D752BDCD841631")
                    .IsUnique();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<ShipTypeUnPay>(entity =>
            {
                entity.HasKey(e => e.UnPayId)
                    .HasName("PK__TShipTyp__7EDAEFBB54582135");

                entity.ToTable("TShipTypeUnPay");

                entity.HasIndex(e => new { e.ShipTypeId, e.PayTypeId })
                    .HasName("UQ__TShipTyp__461646808D7CF025")
                    .IsUnique();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });


            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.WarehouseId)
                    .HasName("PK_TWAREHOUSE");

                entity.ToTable("TWarehouse");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.WarehouseCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WarehouseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WarehouseDeliveryArea>(entity =>
            {
                entity.HasKey(e => new { e.WarehouseId, e.CityId })
                    .HasName("PK_TWAREHOUSEDELIVERYAREA");

                entity.ToTable("TWarehouseDeliveryArea");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });


            modelBuilder.Entity<WarehouseShipType>(entity =>
            {
                entity.HasKey(e => new { e.WarehouseId, e.ShipTypeId })
                    .HasName("PK_TWAREHOUSESHIPTYPE");

                entity.ToTable("TWarehouseShipType");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });


            modelBuilder.Entity<Channel>(entity =>
            {
                entity.HasKey(e => e.ChannelId)
                    .HasName("PK_TCHANNEL");

                entity.ToTable("TChannel");

                entity.Property(e => e.ChannelCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ChannelName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });



        }
        #endregion

    }
}
