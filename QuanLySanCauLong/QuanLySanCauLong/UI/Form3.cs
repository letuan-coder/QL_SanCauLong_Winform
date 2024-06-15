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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatSan d = new DatSan(false);
            d.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            TruyCapDuLieu.DocFile("dssan.dat");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 dat = new Form1();
            dat.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UI.SanTrong trong = new UI.SanTrong(false);
            trong.ShowDialog();
        }

        private void btn_san_Click(object sender, EventArgs e)
        {
            UI.Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đóng cửa sổ này không?",
                "Cảnh báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Hủy sự kiện đóng Form
            }
        }

    }
}
