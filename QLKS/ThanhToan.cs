    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace QLKS
    {
        public partial class ThanhToan : Form
        {
            SqlConnection conn = new SqlConnection(
                @"Data Source=Xu4nNh4n\SQLEXPRESS;Initial Catalog=QLKS;Integrated Security=True");
            Panel pnlLeft, pnlRight;
            DataGridView dgvBooking, dgvDichVu;

            Label lblTitle;

            Label lblKH, lblPhong, lblNgayNhan;
            Label lblTienPhong, lblTienDV, lblTong;

            Button btnThanhToan, btnInHoaDon, btnLamMoi;
            public ThanhToan()
            {
                InitializeComponent();
                BuildUI();

            }

            private void ThanhToan_Load(object sender, EventArgs e)
            {
                LoadTTDatPhong();
                btnThanhToan.Click += btnThanhToan_Click;
                btnLamMoi.Click += BtnRefresh_Click;
        }
            private void BuildUI()
            {
                this.BackColor = Color.White;
                this.AutoScroll = false;

                // ========= TITLE =========
                lblTitle = new Label()
                {
                    Text = "THANH TOÁN",
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    AutoSize = true,
                    Location = new Point(20, 15)
                };
                this.Controls.Add(lblTitle);

                // ========= LEFT PANEL =========
                pnlLeft = new Panel()
                {
                    Location = new Point(20, 60),
                    Size = new Size(450, 450),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };
                Controls.Add(pnlLeft);

                Label lblList = new Label()
                {
                    Text = "Danh sách phòng cần thanh toán:",
                    Location = new Point(10, 10),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                pnlLeft.Controls.Add(lblList);

                dgvBooking = new DataGridView()
                {
                    Location = new Point(10, 40),
                    Size = new Size(420, 380),
                    BackgroundColor = Color.White,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                };
                dgvBooking.ReadOnly = true;
                dgvBooking.AllowUserToAddRows = false;
                dgvBooking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvBooking.MultiSelect = false;
                pnlLeft.Controls.Add(dgvBooking);
                dgvBooking.CellClick += DgvBooking_CellClick;

                // ========= RIGHT PANEL =========
                pnlRight = new Panel()
                {
                    Location = new Point(490, 60),
                    Size = new Size(430, 450),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle
                };
                Controls.Add(pnlRight);

                Label lblDetailHeader = new Label()
                {
                    Text = "Chi tiết thanh toán",
                    Location = new Point(150, 10),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold)
                };
                pnlRight.Controls.Add(lblDetailHeader);

                lblKH = NewLabel("Khách hàng:", 50);
                lblPhong = NewLabel("Phòng:", 80);
                lblNgayNhan = NewLabel("Ngày nhận:", 110);

                pnlRight.Controls.Add(lblKH);
                pnlRight.Controls.Add(lblPhong);
                pnlRight.Controls.Add(lblNgayNhan);

                // ===== DỊCH VỤ =====
                Label lblDV = new Label()
                {
                    Text = "Dịch vụ sử dụng:",
                    Location = new Point(20, 175),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                pnlRight.Controls.Add(lblDV);

                dgvDichVu = new DataGridView()
                {
                    Location = new Point(20, 200),
                    Size = new Size(390, 150),
                    BackgroundColor = Color.White,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };
                dgvDichVu.ReadOnly = true;
                dgvDichVu.AllowUserToAddRows = false;
                dgvDichVu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                pnlRight.Controls.Add(dgvDichVu);

                // ===== TIỀN =====
                lblTienPhong = NewLabel("Tiền phòng: 0 VND", 360);
                lblTienDV = NewLabel("Tiền dịch vụ: 0 VND", 385);
                lblTong = new Label()
                {
                    Text = "Tổng thanh toán: 0 VND",
                    Location = new Point(20, 415),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.Red
                };

                pnlRight.Controls.Add(lblTienPhong);
                pnlRight.Controls.Add(lblTienDV);
                pnlRight.Controls.Add(lblTong);

                // ===== BUTTONS =====
                btnThanhToan = new Button()
                {
                    Text = "Thanh toán",
                    Size = new Size(130, 45),
                    Location = new Point(660, 10),
                    BackColor = Color.FromArgb(46, 204, 113),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White
                };

                btnLamMoi = new Button()
                {
                    Text = "Làm mới",
                    Size = new Size(130, 45),
                    Location = new Point(792, 10),
                    BackColor = Color.FromArgb(52, 152, 219),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White
                };

                Controls.Add(btnThanhToan);
                Controls.Add(btnLamMoi);
            }

            private Label NewLabel(string text, int y)
            {
                return new Label()
                {
                    Text = text,
                    Location = new Point(20, y),
                    Font = new Font("Segoe UI", 10),
                    AutoSize = true
                };
            }
            private void LoadTTDatPhong()
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    string query = @"SELECT DP.MADATPH, KH.TENKH, P.SOPHONG, P.TRANGTHAI, DP.NGAYNHAN, DP.NGAYTRA, dbo.fn_TongTienPhong(DP.MADATPH) AS TienPhong, dbo.fn_TongTienDichVu(DP.MADATPH) AS TienDV, dbo.fn_TongTienPhong(DP.MADATPH) + dbo.fn_TongTienDichVu(DP.MADATPH) AS TongTien FROM DATPHONG DP JOIN KHACH KH ON KH.MAKH = DP.MAKH JOIN PHONG P ON P.MAPH = DP.MAPH WHERE DP.NGAYTRA IS NULL AND NOT EXISTS (SELECT 1 FROM HOADON WHERE MADATPH = DP.MADATPH)";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBooking.DataSource = dt;
                    dgvBooking.Columns["NGAYTRA"].Visible = false;
                    dgvBooking.Columns["NGAYNHAN"].Visible = false;
                    dgvBooking.Columns["TienPhong"].Visible = false;
                    dgvBooking.Columns["TienDV"].Visible = false;
                    dgvBooking.Columns["TongTien"].Visible = false;
                    void setHeader(string col, string header)
                    {
                        if (dgvBooking.Columns[col] != null)
                            dgvBooking.Columns[col].HeaderText = header;
                    }
                    setHeader("MADATPH", "Mã đặt phòng");
                    setHeader("TENKH", "Tên khách hàng");
                    setHeader("SOPHONG", "Số phòng");
                    setHeader("TRANGTHAI", "Trạng thái");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            
            }
            private int selectedMaDatPh = -1;

            private void DgvBooking_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex < 0) return;
                if (dgvBooking.Rows.Count == 0) return;
                if (dgvBooking.CurrentRow == null) return;

                DataGridViewRow row = dgvBooking.Rows[e.RowIndex];
                string Get(string col)
                {
                    return row.Cells[col]?.Value?.ToString() ?? "";
                }
                decimal SafeDecimal(string s)
                {
                    decimal val;
                    if (decimal.TryParse(s, out val))
                        return val;
                    return 0;
                }
                lblKH.Text = "Khách hàng: " + Get("TENKH");
                lblPhong.Text = "Phòng: " + Get("SOPHONG");
                lblNgayNhan.Text = DateTime.TryParse(Get("NGAYNHAN"), out DateTime nn) ? "Ngày nhận: " + nn.ToString("dd/MM/yyyy") : "Ngày nhận: ---";  
                lblTienPhong.Text = "Tiền phòng: " + SafeDecimal(Get("TienPhong")).ToString("N0") + " VND";
                lblTienDV.Text = "Tiền dịch vụ: " + SafeDecimal(Get("TienDV")).ToString("N0") + " VND";
                decimal tong = SafeDecimal(Get("TongTien"));
                lblTong.Text = "Tổng thanh toán: " + tong.ToString("N0") + " VND";
            if (int.TryParse(Get("MADATPH"), out int maDatPh))
                {
                    selectedMaDatPh = maDatPh;
                    LoadDichVu(maDatPh); 
                }
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
                WHERE SD.MADATPH = @MaDP AND SD.TRANGTHAI = N'Đã hoàn thành'";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@MaDP", maDatPh);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvDichVu.DataSource = dt;

                    // header đẹp
                    dgvDichVu.Columns["TenDV"].HeaderText = "Tên DV";
                    dgvDichVu.Columns["DonGia"].HeaderText = "Đơn giá";
                    dgvDichVu.Columns["SoLuong"].HeaderText = "SL";
                    dgvDichVu.Columns["ThanhTien"].HeaderText = "Thành tiền";
                }
                finally
                {
                    conn.Close();
                }
            }
            private void btnThanhToan_Click(object sender, EventArgs e)
            {
                if (selectedMaDatPh == -1)
                {
                    MessageBox.Show("Vui lòng chọn phòng cần thanh toán!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận
                if (MessageBox.Show("Xác nhận thanh toán?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    string sql = "UPDATE DATPHONG SET NGAYTRA = GETDATE() WHERE MADATPH = @ma";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ma", selectedMaDatPh);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thanh toán thành công!\nHóa đơn đã được tạo tự động.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTTDatPhong();
                    lblKH.Text = "Khách hàng:";
                    lblPhong.Text = "Phòng:";
                    lblNgayNhan.Text = "Ngày nhận:";
                    lblTienPhong.Text = "Tiền phòng: 0 VND";
                    lblTienDV.Text = "Tiền dịch vụ: 0 VND";
                    lblTong.Text = "Tổng thanh toán: 0 VND";
                    dgvDichVu.DataSource = null;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thanh toán: " + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            private void BtnRefresh_Click(object sender, EventArgs e)
            {
            dgvBooking.DataSource = null;
            selectedMaDatPh = -1;

            lblKH.Text = "Khách hàng:";
            lblPhong.Text = "Phòng:";
            lblNgayNhan.Text = "Ngày nhận:";
            lblTienDV.Text = "Tiền dịch vụ:";
            lblTienPhong.Text = "Tiền phòng:";
            lblTong.Text = "Tổng thanh toán:";
            LoadTTDatPhong();

        }
    }
    }
