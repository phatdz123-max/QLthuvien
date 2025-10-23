using QLTV.BUS;
using QLTV.GUI;
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
    public partial class Formtimkiemsach : Form
    {
        private readonly SachBUS sachBUS = new SachBUS();
        public Formtimkiemsach()
        {
            InitializeComponent();
        }

        private void Formtimkiemsach_Load(object sender, EventArgs e)
        {
            dgvSach.AllowUserToAddRows = false;
            dgvSach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSach.ReadOnly = true;
            dgvSach.DataSource = sachBUS.GetAll();
            if (dgvSach.Columns["MUONTRAs"] != null)
                dgvSach.Columns["MUONTRAs"].Visible = false;
            cboTimKiemTheo.Items.Add("Mã Sách");
            cboTimKiemTheo.Items.Add("Tên Sách");
            cboTimKiemTheo.Items.Add("Tác Giả");
            cboTimKiemTheo.Items.Add("Thể Loại");
            cboTimKiemTheo.SelectedIndex = -1;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dgvSach.CurrentRow == null)
            {
                MessageBox.Show("VUI LÒNG CHỌN DÒNG CẦN SỬA!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSach = dgvSach.CurrentRow.Cells["MaSach"].Value?.ToString();
            if (string.IsNullOrEmpty(maSach))
            {
                MessageBox.Show("KHÔNG XÁC ĐỊNH ĐƯỢC MÃ SÁCH!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sach = sachBUS.GetById(maSach);
            if (sach == null)
            {
                MessageBox.Show("KHÔNG TÌM THẤY SÁCH!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Formsuasach frm = new Formsuasach();
            frm.LoadData(sach);
            frm.ShowDialog();

            dgvSach.DataSource = sachBUS.GetAll();
        }
   

        private void btntim_Click(object sender, EventArgs e)
        {
            if (cboTimKiemTheo.SelectedIndex == -1)
            {
                MessageBox.Show("VUI LÒNG CHỌN MỤC TÌM KIẾM!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string keyword = txtTuKhoa.Text.Trim();
            string field = cboTimKiemTheo.SelectedItem.ToString();
            dgvSach.DataSource = sachBUS.Search(field, keyword);
        }
    }
}
