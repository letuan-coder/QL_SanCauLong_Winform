using QuanLySanCauLong.Model;
using QuanLySanCauLong.UI;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanCauLong.XuLy
{
    public class CXuLyDatSan
    {
        TruyCapDuLieu data = TruyCapDuLieu.khoitao();
        public List<CDatSan> datsan;
        public List<CSan> xuLySan;

        public CXuLyDatSan()
        {
            datsan = data.GetBook();
        }
        public CXuLyDatSan(int a)
        {
            datsan = new List<CDatSan>();
        }
        public List<CDatSan> getDSDatSan()
        {
            return datsan.ToList();
        }

        public CDatSan tim(string madat)
        {
            foreach (var item in datsan)
            {
                if (item.Id == madat)
                    return item;
            }
            return null;
        }
        public CDatSan timtheoten(string ten)
        {
            foreach (var item in datsan)
            {
                if (item.TenKH.Contains(ten))
                    return item;
            }
            return null;
        }
        public List<CDatSan> timtheosdt(int sdt)
        {
            List<CDatSan> ketQua = new List<CDatSan>();
            foreach (var item in datsan)
            {
                if (item.SDT == sdt)
                    ketQua.Add(item);
            }
            return null;
        }




        public bool them(CDatSan a, DateTime ngayChon, double gioBDChon, double gioKTChon)
        {
            if (timVaNhapLai(a, ngayChon, gioBDChon, gioKTChon))
            {
                return false;
            }
            else
            {
                datsan.Add(a);
                return true;

            }
        }
        public bool themsantim(CDatSan a)
        {
            if (tim(a.Id) == null)
            {
                datsan.Add(a);
                return true;
            }
            else
            {

                return false;

            }
        }
        public bool themsantheogio(CDatSan a)
        {
            
            datsan.Add(a);
            return true;
        }
        public bool timVaNhapLai(CDatSan a, DateTime ngayChon, double gioBDChon, double gioKTChon)
        {
            foreach (var item in datsan)
            {
                // So sánh ngày và mã sân
                if (item.NgayBD.Date == ngayChon.Date && item.masan.Id == a.masan.Id)
                {
                    // Kiểm tra nếu có trùng thời gian
                    if ((gioBDChon < item.TGKT && gioKTChon > item.TGBD))
                    {
                        MessageBox.Show("Đã có người đặt sân trong khung giờ này. Vui lòng chọn khung giờ khác.");
                        return true;
                    }
                }
            }
            return false;
        }


        public bool TimMaSanKhongDat(int masan, DateTime ngayChon, double gioBDChon, double gioKTChon)
        {
            foreach (var item in datsan)
            {
                // So sánh ngày và mã sân
                if (item.NgayBD.Date == ngayChon.Date && item.masan.Id == masan)
                {
                    // Kiểm tra nếu có trùng thời gian
                    if ((item.TGBD <= gioBDChon && item.TGKT > gioBDChon) || (item.TGBD < gioKTChon && item.TGKT >= gioKTChon))
                    {

                        return true;
                    }
                }
            }
            return false;
        }
        public CDatSan timTheoNgaySua(CDatSan a, DateTime ngayChon, double gioBDChon, double gioKTChon)
        {
            foreach (var item in datsan)
            {
                // So sánh ngày và mã sân
                if (item.NgayBD.Date == ngayChon.Date && item.masan.Id == a.masan.Id)
                {
                    // Kiểm tra nếu có trùng thời gian
                    if ((gioBDChon < item.TGKT && gioKTChon > item.TGBD))
                    {
                        MessageBox.Show("Đã có người đặt sân trong khung giờ này. Vui lòng chọn khung giờ khác.");
                        return item;
                    }


                }

            }
            return null;
        }
        public bool suatheoma(CDatSan newDatSan, DateTime ngay, double TGBD, double TGKT)
        {
            // Tìm đối tượng cần sửa
            CDatSan existingDatSan = tim(newDatSan.Id);
            if (existingDatSan == null)
            {
                return false; // Không tìm thấy đối tượng cần sửa
            }
            else
            {
                datsan.Remove(existingDatSan);
                // Kiểm tra xem có xung đột không
                CDatSan conflictItem = timTheoNgaySua(newDatSan, ngay, TGBD, TGKT);
                if (conflictItem != null)
                {
                    datsan.Add(existingDatSan);
                    return false;
                }
                else
                {

                    newDatSan.Id = existingDatSan.Id;
                    existingDatSan.TenKH = newDatSan.TenKH;
                    existingDatSan.masan = newDatSan.masan;
                    existingDatSan.SDT = newDatSan.SDT;
                    existingDatSan.SoGio = newDatSan.SoGio;
                    existingDatSan.SoNg = newDatSan.SoNg;
                    existingDatSan.email = newDatSan.email;
                    existingDatSan.TongTien = newDatSan.TongTien;
                    existingDatSan.NgayBD = newDatSan.NgayBD;
                    existingDatSan.TGBD = newDatSan.TGBD;
                    existingDatSan.TGKT = newDatSan.TGKT;
                    datsan.Add(existingDatSan);
                    return true; // Sửa thành công
                }
            }
        }

        public bool sua(CDatSan a)
        {

            CDatSan result = tim(a.Id);
            if (result == null)
            {
                return false;
            }
            else
            {

                // Cập nhật thông tin cơ bản
                result.TenKH = a.TenKH;
                result.masan = a.masan;
                result.SDT = a.SDT;
                result.SoGio = a.SoGio;
                result.SoNg = a.SoNg;
                result.email = a.email;
                result.TongTien = a.TongTien;

                return true;

            }

        }
        public bool xoa(CDatSan a)
        {
            if (tim(a.Id) != null)
            {
                datsan.Remove(a);
                return true;
            }
            else
            {
                return false;
            }
        }



        public CDatSan timTheoThoiGian(DateTime date, double gioBDChon, double gioKTChon)
        {
            foreach (var item in datsan)
            {
                // Kiểm tra nếu thời gian bắt đầu và kết thúc của cuộc đặt sân nằm trong khoảng thời gian được chọn
                if (item.NgayBD == date && item.TGBD >= gioBDChon && item.TGKT <= gioKTChon)
                {
                    return item;
                }
            }
            return null;
        }
        public List<CDatSan> timTheoThoiGianSan(int masan, DateTime date, DateTime gioBDChon, DateTime gioKTChon)
        {
            List<CDatSan> ketQua = new List<CDatSan>();

            foreach (var item in datsan)
            {

                if (item.masan.Id == masan && item.NgayBD == date && item.TGBD == gioBDChon.Hour && item.TGKT == gioKTChon.Hour)
                {
                    ketQua.Add(item);
                }
            }
            return ketQua;
        }
    }
}