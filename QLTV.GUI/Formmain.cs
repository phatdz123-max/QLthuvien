using System;
using System.Windows.Forms;
using QLTV.BUS;
using QLTV.DAL.Entities;
namespace QLTV
{
    public partial class frmmain : Form
    {
        public frmmain()
        {
            InitializeComponent();
            LoadData();
        }
        

        private void ClearText()
        {
            txtmasach.Clear();
            txttensach.Clear();
            txttacgia.Clear();
            txttheloai.Clear();
            txtNhaXB.Clear();
            txtsoluong.Clear();
            txtsotien.Clear();
        }
        private void LoadData()
        {
            dgvSach.DataSource = sachBUS.GetAll();
            if (dgvSach.Columns["MUONTRAs"] != null)
                dgvSach.Columns["MUONTRAs"].Visible = false;
        }
        private readonly SachBUS sachBUS = new SachBUS();
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void quảnLýMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formmuon formmuon = new Formmuon();
            FormManagerBUS.OpenChildForm(formmuon, this.pnlmain);
        }

        private void quảnLýĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formdocgia formdocgia = new Formdocgia();
            FormManagerBUS.OpenChildForm(formdocgia, this.pnlmain);
        }

        private void tìmKiếmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formtimkiemsach formtimkiemsach = new Formtimkiemsach();
            FormManagerBUS.OpenChildForm(formtimkiemsach, this.pnlmain);
        }

        private void quảnLýTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formtra formtra = new Formtra();
            FormManagerBUS.OpenChildForm(formtra, this.pnlmain);

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            var sach = new SACH
            {
                MaSach = txtmasach.Text.Trim(),
                TenSach = txttensach.Text.Trim(),
                TacGia = txttacgia.Text.Trim(),
                TheLoai = txttheloai.Text.Trim(),
                NhaXuatBan = txtNhaXB.Text.Trim(),
                NgayXuatBan = dtpngayxb.Value,
                SoLuong = int.Parse(txtsoluong.Text),
                Gia = decimal.Parse(txtsotien.Text)
            };

            if (sachBUS.Add(sach))
            {
                MessageBox.Show("THÊM SÁCH THÀNH CÔNG!", "THÔNG BÁO");
                LoadData();
                ClearText();
            }
            else
            {
                MessageBox.Show("MÃ SÁCH ĐÃ TỒN TẠI!", "LỖI");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmasach.Text) ||
         string.IsNullOrWhiteSpace(txttensach.Text))
            {
                MessageBox.Show("VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN!", "CẢNH BÁO");
                return;
            }

            // CHUYỂN ĐỔI AN TOÀN
            if (!int.TryParse(txtsoluong.Text, out int soLuong))
            {
                MessageBox.Show("SỐ LƯỢNG PHẢI LÀ SỐ NGUYÊN!", "LỖI ĐỊNH DẠNG");
                return;
            }

            if (!decimal.TryParse(txtsotien.Text, out decimal gia))
            {
                MessageBox.Show("SỐ TIỀN KHÔNG HỢP LỆ!", "LỖI ĐỊNH DẠNG");
                return;
            }

            var sach = new SACH
            {
                MaSach = txtmasach.Text.Trim(),
                TenSach = txttensach.Text.Trim(),
                TacGia = txttacgia.Text.Trim(),
                TheLoai = txttheloai.Text.Trim(),
                NhaXuatBan = txtNhaXB.Text.Trim(),
                NgayXuatBan = dtpngayxb.Value,
                SoLuong = soLuong,
                Gia = gia
            };

            if (sachBUS.Update(sach))
            {
                MessageBox.Show("CẬP NHẬT THÀNH CÔNG!", "THÔNG BÁO");
                LoadData();
            }
            else
            {
                MessageBox.Show("KHÔNG TÌM THẤY SÁCH!", "LỖI");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (sachBUS.Delete(txtmasach.Text.Trim()))
            {
                MessageBox.Show("XÓA THÀNH CÔNG!", "THÔNG BÁO");
                LoadData();
                ClearText();
            }
            else
            {
                MessageBox.Show("KHÔNG TÌM THẤY SÁCH!", "LỖI");
            }
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSach.Rows[e.RowIndex];

                txtmasach.Text = row.Cells["MaSach"].Value?.ToString();
                txttensach.Text = row.Cells["TenSach"].Value?.ToString();
                txttacgia.Text = row.Cells["TacGia"].Value?.ToString();
                txttheloai.Text = row.Cells["TheLoai"].Value?.ToString();
                txtNhaXB.Text = row.Cells["NhaXuatBan"].Value?.ToString();

                if (row.Cells["NgayXuatBan"].Value != null)
                    dtpngayxb.Value = Convert.ToDateTime(row.Cells["NgayXuatBan"].Value);

                txtsoluong.Text = row.Cells["SoLuong"].Value?.ToString();
                txtsotien.Text = row.Cells["Gia"].Value?.ToString();
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            ClearText();
            LoadData();
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmmain frmmain = new frmmain();
            FormManagerBUS.OpenChildForm(frmmain, this.pnlmain);
            frmmain.menuStrip1.Visible = false;
        }
    }
}
