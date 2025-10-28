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
    public partial class Formdangnhap : Form
    {
        public Formdangnhap()
        {
            InitializeComponent();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            string username = txttaikhoan.Text.Trim();
            string password = txtmatkhau.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("VUI LÒNG NHẬP ĐẦY ĐỦ TÀI KHOẢN VÀ MẬT KHẨU!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new Model1())
            {
                var user = db.LOGINs.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    MessageBox.Show("ĐĂNG NHẬP THÀNH CÔNG!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // ẨN FORM LOGIN
                    this.Hide();

                    // MỞ FORM CHÍNH
                    frmmain frm = new frmmain();
                    frm.ShowDialog();

                    // KHI ĐÓNG FORM CHÍNH → QUAY LẠI LOGIN
                    this.Show();
                }
                else
                {
                    MessageBox.Show("TÊN ĐĂNG NHẬP HOẶC MẬT KHẨU KHÔNG CHÍNH XÁC!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            this.Close();
        }

        private void lbldangky_Click(object sender, EventArgs e)
        {
            Formdangky frm = new Formdangky();
            frm.ShowDialog();
            this.Hide();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
