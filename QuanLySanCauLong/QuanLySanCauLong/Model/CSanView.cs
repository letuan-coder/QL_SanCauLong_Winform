using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanCauLong.Model
{
    internal class CSanView
    {
        public int Id { get; set; }
        public string tinhtrang { get; set; }

        public static List<Model.CSanView> getDSSanViews(List<Model.CSan> x)
        {
            List<Model.CSanView> dsch = new List<Model.CSanView>();
            foreach (Model.CSan a in x)
            {
                CSanView chv=new CSanView();
                chv.Id = a.Id;
                chv.tinhtrang = a.tinhtrang.ToString() ;

                dsch.Add(chv);
            }
            return dsch;
        }
    }
}
