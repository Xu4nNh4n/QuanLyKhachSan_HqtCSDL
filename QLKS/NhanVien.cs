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
    public partial class NhanVien : Form
    {
        SqlConnection conn;
        public NhanVien()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=Xu4nNh4n\SQLEXPRESS;Initial Catalog=QLKSSS;Integrated Security=True");
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            loadDSNV();
            cbChucVu.Items.Clear();
            cbChucVu.Items.Add("Chọn chức vụ");
            cbChucVu.Items.Add("Quản lý");
            cbChucVu.Items.Add("Nhân viên");
            cbChucVu.SelectedIndex = 0;
        }
        private void loadDSNV()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                tvDSNV.Nodes.Clear();

                TreeNode root = new TreeNode("Danh sách nhân viên");
                tvDSNV.Nodes.Add(root);

                // Lấy danh sách chức vụ
                string sqlChucVu = "SELECT DISTINCT CHUCVU FROM NHANVIEN";
                SqlCommand cmdChucVu = new SqlCommand(sqlChucVu, conn);
                SqlDataReader drChucVu = cmdChucVu.ExecuteReader();

                List<string> lstChucVu = new List<string>();
                while (drChucVu.Read())
                {
                    lstChucVu.Add(drChucVu["CHUCVU"].ToString());
                }
                drChucVu.Close();

                // Ưu tiên Quản lý lên đầu
                lstChucVu = lstChucVu
                            .OrderBy(x => x == "Quản lý" ? 0 : 1)
                            .ThenBy(x => x)
                            .ToList();

                foreach (string chucVu in lstChucVu)
                {
                    TreeNode nodeChucVu = new TreeNode(chucVu);
                    root.Nodes.Add(nodeChucVu);

                    string sqlNhanVien = @"
                SELECT N.MANV, N.TENNV, N.GIOITINH, N.SDT, N.CCCD, N.DIACHI, N.NGAYVAOLAM, 
                       TK.TENTK, TK.MATKHAU, TK.NGAYTAO, TK.TRANGTHAI
                FROM NHANVIEN N
                JOIN TAIKHOAN TK ON N.MANV = TK.MANV
                WHERE N.CHUCVU = @CHUCVU";

                    SqlCommand cmdNhanVien = new SqlCommand(sqlNhanVien, conn);
                    cmdNhanVien.Parameters.AddWithValue("@CHUCVU", chucVu);

                    SqlDataReader drNhanVien = cmdNhanVien.ExecuteReader();

                    while (drNhanVien.Read())
                    {
                        string tenNV = drNhanVien["TENNV"].ToString();
                        string trangthai = drNhanVien["TRANGTHAI"].ToString();

                        TreeNode nodeNV = new TreeNode(tenNV);
                        nodeNV.Tag = drNhanVien["MANV"].ToString();      
                        nodeChucVu.Nodes.Add(nodeNV);

                        TreeNode nodeInfo = new TreeNode("Thông tin nhân viên");
                        nodeNV.Nodes.Add(nodeInfo);

                        nodeInfo.Nodes.Add($"Mã NV: {drNhanVien["MANV"]}");
                        nodeInfo.Nodes.Add($"Giới tính: {drNhanVien["GIOITINH"]}");
                        nodeInfo.Nodes.Add($"SDT: {drNhanVien["SDT"]}");
                        nodeInfo.Nodes.Add($"CCCD: {drNhanVien["CCCD"]}");
                        nodeInfo.Nodes.Add($"Địa chỉ: {drNhanVien["DIACHI"]}");

                        DateTime ngayVaoLam = Convert.ToDateTime(drNhanVien["NGAYVAOLAM"]);
                        nodeInfo.Nodes.Add($"Ngày vào làm: {ngayVaoLam:dd/MM/yyyy}");

                        // Node đăng nhập
                        TreeNode nodeLogin = new TreeNode("Thông tin đăng nhập");
                        nodeNV.Nodes.Add(nodeLogin);

                        nodeLogin.Nodes.Add($"Tài khoản: {drNhanVien["TENTK"]}");
                        nodeLogin.Nodes.Add($"Mật khẩu: {drNhanVien["MATKHAU"]}");

                        DateTime ngayTao = Convert.ToDateTime(drNhanVien["NGAYTAO"]);
                        nodeLogin.Nodes.Add($"Ngày tạo: {ngayTao:dd/MM/yyyy}");

                        // Trạng thái
                        TreeNode nodeTT = new TreeNode("Trạng thái: " + trangthai);

                        nodeTT.ForeColor = (trangthai == "Hoạt động" ? Color.Green : Color.Red);

                        nodeLogin.Nodes.Add(nodeTT);
                    }

                    drNhanVien.Close();
                }

                tvDSNV.ExpandAll(); // Nếu muốn mặc định đóng thì bỏ dòng này
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách nhân viên: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void loadChucVu()
        {

        }
        private void tvDSNV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) return;
            if (!int.TryParse(e.Node.Tag.ToString(), out int maNV))
                return;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string sqlTTNV = @"SELECT NV.TENNV, NV.GIOITINH, NV.SDT, NV.CCCD, NV.DIACHI, NV.CHUCVU, TK.TENTK, TK.MATKHAU, TK.TRANGTHAI FROM NHANVIEN NV JOIN TAIKHOAN TK ON TK.MANV = NV.MANV WHERE NV.MANV = @MANV";
                SqlCommand cmd = new SqlCommand(sqlTTNV, conn);
                cmd.Parameters.AddWithValue("@MANV", maNV);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    txtHoTen.Text = dr["TENNV"].ToString();
                    string GioiTinh = dr["GIOITINH"].ToString();
                    if(GioiTinh == "Nam")
                    {
                        radNam.Checked = true;
                        radNu.Checked = false;
                    }
                    else
                    {
                        radNam.Checked = false;
                        radNu.Checked = true;
                    }
                    txtSDT.Text = dr["SDT"].ToString();
                    txtCCCD.Text = dr["CCCD"].ToString();
                    txtDiaChi.Text = dr["DIACHI"].ToString();
                    cbChucVu.SelectedItem = dr["CHUCVU"].ToString();
                    txtTenDangNhap.Text = dr["TENTK"].ToString();
                    txtMatKhau.Text = dr["MATKHAU"].ToString();
                    string trangthai = dr["TRANGTHAI"].ToString();
                    if(trangthai == "Hoạt động")
                    {
                        radHoatDong.Checked = true;
                        radKhoa.Checked = false;
                    }
                    else
                    {
                        radHoatDong.Checked = false;
                        radKhoa.Checked = true;
                    }
                }
                dr.Close();
                txtHoTen.Tag = maNV;
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(cbChucVu.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn chức vụ");
                return;
            } 
                
            string tennv = txtHoTen.Text.Trim();
            string GioiTinh = "";
            if (radNam.Checked == true) GioiTinh = radNam.Text.Trim();
            if (radNu.Checked == true) GioiTinh = radNu.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string CCCD = txtCCCD.Text.Trim();
            string DiaChi = txtDiaChi.Text.Trim();
            string ChucVu = cbChucVu.SelectedItem.ToString();
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            string trangthai = "";
            if (radHoatDong.Checked == true) trangthai = radHoatDong.Text.Trim();
            if (radKhoa.Checked == true) trangthai = radKhoa.Text.Trim();
            if (tennv == "" || GioiTinh == "" || sdt == "" || CCCD == "" || DiaChi == "" || username == "" || password == "" || trangthai == "")
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!");
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string sqlCheckTenDN = "SELECT COUNT(*) FROM TAIKHOAN WHERE TENTK = @TENTK";
                SqlCommand cmdCheck = new SqlCommand(sqlCheckTenDN, conn);
                cmdCheck.Parameters.AddWithValue("@TENTK", username);
                int count = (int)cmdCheck.ExecuteScalar();
                if(count > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn tên khác!");
                    return;
                }
                string sqlCheckCCCD = "SELECT COUNT(*) FROM NHANVIEN WHERE CCCD = @CCCD";
                SqlCommand cmd = new SqlCommand(sqlCheckCCCD, conn);
                cmd.Parameters.AddWithValue("@CCCD", txtCCCD.Text);

                int count2 = (int)cmd.ExecuteScalar();
                if (count2 > 0)
                {
                    MessageBox.Show("CCCD đã tồn tại. Vui lòng nhập lại!");
                    return;
                }
                DateTime today = DateTime.Today;
                string sqlInsertNV = @"
                                    INSERT INTO NHANVIEN(TENNV, GIOITINH, SDT, CCCD, DIACHI, CHUCVU, NGAYVAOLAM) OUTPUT INSERTED.MANV VALUES (@tennv, @gioitinh, @sdt, @cccd, @diachi, @chucvu, @ngayvaolam)";
                SqlCommand cmdInsertNV = new SqlCommand(sqlInsertNV, conn);
                cmdInsertNV.Parameters.AddWithValue("@tennv", tennv);
                cmdInsertNV.Parameters.AddWithValue("@gioitinh", GioiTinh);
                cmdInsertNV.Parameters.AddWithValue("@sdt", sdt);
                cmdInsertNV.Parameters.AddWithValue("@cccd", CCCD);
                cmdInsertNV.Parameters.AddWithValue("@diachi", DiaChi);
                cmdInsertNV.Parameters.AddWithValue("@chucvu", ChucVu);
                cmdInsertNV.Parameters.AddWithValue("@ngayvaolam", today);
                int maNV = Convert.ToInt32(cmdInsertNV.ExecuteScalar());
                string VaiTro = (ChucVu == "Quản lý") ? "Quản trị viên" : "Nhân viên";

                string sqlInsertTaiKhoan = @"INSERT INTO TAIKHOAN(MANV, TENTK, MATKHAU, VAITRO, NGAYTAO, TRANGTHAI) VALUES (@manv, @tentk, @matkhau, @vaitro, @ngaytao, @trangthai)";
                SqlCommand cmdInsertTK = new SqlCommand(sqlInsertTaiKhoan, conn);
                cmdInsertTK.Parameters.AddWithValue("@manv", maNV);
                cmdInsertTK.Parameters.AddWithValue("@tentk", username);
                cmdInsertTK.Parameters.AddWithValue("@matkhau", password);
                cmdInsertTK.Parameters.AddWithValue("@vaitro", VaiTro);
                cmdInsertTK.Parameters.AddWithValue("@ngaytao", today);
                cmdInsertTK.Parameters.AddWithValue("@trangthai", trangthai);
                cmdInsertTK.ExecuteNonQuery();

                MessageBox.Show("Thêm nhân viên thành công");
                loadDSNV();
                txtHoTen.Clear();
                txtTenDangNhap.Clear();
                txtCCCD.Clear();
                txtDiaChi.Clear();
                txtMatKhau.Clear();
                txtSDT.Clear();
                cbChucVu.SelectedIndex = 0;
                radNam.Checked = false;
                radNu.Checked = false;
                radHoatDong.Checked = false;
                radKhoa.Checked = false;
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
                return;
            }

            int maNV = Convert.ToInt32(txtHoTen.Tag);

            string tennv = txtHoTen.Text.Trim();
            string GioiTinh = radNam.Checked ? "Nam" : (radNu.Checked ? "Nữ" : "");
            string sdt = txtSDT.Text.Trim();
            string CCCD = txtCCCD.Text.Trim();
            string DiaChi = txtDiaChi.Text.Trim();
            string ChucVu = cbChucVu.SelectedItem.ToString();
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            string trangthai = radHoatDong.Checked ? "Hoạt động" : (radKhoa.Checked ? "Khóa" : "");

            if (tennv == "" || GioiTinh == "" || sdt == "" || CCCD == "" || DiaChi == "" ||
                username == "" || password == "" || trangthai == "")
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Kiểm tra CCCD nếu sửa
                string sqlCheckCCCD = "SELECT COUNT(*) FROM NHANVIEN WHERE CCCD = @CCCD AND MANV <> @MANV";
                SqlCommand cmdCheckCCCD = new SqlCommand(sqlCheckCCCD, conn);
                cmdCheckCCCD.Parameters.AddWithValue("@CCCD", CCCD);
                cmdCheckCCCD.Parameters.AddWithValue("@MANV", maNV);

                if ((int)cmdCheckCCCD.ExecuteScalar() > 0)
                {
                    MessageBox.Show("CCCD đã tồn tại ở nhân viên khác. Vui lòng nhập lại!");
                    return;
                }

                // Cập nhật bảng NHÂN VIÊN
                string sqlUpdateNV = @"UPDATE NHANVIEN 
                               SET TENNV = @tennv, GIOITINH = @gioitinh, SDT = @sdt, 
                                   CCCD = @cccd, DIACHI = @diachi, CHUCVU = @chucvu
                               WHERE MANV = @manv";

                SqlCommand cmdUpdateNV = new SqlCommand(sqlUpdateNV, conn);
                cmdUpdateNV.Parameters.AddWithValue("@tennv", tennv);
                cmdUpdateNV.Parameters.AddWithValue("@gioitinh", GioiTinh);
                cmdUpdateNV.Parameters.AddWithValue("@sdt", sdt);
                cmdUpdateNV.Parameters.AddWithValue("@cccd", CCCD);
                cmdUpdateNV.Parameters.AddWithValue("@diachi", DiaChi);
                cmdUpdateNV.Parameters.AddWithValue("@chucvu", ChucVu);
                cmdUpdateNV.Parameters.AddWithValue("@manv", maNV);
                cmdUpdateNV.ExecuteNonQuery();

                // Vai trò tự động theo chức vụ
                string VaiTro = (ChucVu == "Quản lý") ? "Quản trị viên" : "Nhân viên";

                // Cập nhật bảng TÀI KHOẢN
                string sqlUpdateTK = @"UPDATE TAIKHOAN 
                               SET TENTK = @tentk, MATKHAU = @matkhau, VAITRO = @vaitro, TRANGTHAI = @trangthai
                               WHERE MANV = @manv";

                SqlCommand cmdUpdateTK = new SqlCommand(sqlUpdateTK, conn);
                cmdUpdateTK.Parameters.AddWithValue("@tentk", username);
                cmdUpdateTK.Parameters.AddWithValue("@matkhau", password);
                cmdUpdateTK.Parameters.AddWithValue("@vaitro", VaiTro);
                cmdUpdateTK.Parameters.AddWithValue("@trangthai", trangthai);
                cmdUpdateTK.Parameters.AddWithValue("@manv", maNV);
                cmdUpdateTK.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thông tin nhân viên thành công!");

                loadDSNV();
                txtHoTen.Clear();
                txtCCCD.Clear();
                txtDiaChi.Clear();
                txtMatKhau.Clear();
                txtSDT.Clear();
                txtTenDangNhap.Clear();
                cbChucVu.SelectedIndex = 0;

                radNam.Checked = false;
                radNu.Checked = false;
                radHoatDong.Checked = false;
                radKhoa.Checked = false;

                txtHoTen.Tag = null;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            int maNV = Convert.ToInt32(txtHoTen.Tag);

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa nhân viên này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Xóa tài khoản trước (vì FK)
                string sqlDeleteTK = "DELETE FROM TAIKHOAN WHERE MANV = @MANV";
                SqlCommand cmdDelTK = new SqlCommand(sqlDeleteTK, conn);
                cmdDelTK.Parameters.AddWithValue("@MANV", maNV);
                cmdDelTK.ExecuteNonQuery();

                // Xóa nhân viên
                string sqlDeleteNV = "DELETE FROM NHANVIEN WHERE MANV = @MANV";
                SqlCommand cmdDelNV = new SqlCommand(sqlDeleteNV, conn);
                cmdDelNV.Parameters.AddWithValue("@MANV", maNV);
                cmdDelNV.ExecuteNonQuery();

                MessageBox.Show("Xóa nhân viên thành công!");

                loadDSNV();

                // Reset form
                txtHoTen.Clear();
                txtCCCD.Clear();
                txtDiaChi.Clear();
                txtMatKhau.Clear();
                txtSDT.Clear();
                txtTenDangNhap.Clear();
                cbChucVu.SelectedIndex = 0;

                radNam.Checked = false;
                radNu.Checked = false;
                radHoatDong.Checked = false;
                radKhoa.Checked = false;

                txtHoTen.Tag = null;
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
    }
}
