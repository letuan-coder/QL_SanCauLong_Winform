using HiveMQtt.Client.Options;
using HiveMQtt.Client;
using QuanLySanCauLong.Model;
using QuanLySanCauLong.XuLy;
using Sunny.UI;
using HiveMQtt.MQTT5.Types;
using QuanLySanCauLong.UI;
using System.Text.Json;
using System.Drawing.Design;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System.Data;

namespace QuanLySanCauLong
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer reloadTimer;
        private string received_message;
        private string message1;
        private HiveMQClient client;
        private int f;
        public CXuLyDatSan xuly = new CXuLyDatSan();
        private int n1, n2, n3, n4 = 1;
        private bool autoModeInitialized = false;
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

            var topic1 = "nhietdo";
            var topic2 = "court_state";

            var subscribeResult1 = await client.SubscribeAsync(topic1, HiveMQtt.MQTT5.Types.QualityOfService.ExactlyOnceDelivery).ConfigureAwait(false);
            var subscribeResult2 = await client.SubscribeAsync(topic2, HiveMQtt.MQTT5.Types.QualityOfService.ExactlyOnceDelivery).ConfigureAwait(false);
            string dataFromTopic1 = "";

            client.OnMessageReceived += (sender, args) =>
            {
                received_message = args.PublishMessage.Topic;
                if (received_message == topic1)
                {
                    message1 = args.PublishMessage.PayloadAsString;

                }
                if (received_message == topic2)
                {
                    string message2 = args.PublishMessage.PayloadAsString;
                    string json = message2;

                    using (JsonDocument doc = JsonDocument.Parse(json))
                    {
                        string state_s1 = doc.RootElement.GetProperty("San1").GetString();
                        string state_s2 = doc.RootElement.GetProperty("San2").GetString();
                        string state_s3 = doc.RootElement.GetProperty("San3").GetString();
                        string state_s4 = doc.RootElement.GetProperty("San4").GetString();
                        string auto_mode = doc.RootElement.GetProperty("modeauto").GetString();
                        string manual_mode = doc.RootElement.GetProperty("modemanual").GetString();
                        string fanstate = doc.RootElement.GetProperty("fan").GetString();


                        if (IsHandleCreated)
                        {
                            if (state_s1 == "on")
                            {
                                pics1sang.BeginInvoke(new Action(() => pics1sang.Visible = true));
                                pics1toi.BeginInvoke(new Action(() => pics1toi.Visible = false));
                                btn_san1.BeginInvoke(new Action(() => btn_san1.Text = "Đã Bật"));
                            }
                            else if (state_s1 == "off")
                            {
                                pics1sang.BeginInvoke(new Action(() => pics1sang.Visible = false));
                                pics1toi.BeginInvoke(new Action(() => pics1toi.Visible = true));
                                btn_san1.BeginInvoke(new Action(() => btn_san1.Text = "Đã Tắt"));
                            }
                            if (state_s2 == "on")
                            {
                                pics2sang.BeginInvoke(new Action(() => pics2sang.Visible = true));
                                pics2toi.BeginInvoke(new Action(() => pics2toi.Visible = false));
                                btn_san2.BeginInvoke(new Action(() => btn_san2.Text = "Đã Bật"));
                            }
                            else if (state_s2 == "off")
                            {
                                pics2sang.BeginInvoke(new Action(() => pics2sang.Visible = false));
                                pics2toi.BeginInvoke(new Action(() => pics2toi.Visible = true));
                                btn_san2.BeginInvoke(new Action(() => btn_san2.Text = "Đã Tắt"));
                            }
                            if (state_s3 == "on")
                            {
                                pics3sang.BeginInvoke(new Action(() => pics3sang.Visible = true));
                                pics3toi.BeginInvoke(new Action(() => pics3toi.Visible = false));
                                btn_san3.BeginInvoke(new Action(() => btn_san3.Text = "Đã Bật"));
                            }
                            else if (state_s3 == "off")
                            {
                                pics3sang.BeginInvoke(new Action(() => pics3sang.Visible = false));
                                pics3toi.BeginInvoke(new Action(() => pics3toi.Visible = true));
                                btn_san3.BeginInvoke(new Action(() => btn_san3.Text = "Đã Tắt"));
                            }
                            if (state_s4 == "on")
                            {
                                pics4sang.BeginInvoke(new Action(() => pics4sang.Visible = true));
                                pics4toi.BeginInvoke(new Action(() => pics4toi.Visible = false));
                                btn_san4.BeginInvoke(new Action(() => btn_san4.Text = "Đã Bật"));
                            }
                            else if (state_s4 == "off")
                            {
                                pics4sang.BeginInvoke(new Action(() => pics4sang.Visible = false));
                                pics4toi.BeginInvoke(new Action(() => pics4toi.Visible = true));
                                btn_san4.BeginInvoke(new Action(() => btn_san4.Text = "Đã Tắt"));
                            }

                            if (!autoModeInitialized)
                            {
                                if (auto_mode == "on")
                                {
                                    autopng.BeginInvoke(new Action(() => autopng.Visible = true));
                                    sButton1.BeginInvoke(new Action(() => sButton1.Checked = true));
                                }
                                else if (auto_mode == "off")
                                {
                                    autopng.BeginInvoke(new Action(() => autopng.Visible = false));
                                    sButton1.BeginInvoke(new Action(() => sButton1.Checked = false));
                                }

                                // Đặt biến cờ thành true sau khi đoạn mã được thực thi
                                autoModeInitialized = true;
                            }
                            //else if (manual_mode == "on")
                            //{
                            //    autopng.BeginInvoke(new Action(() => autopng.Visible = false));
                            //}

                            if (fanstate == "on1")
                            {
                                buttonfan.BeginInvoke(new Action(() => buttonfan.Text = "Muc1"));
                                muc1png.BeginInvoke(new Action(() => muc1png.Visible = true));
                                muc2png.BeginInvoke(new Action(() => muc2png.Visible = false));
                                muc3png.BeginInvoke(new Action(() => muc3png.Visible = false));
                                muc0png.BeginInvoke(new Action(() => muc0png.Visible = false));
                                autopng.BeginInvoke(new Action(() => autopng.Visible = false));
                            }
                            else if (fanstate == "on2")
                            {
                                buttonfan.BeginInvoke(new Action(() => buttonfan.Text = "Muc2"));
                                muc2png.BeginInvoke(new Action(() => muc2png.Visible = true));
                                muc1png.BeginInvoke(new Action(() => muc1png.Visible = false));
                                muc3png.BeginInvoke(new Action(() => muc3png.Visible = false));
                                muc0png.BeginInvoke(new Action(() => muc0png.Visible = false));
                                autopng.BeginInvoke(new Action(() => autopng.Visible = false));
                            }
                            else if (fanstate == "on3")
                            {
                                buttonfan.BeginInvoke(new Action(() => buttonfan.Text = "Muc3"));
                                muc3png.BeginInvoke(new Action(() => muc3png.Visible = true));
                                muc1png.BeginInvoke(new Action(() => muc1png.Visible = false));
                                muc2png.BeginInvoke(new Action(() => muc2png.Visible = false));
                                muc0png.BeginInvoke(new Action(() => muc0png.Visible = false));
                                autopng.BeginInvoke(new Action(() => autopng.Visible = false));
                            }
                            else if (fanstate == "off")
                            {
                                buttonfan.BeginInvoke(new Action(() => buttonfan.Text = "OFF"));
                                muc0png.BeginInvoke(new Action(() => muc0png.Visible = true));
                                muc1png.BeginInvoke(new Action(() => muc1png.Visible = false));
                                muc2png.BeginInvoke(new Action(() => muc2png.Visible = false));
                                muc3png.BeginInvoke(new Action(() => muc3png.Visible = false));
                                autopng.BeginInvoke(new Action(() => autopng.Visible = false));
                            }
                            if (fanstate == "NO")
                            {
                                muc0png.BeginInvoke(new Action(() => muc0png.Visible = false));
                                muc1png.BeginInvoke(new Action(() => muc1png.Visible = false));
                                muc2png.BeginInvoke(new Action(() => muc2png.Visible = false));
                                muc3png.BeginInvoke(new Action(() => muc3png.Visible = false));
                                autopng.BeginInvoke(new Action(() => autopng.Visible = true));
                            }
                        }
                    }
                }
            };

        }
        public Form1()
        {
            InitializeComponent();
            reloadTimer = new System.Windows.Forms.Timer();
            reloadTimer.Interval = 5000; // 5000ms = 5 giây
            reloadTimer.Tick += new EventHandler(timer1_Tick); // Xử lý sự kiện Tick của timer
            StartReloadTimer();
            timer2.Start();
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

        private const string configFilePath = "config.txt"; // Đường dẫn tệp cấu hình

        private void SaveConfig()
        {
            File.WriteAllText(configFilePath, f.ToString());
        }

        private void LoadConfig()
        {
            if (File.Exists(configFilePath))
            {
                string content = File.ReadAllText(configFilePath);
                if (int.TryParse(content, out int value))
                {
                    f = value;
                }
            }
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            LoadConfig(); // Đọc giá trị f từ tệp cấu hình

            await connect();
            hienthiview(xuly.getDSDatSan());
            DATE.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Cập nhật trạng thái của buttonfan dựa trên giá trị của f
            UpdateFanButtonState();
        }
        private void StartReloadTimer()
        {
            reloadTimer.Start();
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

                // Apply the default cell style if needed
                dgv_datsan.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                dgv_datsan.DefaultCellStyle.ForeColor = System.Drawing.Color.Black; // Optional, set text color
            }
            else
            {
                MessageBox.Show("Sân đang thêm dữ liệu");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UI.Form2 san = new UI.Form2();
            san.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UI.DatSan datsann = new UI.DatSan();
            datsann.Show();
        }
        private int value;

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();

            OnOff(xuly.getDSDatSan());
            OnOff1(xuly.getDSDatSan());
            OnOff2(xuly.getDSDatSan());
            OnOff3(xuly.getDSDatSan());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            f++;
            if (f == 1)
            {
                client.PublishAsync("fan", "onfan1", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(continueOnCapturedContext: false);
                //muc1png.Visible = true;
                //muc2png.Visible = false;
                //muc3png.Visible = false;
                //muc0png.Visible = false;
                buttonfan.Text = "Muc 1";
            }
            else if (f == 2)
            {
                client.PublishAsync("fan", "onfan2", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(continueOnCapturedContext: false);
                //muc1png.Visible = false;
                //muc2png.Visible = true;
                //muc3png.Visible = false;
                //muc0png.Visible = false;
                buttonfan.Text = "Muc 2";
            }
            else if (f == 3)
            {
                client.PublishAsync("fan", "onfan3", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(continueOnCapturedContext: false);
                //muc1png.Visible = false;
                //muc2png.Visible = false;
                //muc3png.Visible = true;
                //muc0png.Visible = false;
                buttonfan.Text = "Muc 3";
            }
            else
            {
                f = 0;
                client.PublishAsync("fan", "offfan", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(continueOnCapturedContext: false);
                //muc1png.Visible = false;
                //muc2png.Visible = false;
                //muc3png.Visible = false;
                //muc0png.Visible = true;
                buttonfan.Text = "OFF";
            }
            SaveConfig(); // Lưu giá trị f vào tệp cấu hình mỗi khi thay đổi
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig(); // Lưu giá trị f vào tệp cấu hình
        }
        private void UpdateFanButtonState()
        {
            switch (f)
            {
                case 1:
                    buttonfan.Text = "Muc 1";
                    break;
                case 2:
                    buttonfan.Text = "Muc 2";
                    break;
                case 3:
                    buttonfan.Text = "Muc 3";
                    break;
                default:
                    buttonfan.Text = "OFF";
                    break;
            }
        }

        private async void sButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (sButton1.Checked)
                {
                    buttonfan.Visible = false;
                    await client.PublishAsync("mode", "auto", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);

                    // Hiện autopng khi chuyển sang chế độ tự động
                    BeginInvoke(new Action(() => autopng.Visible = true));
                    BeginInvoke(new Action(() => muc0png.Visible = false));
                    BeginInvoke(new Action(() => muc1png.Visible = false));
                    BeginInvoke(new Action(() => muc2png.Visible = false));
                    BeginInvoke(new Action(() => muc3png.Visible = false));
                }
                else
                {
                    buttonfan.Visible = true;
                    await client.PublishAsync("mode", "manual", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                    await client.PublishAsync("fan", "offfan", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                    // Ẩn autopng khi chuyển sang chế độ thủ công
                    BeginInvoke(new Action(() => autopng.Visible = false));
                    f = 0; // Đặt lại giá trị f khi chuyển sang chế độ manual
                    SaveConfig(); // Lưu giá trị f vào tệp cấu hình
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Vui lòng thao tác chậm lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
            private void uiButton1_Click(object sender, EventArgs e)
        {
            UI.send_email email = new UI.send_email();
            email.Show();
        }
        private void btn_san1_Click(object sender, EventArgs e)
        {
            n1++;
            if (n1 % 2 != 0)
            {
                client.PublishAsync("san1", "on1", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                pics1sang.Visible = true;
                pics1toi.Visible = false;
                btn_san1.Text = "Đã Bật";
            }
            else if (n1 % 2 == 0)
            {
                client.PublishAsync("san1", "off1", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                pics1sang.Visible = false;
                pics1toi.Visible = true;
                btn_san1.Text = "Đã Tắt";
            }
        }

        private void btn_san2_Click(object sender, EventArgs e)
        {
            n2++;
            if (n2 % 2 != 0)
            {
                client.PublishAsync("san2", "on2", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                //pics2sang.Visible = true;
                //pics2toi.Visible = false;
                //btn_san2.Text = "Đã Bật";
            }
            else if (n2 % 2 == 0)
            {
                client.PublishAsync("san2", "off2", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                //pics2sang.Visible = false;
                //pics2toi.Visible = true;
                //btn_san2.Text = "Đã Tắt";
            }

        }

        private void btn_san3_Click(object sender, EventArgs e)
        {
            n3++;
            if (n3 % 2 != 0)
            {
                client.PublishAsync("san3", "on3", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                //pics3sang.Visible = true;
                //pics3toi.Visible = false;
                //btn_san3.Text = "Đã Bật";

            }
            else if (n3 % 2 == 0)
            {
                client.PublishAsync("san3", "off3", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                //pics3sang.Visible = false;
                //pics3toi.Visible = true;
                //btn_san3.Text = "Đã Tắt";
            }
        }

        private void btn_san4_Click(object sender, EventArgs e)
        {
            n4++;
            if (n4 % 2 != 0)
            {
                client.PublishAsync("san4", "on4", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                //pics4sang.Visible = false;
                //pics4toi.Visible = true;
                //btn_san4.Text = "Đã Bật";

            }
            else if (n4 % 2 == 0)
            {
                client.PublishAsync("san4", "off4", QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);
                //pics4sang.Visible = true;
                //pics4toi.Visible = false;
                //btn_san4.Text = "Đã Tắt";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            uiLedDisplay1.Text = message1;
            timer.Text = DateTime.Now.ToLongTimeString();
        }

        
        private void uiButton1_Click_1(object sender, EventArgs e)
        {
        }
    }
}

