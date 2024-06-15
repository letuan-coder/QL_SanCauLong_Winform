using QuanLySanCauLong.Model;
using QuanLySanCauLong.XuLy;
using System;
using HiveMQtt.Client;
using HiveMQtt.Client.Options;
using HiveMQtt.MQTT5.Types;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Sunny.UI.Win32;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices.ActiveDirectory;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using Sunny.UI;
using DocumentFormat.OpenXml.VariantTypes;

namespace QuanLySanCauLong.UI
{

    public partial class DatSan : Form
    {
        public DateTime ngaytrong;
        public int sanso;
        public string giovaotrong;
        public string gioratrong;
        private bool _isOpenedFromSanTrong = false;
        private string received_message;
        private System.Windows.Forms.Timer reloadTimer;
        private CDatSan datSan = new CDatSan();//thêm
        public CXuLySan xuLySan = new CXuLySan();
        private CXuLyDatSan timsan;
        public CXuLyDatSan xuly = new CXuLyDatSan();
        public List<CDatSan> danhsachdatsan = new List<CDatSan>();
        public List<CSan> DSSAN = new List<CSan>();
        private HiveMQClient client;
        //CDatSan ds = new CDatSan();

        CDatSan datsan = new CDatSan();
        public DatSan()
        {
            InitializeComponent();
            reloadTimer = new System.Windows.Forms.Timer();
            reloadTimer.Interval = 15000; // 5000ms = 5 giây
            reloadTimer.Tick += new EventHandler(timer1_Tick); // Xử lý sự kiện Tick của timer
            StartReloadTimer();
        }

        public async Task connect()
        {

            var options = new HiveMQClientOptions
            {
                Host = "your_own_cloud_client",
                Port = 8883,
                UseTLS = true,
                UserName = "your_username",
                Password = "123456789",
                ClientId = "your_client_Id",
            };

            client = new HiveMQClient(options);

            var connectResult = await client.ConnectAsync().ConfigureAwait(false);
            if (connectResult.ReasonCode != HiveMQtt.MQTT5.ReasonCodes.ConnAckReasonCode.Success)
            {

                //lbtt.Invoke(new Action(() => lbtt.Text = "Failed"));
                MessageBox.Show("Kết nối không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                MessageBox.Show("Kết nối thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

            var topic = "nhietdo";
            var subscribeResult = await client.SubscribeAsync(topic, HiveMQtt.MQTT5.Types.QualityOfService.ExactlyOnceDelivery).ConfigureAwait(false);

            client.OnMessageReceived += (sender, args) =>
            {
                received_message = args.PublishMessage.PayloadAsString;
            };


        }
        public DatSan(bool isOpenedFromSanTrong) : this()
        {
            _isOpenedFromSanTrong = isOpenedFromSanTrong;
        }
        private async void DatSan_Load(object sender, EventArgs e)
        {
            await connect();
            if (_isOpenedFromSanTrong)
            {
                cb_idsan.ValueMember = "Id";
                cb_idsan.DisplayMember = "Id";
                cb_idsan.DataSource = xuLySan.getDSSans().ToList();

                cb_idsan.SelectedValue = sanso;
                dtp_checkin.Text = giovaotrong;
                dtp_checkout.Text = gioratrong;
                dtp_date.Value = ngaytrong.Date;
                dtp_checkin.Format = DateTimePickerFormat.Custom;
                dtp_checkin.CustomFormat = "HH:mm";
                dtp_checkin.ShowUpDown = true;
                dtp_checkout.Format = DateTimePickerFormat.Custom;
                dtp_checkout.CustomFormat = "HH:mm";
                dtp_checkout.ShowUpDown = true;

                hienthiview(xuly.getDSDatSan());
            }
            else
            {

                dtp_date.Format = DateTimePickerFormat.Long;
                dtp_date.Value = DateTime.Today;
                dtp_checkin.Format = DateTimePickerFormat.Custom;
                dtp_checkin.CustomFormat = "HH:mm";
                dtp_checkin.ShowUpDown = true;
                dtp_checkout.Format = DateTimePickerFormat.Custom;
                dtp_checkout.CustomFormat = "HH:mm";
                dtp_checkout.ShowUpDown = true;

                hienthisan(xuLySan.getDSSans());
                hienthisantrong();
                hienthiview(xuly.getDSDatSan());
            }

        }
        public void hienthisan(List<CSan> dss)
        {
            List<CSan> danhSachSansTrue = dss.Where(san => san.tinhtrang == true).ToList();
            List<int> maSansTrue = danhSachSansTrue.Select(san => san.Id).ToList();
            cb_idsan.DataSource = maSansTrue;
        }
        public void hienthiview(List<CDatSan> dsds)
        {
            BindingSource bs = new BindingSource();
            List<CDatSan> danhsachsapxep = Sorting(dsds);

            bs.DataSource = Model.CDatSanVIew.getdsDatSanViews(danhsachsapxep);
            if (dgv_datsan != null)
            {
                dgv_datsan.DataSource = bs;
                dgv_datsan.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                dgv_datsan.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.Black; // Optional, set text color


                dgv_datsan.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgv_datsan.DefaultCellStyle.ForeColor = System.Drawing.Color.Black; // Optional, set text color
            }
            else
            {
                MessageBox.Show("Sân đang thêm dữ liệu");
            }

        }
        public void hienthiviewSearch(List<CDatSan> dsds)
        {
            BindingSource bs = new BindingSource();
            List<CDatSan> danhsachsapxep = Sorting(dsds);
            bs.DataSource = Model.CDatSanVIew.getdsDatSanViews(danhsachsapxep);
            dgv_datsan.DataSource = bs;

        }
        private void uiSymbolButton1_Click(object sender, EventArgs e)//nút đặt sân
        {
            CDatSan datSan = new CDatSan();

            datSan.Id = CDatSan.GenerateUniqueId(); // Sử dụng phương thức tạo mã mới duy nhất
            txb_id.Text = datSan.Id;
            if (cb_idsan.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một sân.");
                return;
            }
            string masan = cb_idsan.Text;
            CSan a = xuLySan.tim(Int32.Parse(masan));
            datSan.masan = a;
            datSan.email = txb_email.Text;
            datSan.TenKH = txb_name.Text;

            // Kiểm tra nhập liệu
            if (!int.TryParse(txb_people.Text, out int soNg) || soNg <= 0)
            {
                MessageBox.Show("Số người phải là một số lớn hơn 0.");
                return;
            }
            datSan.SoNg = soNg;

            if (!int.TryParse(txb_phonenumber.Text, out int sdt) || sdt <= 0)
            {
                MessageBox.Show("Số điện thoại phải là một số lớn hơn 0.");
                return;
            }
            datSan.SDT = sdt;

            if (string.IsNullOrEmpty(datSan.TenKH))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.");
                return;
            }

            if (string.IsNullOrEmpty(datSan.TenKH) || datSan.SoNg <= 0 || datSan.SDT <= 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            datSan.NgayBD = dtp_date.Value.Date;
            int hourIn = dtp_checkin.Value.Hour;
            int minuteIn = dtp_checkin.Value.Minute;
            double totalMinuteIn = hourIn * 60 + minuteIn;
            datSan.TGBD = totalMinuteIn / 60.0;

            int hourOut = dtp_checkout.Value.Hour;
            int minuteOut = dtp_checkout.Value.Minute;
            double totalMinuteOut = hourOut * 60 + minuteOut;
            datSan.TGKT = totalMinuteOut / 60.0;

            datSan.SoGio = datSan.TGKT - datSan.TGBD;
            if ((datSan.TGBD < 5 || datSan.TGKT > 23))
            {
                MessageBox.Show("Giờ mở cửa là 5:00 và đóng cửa lúc 23:00");
                return;
            }
            if (minuteIn != 0 && minuteIn != 30)
            {

                MessageBox.Show("Minute In chỉ có thể là 0 hoặc 30.");

                return; // Dừng xử lý tiếp theo
            }

            // Kiểm tra giá trị của minuteOut
            if (minuteOut != 0 && minuteOut != 30)
            {
                // Hiển thị thông báo hoặc thực hiện hành động phù hợp
                MessageBox.Show("Minute Out chỉ có thể là 0 hoặc 30.");

                return; // Dừng xử lý tiếp theo
            }
            if (datSan.TGBD >= datSan.TGKT)
            {

                MessageBox.Show("Giờ vào phải sau giờ ra");
                return;
            }
            double tongTien = TinhTongTien(datSan.TGBD, datSan.TGKT);
            string formattedTongTien = tongTien.ToString("#,##0") + " ₫"; // ₫ là ký hiệu của đồng Việt Nam
            datSan.TongTien = formattedTongTien;
            if (!xuLySan.KTTrangSan(datSan.masan.Id))
            {
                MessageBox.Show("Sân đang bảo trì hãy chọn sân khác");
                return;
            }
            if (xuly.them(datSan, datSan.NgayBD, datSan.TGBD, datSan.TGKT) == true)
            {

                UI.send_email email = new send_email();
                email.tempcontent_madat = txb_id.Text;
                email.tempcontent_ten = txb_name.Text;
                email.tempcontent_sdt = txb_phonenumber.Text;
                email.tempcontent_giovao = dtp_checkin.Text;
                email.tempcontent_giora = dtp_checkout.Text;
                email.tempconntent_songuoi = txb_people.Text;
                email.temconntent_masan = cb_idsan.Text;
                email.tempcontent_email = txb_email.Text;
                email.tempcontent_sogio = datSan.SoGio.ToString();
                email.tempcontent_ngay = dtp_date.Text;
                email.tempcontent_tongtien = datSan.TongTien.ToString();
                email.ShowDialog();
                reset();
                hienthiview(xuly.getDSDatSan());
            }
            else
            {
                MessageBox.Show("KHÔNG THỂ THÊM");
                dtp_date.Focus();
            }
        }

        public void OnOff(List<CDatSan> danhSachDatSan)
        {
            DateTime currentTime = DateTime.Now;
            List<CDatSan> sortinglist = Sorting(danhSachDatSan);

            for (int i = 0; i < sortinglist.Count; i++)
            {

                CDatSan datSan = sortinglist[i];
                DateTime ngayBatDau = datSan.NgayBD;
                DateTime thoiGianBatDau = ngayBatDau.AddHours(datSan.TGBD);
                DateTime thoiGianKetThuc = ngayBatDau.AddHours(datSan.TGKT);
                if (datSan.masan.Id == 1 && datSan.NgayBD == DateTime.Now.Date && datSan != null)
                {

                    if (currentTime.Hour == thoiGianBatDau.Hour && currentTime.Minute == thoiGianBatDau.Minute)
                    {
                        // Kiểm tra nếu giờ bắt đầu của sân hiện tại trùng với giờ kết thúc của sân trước đó
                        if (i > 0) // Đảm bảo rằng có sân trước đó để kiểm tra
                        {
                            CDatSan previousDatSan = sortinglist[i - 1];
                            DateTime prevThoiGianKetThuc = previousDatSan.NgayBD.Date.AddHours(previousDatSan.TGKT);

                            if (thoiGianBatDau.Hour == prevThoiGianKetThuc.Hour && thoiGianBatDau.Minute == prevThoiGianKetThuc.Minute)
                            {
                                client.PublishAsync("san1", "on1", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else if (thoiGianBatDau.Hour == currentTime.Hour && thoiGianBatDau.Minute == currentTime.Minute)
                            {
                                client.PublishAsync("san1", "on1", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else if (currentTime.Hour == thoiGianKetThuc.Hour && currentTime.Minute == thoiGianKetThuc.Minute)
                            {
                                client.PublishAsync("san1", "off1", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                        }
                        else if (i == 0) // Đảm bảo rằng có sân đầu
                        {


                            if (currentTime.Hour == thoiGianBatDau.Hour && currentTime.Minute == thoiGianBatDau.Minute)
                            {
                                client.PublishAsync("san1", "on1", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }


                        }
                    }
                    else if (currentTime.Hour == thoiGianKetThuc.Hour && currentTime.Minute == thoiGianKetThuc.Minute)
                    {

                        if (i == sortinglist.Count - 1)
                        {
                            client.PublishAsync("san1", "off1", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                            break;
                        }
                        CDatSan previousDatSan = sortinglist[i + 1];
                        if (previousDatSan.masan.Id == 1)
                        {
                            DateTime prevThoiGianBatDau = previousDatSan.NgayBD.Date.AddHours(previousDatSan.TGBD);

                            if (thoiGianBatDau.Hour == currentTime.Hour && thoiGianBatDau.Minute == currentTime.Minute)
                            {
                                client.PublishAsync("san1", "on1", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else if (prevThoiGianBatDau.Hour == thoiGianKetThuc.Hour && prevThoiGianBatDau.Minute == thoiGianKetThuc.Minute)
                            {
                                client.PublishAsync("san1", "on1", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else
                            {
                                client.PublishAsync("san1", "off1", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                        }
                        else
                        {
                            client.PublishAsync("san1", "off1", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                            break;
                        }
                    }

                }
            }
        }

        public void OnOff1(List<CDatSan> danhSachDatSan)
        {
            DateTime currentTime = DateTime.Now;
            List<CDatSan> sortinglist = Sorting(danhSachDatSan);

            for (int i = 0; i < sortinglist.Count; i++)
            {

                CDatSan datSan = sortinglist[i];
                DateTime ngayBatDau = datSan.NgayBD;
                DateTime thoiGianBatDau = ngayBatDau.AddHours(datSan.TGBD);
                DateTime thoiGianKetThuc = ngayBatDau.AddHours(datSan.TGKT);
                if (datSan.masan.Id == 2 && datSan.NgayBD == DateTime.Now.Date && datSan != null)
                {

                    if (currentTime.Hour == thoiGianBatDau.Hour && currentTime.Minute == thoiGianBatDau.Minute)
                    {
                        // Kiểm tra nếu giờ bắt đầu của sân hiện tại trùng với giờ kết thúc của sân trước đó
                        if (i > 0) // Đảm bảo rằng có sân trước đó để kiểm tra
                        {
                            CDatSan previousDatSan = sortinglist[i - 1];
                            DateTime prevThoiGianKetThuc = previousDatSan.NgayBD.Date.AddHours(previousDatSan.TGKT);

                            if (thoiGianBatDau.Hour == prevThoiGianKetThuc.Hour && thoiGianBatDau.Minute == prevThoiGianKetThuc.Minute)
                            {
                                client.PublishAsync("san2", "on2", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else if (thoiGianBatDau.Hour == currentTime.Hour && thoiGianBatDau.Minute == currentTime.Minute)
                            {
                                client.PublishAsync("san2", "on2", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else if (currentTime.Hour == thoiGianKetThuc.Hour && currentTime.Minute == thoiGianKetThuc.Minute)
                            {
                                client.PublishAsync("san2", "off2", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                        }
                        else if (i == 0) // Đảm bảo rằng có sân đầu
                        {

                            if (currentTime.Hour == thoiGianBatDau.Hour && currentTime.Minute == thoiGianBatDau.Minute)
                            {
                                client.PublishAsync("san2", "on2", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }


                        }
                    }
                    else if (currentTime.Hour == thoiGianKetThuc.Hour && currentTime.Minute == thoiGianKetThuc.Minute)
                    {

                        if (i == sortinglist.Count - 1)
                        {
                            client.PublishAsync("san2", "off2", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                            break;
                        }
                        CDatSan previousDatSan = sortinglist[i + 1];
                        if (previousDatSan.masan.Id == 2)
                        {
                            DateTime prevThoiGianBatDau = previousDatSan.NgayBD.Date.AddHours(previousDatSan.TGBD);

                            if (thoiGianBatDau.Hour == currentTime.Hour && thoiGianBatDau.Minute == currentTime.Minute)
                            {
                                client.PublishAsync("san2", "on2", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else if (prevThoiGianBatDau.Hour == thoiGianKetThuc.Hour && prevThoiGianBatDau.Minute == thoiGianKetThuc.Minute)
                            {
                                client.PublishAsync("san2", "on2", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else
                            {
                                client.PublishAsync("san3", "off3", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                        }
                        else
                        {
                            client.PublishAsync("san2", "off2", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                            break;
                        }
                    }

                }
            }
        }
        public void OnOff2(List<CDatSan> danhSachDatSan)
        {
            DateTime currentTime = DateTime.Now;
            List<CDatSan> sortinglist = Sorting(danhSachDatSan);

            for (int i = 0; i < sortinglist.Count; i++)
            {

                CDatSan datSan = sortinglist[i];
                DateTime ngayBatDau = datSan.NgayBD;
                DateTime thoiGianBatDau = ngayBatDau.AddHours(datSan.TGBD);
                DateTime thoiGianKetThuc = ngayBatDau.AddHours(datSan.TGKT);
                if (datSan.masan.Id == 3 && datSan.NgayBD == DateTime.Now.Date && datSan != null)
                {

                    if (currentTime.Hour == thoiGianBatDau.Hour && currentTime.Minute == thoiGianBatDau.Minute)
                    {
                        // Kiểm tra nếu giờ bắt đầu của sân hiện tại trùng với giờ kết thúc của sân trước đó
                        if (i > 0) // Đảm bảo rằng có sân trước đó để kiểm tra
                        {
                            CDatSan previousDatSan = sortinglist[i - 1];
                            DateTime prevThoiGianKetThuc = previousDatSan.NgayBD.Date.AddHours(previousDatSan.TGKT);

                            if (thoiGianBatDau.Hour == prevThoiGianKetThuc.Hour && thoiGianBatDau.Minute == prevThoiGianKetThuc.Minute)
                            {
                                client.PublishAsync("san3", "on3", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else if (thoiGianBatDau.Hour == currentTime.Hour && thoiGianBatDau.Minute == currentTime.Minute)
                            {
                                client.PublishAsync("san3", "on3", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else if (currentTime.Hour == thoiGianKetThuc.Hour && currentTime.Minute == thoiGianKetThuc.Minute)
                            {
                                client.PublishAsync("san3", "off3", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                        }
                        else if (i == 0) // Đảm bảo rằng có sân đầu
                        {

                            if (currentTime.Hour == thoiGianBatDau.Hour && currentTime.Minute == thoiGianBatDau.Minute)
                            {
                                client.PublishAsync("san3", "on3", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }

                        }
                    }
                    else if (currentTime.Hour == thoiGianKetThuc.Hour && currentTime.Minute == thoiGianKetThuc.Minute)
                    {


                        if (i == sortinglist.Count - 1)
                        {
                            client.PublishAsync("san3", "off3", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                            break;
                        }

                        // Kiểm tra nếu giờ bắt đầu của sân hiện tại trùng với giờ kết thúc của sân trước đó
                        CDatSan previousDatSan = sortinglist[i + 1];
                        if (previousDatSan.masan.Id == 3)
                        {
                            DateTime prevThoiGianBatDau = previousDatSan.NgayBD.Date.AddHours(previousDatSan.TGBD);

                            if (thoiGianBatDau.Hour == currentTime.Hour && thoiGianBatDau.Minute == currentTime.Minute)
                            {
                                client.PublishAsync("san3", "on3", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else if (prevThoiGianBatDau.Hour == thoiGianKetThuc.Hour && prevThoiGianBatDau.Minute == thoiGianKetThuc.Minute)
                            {
                                client.PublishAsync("san3", "on3", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else
                            {
                                client.PublishAsync("san3", "off3", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                        }
                        else
                        {
                            client.PublishAsync("san3", "off3", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                            break;
                        }



                    }

                }
            }
        }
        public void OnOff3(List<CDatSan> danhSachDatSan)
        {
            DateTime currentTime = DateTime.Now;
            List<CDatSan> sortinglist = Sorting(danhSachDatSan);

            for (int i = 0; i < sortinglist.Count; i++)
            {

                CDatSan datSan = sortinglist[i];
                DateTime ngayBatDau = datSan.NgayBD;
                DateTime thoiGianBatDau = ngayBatDau.AddHours(datSan.TGBD);
                DateTime thoiGianKetThuc = ngayBatDau.AddHours(datSan.TGKT);
                if (datSan.masan.Id == 4 && datSan.NgayBD == DateTime.Now.Date && datSan != null)
                {

                    if (currentTime.Hour == thoiGianBatDau.Hour && currentTime.Minute == thoiGianBatDau.Minute)
                    {
                        // Kiểm tra nếu giờ bắt đầu của sân hiện tại trùng với giờ kết thúc của sân trước đó
                        if (i > 0) // Đảm bảo rằng có sân trước đó để kiểm tra
                        {
                            CDatSan previousDatSan = sortinglist[i - 1];
                            DateTime prevThoiGianKetThuc = previousDatSan.NgayBD.Date.AddHours(previousDatSan.TGKT);

                            if (thoiGianBatDau.Hour == prevThoiGianKetThuc.Hour && thoiGianBatDau.Minute == prevThoiGianKetThuc.Minute)
                            {
                                client.PublishAsync("san4", "on4", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else if (thoiGianBatDau.Hour == currentTime.Hour && thoiGianBatDau.Minute == currentTime.Minute)
                            {
                                client.PublishAsync("san4", "on4", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else if (currentTime.Hour == thoiGianKetThuc.Hour && currentTime.Minute == thoiGianKetThuc.Minute)
                            {
                                client.PublishAsync("san4", "off4", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                        }
                        else if (i == 0) // Đảm bảo rằng có sân đầu
                        {

                            if (currentTime.Hour == thoiGianBatDau.Hour && currentTime.Minute == thoiGianBatDau.Minute)
                            {
                                client.PublishAsync("san4", "on4", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }


                        }
                    }
                    else if (currentTime.Hour == thoiGianKetThuc.Hour && currentTime.Minute == thoiGianKetThuc.Minute)
                    {

                        if (i == sortinglist.Count - 1)
                        {
                            client.PublishAsync("san4", "off4", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                            break;
                        }
                        CDatSan previousDatSan = sortinglist[i + 1];
                        if (previousDatSan.masan.Id == 4)
                        {
                            DateTime prevThoiGianBatDau = previousDatSan.NgayBD.Date.AddHours(previousDatSan.TGBD);

                            if (thoiGianBatDau.Hour == currentTime.Hour && thoiGianBatDau.Minute == currentTime.Minute)
                            {
                                client.PublishAsync("san4", "on4", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else if (prevThoiGianBatDau.Hour == thoiGianKetThuc.Hour && prevThoiGianBatDau.Minute == thoiGianKetThuc.Minute)
                            {
                                client.PublishAsync("san4", "on4", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                            else
                            {
                                client.PublishAsync("san4", "off4", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                                break;
                            }
                        }
                        else
                        {
                            client.PublishAsync("san4", "off4", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                            break;
                        }


                    }

                }
            }
        }
        private void btn_reset_Click(object sender, EventArgs e)
        {
            reset();
        }
        public void reset()
        {


            txb_id.Text = "";
            cb_idsan.SelectedIndex = -1; // Clear selection
            txb_name.Text = "";
            txb_phonenumber.Text = "";
            txb_people.Text = "";
            txb_email.Text = "";

            // Đặt lại ngày bắt đầu là ngày hiện tại
            dtp_checkin.Text = "05:00"; // Đặt lại giờ vào là 00:00
            dtp_checkout.Text = "23:00";

            // Kiểm tra xem danh sách có trống không


            hienthisantrong();
            hienthiview(xuly.getDSDatSan());

        }
        public void hienthisantrong()
        {

            List<(int, DateTime, double, double)> chuadat = santrong();

            List<(int, DateTime, double, double)> dsstrong = SortingEmpty(chuadat);
            if (dsstrong.Any())
            {
                var firstSlot = dsstrong.First();

                cb_idsan.SelectedItem = firstSlot.Item1;
                //DateTime ngayBD = dtp_date.Value.Date;
                // Đặt giá trị cho DateTimePicker check-in và check-out
                DateTime checkinTime = dtp_date.Value.Date.AddHours(firstSlot.Item3);
                DateTime checkoutTime = dtp_date.Value.Date.AddHours(firstSlot.Item4);

                dtp_checkin.Value = checkinTime;
                dtp_checkout.Value = checkoutTime;

            }
        }

        public List<CDatSan> Sorting(List<CDatSan> danhSachSanDat)
        {
            List<CDatSan> danhSachDatSanSapXep = danhSachSanDat
        .OrderBy(datSan => datSan.NgayBD.Date)
        .ThenBy(datSan => datSan.masan.Id)
        .ThenBy(datSan => datSan.TGBD)
        .ToList();
            return danhSachDatSanSapXep;
        }
        public List<(int, DateTime, double, double)> SortingEmpty(List<(int, DateTime, double, double)> danhSachCacKhungGioChuaDat)
        {
            var sortedList = danhSachCacKhungGioChuaDat
                .OrderBy(slot => slot.Item1)
                .ThenBy(slot => slot.Item2.Date)
                .ThenBy(slot => slot.Item3)
                .ThenBy(slot => slot.Item4)
                .ToList();

            return sortedList;
        }

        public List<(int, DateTime, double, double)> santrong()
        {
            List<(int, DateTime, double, double)> danhSachCacKhungGioChuaDat = new List<(int, DateTime, double, double)>();
            for (int masan = 1; masan <= 4; masan++)
            {
                if (!xuLySan.KTTrangSan(masan))
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
                        danhSachCacKhungGioChuaDat.Add((masan, ngaybd, startTime, endTime));
                        startTime = khungGio.Item2;
                        endTime = khungGio.Item3;
                    }
                }

                // Đừng quên thêm chuỗi khung giờ cuối cùng nếu cần
                if (startTime != -1)
                {
                    danhSachCacKhungGioChuaDat.Add((masan, ngaybd, startTime, endTime));
                }
            }

            return danhSachCacKhungGioChuaDat;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            OnOff(xuly.getDSDatSan());

            OnOff3(xuly.getDSDatSan());
            OnOff2(xuly.getDSDatSan());
            OnOff1(xuly.getDSDatSan());


        }
        private void StartReloadTimer()
        {
            reloadTimer.Start();
        }


        private void StopReloadTimer()
        {
            reloadTimer.Stop();
        }



        private void uiSymbolButton2_Click(object sender, EventArgs e) // nút xóa
        {
            // Kiểm tra xem có hàng được chọn không
            if (dgv_datsan.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa các mục đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                int lastRowIndex = dgv_datsan.Rows.Count - 1;
                if (result == DialogResult.Yes)
                {
                    List<CDatSan> datsanToDelete = new List<CDatSan>();

                    foreach (DataGridViewRow r in dgv_datsan.SelectedRows)
                    {
                        if (r.Index == lastRowIndex)
                        {
                            // Bỏ qua dòng cuối cùng
                            continue;
                        }

                        string msch = r.Cells[0].Value.ToString();
                        CDatSan datSan = xuly.tim(msch);
                        if (datSan != null)
                        {
                            // Thêm đối tượng CDatSan vào danh sách tạm thời
                            datsanToDelete.Add(datSan);
                        }

                    }

                    foreach (var datSanToDelete in datsanToDelete)
                    {
                        xuly.xoa(datSanToDelete);
                    }

                    hienthiview(xuly.getDSDatSan());
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một mục để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void uiSymbolButton3_Click(object sender, EventArgs e)//nút sửa
        {
            int currentHourIn = dtp_checkin.Value.Hour;
            int currentMinuteIn = dtp_checkin.Value.Minute;
            int currentHourOut = dtp_checkout.Value.Hour;
            int currentMinuteOut = dtp_checkout.Value.Minute;

            // Lấy mã đặt sân hiện tại từ textbox
            string currentId = txb_id.Text;

            CDatSan existingDatSan = xuly.tim(currentId);
            if (existingDatSan == null)
            {
                MessageBox.Show("Không tìm thấy mã đặt sân.");

                return;
            }

            // Tạo đối tượng CDatSan mới với các giá trị đã nhập
            CDatSan datSan = new CDatSan();
            datSan.Id = currentId;
            datSan.TenKH = txb_name.Text;
            datSan.SDT = Int32.Parse(txb_phonenumber.Text);
            datSan.SoNg = Int32.Parse(txb_people.Text);
            datSan.masan = xuLySan.tim(Int32.Parse(cb_idsan.Text));
            datSan.email = txb_email.Text;
            datSan.NgayBD = dtp_date.Value;

            int hourIn = dtp_checkin.Value.Hour;
            int minuteIn = dtp_checkin.Value.Minute;
            double totalMinuteIn = hourIn * 60 + minuteIn;
            datSan.TGBD = totalMinuteIn / 60.0;

            int hourOut = dtp_checkout.Value.Hour;
            int minuteOut = dtp_checkout.Value.Minute;
            double totalMinuteOut = hourOut * 60 + minuteOut;
            datSan.TGKT = totalMinuteOut / 60.0;

            if (datSan.TGBD < 5 || datSan.TGKT > 23)
            {
                MessageBox.Show("Giờ vào là 5:00 giờ đóng cửa là 23:00");
                return;
            }
            if (minuteIn != 0 && minuteIn != 30)
            {

                MessageBox.Show("Minute In chỉ có thể là 0 hoặc 30.");

                return; // Dừng xử lý tiếp theo
            }

            // Kiểm tra giá trị của minuteOut
            if (minuteOut != 0 && minuteOut != 30)
            {
                // Hiển thị thông báo hoặc thực hiện hành động phù hợp
                MessageBox.Show("Minute Out chỉ có thể là 0 hoặc 30.");

                return; // Dừng xử lý tiếp theo
            }
            if (datSan.TGBD >= datSan.TGKT)
            {
                MessageBox.Show("Giờ kết thúc phải sau giờ bắt đầu.");
                return;
            }

            datSan.SoGio = datSan.TGKT - datSan.TGBD;

            // Kiểm tra xem giá trị ngày giờ có thay đổi không
            if (datSan.NgayBD == existingDatSan.NgayBD && datSan.TGBD == existingDatSan.TGBD && datSan.TGKT == existingDatSan.TGKT)
            {
                if (xuly.sua(datSan) == true)
                {
                    // Chỉ sửa thông tin cơ bản
                    hienthiview(xuly.getDSDatSan());
                }
                else
                {
                    MessageBox.Show("Không thể sửa.");
                }

            }
            else
            {
                // Sửa cả thông tin cơ bản và ngày giờ
                if (xuly.suatheoma(datSan, datSan.NgayBD, datSan.TGBD, datSan.TGKT))
                {
                    hienthiview(xuly.getDSDatSan()); // Refresh data grid view
                }
                else
                {
                    MessageBox.Show("Không thể sửa.");
                }
            }

        }
        public static double TinhTongTien(double gioBD, double gioKT)
        {
            double tongTien = 0;

            // Mốc thời gian buổi sáng: 05:00 - 10:00
            TimeSpan morningStart = TimeSpan.FromHours(5);
            TimeSpan morningEnd = TimeSpan.FromHours(10);

            if (TimeSpan.FromHours(gioBD) < morningEnd && TimeSpan.FromHours(gioKT) > morningStart)
            {
                DateTime gioBatDau = TimeSpan.FromHours(gioBD) > morningStart ? DateTime.Today.Add(TimeSpan.FromHours(gioBD)) : DateTime.Today.Add(morningStart);
                DateTime gioKetThuc = TimeSpan.FromHours(gioKT) < morningEnd ? DateTime.Today.Add(TimeSpan.FromHours(gioKT)) : DateTime.Today.Add(morningEnd);
                double soGioTien = (gioKetThuc - gioBatDau).TotalHours;
                tongTien += soGioTien * 2 * 40000; // Tính tiền cho mốc thời gian đầu tiên
            }

            // Mốc thời gian buổi trưa: 10:00 - 16:00
            TimeSpan afternoonStart = TimeSpan.FromHours(10);
            TimeSpan afternoonEnd = TimeSpan.FromHours(16);

            if (TimeSpan.FromHours(gioBD) < afternoonEnd && TimeSpan.FromHours(gioKT) > afternoonStart)
            {
                DateTime gioBatDau = TimeSpan.FromHours(gioBD) > afternoonStart ? DateTime.Today.Add(TimeSpan.FromHours(gioBD)) : DateTime.Today.Add(afternoonStart);
                DateTime gioKetThuc = TimeSpan.FromHours(gioKT) < afternoonEnd ? DateTime.Today.Add(TimeSpan.FromHours(gioKT)) : DateTime.Today.Add(afternoonEnd);
                double soGioTien = (gioKetThuc - gioBatDau).TotalHours;
                tongTien += soGioTien * 2 * 25000; // Tính tiền cho mốc thời gian thứ hai
            }

            // Mốc thời gian buổi tối: 16:00 - 23:00
            TimeSpan eveningStart = TimeSpan.FromHours(16);
            TimeSpan eveningEnd = TimeSpan.FromHours(23);

            if (TimeSpan.FromHours(gioBD) < eveningEnd && TimeSpan.FromHours(gioKT) > eveningStart)
            {
                DateTime gioBatDau = TimeSpan.FromHours(gioBD) > eveningStart ? DateTime.Today.Add(TimeSpan.FromHours(gioBD)) : DateTime.Today.Add(eveningStart);
                DateTime gioKetThuc = TimeSpan.FromHours(gioKT) < eveningEnd ? DateTime.Today.Add(TimeSpan.FromHours(gioKT)) : DateTime.Today.Add(eveningEnd);
                double soGioTien = (gioKetThuc - gioBatDau).TotalHours;
                tongTien += soGioTien * 2 * 50000; // Tính tiền cho mốc thời gian thứ ba
            }

            return tongTien;
        }


        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {

            if (TruyCapDuLieu.ghiFile("dssan.dat") == true)
            {
                MessageBox.Show("Lưu thành công!!!");
            }
            else
            {
                MessageBox.Show("Không lưu được");
            }
        }



        private void dgv_datsan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_datsan.Rows[e.RowIndex];

                // Kiểm tra nếu đây không phải là hàng tổng tiền
                if (row.Cells["ID"].Value != null)
                {
                    txb_id.Text = row.Cells["ID"].Value.ToString();
                    // Lấy dữ liệu từ các ô trong hàng được chọn và hiển thị lên các control tương ứng trên form
                    cb_idsan.Text = row.Cells["ID_San"].Value.ToString();
                    txb_name.Text = row.Cells["name"].Value.ToString();
                    txb_phonenumber.Text = row.Cells["Number"].Value.ToString();
                    txb_people.Text = row.Cells["People"].Value.ToString();
                    txb_total.Text = row.Cells["Column2"].Value.ToString();
                    txb_email.Text = row.Cells["email"].Value.ToString();
                    txb_sogio.Text = row.Cells["hour"].Value.ToString();
                    // Chuyển đổi và hiển thị ngày bắt đầu từ kiểu DateTime sang kiểu string
                    DateTime ngayBD = (DateTime)row.Cells["date"].Value;
                    dtp_date.Text = ngayBD.ToString("MM/dd/yyyy");
                    txb_total.Text = row.Cells["Column2"].Value.ToString();
                    // Hiển thị giờ vào và giờ ra dưới dạng chuỗi
                    dtp_checkin.Text = row.Cells["TGBD"].Value.ToString();
                    dtp_checkout.Text = row.Cells["Column1"].Value.ToString();
                }
            }

        }
        private void roundedButton1_Click(object sender, EventArgs e)
        {
            sendmail();
        }
        public void sendmail()
        {
            UI.send_email email = new send_email();
            email.tempcontent_madat = txb_id.Text;
            email.tempcontent_ten = txb_name.Text;
            email.tempcontent_sdt = txb_phonenumber.Text;
            email.tempcontent_giovao = dtp_checkin.Text;
            email.tempcontent_giora = dtp_checkout.Text;
            email.tempconntent_songuoi = txb_people.Text;
            email.temconntent_masan = cb_idsan.Text;
            email.tempcontent_email = txb_email.Text;
            email.tempcontent_sogio = txb_sogio.Text;
            email.tempcontent_ngay = dtp_date.Text;
            email.tempcontent_tongtien = txb_total.Text;
            email.Show();
        }


        private void btn_san1_Click(object sender, EventArgs e)
        {
            List<CDatSan> san1List = xuly.getDSDatSan().Where(ds => ds.masan.Id == 1).ToList();

            hienthiview(san1List);

        }

        private void btn_San2_Click(object sender, EventArgs e)
        {
            List<CDatSan> san1List = xuly.getDSDatSan().Where(ds => ds.masan.Id == 2).ToList();
            hienthiview(san1List);
        }

        private void btn_san3_Click(object sender, EventArgs e)
        {
            List<CDatSan> san1List = xuly.getDSDatSan().Where(ds => ds.masan.Id == 3).ToList();
            hienthiview(san1List);
        }

        private void btn_San4_Click(object sender, EventArgs e)
        {
            List<CDatSan> san1List = xuly.getDSDatSan().Where(ds => ds.masan.Id == 4).ToList();
            hienthiview(san1List);
        }

        private void txb_sogio_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiSymbolButton5_Click(object sender, EventArgs e)//nút tìm
        {

            DateTime date = dtp_date.Value;
            double gioBDChon = dtp_checkin.Value.Hour;
            double gioKTChon = dtp_checkout.Value.Hour;

            timsan = new CXuLyDatSan(0);
            string ten = txb_name.Text;
            bool isNameEmpty = string.IsNullOrEmpty(ten);
            string tenmoi = CStringExtensions.RemoveDiacritics(ten).ToUpper();
            string phoneNumberText = txb_phonenumber.Text;
            bool isPhoneNumberEmpty = string.IsNullOrEmpty(phoneNumberText);
            int sdt = 0;
            if (!isPhoneNumberEmpty)
            {
                sdt = Int32.Parse(phoneNumberText);
            }

            foreach (CDatSan item in xuly.getDSDatSan())
            {
                string tenkh= CStringExtensions.RemoveDiacritics(item.TenKH).ToUpper();

                if (isNameEmpty && isPhoneNumberEmpty)
                {
                    if (item.NgayBD == date && item.TGBD >= gioBDChon && item.TGKT <= gioKTChon)
                    {
                        timsan.themsantheogio(item);
                    }

                }

                else if(isPhoneNumberEmpty)
                {

                    if (tenkh.Contains(tenmoi)||tenkh.StartsWith(ten))
                    {
                        timsan.themsantim(item);
                    }
                    
                }
                else if (isNameEmpty)
                {
                    if (item.SDT == sdt)
                    {
                        timsan.themsantheogio(item);
                    }
                }
               

            }
            hienthiviewSearch(timsan.getDSDatSan());

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SanTrong trong = new SanTrong(true);
            trong.tempdatetime_ngaytrong = dtp_date.Value.Date;
            trong.Show();
            this.Close();


        }

        private void cb_idsan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ExportToExcel(DataGridView dataGridView)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveDialog.FilterIndex = 1;
            saveDialog.RestoreDirectory = true;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveDialog.FileName;

                try
                {
                    using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
                    {
                        WorkbookPart workbookPart = document.AddWorkbookPart();
                        workbookPart.Workbook = new Workbook();

                        WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                        SheetData sheetData = new SheetData();
                        worksheetPart.Worksheet = new Worksheet(sheetData);

                        Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                        Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                        sheets.Append(sheet);

                        // Thêm hàng tiêu đề
                        Row headerRow = new Row();
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            Cell headerCell = new Cell
                            {
                                DataType = CellValues.String,
                                CellValue = new CellValue(column.HeaderText)
                            };
                            headerRow.AppendChild(headerCell);
                        }
                        sheetData.AppendChild(headerRow);

                        // Thêm các hàng dữ liệu
                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            if (!row.IsNewRow) // Bỏ qua hàng trống mới (nếu có)
                            {
                                Row newRow = new Row();
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    Cell newCell = new Cell
                                    {
                                        DataType = CellValues.String,
                                        CellValue = new CellValue(cell.Value?.ToString() ?? "")
                                    };
                                    newRow.AppendChild(newCell);
                                }
                                sheetData.AppendChild(newRow);
                            }
                        }

                        workbookPart.Workbook.Save();
                    }

                    MessageBox.Show("Export thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }
        private void Export_Excel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgv_datsan);
        }
    }
}

