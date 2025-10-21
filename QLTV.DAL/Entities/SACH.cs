namespace QLTV.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            MUONTRAs = new HashSet<MUONTRA>();
        }

        [Key]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSach { get; set; }

        [StringLength(100)]
        public string TacGia { get; set; }

        [StringLength(50)]
        public string TheLoai { get; set; }

        [StringLength(100)]
        public string NhaXuatBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayXuatBan { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "money")]
        public decimal? Gia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MUONTRA> MUONTRAs { get; set; }
    }
}
