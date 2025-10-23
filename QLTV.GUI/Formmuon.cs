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
    public partial class Formmuon : Form
    {
        private readonly MuonTraBUS bus = new MuonTraBUS();
        public Formmuon()
        {
            InitializeComponent();
        }

        private void Formmuon_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dgvMuon.DataSource = null;
            dgvMuon.DataSource = bus.GetAll();
            if (dgvMuon.Columns["SACH"] != null)
                dgvMuon.Columns["SACH"].Visible = false;
            if (dgvMuon.Columns["DOCGIA"] != null)
                dgvMuon.Columns["DOCGIA"].Visible = false;
            if (dgvMuon.Columns["MaMuonTra"] != null)
                dgvMuon.Columns["MaMuonTra"].Visible = false;
        }
        private void ClearInput()
        {
            txtmadocgia.Clear();
            txtmasach.Clear();
           
            txtsoluong.Clear();            
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            MUONTRA mt = new MUONTRA
            {
                MaMuonTra = Guid.NewGuid().ToString().Substring(0, 6).ToUpper(), // TẠO MÃ TỰ ĐỘNG
                MaDocGia = txtmadocgia.Text.Trim(),
                MaSach = txtmasach.Text.Trim(),
                NgayMuon = dtpngaymuon.Value,
                NgayTra = dtpngaytra.Value,
                SoLuong = int.TryParse(txtsoluong.Text, out int sl) ? sl : 0,
                TrangThai = "Đang mượn"
            };

            string result = bus.Add(mt);
            MessageBox.Show(result, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == "THÊM THÀNH CÔNG!")
            {
                LoadData();
                ClearInput();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dgvMuon.CurrentRow == null) return;

            string maMuon = dgvMuon.CurrentRow.Cells["MaMuonTra"].Value.ToString();

            MUONTRA mt = new MUONTRA
            {
                MaMuonTra = maMuon,
                MaDocGia = txtmadocgia.Text.Trim(),
                MaSach = txtmasach.Text.Trim(),
                NgayMuon = dtpngaymuon.Value,
                NgayTra = dtpngaytra.Value,
                SoLuong = int.TryParse(txtsoluong.Text, out int sl) ? sl : 0,
                TrangThai = "Đang mượn"
            };

            string result = bus.Update(mt);
            MessageBox.Show(result, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (dgvMuon.CurrentRow == null) return;

            string maMuon = dgvMuon.CurrentRow.Cells["MaMuonTra"].Value.ToString();

            DialogResult dr = MessageBox.Show("BẠN CÓ CHẮC MUỐN XÓA?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string result = bus.Delete(maMuon);
                MessageBox.Show(result, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void dgvMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMuon.Rows[e.RowIndex];
                txtmadocgia.Text = row.Cells["MaDocGia"].Value?.ToString();
                txtmasach.Text = row.Cells["MaSach"].Value?.ToString();
               
                txtsoluong.Text = row.Cells["SoLuong"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgayMuon"].Value?.ToString(), out DateTime nm))
                    dtpngaymuon.Value = nm;
                if (DateTime.TryParse(row.Cells["NgayTra"].Value?.ToString(), out DateTime nt))
                    dtpngaytra.Value = nt;
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            ClearInput();
        }
    }
}
