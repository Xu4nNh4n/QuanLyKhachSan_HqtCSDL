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
    public partial class DatPhong : Form
    {
        SqlConnection conn;
        bool isLoading = false;

        public DatPhong()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=Xu4nNh4n\SQLEXPRESS;Initial Catalog=QLKSSS;Integrated Security=True");
        }

        private void DatPhong_Load(object sender, EventArgs e)
        {
            int tongWidth = lstVThongTin.ClientSize.Width;

            lstVThongTin.Columns[0].Width = (int)(tongWidth * 0.06);
            lstVThongTin.Columns[1].Width = (int)(tongWidth * 0.18);
            lstVThongTin.Columns[2].Width = (int)(tongWidth * 0.08);
            lstVThongTin.Columns[3].Width = (int)(tongWidth * 0.12);
            lstVThongTin.Columns[4].Width = (int)(tongWidth * 0.08);
            lstVThongTin.Columns[5].Width = (int)(tongWidth * 0.12);
            lstVThongTin.Columns[6].Width = (int)(tongWidth * 0.12);
            lstVThongTin.Columns[7].Width = (int)(tongWidth * 0.12);
            lstVThongTin.Columns[8].Width = (int)(tongWidth * 0.12);
            int tongWidth2 = lstVKH.ClientSize.Width;
            lstVKH.Columns[0].Width = (int)(tongWidth2 * 0.06);
            lstVKH.Columns[1].Width = (int)(tongWidth2 * 0.18);
            lstVKH.Columns[2].Width = (int)(tongWidth2 * 0.08);
            lstVKH.Columns[3].Width = (int)(tongWidth2 * 0.12);
            lstVKH.Columns[4].Width = (int)(tongWidth2 * 0.08);
            lstVKH.Columns[5].Width = (int)(tongWidth2 * 0.12);
            dtPNgayNhan.Format = DateTimePickerFormat.Short;
            dtPNgayNhan.CustomFormat = "dd/MM/yyyy";
            dtPNgayTra.Enabled = false;
            dtPNgayTra.Format = DateTimePickerFormat.Custom;
            dtPNgayTra.CustomFormat = " ";
            LoadTTKhach();
            lstVKH.Visible = false;
            LoadListViewKhach();
            isLoading = true;
            LoadLoaiPhong();
            isLoading = false;
        }
        private void LoadTTKhach()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = @"SELECT DP.MADATPH, KH.TENKH, KH.GIOITINH, KH.SDT, PH.SOPHONG, DP.NGAYDAT, DP.NGAYNHAN, DP.NGAYTRA, PH.TRANGTHAI
                               FROM KHACH KH
                               JOIN DATPHONG DP ON DP.MAKH = KH.MAKH
                               JOIN PHONG PH ON PH.MAPH = DP.MAPH
                               ORDER BY DP.MADATPH DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    lstVThongTin.Items.Clear();
                    int STT = 1;

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(STT.ToString());
                        item.SubItems.Add(reader["TENKH"]?.ToString() ?? "");
                        item.SubItems.Add(reader["GIOITINH"]?.ToString() ?? "");
                        item.SubItems.Add(reader["SDT"]?.ToString() ?? "");
                        item.SubItems.Add(reader["SOPHONG"]?.ToString() ?? "");

                        // NGAYDAT, NGAYNHAN non-null theo schema, nhưng vẫn kiểm tra an toàn
                        DateTime ngayDat = reader["NGAYDAT"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGAYDAT"]);
                        DateTime ngayNhan = reader["NGAYNHAN"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGAYNHAN"]);
                        item.SubItems.Add(ngayDat == DateTime.MinValue ? "" : ngayDat.ToShortDateString());
                        item.SubItems.Add(ngayNhan == DateTime.MinValue ? "" : ngayNhan.ToShortDateString());

                        // NGAYTRA có thể null
                        item.SubItems.Add(reader["NGAYTRA"] == DBNull.Value ? "" : Convert.ToDateTime(reader["NGAYTRA"]).ToShortDateString());

                        string trangThai = reader["TRANGTHAI"]?.ToString() ?? "";
                        string trangthaiHienThi = "";
                        if (trangThai == "Đã đặt") trangthaiHienThi = "Đã đặt";
                        else if (trangThai == "Đang ở") trangthaiHienThi = "Đã nhận phòng";
                        else trangthaiHienThi = trangThai; // fallback

                        item.SubItems.Add(trangthaiHienThi);

                        // Màu cho cột trạng thái (subitem index = 8)
                        int idxTrangThai = 8;
                        if (trangthaiHienThi == "Đã đặt")
                            item.SubItems[idxTrangThai].ForeColor = Color.Red;
                        else if (trangthaiHienThi == "Đã nhận phòng")
                            item.SubItems[idxTrangThai].ForeColor = Color.Green;

                        item.Tag = reader["MADATPH"]; // giữ mã đặt phòng
                        lstVThongTin.Items.Add(item);
                        STT++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị phiếu đặt: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
        private void LoadLoaiPhong()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = "SELECT MALP, TENLP FROM LOAIPHONG";
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbLoaiPhong.DataSource = dt;
                    cbLoaiPhong.DisplayMember = "TENLP";
                    cbLoaiPhong.ValueMember = "MALP";
                    cbLoaiPhong.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load loại phòng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void LoadPhongTheoLoai()
        {
            if (isLoading) return;
            if (cbLoaiPhong.SelectedValue == null) return;

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = "SELECT MAPH, SOPHONG FROM PHONG WHERE MALP = @MALP AND TRANGTHAI = N'Trống'";
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@MALP", cbLoaiPhong.SelectedValue);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbPhong.DataSource = dt;
                    cbPhong.DisplayMember = "SOPHONG";
                    cbPhong.ValueMember = "MAPH";
                    cbPhong.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load phòng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void cbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            LoadPhongTheoLoai();
          
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            string tenKhach = txtTenKhach.Text.Trim();
            string gioitinh = txtGioiTinh.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string madinhdanh = txtMaDinhDanh.Text.Trim();
            string loaigiayto = txtLoaiGiayTo.Text.Trim();
            string quoctich = txtQuocTich.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenKhach) ||
                string.IsNullOrWhiteSpace(gioitinh) ||
                string.IsNullOrWhiteSpace(sdt) ||
                string.IsNullOrWhiteSpace(madinhdanh) ||
                string.IsNullOrWhiteSpace(loaigiayto) ||
                string.IsNullOrWhiteSpace(quoctich))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!");
                return;
            }

            if (cbPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phòng!");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                int mapSelected = Convert.ToInt32(cbPhong.SelectedValue);

                // kiểm tra phòng
                string sqlCheckPhong = "SELECT TRANGTHAI FROM PHONG WHERE MAPH = @maph";
                using (SqlCommand cmd = new SqlCommand(sqlCheckPhong, conn))
                {
                    cmd.Parameters.AddWithValue("@maph", mapSelected);
                    string ttPhong = (cmd.ExecuteScalar()?.ToString() ?? "").Trim();

                    if (!ttPhong.Equals("Trống", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Phòng này hiện không trống, vui lòng chọn phòng khác.");
                        return;
                    }
                }

                DateTime ngayDat = DateTime.Today;
                DateTime ngayNhan = dtPNgayNhan.Value.Date;
                DateTime? ngayTra = dtPNgayTra.Checked ? dtPNgayTra.Value.Date : (DateTime?)null;

                if (ngayNhan < ngayDat)
                {
                    MessageBox.Show("Ngày nhận không được nhỏ hơn ngày đặt!");
                    return;
                }

                if (ngayTra.HasValue && ngayTra.Value <= ngayNhan)
                {
                    MessageBox.Show("Ngày trả phải lớn hơn ngày nhận!");
                    return;
                }

                // KHÁCH CŨ: kiểm tra theo SDT
                int makh = 0;
                using (SqlCommand cmd = new SqlCommand("SELECT MAKH FROM KHACH WHERE SDT = @sdt", conn))
                {
                    cmd.Parameters.AddWithValue("@sdt", sdt);
                    object rs = cmd.ExecuteScalar();
                    if (rs != null)
                    {
                        makh = Convert.ToInt32(rs);
                    }
                    else
                    {
                        // KHÁCH MỚI
                        string sqlInsertKhach = @"
                    INSERT INTO KHACH(TENKH, GIOITINH, SDT, MADINHDANH, LOAIGIAYTO, QUOCTICH)
                    OUTPUT INSERTED.MAKH 
                    VALUES (@tenkh, @gioitinh, @sdt, @madinhdanh, @loaigiayto, @quoctich)";

                        using (SqlCommand cmd2 = new SqlCommand(sqlInsertKhach, conn))
                        {
                            cmd2.Parameters.AddWithValue("@tenkh", tenKhach);
                            cmd2.Parameters.AddWithValue("@gioitinh", gioitinh);
                            cmd2.Parameters.AddWithValue("@sdt", sdt);
                            cmd2.Parameters.AddWithValue("@madinhdanh", madinhdanh);
                            cmd2.Parameters.AddWithValue("@loaigiayto", loaigiayto);
                            cmd2.Parameters.AddWithValue("@quoctich", quoctich);
                            makh = (int)cmd2.ExecuteScalar();
                        }
                    }
                }

                // Insert đặt phòng
                string sqlDat = @"
            INSERT INTO DATPHONG (MAKH, MAPH, NGAYDAT, NGAYNHAN, NGAYTRA)
            VALUES (@makh, @maph, @ngaydat, @ngaynhan, @ngaytra)";

                using (SqlCommand cmd = new SqlCommand(sqlDat, conn))
                {
                    cmd.Parameters.AddWithValue("@makh", makh);
                    cmd.Parameters.AddWithValue("@maph", mapSelected);
                    cmd.Parameters.AddWithValue("@ngaydat", ngayDat);
                    cmd.Parameters.AddWithValue("@ngaynhan", ngayNhan);
                    cmd.Parameters.AddWithValue("@ngaytra", (object)ngayTra ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }

                // Cập nhật trạng thái phòng
                string newStatus = (ngayNhan == ngayDat) ? "Đang ở" : "Đã đặt";
                using (SqlCommand cmd = new SqlCommand("UPDATE PHONG SET TRANGTHAI = @tt WHERE MAPH = @maph", conn))
                {
                    cmd.Parameters.AddWithValue("@tt", newStatus);
                    cmd.Parameters.AddWithValue("@maph", mapSelected);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đặt phòng thành công!");
                LoadTTKhach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void chkNgayTra_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkNgayTra.Checked)
            {
                dtPNgayTra.Enabled = false;
                dtPNgayTra.Format = DateTimePickerFormat.Custom;
                dtPNgayTra.CustomFormat = " ";
            }
            else
            {
                dtPNgayTra.Enabled = true;
                dtPNgayTra.Format = DateTimePickerFormat.Short;
                dtPNgayTra.CustomFormat = "dd/MM/yyyy";
            }
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            if (lstVThongTin.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu đặt phòng để nhận!");
                return;
            }

            // Lấy mã đặt phòng từ item.Tag
            int maDatPhong = Convert.ToInt32(lstVThongTin.SelectedItems[0].Tag);

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // 1. Lấy MAPH và TRANGTHAI hiện tại
                int maph = 0;
                string trangThai = "";

                using (SqlCommand cmdCheck = new SqlCommand(@"
                    SELECT DP.MAPH, PH.TRANGTHAI
                    FROM DATPHONG DP
                    JOIN PHONG PH ON DP.MAPH = PH.MAPH
                    WHERE DP.MADATPH = @madp", conn))
                {
                    cmdCheck.Parameters.AddWithValue("@madp", maDatPhong);
                    using (SqlDataReader reader = cmdCheck.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            maph = Convert.ToInt32(reader["MAPH"]);
                            trangThai = reader["TRANGTHAI"]?.ToString() ?? "";
                        }
                    }
                }

                if (maph == 0)
                {
                    MessageBox.Show("Không tìm thấy đặt phòng.");
                    return;
                }

                // 2. Kiểm tra trạng thái phòng
                if (trangThai == "Đang ở")
                {
                    MessageBox.Show("Phòng này đã được nhận rồi!");
                    return;
                }
                if (trangThai != "Đã đặt")
                {
                    MessageBox.Show("Phòng chưa được đặt nên không thể nhận!");
                    return;
                }

                // 3. Cập nhật NGÀY NHẬN & TRẠNG THÁI PHÒNG
                using (SqlCommand cmd = new SqlCommand(@"
                    UPDATE DATPHONG SET NGAYNHAN = @ngaynhan
                    WHERE MADATPH = @madp;

                    UPDATE PHONG SET TRANGTHAI = N'Đang ở'
                    WHERE MAPH = @maph;", conn))
                {
                    cmd.Parameters.AddWithValue("@ngaynhan", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@madp", maDatPhong);
                    cmd.Parameters.AddWithValue("@maph", maph);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Nhận phòng thành công!");
                LoadTTKhach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void lstVThongTin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVThongTin.SelectedItems.Count == 0)
                return;

            ListViewItem item = lstVThongTin.SelectedItems[0];
            int maDatPhong = Convert.ToInt32(item.Tag);

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = @"
                    SELECT KH.TENKH, KH.GIOITINH, KH.SDT, KH.MADINHDANH, KH.LOAIGIAYTO, KH.QUOCTICH,
                           LP.MALP, PH.MAPH,
                           DP.NGAYNHAN, DP.NGAYTRA
                    FROM DATPHONG DP
                    JOIN KHACH KH ON DP.MAKH = KH.MAKH
                    JOIN PHONG PH ON DP.MAPH = PH.MAPH
                    JOIN LOAIPHONG LP ON PH.MALP = LP.MALP
                    WHERE DP.MADATPH = @madp";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@madp", maDatPhong);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string maLoaiPhong = "";
                        string maPhong = "";

                        if (reader.Read())
                        {
                            // Load thông tin khách
                            txtTenKhach.Text = reader["TENKH"]?.ToString() ?? "";
                            txtGioiTinh.Text = reader["GIOITINH"]?.ToString() ?? "";
                            txtSDT.Text = reader["SDT"]?.ToString() ?? "";
                            txtMaDinhDanh.Text = reader["MADINHDANH"]?.ToString() ?? "";
                            txtLoaiGiayTo.Text = reader["LOAIGIAYTO"]?.ToString() ?? "";
                            txtQuocTich.Text = reader["QUOCTICH"]?.ToString() ?? "";

                            // Lưu loại phòng & phòng để set sau (dùng string to be safe)
                            maLoaiPhong = reader["MALP"]?.ToString() ?? "";
                            maPhong = reader["MAPH"]?.ToString() ?? "";

                            // Ngày nhận
                            if (reader["NGAYNHAN"] != DBNull.Value)
                                dtPNgayNhan.Value = Convert.ToDateTime(reader["NGAYNHAN"]);
                            else
                                dtPNgayNhan.Value = DateTime.Today;

                            // Ngày trả
                            if (reader["NGAYTRA"] == DBNull.Value)
                            {
                                chkNgayTra.Checked = false;
                                dtPNgayTra.Enabled = false;
                                dtPNgayTra.CustomFormat = " ";
                            }
                            else
                            {
                                chkNgayTra.Checked = true;
                                dtPNgayTra.Enabled = true;
                                dtPNgayTra.Format = DateTimePickerFormat.Short;
                                dtPNgayTra.Value = Convert.ToDateTime(reader["NGAYTRA"]);
                            }

                            // set selected values safely
                            // đóng reader trước khi gọi LoadPhongTheoLoai (đã trong using so reader auto closed)
                            reader.Close();

                            isLoading = true;
                            cbLoaiPhong.SelectedValue = string.IsNullOrEmpty(maLoaiPhong) ? (object)null : Convert.ToInt32(maLoaiPhong);
                            LoadPhongTheoLoai();
                            cbPhong.SelectedValue = string.IsNullOrEmpty(maPhong) ? (object)null : Convert.ToInt32(maPhong);
                            isLoading = false;

                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load phiếu đặt: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void LoadListViewKhach()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
            lstVKH.Items.Clear();

            string sql = "SELECT MAKH, TENKH, GIOITINH, SDT, MADINHDANH, LOAIGIAYTO, QUOCTICH FROM KHACH";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["MAKH"].ToString());
                item.SubItems.Add(dr["TENKH"].ToString());
                item.SubItems.Add(dr["GIOITINH"].ToString());
                item.SubItems.Add(dr["SDT"].ToString());
                item.SubItems.Add(dr["MADINHDANH"].ToString());
                item.SubItems.Add(dr["LOAIGIAYTO"].ToString());
                item.SubItems.Add(dr["QUOCTICH"].ToString());

                // Lưu MAKH vào .Tag để sau dùng
                item.Tag = dr["MAKH"];

                lstVKH.Items.Add(item);
            }

            dr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void lstVKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVKH.SelectedItems.Count == 0)
                return;

            ListViewItem item = lstVKH.SelectedItems[0];

            txtTenKhach.Text = item.SubItems[1].Text;
            txtGioiTinh.Text = item.SubItems[2].Text;
            txtSDT.Text = item.SubItems[3].Text;
            txtMaDinhDanh.Text = item.SubItems[4].Text;
            txtLoaiGiayTo.Text = item.SubItems[5].Text;
            txtQuocTich.Text = item.SubItems[6].Text;

            // Lấy mã khách
            int makh = Convert.ToInt32(item.Tag);
        }

        private void cbHienThiDSKH_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThiDSKH.Checked)
            {
                lstVKH.Visible = true;
                LoadListViewKhach();               
            }
            else
            {
                lstVKH.Items.Clear();  
                lstVKH.Visible = false;

     
                txtTenKhach.Text = "";
                txtGioiTinh.Text = "";
                txtSDT.Text = "";
                txtMaDinhDanh.Text = "";
                txtLoaiGiayTo.Text = "";
                txtQuocTich.Text = "";
            }
        }
    }
}
