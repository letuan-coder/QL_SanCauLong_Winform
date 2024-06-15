using QuanLySanCauLong.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanCauLong
{
    [Serializable]
    public class TruyCapDuLieu
    {
        private static TruyCapDuLieu data = null;
        private List<CSan> m_san;
        private List<CDatSan> m_book;

        private TruyCapDuLieu()
        {
            m_san = new List<CSan>();
            m_book = new List<CDatSan>();

        }
        public static TruyCapDuLieu khoitao()
        {
            if (data == null)
                data = new TruyCapDuLieu();
            return data;
        }
        public List<CSan> getSan()
        {
            return m_san;
        }
        public List<CDatSan> GetBook()
        {
            return m_book;
        }

        public static bool ghiFile(string tenfile)
        {
            try
            {
                FileStream f = new FileStream(tenfile, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(f, data);
                f.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool DocFile(string tenfile)
        {
            try
            {
                FileStream f = new FileStream(tenfile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                data = (TruyCapDuLieu)bf.Deserialize(f);
                f.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
