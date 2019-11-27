using Colipu.BasicData.API.Core.ECPubDB;
using Microsoft.EntityFrameworkCore;
using System;


namespace Colipu.BasicData.API.EntityFrameworkCore.ECPubDB
{
    public partial class ECPubDBContext : DbContext
    {
        public ECPubDBContext()
        {
        }

        public ECPubDBContext(DbContextOptions<ECPubDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SaleDistrict> TsaleDistrict { get; set; }

        // Unable to generate entity type for table 'dbo.MGItemPicture2019'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.商品List$'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Sheet1$'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ecpubdb0902低性能sql$'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SQL20190902'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SMBMap$'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.cartinfo$'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.test$'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TBranch_REPL'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TChannel_REPL'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.账号可视范围设置'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=10.10.4.201;User ID=sa;Password=colipu;Database=ECPubDB;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<SaleDistrict>(entity =>
            {
                entity.HasKey(e => e.DistrictId)
                    .HasName("PK_TSALEDISTRICT");

                entity.ToTable("TSaleDistrict");

                entity.Property(e => e.DistrictId).ValueGeneratedNever();

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });


        }
    }
}
