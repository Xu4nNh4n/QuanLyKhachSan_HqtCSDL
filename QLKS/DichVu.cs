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
    public partial class DichVu : Form
    {
        SqlConnection conn;
        public DichVu()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=Xu4nNh4n\SQLEXPRESS;Initial Catalog=QLKS;Integrated Security=True");
        }

        private void DichVu_Load(object sender, EventArgs e)
        {
            LoadDanhSachDichVu();
            int tongWidth = lstTTDichVu.ClientSize.Width;
            lstTTDichVu.Columns[0].Width = (int)(tongWidth * 0.2);
            lstTTDichVu.Columns[1].Width = (int)(tongWidth * 0.5);
            lstTTDichVu.Columns[2].Width = (int)(tongWidth * 0.4);
            LoadSuDungDV();
            int tongWidth2 = lstVTTDatDichVu.ClientSize.Width;
            lstVTTDatDichVu.Columns[0].Width = (int)(tongWidth2 * 0.08);   
            lstVTTDatDichVu.Columns[1].Width = (int)(tongWidth2 * 0.12);   
            lstVTTDatDichVu.Columns[2].Width = (int)(tongWidth2 * 0.25);  
            lstVTTDatDichVu.Columns[3].Width = (int)(tongWidth2 * 0.15);   
            lstVTTDatDichVu.Columns[4].Width = (int)(tongWidth2 * 0.15);   
            lstVTTDatDichVu.Columns[5].Width = (int)(tongWidth2 * 0.25);   
            LoadPhongLenCombo();
            LoadDichVuLenCombo();
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Lựa chọn trạng thái");
            cbTrangThai.Items.Add("Đã đặt");
            cbTrangThai.Items.Add("Đang thực hiện");
            cbTrangThai.Items.Add("Đã hoàn thành");

            cbTrangThai.SelectedIndex = 0; 

        }
        void LoadDanhSachDichVu()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT MADV, TENDV, DONGIA FROM DICHVU";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                lstTTDichVu.Items.Clear();

                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(rd["MADV"].ToString());
                    item.SubItems.Add(rd["TENDV"].ToString());
                    item.SubItems.Add(rd["DONGIA"].ToString());
                    lstTTDichVu.Items.Add(item);
                }

                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dịch vụ: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        void LoadSuDungDV()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"
            SELECT SD.MASDDV, KH.TENKH, DV.TENDV, NV.TENNV ,SD.SOLUONG, SD.GHICHU, SD.TRANGTHAI
            FROM SUDUNGDV SD
            JOIN DATPHONG DP ON DP.MADATPH = SD.MADATPH
            JOIN KHACH KH ON KH.MAKH = DP.MAKH
            JOIN DICHVU DV ON DV.MADV = SD.MADV
            JOIN NHANVIEN NV ON NV.MANV = SD.MANV 
            WHERE SD.TRANGTHAI  NOT IN (N'Đã hoàn thành')";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader rd = cmd.ExecuteReader();

                lstVTTDatDichVu.Items.Clear();

                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(rd["MASDDV"].ToString());
                    item.SubItems.Add(rd["TENKH"].ToString());
                    item.SubItems.Add(rd["TENDV"].ToString());
                    item.SubItems.Add(rd["TENNV"].ToString());
                    item.SubItems.Add(rd["SOLUONG"].ToString());
                    item.SubItems.Add(rd["GHICHU"].ToString());
                    item.SubItems.Add(rd["TRANGTHAI"].ToString());

                    lstVTTDatDichVu.Items.Add(item);
                }

                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load sử dụng DV: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        void LoadPhongLenCombo()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = @"
            SELECT MAPH, SOPHONG
            FROM PHONG
            WHERE TRANGTHAI = N'Đang ở'";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbPhongDat.DataSource = dt;
                cbPhongDat.DisplayMember = "SOPHONG";
                cbPhongDat.ValueMember = "MAPH";

                if (dt.Rows.Count > 0)
                {
                    cbPhongDat.SelectedIndex = 0;  
                }
                else
                {
                    cbPhongDat.SelectedIndex = -1; 
                    MessageBox.Show("Không có phòng nào đang ở để đặt dịch vụ.");
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
        void LoadDichVuLenCombo()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string sql = "SELECT MADV, TENDV FROM DICHVU";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbTenDichVu.DataSource = dt;
                cbTenDichVu.DisplayMember = "TENDV"; 
                cbTenDichVu.ValueMember = "MADV";      
                cbTenDichVu.SelectedIndex = -1;     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dịch vụ: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void lstTTDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTTDichVu.SelectedItems.Count == 0) return;

            ListViewItem item = lstTTDichVu.SelectedItems[0];

            txtTenDichVu.Text = item.SubItems[1].Text;
            txtDonGia.Text = item.SubItems[2].Text;
        }

        private void lstVTTDatDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVTTDatDichVu.SelectedItems.Count == 0)
                return;

            ListViewItem it = lstVTTDatDichVu.SelectedItems[0];

            cbTenDichVu.Text = it.SubItems[2].Text;
            numricSoLuong.Value = int.Parse(it.SubItems[4].Text);
            txtGhiChu.Text = it.SubItems[5].Text;

            cbTrangThai.Text = it.SubItems[6].Text;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtTenDichVu.Text.Trim();
            string gia = txtDonGia.Text.Trim();

            if (ten == "" || gia == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = @"INSERT INTO DICHVU (TENDV, DONGIA)
                       VALUES (@TEN, @GIA)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TEN", ten);
                cmd.Parameters.AddWithValue("@GIA", gia);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm dịch vụ thành công!");
                LoadDanhSachDichVu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm dịch vụ: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(lstTTDichVu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để sửa.");
                return;
            }
            string maDV = lstTTDichVu.SelectedItems[0].SubItems[0].Text;
            string ten = txtTenDichVu.Text.Trim();
            string gia = txtDonGia.Text.Trim();
            if (ten == "" || gia == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.");
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string sql = @"UPDATE DICHVU
                       SET TENDV = @TEN, DONGIA = @GIA
                       WHERE MADV = @MADV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TEN", ten);
                cmd.Parameters.AddWithValue("@GIA", gia);
                cmd.Parameters.AddWithValue("@MADV", maDV);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa dịch vụ thành công!");
                LoadDanhSachDichVu();
                txtDonGia.Clear();
                txtTenDichVu.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa dịch vụ: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstTTDichVu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để xóa.");
                return;
            }
            string maDV = lstTTDichVu.SelectedItems[0].SubItems[0].Text;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string sql = @"DELETE FROM DICHVU
                       WHERE MADV = @MADV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MADV", maDV);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dịch vụ thành công!");
                LoadDanhSachDichVu();
                txtDonGia.Clear();
                txtTenDichVu.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa dịch vụ: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (cbPhongDat.SelectedIndex == -1 || cbTenDichVu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phòng và dịch vụ.");
                return;
            }

            int maPhong = (int)cbPhongDat.SelectedValue;
            int maDichVu = (int)cbTenDichVu.SelectedValue;
            int soLuong = (int)numricSoLuong.Value;
            string ghiChu = txtGhiChu.Text.Trim();

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Lấy MADATPH
                string getMaDatPhSql = @"SELECT TOP 1 MADATPH
                                        FROM DATPHONG
                                        WHERE MAPH = 1 AND NGAYTRA IS NULL";
                SqlCommand getMaDatPhCmd = new SqlCommand(getMaDatPhSql, conn);
                getMaDatPhCmd.Parameters.AddWithValue("@MAPH", maPhong);

                object result = getMaDatPhCmd.ExecuteScalar();
                if (result == null)
                {
                    MessageBox.Show("Không tìm thấy đặt phòng cho phòng đã chọn.");
                    return;
                }

                int maDatPh = (int)result;

                // GỌI STORE PROCEDURE
                SqlCommand cmd = new SqlCommand("sp_CapNhatDichVuPhong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MADATPH", maDatPh);
                cmd.Parameters.AddWithValue("@MADV", maDichVu);
                cmd.Parameters.AddWithValue("@MANV", Account.Current.MaNV);
                cmd.Parameters.AddWithValue("@SOLUONG", soLuong);
                cmd.Parameters.AddWithValue("@GHICHU", ghiChu);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thực hiện thành công!");
                LoadSuDungDV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sử dụng dịch vụ: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }   
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (lstVTTDatDichVu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để lưu.");
                return;
            }

            string maSDDV = lstVTTDatDichVu.SelectedItems[0].SubItems[0].Text;
            string trangThai = cbTrangThai.Text.Trim();
            int soLuong = (int)numricSoLuong.Value;
            string ghiChu = txtGhiChu.Text.Trim();

            if (cbTrangThai.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái hợp lệ.");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = @"
            UPDATE SUDUNGDV
            SET SOLUONG = @SL,
                GHICHU = @GC,
                TRANGTHAI = @TT
            WHERE MASDDV = @MASDDV";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SL", soLuong);
                cmd.Parameters.AddWithValue("@GC", ghiChu);
                cmd.Parameters.AddWithValue("@TT", trangThai);
                cmd.Parameters.AddWithValue("@MASDDV", maSDDV);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật trạng thái thành công!");
                LoadSuDungDV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
