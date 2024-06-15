using System;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace QuanLySanCauLong.UI
{
    public partial class send_email : Form
    {
        public string tempcontent_email;
        public string tempcontent_ten;
        public string tempconntent_songuoi;
        public string tempcontent_sogio;
        public string tempcontent_song;
        public string tempcontent_ngay;
        public string tempcontent_giovao;
        public string tempcontent_giora;
        public string tempcontent_tongtien;
        public string temconntent_masan;
        public string tempcontent_madat;
        public string tempcontent_sdt;
        public send_email()
        {
            InitializeComponent();
            pass.PasswordChar = '*';
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mm = new MailMessage();
                SmtpClient sc = new SmtpClient("smtp.gmail.com");

                // Thiết lập chi tiết email
                mm.From = new MailAddress(from.Text);
                mm.To.Add(to.Text);
                mm.Subject = subj.Text;
                mm.Body = noidung.Text;

                // Cấu hình SMTP client
                sc.Port = 587;
                sc.Credentials = new NetworkCredential(from.Text, pass.Text);
                sc.EnableSsl = true;
                sc.EnableSsl = true;

                // Gửi email
                sc.Send(mm);

                // Hiển thị thông báo thành công
                MessageBox.Show("Email đã được gửi thành công.");
            }
            catch (SmtpException ex)
            {
                // Xử lý các ngoại lệ SMTP
                MessageBox.Show("Gửi email thất bại: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ khác
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void send_email_Load(object sender, EventArgs e)
        {
            string emailContent = $"Gửi anh/chị: {tempcontent_ten}\n " +
                         $"Mã đặt của anh/chị : {tempcontent_madat}\n " +
                         $"Ngày: {tempcontent_ngay}\n " +
                         $"Giờ vào : {tempcontent_giovao}\n " +
                         $"Giờ ra là : {tempcontent_giora}\n " +
                         $"Số giờ chơi : {tempcontent_sogio}\n " +
                         $"Số người chơi  : {tempconntent_songuoi}\n " +
                         $"Sân Số : {temconntent_masan}\n " +
                         $"Số điện thoại : {tempcontent_sdt}\n " +
                         $"Tổng tiền là : {tempcontent_tongtien}\n ";

            noidung.Text = emailContent;
            to.Text= tempcontent_email+"@gmail.com";
        }
    }
}
