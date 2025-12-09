using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QLKS
{
    public partial class HoaDon : Form
    {
        SqlConnection conn = new SqlConnection(
            @"Data Source=Xu4nNh4n\SQLEXPRESS;Initial Catalog=QLKSSS;Integrated Security=True"
        );

        TextBox txtSearch;
        Button btnSearch, btnRefresh, btnIn;
        DataGridView dgvInvoices, dgvServices;
        Panel pnlDetail;
        Label lblKH, lblPhong, lblNgay, lblTienPhong, lblTienDV, lblTong;

        public HoaDon()
        {
            InitializeComponent();
            BuildUI();
            LoadHoaDon();

            dgvInvoices.CellClick += DgvInvoices_CellClick;
            btnSearch.Click += BtnSearch_Click;
            btnRefresh.Click += BtnRefresh_Click;
        }

        private void BuildUI()
        {
            this.Text = "Quản lý hóa đơn";
            this.Size = new Size(1200, 720);
            this.BackColor = Color.FromArgb(245, 247, 250);

            txtSearch = new TextBox()
            {
                Location = new Point(20, 20),
                Width = 300,
                Font = new Font("Segoe UI", 11),
            };

            btnSearch = new Button()
            {
                Location = new Point(330, 18),
                Text = "Tìm",
                Width = 80,
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnRefresh = new Button()
            {
                Location = new Point(420, 18),
                Text = "Làm mới",
                Width = 90,
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnIn = new Button()
            {
                Location = new Point(520, 18),
                Text = "In hoá đơn",
                Width = 110,
                BackColor = Color.FromArgb(155, 89, 182),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            dgvInvoices = new DataGridView()
            {
                Location = new Point(20, 60),
                Size = new Size(700, 600),
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvInvoices.EnableHeadersVisualStyles = false;

            pnlDetail = new Panel()
            {
                Location = new Point(740, 60),
                Size = new Size(430, 600),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitle = new Label()
            {
                Text = "CHI TIẾT HÓA ĐƠN",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Location = new Point(120, 10),
            };

            lblKH = new Label() { Location = new Point(20, 60), Font = new Font("Segoe UI", 10) };
            lblPhong = new Label() { Location = new Point(20, 90), Font = new Font("Segoe UI", 10) };
            lblNgay = new Label() { Location = new Point(20, 120), Font = new Font("Segoe UI", 10) };

            Label lblDV = new Label()
            {
                Text = "Dịch vụ đã dùng:",
                Location = new Point(20, 160),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            dgvServices = new DataGridView()
            {
                Location = new Point(20, 190),
                Size = new Size(390, 200),
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            lblTienPhong = new Label() { Location = new Point(20, 400), Font = new Font("Segoe UI", 10) };
            lblTienDV = new Label() { Location = new Point(20, 430), Font = new Font("Segoe UI", 10) };
            lblTong = new Label()
            {
                Location = new Point(20, 470),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Red
            };

            pnlDetail.Controls.Add(lblTitle);
            pnlDetail.Controls.Add(lblKH);
            pnlDetail.Controls.Add(lblPhong);
            pnlDetail.Controls.Add(lblNgay);
            pnlDetail.Controls.Add(lblDV);
            pnlDetail.Controls.Add(dgvServices);
            pnlDetail.Controls.Add(lblTienPhong);
            pnlDetail.Controls.Add(lblTienDV);
            pnlDetail.Controls.Add(lblTong);

            this.Controls.Add(txtSearch);
            this.Controls.Add(btnSearch);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(btnIn);
            this.Controls.Add(dgvInvoices);
            this.Controls.Add(pnlDetail);
        }

        // ===============================
        // LOAD HÓA ĐƠN
        // ===============================
        private void LoadHoaDon()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = @"
            SELECT 
                HD.MAHD,
                KH.TENKH AS TenKH,
                P.SOPHONG AS SoPhong,
                HD.NGAYLAP AS NgayLap,
                dbo.fn_TongTienPhong(HD.MADATPH) AS TienPhong,
                dbo.fn_TongTienDichVu(HD.MADATPH) AS TienDV,
                dbo.fn_TongTienPhong(HD.MADATPH) 
                + dbo.fn_TongTienDichVu(HD.MADATPH) AS TongTien,
                HD.MADATPH
            FROM HOADON HD
            JOIN DATPHONG DP ON HD.MADATPH = DP.MADATPH
            JOIN KHACH KH ON DP.MAKH = KH.MAKH
            JOIN PHONG P ON DP.MAPH = P.MAPH
            ORDER BY HD.MAHD DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvInvoices.DataSource = dt;

                // đặt tên header đẹp
                dgvInvoices.Columns["MAHD"].HeaderText = "Mã HĐ";
                dgvInvoices.Columns["TenKH"].HeaderText = "Tên khách";
                dgvInvoices.Columns["SoPhong"].HeaderText = "Phòng";
                dgvInvoices.Columns["NgayLap"].HeaderText = "Ngày lập";
                dgvInvoices.Columns["TienPhong"].HeaderText = "Tiền phòng";
                dgvInvoices.Columns["TienDV"].HeaderText = "Tiền DV";
                dgvInvoices.Columns["TongTien"].HeaderText = "Tổng tiền";
                dgvInvoices.Columns["MADATPH"].HeaderText = "Mã đặt phòng";
            }
            finally
            {
                conn.Close();
            }
        }


        private void DgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var r = dgvInvoices.Rows[e.RowIndex];

            lblKH.Text = "Khách hàng: " + r.Cells["TenKH"].Value.ToString();
            lblPhong.Text = "Phòng: " + r.Cells["SoPhong"].Value.ToString();
            lblNgay.Text = "Ngày lập: " + Convert.ToDateTime(r.Cells["NgayLap"].Value).ToString("dd/MM/yyyy");

            lblTienPhong.Text = "Tiền phòng: " + r.Cells["TienPhong"].Value + " VND";
            lblTienDV.Text = "Tiền dịch vụ: " + r.Cells["TienDV"].Value + " VND";
            lblTong.Text = "Tổng cộng: " + r.Cells["TongTien"].Value + " VND";

            int maDatPh = Convert.ToInt32(r.Cells["MADATPH"].Value);
            LoadDichVu(maDatPh);
        }


        private void LoadDichVu(int maDatPh)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = @"
            SELECT 
                DV.TENDV AS TenDV, 
                DV.DONGIA AS DonGia, 
                SD.SOLUONG AS SoLuong,
                (DV.DONGIA * SD.SOLUONG) AS ThanhTien
            FROM SUDUNGDV SD
            JOIN DICHVU DV ON SD.MADV = DV.MADV
            WHERE SD.MADATPH = @MaDP";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaDP", maDatPh);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvServices.DataSource = dt;

                // header đẹp
                dgvServices.Columns["TenDV"].HeaderText = "Tên DV";
                dgvServices.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvServices.Columns["SoLuong"].HeaderText = "SL";
                dgvServices.Columns["ThanhTien"].HeaderText = "Thành tiền";
            }
            finally
            {
                conn.Close();
            }
        }


        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();

            if (kw == "")
            {
                LoadHoaDon();
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = @"
                    SELECT 
                        HD.MAHD,
                        KH.TENKH,
                        P.SOPHONG,
                        HD.NGAYLAP,
                        dbo.fn_TongTienPhong(HD.MADATPH) AS TienPhong,
                        dbo.fn_TongTienDichVu(HD.MADATPH) AS TienDV,
                        dbo.fn_TongTienPhong(HD.MADATPH) 
                        + dbo.fn_TongTienDichVu(HD.MADATPH) AS TongTien,
                        HD.MADATPH
                    FROM HOADON HD
                    JOIN DATPHONG DP ON HD.MADATPH = DP.MADATPH
                    JOIN KHACH KH ON DP.MAKH = KH.MAKH
                    JOIN PHONG P ON DP.MAPH = P.MAPH
                    WHERE KH.TENKH LIKE '%' + @kw + '%'
                       OR P.SOPHONG LIKE '%' + @kw + '%'
                       OR HD.MAHD LIKE '%' + @kw + '%'";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@kw", kw);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvInvoices.DataSource = dt;
            }
            finally
            {
                conn.Close();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadHoaDon();
            dgvServices.DataSource = null;

            lblKH.Text = "";
            lblPhong.Text = "";
            lblNgay.Text = "";
            lblTienPhong.Text = "";
            lblTienDV.Text = "";
            lblTong.Text = "";
        }
    }
}
