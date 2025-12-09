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
    public partial class DangNhap : Form
    {
        public static int MaNhanVienDangNhap = -1;
        SqlConnection conn;
        public DangNhap()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=Xu4nNh4n\SQLEXPRESS;Initial Catalog=QLKSSS;Integrated Security=True");
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txtPassWord.PasswordChar = '*';
            btnShowPass.Text = "👁️";
            txtuserName.Text = "admin";
            txtPassWord.Text = "admin@123";
        }



        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtuserName.Text;
            string password = txtPassWord.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.");
                return;
            }
            try
            {
                conn.Open();
                string query = @"SELECT NV.TENNV, TK.MANV, TK.VAITRO, TK.NGAYTAO, TK.TRANGTHAI
                                FROM TAIKHOAN TK
                                JOIN NHANVIEN NV ON TK.MANV = NV.MANV
                                WHERE TK.TENTK = @username AND TK.MATKHAU = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    string trangThai = reader["TRANGTHAI"].ToString();
                    if(trangThai == "Khóa")
                    {
                        MessageBox.Show("Tài khoản đã bị khóa");
                        reader.Close();   
                        conn.Close();
                        return;
                    }
                    Account.Current = new Account
                    {
                        MaNV = Convert.ToInt32(reader["MANV"]),
                        TenDN = username,
                        MatKhau = password,
                        VaiTro = reader["VAITRO"].ToString(),
                        NgayTao = Convert.ToDateTime(reader["NGAYTAO"]),
                        TrangThai = reader["TRANGTHAI"].ToString()
                    };

                    string tenNV = reader["TENNV"].ToString();
                    MaNhanVienDangNhap = Convert.ToInt32(reader["MANV"]);
                    string vaiTro = reader["VAITRO"].ToString();

                    MessageBox.Show($"Đăng nhập thành công! Xin chào {tenNV} ({vaiTro})");
                    this.Hide();
                    FormChinh formChinh = new FormChinh();
                    formChinh.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (txtPassWord.PasswordChar == '*')
            {
                txtPassWord.PasswordChar = '\0';
                btnShowPass.Text = "🙈";
            }
            else
            {
                txtPassWord.PasswordChar = '*';
                btnShowPass.Text = "👁️";

            }
        }

        private void txtuserName_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnDangNhap;
        }

        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnDangNhap;
        }
    }
}
