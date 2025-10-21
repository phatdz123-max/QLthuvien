using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.DAL;
using QLTV.DAL.Entities;

namespace QLTV.BUS
{
    public class SachBUS
    {
        // 1️⃣ LẤY TOÀN BỘ DANH SÁCH SÁCH
        public List<SACH> GetAll()
        {
            using (var db = new Model1())
            {
                return db.SACHes.ToList();
            }
        }

        // 2️⃣ THÊM SÁCH MỚI
        public bool Add(SACH sach)
        {
            using (var db = new Model1())
            {
                if (db.SACHes.Any(s => s.MaSach == sach.MaSach))
                    return false; // ĐÃ TỒN TẠI

                db.SACHes.Add(sach);
                db.SaveChanges();
                return true;
            }
        }

        // 3️⃣ CẬP NHẬT THÔNG TIN SÁCH
        public bool Update(SACH sach)
        {
            using (var db = new Model1())
            {
                var existing = db.SACHes.FirstOrDefault(s => s.MaSach == sach.MaSach);
                if (existing == null) return false;

                existing.TenSach = sach.TenSach;
                existing.TacGia = sach.TacGia;
                existing.TheLoai = sach.TheLoai;
                existing.NhaXuatBan = sach.NhaXuatBan;
                existing.NgayXuatBan = sach.NgayXuatBan;
                existing.SoLuong = sach.SoLuong;
                existing.Gia = sach.Gia;

                db.SaveChanges();
                return true;
            }
        }

        // 4️⃣ XÓA SÁCH
        public bool Delete(string maSach)
        {
            using (var db = new Model1())
            {
                var sach = db.SACHes.FirstOrDefault(s => s.MaSach == maSach);
                if (sach == null) return false;

                db.SACHes.Remove(sach);
                db.SaveChanges();
                return true;
            }
        }

        // 5️⃣ TÌM KIẾM SÁCH THEO TÊN HOẶC TÁC GIẢ
        public List<SACH> Search(string keyword)
        {
            using (var db = new Model1())
            {
                return db.SACHes
                         .Where(s => s.TenSach.Contains(keyword) ||
                                     s.TacGia.Contains(keyword))
                         .ToList();
            }
        }
    }
}
