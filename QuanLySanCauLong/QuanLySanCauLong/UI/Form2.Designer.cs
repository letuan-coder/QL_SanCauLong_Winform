namespace QuanLySanCauLong.UI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new Label();
            txt_id = new TextBox();
            dgv_san = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            tinhtrang = new DataGridViewTextBoxColumn();
            btn_add = new Button();
            btn_save = new Button();
            btn_xoa = new Button();
            rdo_notuse = new RadioButton();
            rdo_use = new RadioButton();
            groupBox1 = new GroupBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_san).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 34);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã Sân";
            // 
            // txt_id
            // 
            txt_id.Location = new Point(101, 35);
            txt_id.Margin = new Padding(2, 1, 2, 1);
            txt_id.Name = "txt_id";
            txt_id.Size = new Size(110, 23);
            txt_id.TabIndex = 3;
            // 
            // dgv_san
            // 
            dgv_san.AllowUserToAddRows = false;
            dgv_san.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_san.Columns.AddRange(new DataGridViewColumn[] { id, tinhtrang });
            dgv_san.Location = new Point(262, 30);
            dgv_san.Margin = new Padding(2, 1, 2, 1);
            dgv_san.Name = "dgv_san";
            dgv_san.RowHeadersWidth = 82;
            dgv_san.RowTemplate.Height = 41;
            dgv_san.Size = new Size(463, 197);
            dgv_san.TabIndex = 10;
            dgv_san.CellClick += dgv_san_CellClick;
            dgv_san.CellFormatting += dgv_san_CellFormatting;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            id.DataPropertyName = "Id";
            id.HeaderText = "Mã Sân";
            id.MinimumWidth = 10;
            id.Name = "id";
            id.ReadOnly = true;
            // 
            // tinhtrang
            // 
            tinhtrang.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tinhtrang.DataPropertyName = "tinhtrang";
            tinhtrang.HeaderText = "Tình Trạng";
            tinhtrang.MinimumWidth = 10;
            tinhtrang.Name = "tinhtrang";
            // 
            // btn_add
            // 
            btn_add.Location = new Point(18, 165);
            btn_add.Margin = new Padding(2, 1, 2, 1);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(81, 22);
            btn_add.TabIndex = 11;
            btn_add.Text = "Thêm sân";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // btn_save
            // 
            btn_save.Location = new Point(128, 165);
            btn_save.Margin = new Padding(2, 1, 2, 1);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(81, 22);
            btn_save.TabIndex = 15;
            btn_save.Text = "Lưu";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // btn_xoa
            // 
            btn_xoa.Location = new Point(18, 203);
            btn_xoa.Margin = new Padding(2, 1, 2, 1);
            btn_xoa.Name = "btn_xoa";
            btn_xoa.Size = new Size(81, 22);
            btn_xoa.TabIndex = 16;
            btn_xoa.Text = "Xóa sân";
            btn_xoa.UseVisualStyleBackColor = true;
            btn_xoa.Click += btn_xoa_Click;
            // 
            // rdo_notuse
            // 
            rdo_notuse.AutoSize = true;
            rdo_notuse.Location = new Point(13, 27);
            rdo_notuse.Margin = new Padding(2, 1, 2, 1);
            rdo_notuse.Name = "rdo_notuse";
            rdo_notuse.Size = new Size(113, 19);
            rdo_notuse.TabIndex = 17;
            rdo_notuse.Text = "Không khả dụng";
            rdo_notuse.UseVisualStyleBackColor = true;
            // 
            // rdo_use
            // 
            rdo_use.AutoSize = true;
            rdo_use.Location = new Point(13, 53);
            rdo_use.Margin = new Padding(2, 1, 2, 1);
            rdo_use.Name = "rdo_use";
            rdo_use.Size = new Size(76, 19);
            rdo_use.TabIndex = 18;
            rdo_use.Text = "Khả dụng";
            rdo_use.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdo_notuse);
            groupBox1.Controls.Add(rdo_use);
            groupBox1.Location = new Point(37, 69);
            groupBox1.Margin = new Padding(2, 1, 2, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 1, 2, 1);
            groupBox1.Size = new Size(172, 94);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tình Trạng Sân";
            // 
            // button1
            // 
            button1.Location = new Point(128, 205);
            button1.Margin = new Padding(2, 1, 2, 1);
            button1.Name = "button1";
            button1.Size = new Size(81, 22);
            button1.TabIndex = 20;
            button1.Text = "Sửa";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 312);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(btn_xoa);
            Controls.Add(btn_save);
            Controls.Add(btn_add);
            Controls.Add(dgv_san);
            Controls.Add(txt_id);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 1, 2, 1);
            Name = "Form2";
            Text = "Danh sách sân";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_san).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_id;
        private DataGridView dgv_san;
        private Button btn_add;
        private Button btn_save;
        private Button btn_xoa;
        private RadioButton rdo_notuse;
        private RadioButton rdo_use;
        private GroupBox groupBox1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn tinhtrang;
        private Button button1;
    }
}