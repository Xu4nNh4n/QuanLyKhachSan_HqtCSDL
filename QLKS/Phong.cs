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
    public partial class Phong : Form
    {
        SqlConnection conn;

        public Phong()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=Xu4nNh4n\SQLEXPRESS;Initial Catalog=QLKS;Integrated Security=True");
        }

        private void Phong_Load(object sender, EventArgs e)
        {
            LoadLoaiPhong();
            int tongWidth = lstVLoaiPhong.ClientSize.Width;
            lstVLoaiPhong.Columns[0].Width = (int)(tongWidth * 0.2);
            lstVLoaiPhong.Columns[1].Width = (int)(tongWidth * 0.4);
            lstVLoaiPhong.Columns[2].Width = (int)(tongWidth * 0.2);
            lstVLoaiPhong.Columns[3].Width = (int)(tongWidth * 0.2);
            LoadPhong();
            int tongWidth2 = lstVPhong.ClientSize.Width;
            lstVPhong.Columns[0].Width = (int)(tongWidth * 0.2);
            lstVPhong.Columns[1].Width = (int)(tongWidth * 0.15);
            lstVPhong.Columns[2].Width = (int)(tongWidth * 0.36);
            lstVPhong.Columns[3].Width = (int)(tongWidth * 0.2);
            if (Account.Current.VaiTro != "Quản trị viên")
            {
                txtSoLuong.Enabled = false;
                txtGia.Enabled = false;
                txtSoPhong.Enabled = false;
                txtTenLoai.Enabled = false;
                btnSuaLoai.Enabled = false;
                btnSuaPhong.Enabled = false;
                btnThemLoai.Enabled = false;
                btnThemPhong.Enabled = false;
                btnXoaLoai.Enabled = false;
                btnXoaPhong.Enabled = false;
                cbLoaiPhong.Enabled = false;
            }
            }
        void LoadLoaiPhong()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                lstVLoaiPhong.Items.Clear();

                // LẤY LOẠI PHÒNG ĐỂ ĐỔ LISTVIEW
                string query = "SELECT * FROM LOAIPHONG";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["MALP"].ToString());
                    item.SubItems.Add(reader["TENLP"].ToString());
                    item.SubItems.Add(reader["GIA"].ToString());
                    item.SubItems.Add(reader["SONGUOITOIDA"].ToString());
                    lstVLoaiPhong.Items.Add(item);
                }
                reader.Close();

                // ĐỔ COMBOBOX
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Thêm placeholder
                DataRow dr = dt.NewRow();
                dr["MALP"] = DBNull.Value;
                dr["TENLP"] = "Chọn loại phòng";
                dt.Rows.InsertAt(dr, 0);

                cbLoaiPhong.DataSource = dt;
                cbLoaiPhong.DisplayMember = "TENLP";
                cbLoaiPhong.ValueMember = "MALP";
                cbLoaiPhong.SelectedIndex = 0;
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


        void LoadPhong()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT P.MAPH, P.SOPHONG, P.MALP, LP.TENLP, P.TRANGTHAI   FROM PHONG P JOIN LOAIPHONG LP ON LP.MALP = P.MALP";
        
        SqlCommand cmdPhong = new SqlCommand(query, conn);
                SqlDataReader reader = cmdPhong.ExecuteReader();

                lstVPhong.Items.Clear();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["MAPH"].ToString());

                    item.SubItems.Add(reader["SOPHONG"].ToString()); 
                    item.SubItems.Add(reader["TENLP"].ToString());    
                    item.SubItems.Add(reader["TRANGTHAI"].ToString());

                    // 👉 Thêm MALP vào Tag (không hiển thị)
                    item.Tag = reader["MALP"].ToString();

                    lstVPhong.Items.Add(item);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string soPhong = txtSoPhong.Text;
                string malp = cbLoaiPhong.SelectedValue.ToString();
                if (soPhong == null)
                {
                    MessageBox.Show("Vui lòng nhập số phòng");
                    return;
                }
                string KiemTraPhong = "SELECT COUNT(*) FROM PHONG WHERE SOPHONG = @SOPHONG AND MALP = @MALP";
                SqlCommand cmdKT = new SqlCommand(KiemTraPhong, conn);
                cmdKT.Parameters.AddWithValue("@SOPHONG", soPhong);
                cmdKT.Parameters.AddWithValue("@MALP", malp);
                int count = (int)cmdKT.ExecuteScalar();
                if(count > 0)
                {
                    MessageBox.Show("Phòng này đã tồn tại ở loại phòng đó");
                    txtSoPhong.Clear();
                    cbLoaiPhong.SelectedIndex = 0;
                    return;
                }
                string sqlThem = @"INSERT INTO PHONG (SOPHONG, MALP, TRANGTHAI) 
                           VALUES (@SOPHONG, @MALP, N'Trống')";

                SqlCommand cmd = new SqlCommand(sqlThem, conn);
                cmd.Parameters.AddWithValue("@SOPHONG", soPhong);
                cmd.Parameters.AddWithValue("@MALP", malp);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm phòng thành công!");

                txtSoPhong.Clear();
                cbLoaiPhong.SelectedIndex = 0;
                cbLoaiPhong.Text = "Chọn loại phòng";
                LoadPhong();

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

        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            if (lstVPhong.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng để xóa!");
                return;
            }

            string maph = lstVPhong.SelectedItems[0].SubItems[0].Text;

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Kiểm tra trạng thái
                string sqlCheck = "SELECT TRANGTHAI FROM PHONG WHERE MAPH = @MAPH";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@MAPH", maph);

                string tt = cmdCheck.ExecuteScalar()?.ToString() ?? "";
                if (tt == "Đang ở" || tt == "Đã đặt")
                {
                    MessageBox.Show("Không thể xóa phòng đang sử dụng!");
                    return;
                }

                string sqlDel = "DELETE FROM PHONG WHERE MAPH = @MAPH";
                SqlCommand cmdDel = new SqlCommand(sqlDel, conn);
                cmdDel.Parameters.AddWithValue("@MAPH", maph);
                cmdDel.ExecuteNonQuery();

                MessageBox.Show("Xóa phòng thành công!");
                LoadPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa phòng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnSuaPhong_Click(object sender, EventArgs e)
        {
            string soPhong = txtSoPhong.Text.Trim();
            string malp = cbLoaiPhong.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(soPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng để sửa!");
                return;
            }

            if (string.IsNullOrEmpty(malp))
            {
                MessageBox.Show("Vui lòng chọn loại phòng!");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sqlCheckTrangThai = "SELECT TRANGTHAI FROM PHONG WHERE SOPHONG = @SOPHONG";
                SqlCommand cmdCheck = new SqlCommand(sqlCheckTrangThai, conn);
                cmdCheck.Parameters.AddWithValue("@SOPHONG", soPhong);

                string ttPhong = cmdCheck.ExecuteScalar()?.ToString() ?? "";

                if (ttPhong == "Đang ở")
                {
                    MessageBox.Show("Phòng đang có người ở. Không thể sửa!");
                    return;
                }

                string sqlKiemTraTrung = @"
                                        SELECT COUNT(*) 
                                        FROM PHONG 
                                        WHERE SOPHONG = @SOPHONG 
                                          AND MALP = @MALP";

                SqlCommand cmdTrung = new SqlCommand(sqlKiemTraTrung, conn);
                cmdTrung.Parameters.AddWithValue("@SOPHONG", soPhong);
                cmdTrung.Parameters.AddWithValue("@MALP", malp);

                int countTrung = (int)cmdTrung.ExecuteScalar();

                if (countTrung > 0)
                {
                    MessageBox.Show("Phòng này đã tồn tại trong loại phòng đó!");
                    return;
                }

                string sqlSua = @"
                                UPDATE PHONG 
                                SET MALP = @MALP
                                WHERE SOPHONG = @SOPHONG";

                SqlCommand cmdSua = new SqlCommand(sqlSua, conn);
                cmdSua.Parameters.AddWithValue("@SOPHONG", soPhong);
                cmdSua.Parameters.AddWithValue("@MALP", malp);

                cmdSua.ExecuteNonQuery();

                MessageBox.Show("Sửa phòng thành công!");

                LoadPhong();

                txtSoPhong.Clear();
                cbLoaiPhong.SelectedIndex = -1;
                cbLoaiPhong.Text = "Chọn loại phòng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa phòng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            string tenLP = txtTenLoai.Text.Trim();
            string giaText = txtGia.Text.Trim();
            string soNguoiText = txtSoLuong.Text.Trim();

            if (tenLP == "" || giaText == "" || soNguoiText == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!decimal.TryParse(giaText, out decimal gia))
            {
                MessageBox.Show("Giá phải là số!");
                return;
            }

            if (!int.TryParse(soNguoiText, out int soNguoi))
            {
                MessageBox.Show("Số người tối đa phải là số!");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sqlCheck = "SELECT COUNT(*) FROM LOAIPHONG WHERE TENLP = @TENLP";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@TENLP", tenLP);

                int count = (int)cmdCheck.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Tên loại phòng đã tồn tại!");
                    return;
                }

                string sqlInsert = "INSERT INTO LOAIPHONG (TENLP, GIA, SONGUOITOIDA) VALUES (@TENLP, @GIA, @SONGUOI)";
                SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn);
                cmdInsert.Parameters.AddWithValue("@TENLP", tenLP);
                cmdInsert.Parameters.AddWithValue("@GIA", gia);
                cmdInsert.Parameters.AddWithValue("@SONGUOI", soNguoi);

                cmdInsert.ExecuteNonQuery();

                MessageBox.Show("Thêm loại phòng thành công!");
                LoadLoaiPhong();
                txtTenLoai.Clear();
                txtGia.Clear();
                txtSoLuong.Clear();
                txtTenLoai.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm loại phòng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnXoaLoai_Click(object sender, EventArgs e)
        {
            if (lstVLoaiPhong.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn loại phòng để xóa!");
                return;
            }

            string malp = lstVLoaiPhong.SelectedItems[0].SubItems[0].Text;

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Kiểm tra loại phòng có đang dùng không
                string sqlCheck = "SELECT COUNT(*) FROM PHONG WHERE MALP = @MALP";
                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@MALP", malp);

                int count = (int)cmdCheck.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Không thể xóa! Đang có phòng sử dụng loại phòng này.");
                    return;
                }

                string sqlDelete = "DELETE FROM LOAIPHONG WHERE MALP = @MALP";
                SqlCommand cmd = new SqlCommand(sqlDelete, conn);
                cmd.Parameters.AddWithValue("@MALP", malp);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa loại phòng thành công!");

                LoadLoaiPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa loại phòng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void lstVPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVPhong.SelectedItems.Count == 0)
                return;

            ListViewItem item = lstVPhong.SelectedItems[0];

            txtSoPhong.Text = item.SubItems[1].Text; 

            cbLoaiPhong.SelectedValue = item.Tag.ToString();
        }

        private void lstVLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVLoaiPhong.SelectedItems.Count == 0)
                return;

            ListViewItem item = lstVLoaiPhong.SelectedItems[0];

            txtTenLoai.Text = item.SubItems[1].Text;      
            txtGia.Text = item.SubItems[2].Text;              
            txtSoLuong.Text = item.SubItems[3].Text;          
        }

        private void btnSuaLoai_Click(object sender, EventArgs e)
        {
            if (lstVLoaiPhong.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn loại phòng để sửa!");
                return;
            }

            string malp = lstVLoaiPhong.SelectedItems[0].SubItems[0].Text;
            string tenLP = txtTenLoai.Text.Trim();
            string giaText = txtGia.Text.Trim();
            string soNguoi = txtSoLuong.Text.Trim();

            if (tenLP == "" || giaText == "" || soNguoi == "")
            {
                MessageBox.Show("Không được để trống!");
                return;
            }

            if (!decimal.TryParse(giaText, out decimal gia))
            {
                MessageBox.Show("Giá phải là số!");
                return;
            }

            if (!int.TryParse(soNguoi, out int sn))
            {
                MessageBox.Show("Số người tối đa phải là số!");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sqlUpdate = @"
            UPDATE LOAIPHONG 
            SET TENLP = @TENLP, GIA = @GIA, SONGUOITOIDA = @SONGUOI
            WHERE MALP = @MALP";

                SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
                cmd.Parameters.AddWithValue("@MALP", malp);
                cmd.Parameters.AddWithValue("@TENLP", tenLP);
                cmd.Parameters.AddWithValue("@GIA", gia);
                cmd.Parameters.AddWithValue("@SONGUOI", sn);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Sửa loại phòng thành công!");
                LoadLoaiPhong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa loại phòng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void TimKiemPhong(string text)
        {
            foreach (ListViewItem item in lstVPhong.Items)
            {
                bool match = false;
                foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                {
                    if (sub.Text.ToLower().Contains(text.ToLower()))
                    {
                        match = true;
                        break;
                    }
                }

                item.BackColor = match ? Color.Yellow : Color.White;
            }
        }
        private void TimKiemLoaiPhong(string text)
        {
            foreach (ListViewItem item in lstVLoaiPhong.Items)
            {
                bool match = false;

                foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                {
                    if (sub.Text.ToLower().Contains(text.ToLower()))
                    {
                        match = true;
                        break;
                    }
                }

                item.BackColor = match ? Color.Yellow : Color.White;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Nhập từ khóa tìm kiếm!");
                return;
            }

            if (radPhong.Checked)
                TimKiemPhong(keyword);
            else if (radLoaiPhong.Checked)
                TimKiemLoaiPhong(keyword);
        }
    }
}
