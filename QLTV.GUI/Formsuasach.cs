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

namespace QLTV.GUI
{
    public partial class Formsuasach : Form
    {
        private readonly SachBUS sachBUS = new SachBUS();
        private SACH currentSach;

        public Formsuasach()
        {
            InitializeComponent();
        }
        public void LoadData(SACH sach)
        {
            currentSach = sach;

            txtmasach.Text = sach.MaSach;
            txttensach.Text = sach.TenSach;
            txttacgia.Text = sach.TacGia;
            txttheloai.Text = sach.TheLoai;
            txtsoluong.Text = sach.SoLuong.ToString();
            txtsotien.Text = sach.Gia.ToString();
            txtNhaXB.Text = sach.NhaXuatBan;
            dtpngayxb.Value = (DateTime)sach.NgayXuatBan;

            txtmasach.Enabled = false; // KHÔNG CHO SỬA KHÓA CHÍNH
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txttensach.Text))
            {
                MessageBox.Show("TÊN SÁCH KHÔNG ĐƯỢC ĐỂ TRỐNG!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttensach.Focus();
                return false;
            }

            if (!int.TryParse(txtsoluong.Text, out int sl) || sl < 0)
            {
                MessageBox.Show("SỐ LƯỢNG PHẢI LÀ SỐ NGUYÊN DƯƠNG!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsoluong.Focus();
                return false;
            }

            if (!decimal.TryParse(txtsotien.Text, out decimal gia) || gia < 0)
            {
                MessageBox.Show("SỐ TIỀN PHẢI LÀ SỐ DƯƠNG!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsotien.Focus();
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentSach == null)
            {
                MessageBox.Show("KHÔNG CÓ DỮ LIỆU ĐỂ CẬP NHẬT!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInput())
                return;

            currentSach.TenSach = txttensach.Text.Trim();
            currentSach.TacGia = txttacgia.Text.Trim();
            currentSach.TheLoai = txttheloai.Text.Trim();
            currentSach.NhaXuatBan = txtNhaXB.Text.Trim();
            currentSach.SoLuong = int.Parse(txtsoluong.Text);
            currentSach.Gia = decimal.Parse(txtsotien.Text);
            currentSach.NgayXuatBan = dtpngayxb.Value;

            string result = sachBUS.UpdateSua(currentSach);
            MessageBox.Show(result, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void Formsuasach_Load(object sender, EventArgs e)
        {

        }

        private void btnthoat(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlqltv_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
