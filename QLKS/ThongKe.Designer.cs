namespace QLKS
{
    partial class ThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lbTongDoanhThu = new System.Windows.Forms.Label();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstTanSuat = new System.Windows.Forms.ListView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lstDoanhThuNam = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstDoanhThuThang = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstDoanhThuNgay = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartTanSuatDV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTanSuatDV)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTongDoanhThu
            // 
            this.lbTongDoanhThu.BackColor = System.Drawing.Color.White;
            this.lbTongDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTongDoanhThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTongDoanhThu.ForeColor = System.Drawing.Color.Black;
            this.lbTongDoanhThu.Location = new System.Drawing.Point(3, 19);
            this.lbTongDoanhThu.Name = "lbTongDoanhThu";
            this.lbTongDoanhThu.Size = new System.Drawing.Size(368, 81);
            this.lbTongDoanhThu.TabIndex = 0;
            this.lbTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Tổng Số Lượt Đã Bán";
            this.columnHeader10.Width = 200;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Số Lượt";
            this.columnHeader9.Width = 90;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tên Dịch vụ";
            this.columnHeader8.Width = 200;
            // 
            // lstTanSuat
            // 
            this.lstTanSuat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lstTanSuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTanSuat.GridLines = true;
            this.lstTanSuat.HideSelection = false;
            this.lstTanSuat.Location = new System.Drawing.Point(3, 3);
            this.lstTanSuat.Name = "lstTanSuat";
            this.tableLayoutPanel2.SetRowSpan(this.lstTanSuat, 2);
            this.lstTanSuat.Size = new System.Drawing.Size(405, 263);
            this.lstTanSuat.TabIndex = 0;
            this.lstTanSuat.UseCompatibleStateImageBehavior = false;
            this.lstTanSuat.View = System.Windows.Forms.View.Details;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.24194F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.75806F));
            this.tableLayoutPanel2.Controls.Add(this.lstTanSuat, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chartTanSuatDV, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 97.02602F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.973978F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(744, 269);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox4, 2);
            this.groupBox4.Controls.Add(this.tableLayoutPanel2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 281);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(750, 291);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tần suất sử dụng dịch vụ";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Doanh Thu";
            this.columnHeader7.Width = 181;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Năm";
            this.columnHeader6.Width = 97;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lbTongDoanhThu);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(759, 281);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(374, 291);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tổng doanh thu";
            // 
            // lstDoanhThuNam
            // 
            this.lstDoanhThuNam.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.lstDoanhThuNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDoanhThuNam.GridLines = true;
            this.lstDoanhThuNam.HideSelection = false;
            this.lstDoanhThuNam.Location = new System.Drawing.Point(3, 19);
            this.lstDoanhThuNam.Name = "lstDoanhThuNam";
            this.lstDoanhThuNam.Size = new System.Drawing.Size(368, 250);
            this.lstDoanhThuNam.TabIndex = 0;
            this.lstDoanhThuNam.UseCompatibleStateImageBehavior = false;
            this.lstDoanhThuNam.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Doanh Thu";
            this.columnHeader5.Width = 181;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tháng";
            this.columnHeader4.Width = 73;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Năm";
            this.columnHeader3.Width = 79;
            // 
            // lstDoanhThuThang
            // 
            this.lstDoanhThuThang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstDoanhThuThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDoanhThuThang.GridLines = true;
            this.lstDoanhThuThang.HideSelection = false;
            this.lstDoanhThuThang.Location = new System.Drawing.Point(3, 19);
            this.lstDoanhThuThang.Name = "lstDoanhThuThang";
            this.lstDoanhThuThang.Size = new System.Drawing.Size(368, 250);
            this.lstDoanhThuThang.TabIndex = 0;
            this.lstDoanhThuThang.UseCompatibleStateImageBehavior = false;
            this.lstDoanhThuThang.View = System.Windows.Forms.View.Details;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstDoanhThuThang);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(379, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 272);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Doanh thu theo tháng";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Doanh Thu";
            this.columnHeader2.Width = 189;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ngày";
            this.columnHeader1.Width = 150;
            // 
            // lstDoanhThuNgay
            // 
            this.lstDoanhThuNgay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstDoanhThuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDoanhThuNgay.GridLines = true;
            this.lstDoanhThuNgay.HideSelection = false;
            this.lstDoanhThuNgay.Location = new System.Drawing.Point(3, 19);
            this.lstDoanhThuNgay.Name = "lstDoanhThuNgay";
            this.lstDoanhThuNgay.Size = new System.Drawing.Size(364, 250);
            this.lstDoanhThuNgay.TabIndex = 0;
            this.lstDoanhThuNgay.UseCompatibleStateImageBehavior = false;
            this.lstDoanhThuNgay.View = System.Windows.Forms.View.Details;
            this.lstDoanhThuNgay.SelectedIndexChanged += new System.EventHandler(this.lstDoanhThuNgay_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstDoanhThuNgay);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 272);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doanh thu theo ngày";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstDoanhThuNam);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(759, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(374, 272);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Doanh thu theo năm";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.09859F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.4507F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.34783F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.65217F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1136, 575);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // chartTanSuatDV
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTanSuatDV.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTanSuatDV.Legends.Add(legend2);
            this.chartTanSuatDV.Location = new System.Drawing.Point(414, 3);
            this.chartTanSuatDV.Name = "chartTanSuatDV";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series3";
            this.chartTanSuatDV.Series.Add(series2);
            this.chartTanSuatDV.Size = new System.Drawing.Size(327, 255);
            this.chartTanSuatDV.TabIndex = 1;
            this.chartTanSuatDV.Text = "chart1";
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 575);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ThongKe";
            this.Text = "ThongKe";
            this.Load += new System.EventHandler(this.ThongKe_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTanSuatDV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTongDoanhThu;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ListView lstTanSuat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstDoanhThuNgay;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lstDoanhThuThang;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lstDoanhThuNam;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTanSuatDV;
    }
}