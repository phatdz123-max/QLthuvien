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
            if (currentForm != null)
                currentForm.Close();

            currentForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // XÓA NỘI DUNG CŨ TRONG PANEL
            container.Controls.Clear();

            // THÊM FORM MỚI VÀO PANEL
            container.Controls.Add(childForm);
            container.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}

