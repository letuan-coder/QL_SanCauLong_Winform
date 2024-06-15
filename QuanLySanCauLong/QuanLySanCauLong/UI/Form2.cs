using QuanLySanCauLong.Model;
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
    public partial class Form2 : Form
    {
        TruyCapDuLieu data = TruyCapDuLieu.khoitao();
        CXuLySan xuly = new CXuLySan();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            hienthi(xuly.getDSSans());
        }
        public void hienthi(List<Model.CSan> dsSan)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dsSan;
            dgv_san.DataSource = bs;

        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txt_id.Text, out int id))
            {
                CSan san = new CSan();
            san.Id = Int32.Parse(txt_id.Text);
            san.tinhtrang = rdo_use.Checked;
            if (xuly.them(san) == true)
            {
                reset();
                hienthi(xuly.getDSSans());
            }
            else
            {
                reset();
                MessageBox.Show(" Khong the them ");
            }
        }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin sân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void reset()
        {
            txt_id.Text = "";
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (TruyCapDuLieu.ghiFile("dssan.dat") == true)
            {

                MessageBox.Show("Lưu thành công");
            }
            else
            {
                MessageBox.Show("Không thể lưu");
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            List<CSan> datsanToDelete = new List<CSan>();

            foreach (DataGridViewRow r in dgv_san.SelectedRows)
            {
                int msch = Convert.ToInt32(r.Cells[0].Value.ToString());
                CSan datSan = xuly.tim(msch);
                if (datSan != null)
                {
                    datsanToDelete.Add(datSan);
                }
            }
            foreach (var datSanToDelete in datsanToDelete)
            {
                xuly.xoa(datSanToDelete);
            }

            hienthi(xuly.getDSSans());

        }
        private void dgv_san_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_san.Rows[e.RowIndex];
                txt_id.Text = row.Cells["ID"].Value.ToString();
                string gen = this.dgv_san.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (gen.Trim() == "True")
                {
                    rdo_use.Checked = true;
                }
                else
                {
                    rdo_notuse.Checked = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem txt_id.Text có phải là một số hợp lệ hay không
            if (int.TryParse(txt_id.Text, out int id))
            {
                CSan san = new CSan();
                san.Id = id;
                san.tinhtrang = rdo_use.Checked;

                if (xuly.sua(san) == true)
                {
                    reset();
                    hienthi(xuly.getDSSans());
                }
                else
                {
                    reset();
                    MessageBox.Show("Không thể thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tình trạng sân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgv_san_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value != null)
            {
                if ((bool)e.Value)
                {
                    e.Value = "Khả dụng";
                }
                else
                {
                    e.Value = "Không Khả dụng";
                }
                e.FormattingApplied = true; // Đặt cờ để thông báo rằng đã xử lý định dạng
            }
        }
    }
}
