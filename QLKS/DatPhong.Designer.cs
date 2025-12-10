namespace QLKS
{
    partial class DatPhong
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
            this.grbNut = new System.Windows.Forms.GroupBox();
            this.btnXoaThongTin = new System.Windows.Forms.Button();
            this.btnSuaThongTin = new System.Windows.Forms.Button();
            this.btnNhanPhong = new System.Windows.Forms.Button();
            this.btnDatPhong = new System.Windows.Forms.Button();
            this.lstVThongTin = new System.Windows.Forms.ListView();
            this.colMaKhach = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGioiTinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSDT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhongDat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNgayDat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNgayNhan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNgayTra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTrangThai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenKhach = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGioiTinh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaDinhDanh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLoaiGiayTo = new System.Windows.Forms.TextBox();
            this.grbTTKhach = new System.Windows.Forms.GroupBox();
            this.cbHienThiDSKH = new System.Windows.Forms.CheckBox();
            this.cbPhong = new System.Windows.Forms.ComboBox();
            this.cbLoaiPhong = new System.Windows.Forms.ComboBox();
            this.txtQuocTich = new System.Windows.Forms.TextBox();
            this.dtPNgayNhan = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstVKH = new System.Windows.Forms.ListView();
            this.colMKH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenKH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGioiTinhKH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSDTKH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMDDKH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuocTichKH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grbNut.SuspendLayout();
            this.grbTTKhach.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbNut
            // 
            this.grbNut.Controls.Add(this.btnXoaThongTin);
            this.grbNut.Controls.Add(this.btnSuaThongTin);
            this.grbNut.Controls.Add(this.btnNhanPhong);
            this.grbNut.Controls.Add(this.btnDatPhong);
            this.grbNut.Location = new System.Drawing.Point(698, 8);
            this.grbNut.Name = "grbNut";
            this.grbNut.Size = new System.Drawing.Size(170, 249);
            this.grbNut.TabIndex = 1;
            this.grbNut.TabStop = false;
            this.grbNut.Text = "Nút xử lý";
            // 
            // btnXoaThongTin
            // 
            this.btnXoaThongTin.Location = new System.Drawing.Point(87, 99);
            this.btnXoaThongTin.Name = "btnXoaThongTin";
            this.btnXoaThongTin.Size = new System.Drawing.Size(75, 67);
            this.btnXoaThongTin.TabIndex = 3;
            this.btnXoaThongTin.Text = "Xóa thông tin";
            this.btnXoaThongTin.UseVisualStyleBackColor = true;
            // 
            // btnSuaThongTin
            // 
            this.btnSuaThongTin.Location = new System.Drawing.Point(6, 98);
            this.btnSuaThongTin.Name = "btnSuaThongTin";
            this.btnSuaThongTin.Size = new System.Drawing.Size(75, 67);
            this.btnSuaThongTin.TabIndex = 2;
            this.btnSuaThongTin.Text = "Sửa thông tin";
            this.btnSuaThongTin.UseVisualStyleBackColor = true;
            // 
            // btnNhanPhong
            // 
            this.btnNhanPhong.Location = new System.Drawing.Point(87, 25);
            this.btnNhanPhong.Name = "btnNhanPhong";
            this.btnNhanPhong.Size = new System.Drawing.Size(75, 67);
            this.btnNhanPhong.TabIndex = 1;
            this.btnNhanPhong.Text = "Nhận phòng";
            this.btnNhanPhong.UseVisualStyleBackColor = true;
            this.btnNhanPhong.Click += new System.EventHandler(this.btnNhanPhong_Click);
            // 
            // btnDatPhong
            // 
            this.btnDatPhong.Location = new System.Drawing.Point(6, 25);
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.Size = new System.Drawing.Size(75, 67);
            this.btnDatPhong.TabIndex = 0;
            this.btnDatPhong.Text = "Đặt phòng";
            this.btnDatPhong.UseVisualStyleBackColor = true;
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);
            // 
            // lstVThongTin
            // 
            this.lstVThongTin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaKhach,
            this.colTen,
            this.colGioiTinh,
            this.colSDT,
            this.colPhongDat,
            this.colNgayDat,
            this.colNgayNhan,
            this.colNgayTra,
            this.colTrangThai});
            this.lstVThongTin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstVThongTin.FullRowSelect = true;
            this.lstVThongTin.GridLines = true;
            this.lstVThongTin.HideSelection = false;
            this.lstVThongTin.Location = new System.Drawing.Point(0, 263);
            this.lstVThongTin.Name = "lstVThongTin";
            this.lstVThongTin.Size = new System.Drawing.Size(880, 283);
            this.lstVThongTin.TabIndex = 2;
            this.lstVThongTin.UseCompatibleStateImageBehavior = false;
            this.lstVThongTin.View = System.Windows.Forms.View.Details;
            this.lstVThongTin.SelectedIndexChanged += new System.EventHandler(this.lstVThongTin_SelectedIndexChanged);
            // 
            // colMaKhach
            // 
            this.colMaKhach.Text = "STT";
            // 
            // colTen
            // 
            this.colTen.Text = "Khách";
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.Text = "Giới tính";
            // 
            // colSDT
            // 
            this.colSDT.Text = "SĐT";
            // 
            // colPhongDat
            // 
            this.colPhongDat.Text = "Phòng đặt";
            // 
            // colNgayDat
            // 
            this.colNgayDat.Text = "Ngày đặt";
            // 
            // colNgayNhan
            // 
            this.colNgayNhan.Text = "Ngày nhận";
            // 
            // colNgayTra
            // 
            this.colNgayTra.Text = "Ngày trả";
            // 
            // colTrangThai
            // 
            this.colTrangThai.Text = "Trạng thái";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên khách";
            // 
            // txtTenKhach
            // 
            this.txtTenKhach.Location = new System.Drawing.Point(120, 33);
            this.txtTenKhach.Name = "txtTenKhach";
            this.txtTenKhach.Size = new System.Drawing.Size(209, 23);
            this.txtTenKhach.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Giới tính";
            // 
            // txtGioiTinh
            // 
            this.txtGioiTinh.Location = new System.Drawing.Point(120, 69);
            this.txtGioiTinh.Name = "txtGioiTinh";
            this.txtGioiTinh.Size = new System.Drawing.Size(209, 23);
            this.txtGioiTinh.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "SĐT";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(120, 105);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(209, 23);
            this.txtSDT.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã định danh";
            // 
            // txtMaDinhDanh
            // 
            this.txtMaDinhDanh.Location = new System.Drawing.Point(117, 143);
            this.txtMaDinhDanh.Name = "txtMaDinhDanh";
            this.txtMaDinhDanh.Size = new System.Drawing.Size(212, 23);
            this.txtMaDinhDanh.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Loại giấy tờ";
            // 
            // txtLoaiGiayTo
            // 
            this.txtLoaiGiayTo.Location = new System.Drawing.Point(120, 177);
            this.txtLoaiGiayTo.Name = "txtLoaiGiayTo";
            this.txtLoaiGiayTo.Size = new System.Drawing.Size(209, 23);
            this.txtLoaiGiayTo.TabIndex = 9;
            // 
            // grbTTKhach
            // 
            this.grbTTKhach.Controls.Add(this.cbHienThiDSKH);
            this.grbTTKhach.Controls.Add(this.cbPhong);
            this.grbTTKhach.Controls.Add(this.cbLoaiPhong);
            this.grbTTKhach.Controls.Add(this.txtQuocTich);
            this.grbTTKhach.Controls.Add(this.dtPNgayNhan);
            this.grbTTKhach.Controls.Add(this.label11);
            this.grbTTKhach.Controls.Add(this.label10);
            this.grbTTKhach.Controls.Add(this.label8);
            this.grbTTKhach.Controls.Add(this.label6);
            this.grbTTKhach.Controls.Add(this.txtLoaiGiayTo);
            this.grbTTKhach.Controls.Add(this.label5);
            this.grbTTKhach.Controls.Add(this.txtMaDinhDanh);
            this.grbTTKhach.Controls.Add(this.label4);
            this.grbTTKhach.Controls.Add(this.txtSDT);
            this.grbTTKhach.Controls.Add(this.label3);
            this.grbTTKhach.Controls.Add(this.txtGioiTinh);
            this.grbTTKhach.Controls.Add(this.label2);
            this.grbTTKhach.Controls.Add(this.txtTenKhach);
            this.grbTTKhach.Controls.Add(this.label1);
            this.grbTTKhach.Location = new System.Drawing.Point(13, 8);
            this.grbTTKhach.Margin = new System.Windows.Forms.Padding(4);
            this.grbTTKhach.Name = "grbTTKhach";
            this.grbTTKhach.Padding = new System.Windows.Forms.Padding(4);
            this.grbTTKhach.Size = new System.Drawing.Size(678, 249);
            this.grbTTKhach.TabIndex = 0;
            this.grbTTKhach.TabStop = false;
            this.grbTTKhach.Text = "Thông tin khách đặt phòng";
            // 
            // cbHienThiDSKH
            // 
            this.cbHienThiDSKH.AutoSize = true;
            this.cbHienThiDSKH.Location = new System.Drawing.Point(10, 215);
            this.cbHienThiDSKH.Name = "cbHienThiDSKH";
            this.cbHienThiDSKH.Size = new System.Drawing.Size(259, 21);
            this.cbHienThiDSKH.TabIndex = 23;
            this.cbHienThiDSKH.Text = "Hiển thị danh sách khách hàng";
            this.cbHienThiDSKH.UseVisualStyleBackColor = true;
            this.cbHienThiDSKH.CheckedChanged += new System.EventHandler(this.cbHienThiDSKH_CheckedChanged);
            // 
            // cbPhong
            // 
            this.cbPhong.FormattingEnabled = true;
            this.cbPhong.Location = new System.Drawing.Point(466, 144);
            this.cbPhong.Name = "cbPhong";
            this.cbPhong.Size = new System.Drawing.Size(200, 25);
            this.cbPhong.TabIndex = 21;
            // 
            // cbLoaiPhong
            // 
            this.cbLoaiPhong.FormattingEnabled = true;
            this.cbLoaiPhong.Location = new System.Drawing.Point(466, 103);
            this.cbLoaiPhong.Name = "cbLoaiPhong";
            this.cbLoaiPhong.Size = new System.Drawing.Size(200, 25);
            this.cbLoaiPhong.TabIndex = 20;
            this.cbLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.cbLoaiPhong_SelectedIndexChanged);
            // 
            // txtQuocTich
            // 
            this.txtQuocTich.Location = new System.Drawing.Point(466, 33);
            this.txtQuocTich.Name = "txtQuocTich";
            this.txtQuocTich.Size = new System.Drawing.Size(200, 23);
            this.txtQuocTich.TabIndex = 19;
            // 
            // dtPNgayNhan
            // 
            this.dtPNgayNhan.CustomFormat = "yyyy-MM-dd";
            this.dtPNgayNhan.Location = new System.Drawing.Point(466, 69);
            this.dtPNgayNhan.Name = "dtPNgayNhan";
            this.dtPNgayNhan.Size = new System.Drawing.Size(200, 23);
            this.dtPNgayNhan.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(356, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Loại phòng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(356, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "Phòng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(356, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Ngày nhận";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(356, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Quốc tịch";
            // 
            // lstVKH
            // 
            this.lstVKH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstVKH.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMKH,
            this.colTenKH,
            this.colGioiTinhKH,
            this.colSDTKH,
            this.colMDDKH,
            this.colLoai,
            this.colQuocTichKH});
            this.lstVKH.FullRowSelect = true;
            this.lstVKH.GridLines = true;
            this.lstVKH.HideSelection = false;
            this.lstVKH.Location = new System.Drawing.Point(0, 263);
            this.lstVKH.Name = "lstVKH";
            this.lstVKH.Size = new System.Drawing.Size(880, 283);
            this.lstVKH.TabIndex = 3;
            this.lstVKH.UseCompatibleStateImageBehavior = false;
            this.lstVKH.View = System.Windows.Forms.View.Details;
            this.lstVKH.SelectedIndexChanged += new System.EventHandler(this.lstVKH_SelectedIndexChanged);
            // 
            // colMKH
            // 
            this.colMKH.Text = "Mã";
            // 
            // colTenKH
            // 
            this.colTenKH.Text = "Tên";
            // 
            // colGioiTinhKH
            // 
            this.colGioiTinhKH.Text = "Giới tính";
            // 
            // colSDTKH
            // 
            this.colSDTKH.Text = "SĐT";
            this.colSDTKH.Width = 77;
            // 
            // colMDDKH
            // 
            this.colMDDKH.Text = "Mã định danh";
            this.colMDDKH.Width = 144;
            // 
            // colLoai
            // 
            this.colLoai.Text = "Loại giấy tờ";
            this.colLoai.Width = 147;
            // 
            // colQuocTichKH
            // 
            this.colQuocTichKH.Text = "Quốc tịch";
            // 
            // DatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 546);
            this.Controls.Add(this.lstVKH);
            this.Controls.Add(this.lstVThongTin);
            this.Controls.Add(this.grbNut);
            this.Controls.Add(this.grbTTKhach);
            this.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DatPhong";
            this.Text = "DatPhong";
            this.Load += new System.EventHandler(this.DatPhong_Load);
            this.grbNut.ResumeLayout(false);
            this.grbTTKhach.ResumeLayout(false);
            this.grbTTKhach.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbNut;
        private System.Windows.Forms.ListView lstVThongTin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenKhach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGioiTinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaDinhDanh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLoaiGiayTo;
        private System.Windows.Forms.GroupBox grbTTKhach;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbPhong;
        private System.Windows.Forms.ComboBox cbLoaiPhong;
        private System.Windows.Forms.TextBox txtQuocTich;
        private System.Windows.Forms.DateTimePicker dtPNgayNhan;
        private System.Windows.Forms.Button btnXoaThongTin;
        private System.Windows.Forms.Button btnSuaThongTin;
        private System.Windows.Forms.Button btnNhanPhong;
        private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.ColumnHeader colMaKhach;
        private System.Windows.Forms.ColumnHeader colTen;
        private System.Windows.Forms.ColumnHeader colGioiTinh;
        private System.Windows.Forms.ColumnHeader colSDT;
        private System.Windows.Forms.ColumnHeader colPhongDat;
        private System.Windows.Forms.ColumnHeader colNgayDat;
        private System.Windows.Forms.ColumnHeader colNgayNhan;
        private System.Windows.Forms.ColumnHeader colNgayTra;
        private System.Windows.Forms.ColumnHeader colTrangThai;
        private System.Windows.Forms.ListView lstVKH;
        private System.Windows.Forms.ColumnHeader colMKH;
        private System.Windows.Forms.ColumnHeader colTenKH;
        private System.Windows.Forms.ColumnHeader colGioiTinhKH;
        private System.Windows.Forms.ColumnHeader colSDTKH;
        private System.Windows.Forms.ColumnHeader colMDDKH;
        private System.Windows.Forms.CheckBox cbHienThiDSKH;
        private System.Windows.Forms.ColumnHeader colLoai;
        private System.Windows.Forms.ColumnHeader colQuocTichKH;
    }
}