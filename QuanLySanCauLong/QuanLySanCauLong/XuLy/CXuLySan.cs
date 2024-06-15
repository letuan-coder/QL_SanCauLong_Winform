using QuanLySanCauLong.Model;
using QuanLySanCauLong.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanCauLong.XuLy
{
    
    public class CXuLySan
    {
        private TruyCapDuLieu data = TruyCapDuLieu.khoitao();
        private List<CSan> sans;
        
        public CXuLySan()
        {
            sans = data.getSan();
        }
        public List<CSan> getDSSans()
        {
            return sans.ToList();
        }
        public CSan tim(int masan)
        {
            foreach (var item in sans)
            {
                if (item.Id==masan)
                    return item;
            }
            return null;
        }

        public bool them(CSan a)
        {
            if (tim(a.Id) == null)
            {
                sans.Add(a);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool KTTrangSan(int Masan)
        {
            foreach (CSan san in sans)
            {
                if (san.Id == Masan && san.tinhtrang == false)
                {
                    return false;
                }
            }
            return true;
        }
        public bool sua(CSan a)
        {
            CSan result = tim(a.Id);
            if (result ==null)
            {
                
                return false;
            }
            else
            {
                result.Id= a.Id;
                result.tinhtrang=a.tinhtrang;
                return true;
            }
        }
        public bool xoa(CSan a)
        {
            if (tim(a.Id) != null)
            {
                sans.Remove(a);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
