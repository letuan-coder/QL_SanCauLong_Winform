using QuanLySanCauLong.Model;
using QuanLySanCauLong.XuLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySanCauLong.UI
{
    public partial class SanTrong : Form
    {
        public CXuLyDatSan xuly = new CXuLyDatSan();
        public DateTime tempdatetime_ngaytrong;
        public CXuLySan xulysan = new CXuLySan();
        public int temp_masan;
        private bool _isOpenedFromDatSan = false;
        public SanTrong()
        {
            InitializeComponent();
        }
        public SanTrong(bool isOpenedFromDatSan) : this()
        {
            _isOpenedFromDatSan = isOpenedFromDatSan;
        }
        private void SanTrong_Load(object sender, EventArgs e)
        {
            dtp_checkin.Format = DateTimePickerFormat.Custom;
            dtp_checkin.CustomFormat = "HH:mm";
            dtp_checkout.Format = DateTimePickerFormat.Custom;
            dtp_checkout.CustomFormat = "HH:mm";

            if (_isOpenedFromDatSan)
            {
                // Nếu form SanTrong được mở từ form DatSan, sử dụng giá trị của DateTimePicker
                dtp_date.Value = tempdatetime_ngaytrong;
            }
            else
            {
                // Nếu form SanTrong được mở từ form khác, sử dụng ngày hiện tại
                dtp_date.Value = DateTime.Today;
            }

            button1_Click(sender, e);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtSanTrong = new DataTable();
            dtSanTrong.Columns.Add("Sân Số", typeof(int));
            dtSanTrong.Columns.Add("Ngày", typeof(DateTime));
            dtSanTrong.Columns.Add("Giờ Vào", typeof(string));
            dtSanTrong.Columns.Add("Giờ Ra", typeof(string));

            // Duyệt qua tất cả các mã sân từ 1 đến 4.
            for (int masan = 1; masan <= 4; masan++)
            {
                if (!xulysan.KTTrangSan(masan))
                {
                    continue;
                }
                DateTime ngaybd = dtp_date.Value.Date;
                double i = 5;
                double start = i;
                List<(DateTime, double, double)> dssantrongGop = new List<(DateTime, double, double)>();

                // Tạo danh sách toàn bộ các khung giờ từ 5 đến 23 giờ.
                List<(DateTime, double, double)> allTimeSlots = Enumerable.Range(0, 36)
                    .Select(offset => (ngaybd, 5 + (offset * 0.5), 5.5 + (offset * 0.5)))
                    .ToList();

                // Tìm và gộp các khung giờ trống liên tiếp.
                while (i < 23)
                {
                    double j = i + 0.5;
                    if (!xuly.TimMaSanKhongDat(masan, ngaybd, i, j))
                    {
                        // Nếu sân đã được đặt, gộp các khung giờ trống liên tiếp trước đó.
                        if (start < i)
                        {
                            dssantrongGop.Add((ngaybd, start, i));
                        }
                        // Bắt đầu một khung giờ trống mới.
                        start = j;
                    }
                    i = j;
                }

                // Thêm khung giờ trống cuối cùng nếu cần.
                if (start < i)
                {
                    dssantrongGop.Add((ngaybd, start, i));
                }

                // Loại bỏ các khung giờ đã được đặt khỏi danh sách toàn diện.
                foreach (var booked in dssantrongGop)
                {
                    allTimeSlots.RemoveAll(slot => slot.Item2 < booked.Item3 && slot.Item3 > booked.Item2);
                }
                List<(DateTime, double, double)> danhSachCacKhungGioChuaDat = new List<(DateTime, double, double)>();
                double startTime = -1;
                double endTime = -1;

                foreach (var khungGio in allTimeSlots)
                {
                    if (startTime == -1)
                    {
                        // Bắt đầu một chuỗi khung giờ mới
                        startTime = khungGio.Item2;
                        endTime = khungGio.Item3;
                    }
                    else if (khungGio.Item2 == endTime)
                    {
                        // Mở rộng chuỗi khung giờ hiện tại
                        endTime = khungGio.Item3;
                    }
                    else
                    {
                        // Kết thúc chuỗi khung giờ hiện tại và thêm vào danh sách
                        danhSachCacKhungGioChuaDat.Add((ngaybd, startTime, endTime));
                        startTime = khungGio.Item2;
                        endTime = khungGio.Item3;
                    }
                }

                // Đừng quên thêm chuỗi khung giờ cuối cùng nếu cần
                if (startTime != -1)
                {
                    danhSachCacKhungGioChuaDat.Add((ngaybd, startTime, endTime));
                }
                // Thêm dữ liệu vào DataTable.
                foreach ((DateTime ngayBD, double tgbd, double tgkt) in danhSachCacKhungGioChuaDat)
                {
                    // Chuyển đổi giờ vào và giờ ra từ double sang chuỗi chỉ hiển thị giờ và phút
                    string gioVao = TimeSpan.FromHours(tgbd).ToString(@"hh\:mm");
                    string gioRa = TimeSpan.FromHours(tgkt).ToString(@"hh\:mm");

                    // Thêm thông tin vào DataTable
                    dtSanTrong.Rows.Add(masan, ngayBD, gioVao, gioRa);
                }

            }

            // Gán DataTable làm nguồn dữ liệu cho DataGridView.
            dgv_santrong.DataSource = dtSanTrong;
            dgv_santrong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public void OnOff(List<CDatSan> danhSachDatSan, DataGridView dgv)
        {
            var danhSachDatSanSapXep = danhSachDatSan
           .OrderBy(datSan => datSan.NgayBD.Date)
           .ThenBy(datSan => datSan.masan.Id)
           .ThenBy(datSan => datSan.TGBD)
           .ToList();

            // Tạo một DataTable mới
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Sân", typeof(int));
            dt.Columns.Add("Ngày Bắt Đầu", typeof(DateTime));
            dt.Columns.Add("Thời Gian Bắt Đầu", typeof(double));
            dt.Columns.Add("Thời Gian Kết Thúc", typeof(double));

            // Điền dữ liệu từ danh sách đã sắp xếp vào DataTable
            foreach (var datSan in danhSachDatSanSapXep)
            {
                dt.Rows.Add(datSan.masan.Id, datSan.NgayBD, datSan.TGBD, datSan.TGKT);
            }

            // Gán DataTable làm nguồn dữ liệu cho DataGridView
            dgv.DataSource = dt;
        }
        private void dgv_santrong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_santrong.Rows[e.RowIndex];
                txb_masan.Text = row.Cells["Sân Số"].Value.ToString();

                dtp_date.Value = Convert.ToDateTime(row.Cells["Ngày"].Value);
                dtp_checkin.Text = row.Cells["Giờ Vào"].Value.ToString();
                dtp_checkout.Text = row.Cells["Giờ Ra"].Value.ToString();// Gán giá trị cho DateTimePicker, chuyển đổi giá trị sang kiểu DateTime
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtp_date.Value.Date;
            string startTime = dtp_checkin.Value.ToString();
            string endTime = dtp_checkout.Value.ToString();
            string masanText = txb_masan.Text;

            if (string.IsNullOrEmpty(masanText) || string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(endTime) || selectedDate == DateTime.MinValue)
            {
                MessageBox.Show("Vui lòng chọn 1 sân");
            }
            else
            {
                try
                {
                    UI.DatSan datSan = new UI.DatSan(true);
                    datSan.ngaytrong = dtp_date.Value;
                    datSan.sanso = Convert.ToInt32(masanText);
                    datSan.giovaotrong = startTime;
                    datSan.gioratrong = endTime;
                    datSan.Show();
                    this.Close();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Mã sân phải là một số hợp lệ.");
                }
            }

        }
    }
}
