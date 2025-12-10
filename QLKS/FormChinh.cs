using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class FormChinh : Form
    {
        private Form currentFormChild;
        public FormChinh()
        {
            InitializeComponent();
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                if (currentFormChild != childForm)
                    currentFormChild.Hide(); 
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            if (!pnlContainer.Controls.Contains(childForm))
                pnlContainer.Controls.Add(childForm);

            childForm.BringToFront();
            childForm.Show();
        }
        private void FormChinh_Load(object sender, EventArgs e)
        {

        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DatPhong());
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DichVu());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Khach());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new NhanVien());
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Phong());
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HoaDon());
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThanhToan());
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DoiMatKhau());
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                DangNhap dangNhap = new DangNhap();
                dangNhap.ShowDialog();
                this.Close();
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKe());
        }
    }
}
