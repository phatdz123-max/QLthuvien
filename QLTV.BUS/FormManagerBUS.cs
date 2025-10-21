using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QLTV.BUS
{
    public class FormManagerBUS
    {
        private static Form currentForm = null;

        public static void OpenChildForm(Form childForm, Panel container)
        {
            // NẾU ĐÃ CÓ FORM KHÁC ĐANG HIỂN THỊ THÌ ĐÓNG LẠI
            if (currentForm != null)
                currentForm.Close();

            currentForm = childForm;

            // CẤU HÌNH CHO FORM CON
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // XÓA NỘI DUNG CŨ TRONG PANEL
            container.Controls.Clear();

            // THÊM FORM MỚI VÀO PANEL
            container.Controls.Add(childForm);
            container.Tag = childForm;

            // HIỂN THỊ
            childForm.BringToFront();
            childForm.Show();
        }
    }
}

