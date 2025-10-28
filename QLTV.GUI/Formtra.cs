using QLTV.BUS;
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
    public partial class Formtra : Form
    {
        private readonly MuonTraBUS bus = new MuonTraBUS();
        public Formtra()
        {
            InitializeComponent();
        }

        private void Formtra_Load(object sender, EventArgs e)
        {
            dgvTra.DataSource = bus.GetAll();
            dgvTra.ReadOnly = true;
            dgvTra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTra.MultiSelect = false;
            dgvTra.AllowUserToAddRows = false;

            if (dgvTra.Columns["SACH"] != null)
                dgvTra.Columns["SACH"].Visible = false;
            if (dgvTra.Columns["DOCGIA"] != null)
                dgvTra.Columns["DOCGIA"].Visible = false;
            if (dgvTra.Columns["MaMuonTra"] != null)
                dgvTra.Columns["MaMuonTra"].Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            string searchType = cboTimKiemTheo.Text;

            if (string.IsNullOrEmpty(searchType))
            {
                MessageBox.Show("VUI LÒNG CHỌN TIÊU CHÍ TÌM KIẾM!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("VUI LÒNG NHẬP DỮ LIỆU CẦN TÌM!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = bus.Search(keyword, searchType);

            if (result == null || result.Count == 0)
            {
                MessageBox.Show("KHÔNG TÌM THẤY KẾT QUẢ PHÙ HỢP!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvTra.DataSource = null;
                return;
            }

            dgvTra.DataSource = result;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void cboTimKiemTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTimKiemTheo.SelectedItem != null)
            {
                lblTieuChi.Text = cboTimKiemTheo.SelectedItem.ToString().ToUpper();
            }
            else
            {
                lblTieuChi.Text = "";
            }
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            if (dgvTra.CurrentRow == null)
            {
                MessageBox.Show("VUI LÒNG CHỌN DÒNG CẦN TRẢ SÁCH!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maMuon = dgvTra.CurrentRow.Cells["MaMuonTra"].Value?.ToString();

            if (string.IsNullOrEmpty(maMuon))
            {
                MessageBox.Show("KHÔNG XÁC ĐỊNH ĐƯỢC MÃ MƯỢN!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
