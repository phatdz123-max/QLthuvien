
using QLTV.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLTV.BUS
{
    public class DocGiaBUS
    {
        private readonly Model1 _context;

        public DocGiaBUS()
        {
            _context = new Model1();
        }

        // 🔹 LẤY DANH SÁCH ĐỘC GIẢ (HIỂN THỊ TRỰC TIẾP NAM / NỮ)
        public List<object> GetAllForDisplay()
        {
            return _context.DOCGIAs
                .Select(x => new
                {
                    x.MaDocGia,
                    x.TenDocGia,
                    GioiTinh = x.GioiTinh,  // GIỜ ĐÃ LÀ STRING "Nam" / "Nữ"
                    x.NgaySinh,
                    x.SoCMND,
                    x.NgayDangKy
                })
                .ToList<object>();
        }

        // 🔹 LẤY TẤT CẢ DẠNG GỐC
        public List<DOCGIA> GetAll()
        {
            return _context.DOCGIAs.ToList();
        }

        // 🔹 THÊM MỚI
        public string Add(DOCGIA dg)
        {
            if (string.IsNullOrWhiteSpace(dg.MaDocGia) || string.IsNullOrWhiteSpace(dg.TenDocGia))
            {
                return "VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN!";
            }

            var exist = _context.DOCGIAs.FirstOrDefault(x => x.MaDocGia == dg.MaDocGia);
            if (exist != null)
            {
                return "MÃ ĐỘC GIẢ ĐÃ TỒN TẠI!";
            }

            _context.DOCGIAs.Add(dg);
            _context.SaveChanges();
            return "THÊM THÀNH CÔNG!";
        }

        // 🔹 CẬP NHẬT
        public string Update(DOCGIA dg)
        {
            var exist = _context.DOCGIAs.FirstOrDefault(x => x.MaDocGia == dg.MaDocGia);
            if (exist == null)
            {
                return "KHÔNG TÌM THẤY ĐỘC GIẢ!";
            }

            exist.TenDocGia = dg.TenDocGia;
            exist.GioiTinh = dg.GioiTinh;
            exist.NgaySinh = dg.NgaySinh;
            exist.SoCMND = dg.SoCMND;
            exist.NgayDangKy = dg.NgayDangKy;

            _context.SaveChanges();
            return "CẬP NHẬT THÀNH CÔNG!";
        }

        // 🔹 XÓA
        public string Delete(string maDG)
        {
            var exist = _context.DOCGIAs.FirstOrDefault(x => x.MaDocGia == maDG);
            if (exist == null)
            {
                return "KHÔNG TÌM THẤY ĐỘC GIẢ!";
            }

            _context.DOCGIAs.Remove(exist);
            _context.SaveChanges();
            return "XÓA THÀNH CÔNG!";
        }

        // 🔹 TÌM KIẾM
        public List<object> Search(string keyword, string type)
        {
            var query = _context.DOCGIAs.AsQueryable();

            if (type == "Mã Độc Giả")
                query = query.Where(x => x.MaDocGia.Contains(keyword));
            else if (type == "Tên Độc Giả")
                query = query.Where(x => x.TenDocGia.Contains(keyword));
            return query
                .Select(x => new
                {
                    x.MaDocGia,
                    x.TenDocGia,
                    GioiTinh = x.GioiTinh,
                    x.NgaySinh,
                    x.SoCMND,
                    x.NgayDangKy
                })
                .ToList<object>();
        }
    }
}
