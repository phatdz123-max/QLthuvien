namespace QLTV.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DOCGIA",
                c => new
                    {
                        MaDocGia = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        TenDocGia = c.String(nullable: false, maxLength: 100),
                        GioiTinh = c.String(maxLength: 10),
                        NgaySinh = c.DateTime(storeType: "date"),
                        SoCMND = c.String(maxLength: 20),
                        NgayDangKy = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.MaDocGia);
            
            CreateTable(
                "dbo.MUONTRA",
                c => new
                    {
                        MaMuonTra = c.String(nullable: false, maxLength: 10),
                        MaDocGia = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        MaSach = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        NgayMuon = c.DateTime(nullable: false, storeType: "date"),
                        NgayTra = c.DateTime(storeType: "date"),
                        SoLuong = c.Int(nullable: false),
                        TrangThai = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.MaMuonTra)
                .ForeignKey("dbo.SACH", t => t.MaSach)
                .ForeignKey("dbo.DOCGIA", t => t.MaDocGia)
                .Index(t => t.MaDocGia)
                .Index(t => t.MaSach);
            
            CreateTable(
                "dbo.SACH",
                c => new
                    {
                        MaSach = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        TenSach = c.String(nullable: false, maxLength: 100),
                        TacGia = c.String(maxLength: 100),
                        TheLoai = c.String(maxLength: 50),
                        NhaXuatBan = c.String(maxLength: 100),
                        NgayXuatBan = c.DateTime(storeType: "date"),
                        SoLuong = c.Int(),
                        Gia = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.MaSach);
            
            CreateTable(
                "dbo.LOGIN",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50, fixedLength: true),
                        Password = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MUONTRA", "MaDocGia", "dbo.DOCGIA");
            DropForeignKey("dbo.MUONTRA", "MaSach", "dbo.SACH");
            DropIndex("dbo.MUONTRA", new[] { "MaSach" });
            DropIndex("dbo.MUONTRA", new[] { "MaDocGia" });
            DropTable("dbo.LOGIN");
            DropTable("dbo.SACH");
            DropTable("dbo.MUONTRA");
            DropTable("dbo.DOCGIA");
        }
    }
}
