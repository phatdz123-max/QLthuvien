using QLTV.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLTV.BUS
{
    public class MuonTraBUS
    {
        private readonly Model1 _context;

        public MuonTraBUS()
        {
            _context = new Model1();
        }

        // LẤY TOÀN BỘ DỮ LIỆU
        public List<MUONTRA> GetAll()
        {
            return _context.MUONTRAs.ToList();
        }

        
        public string Add(MUONTRA mt)
        {
            if (string.IsNullOrWhiteSpace(mt.MaDocGia) || string.IsNullOrWhiteSpace(mt.MaSach))
                return "VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN!";

            var exist = _context.MUONTRAs.FirstOrDefault(x => x.MaMuonTra == mt.MaMuonTra);
            if (exist != null)
                return "MÃ MƯỢN TRẢ ĐÃ TỒN TẠI!";

            _context.MUONTRAs.Add(mt);
            _context.SaveChanges();
            return "THÊM THÀNH CÔNG!";
        }
        public string Update(MUONTRA mt)
        {
            // 🔹 KIỂM TRA DỮ LIỆU NHẬP VÀO
            if (string.IsNullOrWhiteSpace(mt.MaDocGia) ||
                string.IsNullOrWhiteSpace(mt.MaSach) ||
                mt.SoLuong <= 0 ||
                mt.NgayMuon == default(DateTime) ||
                mt.NgayTra == default(DateTime))
            {
                return "VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN TRƯỚC KHI CẬP NHẬT!";
            }

            var exist = _context.MUONTRAs.FirstOrDefault(x => x.MaMuonTra == mt.MaMuonTra);
            if (exist == null)
                return "KHÔNG TÌM THẤY MÃ MƯỢN TRẢ!";
            exist.MaDocGia = mt.MaDocGia;
            exist.MaSach = mt.MaSach;
            exist.NgayMuon = mt.NgayMuon;
            exist.NgayTra = mt.NgayTra;
            exist.SoLuong = mt.SoLuong;
            exist.TrangThai = mt.TrangThai;
            try
            {
                _context.SaveChanges();
                return "CẬP NHẬT THÀNH CÔNG!";
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                string msg = "DỮ LIỆU KHÔNG HỢP LỆ:\n";
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        msg += $"- {ve.PropertyName}: {ve.ErrorMessage}\n";
                    }
                }
                return msg;
            }
            catch (Exception ex)
            {
                return $"LỖI HỆ THỐNG: {ex.Message}";
            }
        }

        public string ReturnBook(string maMuon)
        {
            var exist = _context.MUONTRAs.FirstOrDefault(x => x.MaMuonTra == maMuon);

            if (exist == null)
                return "KHÔNG TÌM THẤY MÃ MƯỢN TRẢ!";

            if (exist.TrangThai == "Đã Trả")
                return "SÁCH NÀY ĐÃ ĐƯỢC TRẢ TRƯỚC ĐÓ!";

            exist.TrangThai = "Đã Trả";
            exist.NgayTra = DateTime.Now;

            _context.SaveChanges();
            return "TRẢ SÁCH THÀNH CÔNG!";
        }

        public List<MUONTRA> Search(string keyword, string searchType)
        {
            keyword = keyword?.Trim().ToLower();

            IQueryable<MUONTRA> query = _context.MUONTRAs;

            switch (searchType)
            {
                case "Mã Độc Giả":
                    query = query.Where(x => x.MaDocGia.ToLower().Contains(keyword));
                    break;

                case "Mã Sách":
                    query = query.Where(x => x.MaSach.ToLower().Contains(keyword));
                    break;             
                default:
                    return new List<MUONTRA>();
            }

            return query.ToList();
        }
        // XÓA PHIẾU MƯỢN
        public string Delete(string maMuon)
        {
            var exist = _context.MUONTRAs.FirstOrDefault(x => x.MaMuonTra == maMuon);
            if (exist == null)
                return "KHÔNG TÌM THẤY MÃ MƯỢN TRẢ!";

            _context.MUONTRAs.Remove(exist);
            _context.SaveChanges();
            return "XÓA THÀNH CÔNG!";
        }
    }
}

