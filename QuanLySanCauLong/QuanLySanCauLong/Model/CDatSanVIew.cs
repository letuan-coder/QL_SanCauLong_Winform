using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace QuanLySanCauLong.Model
{
    public class CDatSanVIew
    {

        public string Id { get; private set; }
        public string email { get; set; }
        public string TenKH { get; set; }
        public int masan { get; set; }
        public string  SDT { get; set; }
        public double SoGio { get; set; }
        public int SoNg { get; set; }
        public DateTime NgayBD { get; set; }
        public string TGBD { get; set; } // Thay đổi kiểu dữ liệu thành string
        public string TGKT { get; set; } // Thay đổi kiểu dữ liệu thành string
        public string TongTien { get; set; }


        public static List<CDatSanVIew> getdsDatSanViews(List<CDatSan> danhsachdatsan)
        {
            List<CDatSanVIew> dsch = new List<CDatSanVIew>();
            double tongTienTatCa = 0;
            foreach (CDatSan a in danhsachdatsan)
            {
                CDatSanVIew chv = new CDatSanVIew();
                chv.Id = a.Id.ToString();
                chv.masan = a.masan.Id;
                chv.TenKH = a.TenKH;
                chv.SDT ="0" + a.SDT;
                chv.email = a.email;
                chv.SoNg = a.SoNg;
                chv.NgayBD = a.NgayBD;
                chv.TGBD = TimeSpan.FromHours(a.TGBD).ToString(@"hh\:mm");
                chv.TGKT = TimeSpan.FromHours(a.TGKT).ToString(@"hh\:mm");
                //chv.TGBD = a.TGBD.ToShortTimeString();
                //chv.TGKT = a.TGKT.ToShortTimeString();
                chv.SoGio = a.SoGio;
                double soGio = chv.SoGio;
                chv.TongTien = a.TongTien;
                double tongTien = 0;
                
                if (a.TGBD < 10 && a.TGKT > 5)
                {
                    double gioBD = Math.Max(a.TGBD, 5);
                    double gioKT = Math.Min(a.TGKT, 10);
                    double soGioTien1 = gioKT - gioBD;
                    tongTien += (int)(soGioTien1 * 2) * 40000; // Tính tiền cho mốc thời gian đầu tiên
                    soGio -= soGioTien1;
                }


                if (a.TGBD < 16 && a.TGKT > 10)
                {
                    double gioBD = Math.Max(a.TGBD, 10); // Lấy giờ bắt đầu ca đặt sân
                    double gioKT = Math.Min(a.TGKT, 16); // Lấy giờ kết thúc ca đặt sân
                    double soGioTien2 = gioKT - gioBD; // Số giờ trong mốc thời gian thứ hai
                    tongTien += (int)(soGioTien2 * 2) * 25000; // Tính tiền cho mốc thời gian thứ hai
                    soGio -= soGioTien2;
                }

                // Tính tiền từ 16h đến 23h: 50k mỗi 30 phút
                if (a.TGBD < 23 && a.TGKT > 16)
                {
                    double gioBD = Math.Max(a.TGBD, 16); // Lấy giờ bắt đầu ca đặt sân
                    double gioKT = Math.Min(a.TGKT, 23); // Lấy giờ kết thúc ca đặt sân
                    double soGioTien3 = gioKT - gioBD; // Số giờ trong mốc thời gian thứ ba
                    tongTien += (int)(soGioTien3 * 2) * 50000; // Tính tiền cho mốc thời gian thứ ba
                    soGio -= soGioTien3;
                }


                tongTien += (int)(soGio * 2) * 50000;
                string tongTienFormatted = tongTien.ToString("#,##0") + " đ";
                chv.TongTien = tongTienFormatted;

                dsch.Add(chv);
                //tongTienTatCa += tongTien;
            }
            //CDatSanVIew tongTienRow = new CDatSanVIew();
            //tongTienRow.TongTien = tongTienTatCa.ToString("#,##0") + " đ"; 
            //dsch.Add(tongTienRow);

            return dsch;
        }
    }
}