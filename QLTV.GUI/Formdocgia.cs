using QLTV.BUS;
using QLTV.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class Formdocgia : Form
    {
        private readonly DocGiaBUS bus = new DocGiaBUS();

        public Formdocgia()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            dgvDocGia.DataSource = bus.GetAll();
            dgvDocGia.DataSource = bus.GetAllForDisplay();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dgvDocGia.SelectedRows.Count == 0)
            {
                MessageBox.Show("VUI LÒNG CHỌN DÒNG CẦN XÓA!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // LẤY MÃ ĐỘC GIẢ CỦA DÒNG ĐANG CHỌN
            string maDG = dgvDocGia.SelectedRows[0].Cells["MaDocGia"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"BẠN CÓ CHẮC MUỐN XÓA ĐỘC GIẢ '{maDG}' KHÔNG?",
                "XÁC NHẬN XÓA",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                string msg = bus.Delete(maDG);
                MessageBox.Show(msg, "KẾT QUẢ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // CẬP NHẬT LẠI DỮ LIỆU SAU KHI XÓA
            }
        }

        private void Formdocgia_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string keyword = txttimkiem.Text.Trim();
            string searchType = cbotktheo.Text;

            // KIỂM TRA COMBOBOX
            if (string.IsNullOrEmpty(searchType))
            {
                MessageBox.Show("VUI LÒNG CHỌN TIÊU CHÍ TÌM KIẾM!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // KIỂM TRA NHẬP LIỆU
            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("VUI LÒNG NHẬP DỮ LIỆU CẦN TÌM!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // GỌI BUS ĐỂ TÌM
            var result = bus.Search(keyword, searchType);

            // NẾU KHÔNG CÓ KẾT QUẢ
            if (result == null || result.Count == 0)
            {
                MessageBox.Show("KHÔNG TÌM THẤY KẾT QUẢ PHÙ HỢP!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // HIỂN THỊ LÊN DGV
            dgvDocGia.DataSource = null;
            dgvDocGia.DataSource = result;

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmadocgia.Text))
            {
                MessageBox.Show("VUI LÒNG CHỌN ĐỘC GIẢ CẦN SỬA!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DOCGIA dg = new DOCGIA
            {
                MaDocGia = txtmadocgia.Text,
                TenDocGia = txttendocgia.Text,
                GioiTinh = rdbnam.Checked ? "Nam" : "Nữ",
                NgaySinh = dtpNgaySinh.Value,
                SoCMND = txtcmnd.Text,
                NgayDangKy = dtpNgayDangKy.Value
            };

            string result = bus.Update(dg);
            MessageBox.Show(result, "KẾT QUẢ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void dgvDocGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDocGia.Rows[e.RowIndex];

                txtmadocgia.Text = row.Cells["MaDocGia"].Value?.ToString();
                txttendocgia.Text = row.Cells["TenDocGia"].Value?.ToString();

                string gt = row.Cells["GioiTinh"].Value?.ToString();
                if (gt == "Nam")
                    rdbnam.Checked = true;
                else
                    rdbnu.Checked = true;

                if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ns))
                    dtpNgaySinh.Value = ns;

                txtcmnd.Text = row.Cells["SoCMND"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgayDangKy"].Value?.ToString(), out DateTime ndk))
                    dtpNgayDangKy.Value = ndk;
            }
        }
        private void ClearInput()
        {
            txtmadocgia.Clear();
            txttendocgia.Clear();
            txtcmnd.Clear();
            rdbnam.Checked = false;
            rdbnu.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
            dtpNgayDangKy.Value = DateTime.Now;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmadocgia.Text) ||
        string.IsNullOrWhiteSpace(txttendocgia.Text) ||
        string.IsNullOrWhiteSpace(txtcmnd.Text))
            {
                MessageBox.Show("VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TẠO ĐỐI TƯỢNG DOCGIA MỚI
            DOCGIA dg = new DOCGIA
            {
                MaDocGia = txtmadocgia.Text.Trim(),
                TenDocGia = txttendocgia.Text.Trim(),
                GioiTinh = rdbnam.Checked ? "Nam" : "Nữ",
                NgaySinh = dtpNgaySinh.Value,
                SoCMND = txtcmnd.Text.Trim(),
                NgayDangKy = dtpNgayDangKy.Value
            };

            // GỌI BUS ĐỂ THÊM
            string result = bus.Add(dg);
            MessageBox.Show(result, "KẾT QUẢ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // NẾU THÊM THÀNH CÔNG → LÀM MỚI
            if (result == "THÊM THÀNH CÔNG!")
            {
                LoadData();
                ClearInput();
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            txttimkiem.Clear();
            txttendocgia.Clear();
            txtmadocgia.Clear();
            txtcmnd.Clear();
            LoadData();
        }
    }
}
