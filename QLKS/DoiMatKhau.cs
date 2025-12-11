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
    public partial class DoiMatKhau : Form
    {
        SqlConnection conn;
        public DoiMatKhau()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=Xu4nNh4n\SQLEXPRESS;Initial Catalog=QLKS;Integrated Security=True");
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtPasswordHientai.Text.Trim();
            string matKhauMoi = txtPasswordNew.Text.Trim();
            string xacNhan = txtPasswordXN.Text.Trim();

            // ===== 1. Kiểm tra nhập đầy đủ =====
            if (string.IsNullOrEmpty(matKhauCu) ||
                string.IsNullOrEmpty(matKhauMoi) ||
                string.IsNullOrEmpty(xacNhan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ===== 2. Kiểm tra trùng khớp =====
            if (matKhauMoi != xacNhan)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // ===== 3. Kiểm tra mật khẩu cũ =====
                string sqlCheck = @"
            SELECT COUNT(*) 
            FROM TAIKHOAN
            WHERE TENTK = @user AND MATKHAU = @oldpass";

                SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
                cmdCheck.Parameters.AddWithValue("@user", Account.Current.TenDN);
                cmdCheck.Parameters.AddWithValue("@oldpass", matKhauCu);

                int exists = (int)cmdCheck.ExecuteScalar();
                if (exists == 0)
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ===== 4. Cập nhật mật khẩu mới =====
                string sqlUpdate = @"
            UPDATE TAIKHOAN
            SET MATKHAU = @newpass
            WHERE TENTK = @user";

                SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn);
                cmdUpdate.Parameters.AddWithValue("@newpass", matKhauMoi);
                cmdUpdate.Parameters.AddWithValue("@user", Account.Current.TenDN);

                cmdUpdate.ExecuteNonQuery();

                // Update vào đối tượng đang đăng nhập
                Account.Current.MatKhau = matKhauMoi;

                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPasswordHientai.Clear();
                txtPasswordNew.Clear();
                txtPasswordXN.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message);
            }
        }

    }
}
