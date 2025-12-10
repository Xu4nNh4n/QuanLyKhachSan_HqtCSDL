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
    public partial class ThongKe : Form
    {
        SqlConnection conn = new SqlConnection(
           @"Data Source=Xu4nNh4n\SQLEXPRESS;Initial Catalog=QLKS;Integrated Security=True");
        public ThongKe()
        {
            InitializeComponent();
            this.Load += ThongKe_Load;
        }

        private void lstDoanhThuNgay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            loadDoanhThuNgay();
            loadDoanhThuThang();
            loadDoanhThuNam();
            setUpChart();
            loadTanSuatDV();
            loadTongDoanhThu();
        }
        void loadDoanhThuNgay()
        {
            lstDoanhThuNgay.Items.Clear();

            SqlCommand cmd = new SqlCommand("sp_DoanhThuTheoNgay", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ngay = Convert.ToDateTime(reader["NGAY"]).ToString("dd/MM/yyyy");
                string doanhThu = string.Format("{0:n0}", reader["DOANHTHU"]);

                ListViewItem item = new ListViewItem(ngay);
                item.SubItems.Add(doanhThu);

                lstDoanhThuNgay.Items.Add(item);
            }

            reader.Close();

            conn.Close();
        }
        void loadDoanhThuThang()
        {
            lstDoanhThuThang.Items.Clear();
            SqlCommand cmd = new SqlCommand("sp_DoanhThuTheoThang", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string nam = reader["NAM"].ToString();
                string thang = reader["THANG"].ToString();
                string doanhThu = string.Format("{0:n0}", reader["DOANHTHU"]);

                ListViewItem item = new ListViewItem(nam);
                item.SubItems.Add(thang);
                item.SubItems.Add(doanhThu);

                lstDoanhThuThang.Items.Add(item);
            }

            reader.Close();

            conn.Close();
        }
        void loadDoanhThuNam()
        {
            lstDoanhThuNam.Items.Clear();

            SqlCommand cmd = new SqlCommand("sp_DoanhThuTheoNam", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string nam = reader["NAM"].ToString();
                string doanhThu = string.Format("{0:n0}", reader["DOANHTHU"]);

                ListViewItem item = new ListViewItem(nam);
                item.SubItems.Add(doanhThu);

                lstDoanhThuNam.Items.Add(item);
            }

            reader.Close();

            conn.Close();
        }

        void setUpChart()
        {
            chartTanSuatDV.Series.Clear();
            chartTanSuatDV.ChartAreas.Clear();
            chartTanSuatDV.Legends.Clear();

            chartTanSuatDV.ChartAreas.Add("ChartArea1");
            chartTanSuatDV.Legends.Add("Legend1");

            var series = chartTanSuatDV.Series.Add("DichVu");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            series.Label = "#PERCENT{P0}";

            series.LegendText = "#VALX";

            series.BorderWidth = 1;
            series.BorderColor = Color.White;

            chartTanSuatDV.Legends["Legend1"].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right;
        }

        void loadTanSuatDV()
        {
            lstTanSuat.Items.Clear();
            chartTanSuatDV.Series["DichVu"].Points.Clear();

            SqlCommand cmd = new SqlCommand("sp_TanSuatSuDungDichVu", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string tenDV = reader["TENDV"].ToString();
                int soLuot = Convert.ToInt32(reader["SOLUOT"]);

                int soLuong = reader["TONG_SOLUONG_DA_BAN"] is DBNull
                    ? 0
                    : Convert.ToInt32(reader["TONG_SOLUONG_DA_BAN"]);

                ListViewItem item = new ListViewItem(tenDV);
                item.SubItems.Add(soLuot.ToString());
                item.SubItems.Add(soLuong.ToString());
                lstTanSuat.Items.Add(item);

                chartTanSuatDV.Series["DichVu"].Points.AddXY(tenDV, soLuot);
            }

            reader.Close();

            conn.Close();
        }

        void loadTongDoanhThu()
        {
            SqlCommand cmd = new SqlCommand("sp_TongDoanhThuKhachSan", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            object result = cmd.ExecuteScalar();

            decimal doanhThu = 0;

            if (result != DBNull.Value && result != null)
            {
                doanhThu = Convert.ToDecimal(result);
            }

            lbTongDoanhThu.Text = doanhThu.ToString("#,##0 VNĐ");

            conn.Close();
        }
    }
}
