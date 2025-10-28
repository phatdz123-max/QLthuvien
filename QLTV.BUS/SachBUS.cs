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

        public SACH GetById(string maSach)
        {
            using (var db = new Model1())
            {
                return db.SACHes.FirstOrDefault(s => s.MaSach == maSach);
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
        public string UpdateSua(SACH updated)
        {
            using (var db = new Model1())
            {
                var exist = db.SACHes.FirstOrDefault(s => s.MaSach == updated.MaSach);
                if (exist == null)
                    return "KHÔNG TÌM THẤY MÃ SÁCH!";

                exist.TenSach = updated.TenSach;
                exist.TacGia = updated.TacGia;
                exist.TheLoai = updated.TheLoai;
                exist.NhaXuatBan = updated.NhaXuatBan;
                exist.SoLuong = updated.SoLuong;
                exist.Gia = updated.Gia;
                exist.NgayXuatBan = updated.NgayXuatBan;

                db.SaveChanges();
                return "CẬP NHẬT THÀNH CÔNG!";
            }
        }

        public List<SACH> Search(string field, string keyword)
        {
            using (var db = new Model1())
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return db.SACHes.ToList();

                keyword = keyword.ToLower().Trim();

                switch (field)
                {
                    case "Mã Sách":
                        return db.SACHes
                            .Where(s => s.MaSach.ToLower().Contains(keyword))
                            .ToList();

                    case "Tên Sách":
                        return db.SACHes
                            .Where(s => s.TenSach.ToLower().Contains(keyword))
                            .ToList();

                    case "Tác Giả":
                        return db.SACHes
                            .Where(s => s.TacGia.ToLower().Contains(keyword))
                            .ToList();

                    case "Thể Loại":
                        return db.SACHes
                            .Where(s => s.TheLoai.ToLower().Contains(keyword))
                            .ToList();

                    case "Nhà Xuất Bản":
                        return db.SACHes
                            .Where(s => s.NhaXuatBan.ToLower().Contains(keyword))
                            .ToList();

                    default:
                        return db.SACHes.ToList();
                }
            }
        }
    }
}
