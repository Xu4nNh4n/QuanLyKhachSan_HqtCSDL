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
using System.Data.SqlClient;
namespace QLKS
{
    public partial class Khach : Form
    {
        SqlConnection conn;
        Label lblTitle;
        GroupBox grpTT;
        Label lblTen, lblGT, lblSDT, lblMaDD, lblLoaiGT, lblQT;
        TextBox txtTen, txtSDT, txtMaDD, txtLoaiGiayTo, txtQuocTich;
        ComboBox cboGioiTinh;
        Button btnThem;
        ListView listView1;
        int selectedMAKH = 0;
        public Khach()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=Xu4nNh4n\SQLEXPRESS;Initial Catalog=QLKS;Integrated Security=True");
            
        }

        private void Khach_Load(object sender, EventArgs e)
        {
            int topStart = 20; // giữ giao diện gọn hơn khi bỏ tiêu đề

            // ===== GROUP THÔNG TIN =====
            grpTT = new GroupBox();
            grpTT.Text = "Thông tin khách hàng";
            grpTT.Size = new Size(750, 160);
            grpTT.Location = new Point(20, topStart);
            this.Controls.Add(grpTT);

            // Label & Textbox
            lblTen = new Label() { Text = "Tên khách:", Location = new Point(20, 30), AutoSize = true };
            txtTen = new TextBox() { Location = new Point(120, 25), Width = 200 };

            lblGT = new Label() { Text = "Giới tính:", Location = new Point(20, 70), AutoSize = true };
            cboGioiTinh = new ComboBox() { Location = new Point(120, 65), Width = 200 };
            cboGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");

            lblSDT = new Label() { Text = "Số điện thoại:", Location = new Point(20, 110), AutoSize = true };
            txtSDT = new TextBox() { Location = new Point(120, 105), Width = 200 };

            lblMaDD = new Label() { Text = "Mã định danh:", Location = new Point(350, 30), AutoSize = true };
            txtMaDD = new TextBox() { Location = new Point(470, 25), Width = 200 };

            lblLoaiGT = new Label() { Text = "Loại giấy tờ:", Location = new Point(350, 70), AutoSize = true };
            txtLoaiGiayTo = new TextBox() { Location = new Point(470, 65), Width = 200 };

            lblQT = new Label() { Text = "Quốc tịch:", Location = new Point(350, 110), AutoSize = true };
            txtQuocTich = new TextBox() { Location = new Point(470, 105), Width = 200 };

            grpTT.Controls.AddRange(new Control[]
            {
        lblTen, txtTen,
        lblGT, cboGioiTinh,
        lblSDT, txtSDT,
        lblMaDD, txtMaDD,
        lblLoaiGT, txtLoaiGiayTo,
        lblQT, txtQuocTich
            });

            // ===== BUTTON =====
            btnThem = new Button();
            btnThem.Text = "Thêm khách";
            btnThem.Size = new Size(120, 40);
            btnThem.Location = new Point(800, topStart + 30);
            btnThem.Click += btnThem_Click;
            this.Controls.Add(btnThem);

            Button btnSua = new Button();
            btnSua.Text = "Sửa thông tin";
            btnSua.Size = new Size(120, 40);
            btnSua.Location = new Point(800, topStart + 80);
            btnSua.Click += btnSua_Click;
            this.Controls.Add(btnSua);

            // ===== LISTVIEW =====
            listView1 = new ListView();
            listView1.Location = new Point(20, topStart + 190);
            listView1.Size = new Size(930, 360);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("MAKH", 70);
            listView1.Columns.Add("Tên khách", 150);
            listView1.Columns.Add("Giới tính", 80);
            listView1.Columns.Add("SĐT", 120);
            listView1.Columns.Add("Mã định danh", 130);
            listView1.Columns.Add("Loại giấy tờ", 120);
            listView1.Columns.Add("Quốc tịch", 120);

            this.Controls.Add(listView1);
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;

            // Load dữ liệu
            LoadDSKhach();
            if(Account.Current.VaiTro != "Quản trị viên")
            {
                btnSua.Enabled = false;
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                selectedMAKH = 0;
                return;
            }

            ListViewItem item = listView1.SelectedItems[0];
            selectedMAKH = int.Parse(item.SubItems[0].Text);

            // Binding dữ liệu lên ô nhập
            txtTen.Text = item.SubItems[1].Text;
            cboGioiTinh.Text = item.SubItems[2].Text;
            txtSDT.Text = item.SubItems[3].Text;
            txtMaDD.Text = item.SubItems[4].Text;
            txtLoaiGiayTo.Text = item.SubItems[5].Text;
            txtQuocTich.Text = item.SubItems[6].Text;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedMAKH == 0)
            {
                MessageBox.Show("Vui lòng chọn khách cần sửa!");
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = @"
            UPDATE KHACH
            SET TENKH = @ten,
                GIOITINH = @gt,
                SDT = @sdt,
                MADINHDANH = @ma,
                LOAIGIAYTO = @loai,
                QUOCTICH = @qt
            WHERE MAKH = @id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", txtTen.Text);
                cmd.Parameters.AddWithValue("@gt", cboGioiTinh.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSDT.Text);
                cmd.Parameters.AddWithValue("@ma", txtMaDD.Text);
                cmd.Parameters.AddWithValue("@loai", txtLoaiGiayTo.Text);
                cmd.Parameters.AddWithValue("@qt", txtQuocTich.Text);
                cmd.Parameters.AddWithValue("@id", selectedMAKH);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thông tin khách thành công!");
                LoadDSKhach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa khách: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void LoadDSKhach()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = "SELECT * FROM KHACH ORDER BY MAKH DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader r = cmd.ExecuteReader();

                listView1.Items.Clear();
                while (r.Read())
                {
                    ListViewItem item = new ListViewItem(r["MAKH"].ToString());
                    item.SubItems.Add(r["TENKH"].ToString());
                    item.SubItems.Add(r["GIOITINH"].ToString());
                    item.SubItems.Add(r["SDT"].ToString());
                    item.SubItems.Add(r["MADINHDANH"].ToString());
                    item.SubItems.Add(r["LOAIGIAYTO"].ToString());
                    item.SubItems.Add(r["QUOCTICH"].ToString());
                    listView1.Items.Add(item);
                }

                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("sp_ThemKhach", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TenKH", txtTen.Text);
                cmd.Parameters.AddWithValue("@GioiTinh", cboGioiTinh.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@MaDinhDanh", txtMaDD.Text);
                cmd.Parameters.AddWithValue("@LoaiGiayTo", txtLoaiGiayTo.Text);
                cmd.Parameters.AddWithValue("@QuocTich", txtQuocTich.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Thêm khách thành công!");
                LoadDSKhach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm khách: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
