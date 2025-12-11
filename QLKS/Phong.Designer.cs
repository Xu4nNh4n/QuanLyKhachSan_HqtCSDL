namespace QLKS
{
    partial class Phong
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
            this.lstVPhong = new System.Windows.Forms.ListView();
            this.colMaPh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoPhong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenLP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTrangThai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstVLoaiPhong = new System.Windows.Forms.ListView();
            this.colMaLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbThemPhong = new System.Windows.Forms.GroupBox();
            this.cbLoaiPhong = new System.Windows.Forms.ComboBox();
            this.btnSuaPhong = new System.Windows.Forms.Button();
            this.btnXoaPhong = new System.Windows.Forms.Button();
            this.btnThemPhong = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.grbLoaiPhong = new System.Windows.Forms.GroupBox();
            this.txtTenLoai = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSuaLoai = new System.Windows.Forms.Button();
            this.btnXoaLoai = new System.Windows.Forms.Button();
            this.btnThemLoai = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grbTimKiem = new System.Windows.Forms.GroupBox();
            this.radLoaiPhong = new System.Windows.Forms.RadioButton();
            this.radPhong = new System.Windows.Forms.RadioButton();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.gbThemPhong.SuspendLayout();
            this.grbLoaiPhong.SuspendLayout();
            this.grbTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstVPhong
            // 
            this.lstVPhong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaPh,
            this.colSoPhong,
            this.colTenLP,
            this.colTrangThai});
            this.lstVPhong.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstVPhong.FullRowSelect = true;
            this.lstVPhong.GridLines = true;
            this.lstVPhong.HideSelection = false;
            this.lstVPhong.Location = new System.Drawing.Point(0, 0);
            this.lstVPhong.Margin = new System.Windows.Forms.Padding(4);
            this.lstVPhong.Name = "lstVPhong";
            this.lstVPhong.Size = new System.Drawing.Size(285, 637);
            this.lstVPhong.TabIndex = 0;
            this.lstVPhong.UseCompatibleStateImageBehavior = false;
            this.lstVPhong.View = System.Windows.Forms.View.Details;
            this.lstVPhong.SelectedIndexChanged += new System.EventHandler(this.lstVPhong_SelectedIndexChanged);
            // 
            // colMaPh
            // 
            this.colMaPh.Text = "Mã";
            // 
            // colSoPhong
            // 
            this.colSoPhong.Text = "Phòng";
            // 
            // colTenLP
            // 
            this.colTenLP.Text = "Tên loại";
            // 
            // colTrangThai
            // 
            this.colTrangThai.Text = "Trạng Thái";
            // 
            // lstVLoaiPhong
            // 
            this.lstVLoaiPhong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaLoai,
            this.colTenLoai,
            this.colGia,
            this.colSoLuong});
            this.lstVLoaiPhong.FullRowSelect = true;
            this.lstVLoaiPhong.GridLines = true;
            this.lstVLoaiPhong.HideSelection = false;
            this.lstVLoaiPhong.Location = new System.Drawing.Point(293, 207);
            this.lstVLoaiPhong.Margin = new System.Windows.Forms.Padding(4);
            this.lstVLoaiPhong.Name = "lstVLoaiPhong";
            this.lstVLoaiPhong.Size = new System.Drawing.Size(391, 417);
            this.lstVLoaiPhong.TabIndex = 1;
            this.lstVLoaiPhong.UseCompatibleStateImageBehavior = false;
            this.lstVLoaiPhong.View = System.Windows.Forms.View.Details;
            this.lstVLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.lstVLoaiPhong_SelectedIndexChanged);
            // 
            // colMaLoai
            // 
            this.colMaLoai.Text = "Mã loại";
            this.colMaLoai.Width = 71;
            // 
            // colTenLoai
            // 
            this.colTenLoai.Text = "Tên loại";
            this.colTenLoai.Width = 129;
            // 
            // colGia
            // 
            this.colGia.Text = "Giá";
            this.colGia.Width = 65;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Text = "Số lượng";
            this.colSoLuong.Width = 89;
            // 
            // gbThemPhong
            // 
            this.gbThemPhong.Controls.Add(this.cbLoaiPhong);
            this.gbThemPhong.Controls.Add(this.btnSuaPhong);
            this.gbThemPhong.Controls.Add(this.btnXoaPhong);
            this.gbThemPhong.Controls.Add(this.btnThemPhong);
            this.gbThemPhong.Controls.Add(this.label2);
            this.gbThemPhong.Controls.Add(this.label1);
            this.gbThemPhong.Controls.Add(this.txtSoPhong);
            this.gbThemPhong.Location = new System.Drawing.Point(293, 16);
            this.gbThemPhong.Margin = new System.Windows.Forms.Padding(4);
            this.gbThemPhong.Name = "gbThemPhong";
            this.gbThemPhong.Padding = new System.Windows.Forms.Padding(4);
            this.gbThemPhong.Size = new System.Drawing.Size(391, 183);
            this.gbThemPhong.TabIndex = 2;
            this.gbThemPhong.TabStop = false;
            this.gbThemPhong.Text = "Thêm phòng";
            // 
            // cbLoaiPhong
            // 
            this.cbLoaiPhong.FormattingEnabled = true;
            this.cbLoaiPhong.Location = new System.Drawing.Point(120, 78);
            this.cbLoaiPhong.Name = "cbLoaiPhong";
            this.cbLoaiPhong.Size = new System.Drawing.Size(205, 25);
            this.cbLoaiPhong.TabIndex = 7;
            // 
            // btnSuaPhong
            // 
            this.btnSuaPhong.Location = new System.Drawing.Point(175, 112);
            this.btnSuaPhong.Name = "btnSuaPhong";
            this.btnSuaPhong.Size = new System.Drawing.Size(75, 46);
            this.btnSuaPhong.TabIndex = 6;
            this.btnSuaPhong.Text = "Sửa";
            this.btnSuaPhong.UseVisualStyleBackColor = true;
            this.btnSuaPhong.Click += new System.EventHandler(this.btnSuaPhong_Click);
            // 
            // btnXoaPhong
            // 
            this.btnXoaPhong.Location = new System.Drawing.Point(94, 112);
            this.btnXoaPhong.Name = "btnXoaPhong";
            this.btnXoaPhong.Size = new System.Drawing.Size(75, 46);
            this.btnXoaPhong.TabIndex = 5;
            this.btnXoaPhong.Text = "Xóa";
            this.btnXoaPhong.UseVisualStyleBackColor = true;
            this.btnXoaPhong.Click += new System.EventHandler(this.btnXoaPhong_Click);
            // 
            // btnThemPhong
            // 
            this.btnThemPhong.Location = new System.Drawing.Point(10, 112);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(75, 46);
            this.btnThemPhong.TabIndex = 4;
            this.btnThemPhong.Text = "Thêm";
            this.btnThemPhong.UseVisualStyleBackColor = true;
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loại phòng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số phòng";
            // 
            // txtSoPhong
            // 
            this.txtSoPhong.Location = new System.Drawing.Point(120, 46);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(205, 23);
            this.txtSoPhong.TabIndex = 0;
            // 
            // grbLoaiPhong
            // 
            this.grbLoaiPhong.Controls.Add(this.txtTenLoai);
            this.grbLoaiPhong.Controls.Add(this.txtGia);
            this.grbLoaiPhong.Controls.Add(this.label5);
            this.grbLoaiPhong.Controls.Add(this.btnSuaLoai);
            this.grbLoaiPhong.Controls.Add(this.btnXoaLoai);
            this.grbLoaiPhong.Controls.Add(this.btnThemLoai);
            this.grbLoaiPhong.Controls.Add(this.txtSoLuong);
            this.grbLoaiPhong.Controls.Add(this.label3);
            this.grbLoaiPhong.Controls.Add(this.label4);
            this.grbLoaiPhong.Location = new System.Drawing.Point(696, 16);
            this.grbLoaiPhong.Margin = new System.Windows.Forms.Padding(4);
            this.grbLoaiPhong.Name = "grbLoaiPhong";
            this.grbLoaiPhong.Padding = new System.Windows.Forms.Padding(4);
            this.grbLoaiPhong.Size = new System.Drawing.Size(243, 247);
            this.grbLoaiPhong.TabIndex = 7;
            this.grbLoaiPhong.TabStop = false;
            this.grbLoaiPhong.Text = "Thêm loại phòng";
            // 
            // txtTenLoai
            // 
            this.txtTenLoai.Location = new System.Drawing.Point(94, 46);
            this.txtTenLoai.Name = "txtTenLoai";
            this.txtTenLoai.Size = new System.Drawing.Size(133, 23);
            this.txtTenLoai.TabIndex = 9;
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(94, 78);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(133, 23);
            this.txtGia.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "số lượng người:";
            // 
            // btnSuaLoai
            // 
            this.btnSuaLoai.Location = new System.Drawing.Point(169, 158);
            this.btnSuaLoai.Name = "btnSuaLoai";
            this.btnSuaLoai.Size = new System.Drawing.Size(67, 46);
            this.btnSuaLoai.TabIndex = 6;
            this.btnSuaLoai.Text = "Sửa";
            this.btnSuaLoai.UseVisualStyleBackColor = true;
            this.btnSuaLoai.Click += new System.EventHandler(this.btnSuaLoai_Click);
            // 
            // btnXoaLoai
            // 
            this.btnXoaLoai.Location = new System.Drawing.Point(88, 158);
            this.btnXoaLoai.Name = "btnXoaLoai";
            this.btnXoaLoai.Size = new System.Drawing.Size(75, 46);
            this.btnXoaLoai.TabIndex = 5;
            this.btnXoaLoai.Text = "Xóa";
            this.btnXoaLoai.UseVisualStyleBackColor = true;
            this.btnXoaLoai.Click += new System.EventHandler(this.btnXoaLoai_Click);
            // 
            // btnThemLoai
            // 
            this.btnThemLoai.Location = new System.Drawing.Point(7, 158);
            this.btnThemLoai.Name = "btnThemLoai";
            this.btnThemLoai.Size = new System.Drawing.Size(75, 46);
            this.btnThemLoai.TabIndex = 4;
            this.btnThemLoai.Text = "Thêm";
            this.btnThemLoai.UseVisualStyleBackColor = true;
            this.btnThemLoai.Click += new System.EventHandler(this.btnThemLoai_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(141, 109);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(86, 23);
            this.txtSoLuong.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tên loại";
            // 
            // grbTimKiem
            // 
            this.grbTimKiem.Controls.Add(this.radLoaiPhong);
            this.grbTimKiem.Controls.Add(this.radPhong);
            this.grbTimKiem.Controls.Add(this.btnTimKiem);
            this.grbTimKiem.Controls.Add(this.txtTimKiem);
            this.grbTimKiem.Location = new System.Drawing.Point(696, 270);
            this.grbTimKiem.Name = "grbTimKiem";
            this.grbTimKiem.Size = new System.Drawing.Size(243, 354);
            this.grbTimKiem.TabIndex = 8;
            this.grbTimKiem.TabStop = false;
            this.grbTimKiem.Text = "Tìm kiếm";
            // 
            // radLoaiPhong
            // 
            this.radLoaiPhong.AutoSize = true;
            this.radLoaiPhong.Location = new System.Drawing.Point(10, 88);
            this.radLoaiPhong.Name = "radLoaiPhong";
            this.radLoaiPhong.Size = new System.Drawing.Size(106, 21);
            this.radLoaiPhong.TabIndex = 12;
            this.radLoaiPhong.TabStop = true;
            this.radLoaiPhong.Text = "Loại phòng";
            this.radLoaiPhong.UseVisualStyleBackColor = true;
            // 
            // radPhong
            // 
            this.radPhong.AutoSize = true;
            this.radPhong.Location = new System.Drawing.Point(10, 61);
            this.radPhong.Name = "radPhong";
            this.radPhong.Size = new System.Drawing.Size(66, 21);
            this.radPhong.TabIndex = 11;
            this.radPhong.TabStop = true;
            this.radPhong.Text = "Phòng";
            this.radPhong.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(10, 119);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(227, 46);
            this.btnTimKiem.TabIndex = 10;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(6, 22);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(227, 23);
            this.txtTimKiem.TabIndex = 10;
            // 
            // Phong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 637);
            this.Controls.Add(this.grbTimKiem);
            this.Controls.Add(this.grbLoaiPhong);
            this.Controls.Add(this.gbThemPhong);
            this.Controls.Add(this.lstVLoaiPhong);
            this.Controls.Add(this.lstVPhong);
            this.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Phong";
            this.Text = "Phong";
            this.Load += new System.EventHandler(this.Phong_Load);
            this.gbThemPhong.ResumeLayout(false);
            this.gbThemPhong.PerformLayout();
            this.grbLoaiPhong.ResumeLayout(false);
            this.grbLoaiPhong.PerformLayout();
            this.grbTimKiem.ResumeLayout(false);
            this.grbTimKiem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstVPhong;
        private System.Windows.Forms.ListView lstVLoaiPhong;
        private System.Windows.Forms.GroupBox gbThemPhong;
        private System.Windows.Forms.Button btnSuaPhong;
        private System.Windows.Forms.Button btnXoaPhong;
        private System.Windows.Forms.Button btnThemPhong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.GroupBox grbLoaiPhong;
        private System.Windows.Forms.Button btnSuaLoai;
        private System.Windows.Forms.Button btnXoaLoai;
        private System.Windows.Forms.Button btnThemLoai;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenLoai;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grbTimKiem;
        private System.Windows.Forms.RadioButton radLoaiPhong;
        private System.Windows.Forms.RadioButton radPhong;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ColumnHeader colMaLoai;
        private System.Windows.Forms.ColumnHeader colTenLoai;
        private System.Windows.Forms.ColumnHeader colGia;
        private System.Windows.Forms.ColumnHeader colSoLuong;
        private System.Windows.Forms.ColumnHeader colMaPh;
        private System.Windows.Forms.ColumnHeader colSoPhong;
        private System.Windows.Forms.ColumnHeader colTenLP;
        private System.Windows.Forms.ColumnHeader colTrangThai;
        private System.Windows.Forms.ComboBox cbLoaiPhong;
    }
}