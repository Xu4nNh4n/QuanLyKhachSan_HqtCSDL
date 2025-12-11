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
            @"Data Source=Xu4nNh4n\SQLEXPRESS;Initial Catalog=QLKS;Integrated Security=True"
        );

        TextBox txtSearch;
        Button btnSearch, btnRefresh, btnIn;
        DataGridView dgvInvoices, dgvServices;
        Panel pnlDetail;
        Label lblKH, lblPhong, lblNgay, lblTienPhong, lblTienDV, lblTong;

        private void HoaDon_Load(object sender, EventArgs e)
        {

        }

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
            this.Size = new Size(896, 585);
            this.BackColor = Color.FromArgb(245, 247, 250);

            // ==============================
            // Ô TÌM KIẾM & NÚT
            // ==============================
            txtSearch = new TextBox()
            {
                Location = new Point(20, 15),
                Width = 220,
                Font = new Font("Segoe UI", 10),
            };

            btnSearch = new Button()
            {
                Location = new Point(250, 13),
                Text = "Tìm",
                Width = 60,
                Height = 28,
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnRefresh = new Button()
            {
                Location = new Point(320, 13),
                Text = "Làm mới",
                Width = 80,
                Height = 28,
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnIn = new Button()
            {
                Location = new Point(410, 13),
                Text = "In hoá đơn",
                Width = 90,
                Height = 28,
                BackColor = Color.FromArgb(155, 89, 182),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // ==============================
            // BẢNG HÓA ĐƠN
            // ==============================
            dgvInvoices = new DataGridView()
            {
                Location = new Point(20, 55),
                Size = new Size(420, 370),
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.FixedSingle
            };
            dgvInvoices.EnableHeadersVisualStyles = false;

            pnlDetail = new Panel()
            {
                Location = new Point(460, 55),
                Size = new Size(350, 420),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // ----- TIÊU ĐỀ -----
            Label lblTitle = new Label()
            {
                Text = "CHI TIẾT HÓA ĐƠN",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Location = new Point(80, 10),
                AutoSize = true
            };

            // ----- THÔNG TIN KHÁCH -----
            Label lblTenKH = new Label()
            {
                Text = "Tên khách:",
                Location = new Point(20, 50),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            lblKH = new Label()
            {
                Location = new Point(120, 50),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            Label lblPhongTitle = new Label()
            {
                Text = "Phòng:",
                Location = new Point(20, 75),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            lblPhong = new Label()
            {
                Location = new Point(120, 75),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            Label lblNgayTitle = new Label()
            {
                Text = "Ngày lập:",
                Location = new Point(20, 100),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            lblNgay = new Label()
            {
                Location = new Point(120, 100),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            // ----- DỊCH VỤ -----
            Label lblDV = new Label()
            {
                Text = "Dịch vụ đã dùng",
                Location = new Point(20, 130),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            dgvServices = new DataGridView()
            {
                Location = new Point(20, 155),
                Size = new Size(310, 150),
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.FixedSingle
            };

            // ----- TIỀN -----
            Label lblTienPhongTitle = new Label()
            {
                Text = "Tiền phòng:",
                Location = new Point(20, 315),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            lblTienPhong = new Label()
            {
                Location = new Point(150, 315),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            Label lblTienDVTitle = new Label()
            {
                Text = "Tiền dịch vụ:",
                Location = new Point(20, 340),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            lblTienDV = new Label()
            {
                Location = new Point(150, 340),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            Label lblTongTitle = new Label()
            {
                Text = "Tổng tiền:",
                Location = new Point(20, 370),
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            lblTong = new Label()
            {
                Location = new Point(150, 370),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Red,
                AutoSize = true
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
                KH.TENKH,
                P.SOPHONG ,
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
            ORDER BY HD.MAHD DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvInvoices.DataSource = dt;
                void SetHeader(string col, string header)
                {
                    if (dgvInvoices.Columns[col] != null)
                        dgvInvoices.Columns[col].HeaderText = header;
                }

                // đặt tên header đẹp
                SetHeader("MAHD", "Mã HĐ");
                SetHeader("TENKH", "Tên khách");
                SetHeader("SOPHONG", "Phòng");
                SetHeader("NGAYLAP", "Ngày lập");
                SetHeader("TienPhong", "Tiền phòng");
                SetHeader("TienDV", "Tiền DV");
                SetHeader("TongTien", "Tổng tiền");
                SetHeader("MADATPH", "Mã đặt phòng");
            }
            finally
            {
                conn.Close();
            }
        }


        private void DgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvInvoices.Rows.Count == 0) return;

            DataGridViewRow r = dgvInvoices.Rows[e.RowIndex];

            string Get(string col)
            {
                return r.Cells[col]?.Value?.ToString() ?? "";
            }

            decimal SafeDecimal(string s)
            {
                decimal val;
                return decimal.TryParse(s, out val) ? val : 0;
            }

            // ==== PHẢI ĐÚNG TÊN CỘT TRONG SQL ====
            lblKH.Text = "Khách hàng: " + Get("TENKH");
            lblPhong.Text = "Phòng: " + Get("SOPHONG");

            // NGÀY LẬP
            
                lblNgay.Text = DateTime.TryParse(Get("NGAYLAP"), out DateTime nn) ? "Ngày lập: " + nn.ToString("dd/MM/yyyy") : "Ngày lập: ---";


            lblTienPhong.Text = "Tiền phòng: " +
                string.Format("{0:N0} VND", SafeDecimal(Get("TienPhong")));

            lblTienDV.Text = "Tiền dịch vụ: " +
                string.Format("{0:N0} VND", SafeDecimal(Get("TienDV")));

            lblTong.Text = "Tổng cộng: " +
                string.Format("{0:N0} VND", SafeDecimal(Get("TongTien")));

            // MÃ ĐẶT PHÒNG
            if (int.TryParse(Get("MADATPH"), out int maDatPh))
                LoadDichVu(maDatPh);
        }



        private void LoadDichVu(int maDatPh)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = @"
            SELECT DV.TENDV, CT.SOLUONG, CT.GIADV, SUM(CT.SOLUONG * CT.GIADV) AS ThanhTien
            FROM CHITIETHD CT
            JOIN HOADON HD ON CT.MAHD = HD.MAHD
            JOIN DICHVU DV ON DV.MADV = CT.MADV
            WHERE HD.MADATPH = @MaDP
            GROUP BY DV.TENDV, CT.SOLUONG, CT.GIADV";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaDP", maDatPh);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvServices.DataSource = dt;

                // header đẹp
                dgvServices.Columns["TENDV"].HeaderText = "Tên DV";
                dgvServices.Columns["SOLUONG"].HeaderText = "SL";
                dgvServices.Columns["GIADV"].HeaderText = "Giá dv";
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
