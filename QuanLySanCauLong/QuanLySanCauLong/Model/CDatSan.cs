using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace QuanLySanCauLong.Model
{
    [Serializable]
    public class CDatSan
    {
        [Required]

        public string Id { get; set; }

        public string TenKH { get; set; }
        public CSan masan { get; set; }
        public int SDT { get; set; }
        public double SoGio { get; set;}
        public string email { get; set; }
        public int SoNg { get; set; }
        public DateTime NgayBD { get; set; } = DateTime.Now.Date;
        private double _TGBD;
        private double _TGKT;
        [Range(typeof(DateTime), "5:00", "23:00", ErrorMessage = "Mở cửa 5:00 tới 23:00")]
        public double TGBD
        {
            get { return _TGBD; }
            set
            {

                if (value >= 5 && value<= 23)
                {

                    _TGBD = value;
                }

                else
                {
                    return;
                }

            }
        }
        [Range(typeof(DateTime), "5:00", "23:00", ErrorMessage = "Mở cửa 5:00 tới 23:00")]
        public double TGKT
        {
            get { return _TGKT; }
            set
            {
                if (value >= 5 && value <= 23)
                {

                    _TGKT = value;
                }
                else
                {
                    
                    return;
                }
            }
        }

        public string TongTien { get; set; }
        public CDatSan()
        {
            Id = GenerateUniqueId();
        }

        public static string GenerateUniqueId()
        {
            using (var provider = new SHA1CryptoServiceProvider())
            {
                var bytes = provider.ComputeHash(Guid.NewGuid().ToByteArray());
                return Convert.ToBase64String(bytes).Substring(0, 8); // Lấy 8 ký tự đầu tiên
            }
        }
    }

}
