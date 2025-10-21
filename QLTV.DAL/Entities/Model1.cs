using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLTV.DAL.Entities
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<DOCGIA> DOCGIAs { get; set; }
        public virtual DbSet<LOGIN> LOGINs { get; set; }
        public virtual DbSet<MUONTRA> MUONTRAs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DOCGIA>()
                .Property(e => e.MaDocGia)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOCGIA>()
                .HasMany(e => e.MUONTRAs)
                .WithRequired(e => e.DOCGIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOGIN>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<LOGIN>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<MUONTRA>()
                .Property(e => e.MaDocGia)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MUONTRA>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.Gia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.MUONTRAs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);
        }
    }
}
