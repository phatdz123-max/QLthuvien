namespace QLTV.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MUONTRA")]
    public partial class MUONTRA
    {
        [Key]
        public int MaMuonTra { get; set; }

        [Required]
        [StringLength(10)]
        public string MaDocGia { get; set; }

        [Required]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayMuon { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTra { get; set; }

        public int SoLuong { get; set; }

        [StringLength(20)]
        public string TrangThai { get; set; }

        public virtual DOCGIA DOCGIA { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
