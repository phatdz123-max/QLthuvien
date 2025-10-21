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
    public partial class Formdangky : Form
    {
        public Formdangky()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btndangky_Click(object sender, EventArgs e)
        {
            string username = txttaikhoan.Text.Trim();
            string password = txtmatkhau.Text.Trim();
            string confirm = txtxacnhanmk.Text.Trim();

            // KIỂM TRA NHẬP ĐẦY ĐỦ
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("VUI LÒNG NHẬP ĐẦY ĐỦ THÔNG TIN!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // KIỂM TRA XÁC NHẬN MẬT KHẨU
            if (password != confirm)
            {
                MessageBox.Show("MẬT KHẨU XÁC NHẬN KHÔNG KHỚP!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new Model1())
            {
                // KIỂM TRA USERNAME ĐÃ TỒN TẠI
                var check = db.LOGINs.FirstOrDefault(u => u.Username == username);
                if (check != null)
                {
                    MessageBox.Show("TÊN ĐĂNG NHẬP ĐÃ TỒN TẠI!", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // THÊM USER MỚI
                LOGIN user = new LOGIN
                {
                    Username = username,
                    Password = password
                };
                db.LOGINs.Add(user);
                db.SaveChanges();

                MessageBox.Show("ĐĂNG KÝ THÀNH CÔNG!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
