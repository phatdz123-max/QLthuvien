namespace QLTV
{
    partial class Formtra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formtra));
            this.dgvTra = new System.Windows.Forms.DataGridView();
            this.pnltra = new Guna.UI2.WinForms.Guna2Panel();
            this.cboTimKiemTheo = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.lblTieuChi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTra)).BeginInit();
            this.pnltra.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTra
            // 
            this.dgvTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTra.Location = new System.Drawing.Point(143, 255);
            this.dgvTra.Name = "dgvTra";
            this.dgvTra.Size = new System.Drawing.Size(627, 226);
            this.dgvTra.TabIndex = 1;
            // 
            // pnltra
            // 
            this.pnltra.BackColor = System.Drawing.Color.Transparent;
            this.pnltra.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnltra.BorderRadius = 20;
            this.pnltra.BorderThickness = 3;
            this.pnltra.Controls.Add(this.cboTimKiemTheo);
            this.pnltra.Controls.Add(this.txtTimKiem);
            this.pnltra.Controls.Add(this.btnXoa);
            this.pnltra.Controls.Add(this.label4);
            this.pnltra.Controls.Add(this.guna2Button1);
            this.pnltra.Controls.Add(this.lblTieuChi);
            this.pnltra.Controls.Add(this.label2);
            this.pnltra.Controls.Add(this.label1);
            this.pnltra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnltra.Location = new System.Drawing.Point(273, 26);
            this.pnltra.Name = "pnltra";
            this.pnltra.Size = new System.Drawing.Size(365, 191);
            this.pnltra.TabIndex = 2;
            // 
            // cboTimKiemTheo
            // 
            this.cboTimKiemTheo.FormattingEnabled = true;
            this.cboTimKiemTheo.Items.AddRange(new object[] {
            "Mã Sách",
            "Mã Độc Giả"});
            this.cboTimKiemTheo.Location = new System.Drawing.Point(180, 93);
            this.cboTimKiemTheo.Name = "cboTimKiemTheo";
            this.cboTimKiemTheo.Size = new System.Drawing.Size(121, 24);
            this.cboTimKiemTheo.TabIndex = 3;
            this.cboTimKiemTheo.SelectedIndexChanged += new System.EventHandler(this.cboTimKiemTheo_SelectedIndexChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(180, 53);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(121, 22);
            this.txtTimKiem.TabIndex = 2;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Transparent;
            this.btnXoa.BorderColor = System.Drawing.Color.RosyBrown;
            this.btnXoa.BorderRadius = 20;
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Location = new System.Drawing.Point(223, 134);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(87, 40);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Trả Sách";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tìm Kiếm Theo";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.RosyBrown;
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.Location = new System.Drawing.Point(79, 134);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(87, 40);
            this.guna2Button1.TabIndex = 1;
            this.guna2Button1.Text = "Tìm";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // lblTieuChi
            // 
            this.lblTieuChi.AutoSize = true;
            this.lblTieuChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuChi.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.lblTieuChi.Location = new System.Drawing.Point(211, 13);
            this.lblTieuChi.Name = "lblTieuChi";
            this.lblTieuChi.Size = new System.Drawing.Size(0, 25);
            this.lblTieuChi.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label2.Location = new System.Drawing.Point(22, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tìm Kiếm Theo :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập Dữ Liệu";
            // 
            // Formtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 493);
            this.Controls.Add(this.pnltra);
            this.Controls.Add(this.dgvTra);
            this.Name = "Formtra";
            this.Text = "Formtra";
            this.Load += new System.EventHandler(this.Formtra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTra)).EndInit();
            this.pnltra.ResumeLayout(false);
            this.pnltra.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvTra;
        private Guna.UI2.WinForms.Guna2Panel pnltra;
        private System.Windows.Forms.ComboBox cboTimKiemTheo;
        private System.Windows.Forms.TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private System.Windows.Forms.Label lblTieuChi;
    }
}