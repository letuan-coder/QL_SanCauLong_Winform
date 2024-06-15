namespace QuanLySanCauLong
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            timer = new Label();
            DATE = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            buttonfan = new Button();
            btn_san4 = new Button();
            btn_san3 = new Button();
            btn_san2 = new Button();
            btn_san1 = new Button();
            label1 = new Label();
            sButton1 = new SButton();
            dgv_datsan = new Sunny.UI.UIDataGridView();
            id = new DataGridViewTextBoxColumn();
            ID_San = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            Number = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            People = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            TGBD = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            hour = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            timer2 = new System.Windows.Forms.Timer(components);
            pics1sang = new Button();
            pics1toi = new Button();
            pics4toi = new Button();
            pics2toi = new Button();
            pics3toi = new Button();
            pics2sang = new Button();
            pics3sang = new Button();
            pics4sang = new Button();
            muc0png = new PictureBox();
            muc1png = new PictureBox();
            muc2png = new PictureBox();
            muc3png = new PictureBox();
            autopng = new PictureBox();
            uiLedDisplay1 = new Sunny.UI.UILedDisplay();
            ((System.ComponentModel.ISupportInitialize)dgv_datsan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)muc0png).BeginInit();
            ((System.ComponentModel.ISupportInitialize)muc1png).BeginInit();
            ((System.ComponentModel.ISupportInitialize)muc2png).BeginInit();
            ((System.ComponentModel.ISupportInitialize)muc3png).BeginInit();
            ((System.ComponentModel.ISupportInitialize)autopng).BeginInit();
            SuspendLayout();
            // 
            // timer
            // 
            timer.AutoSize = true;
            timer.BackColor = Color.Transparent;
            timer.Font = new Font("Times New Roman", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            timer.Location = new Point(626, 137);
            timer.Margin = new Padding(4, 0, 4, 0);
            timer.Name = "timer";
            timer.Size = new Size(65, 33);
            timer.TabIndex = 0;
            timer.Text = "8:00";
            // 
            // DATE
            // 
            DATE.AutoSize = true;
            DATE.BackColor = Color.Transparent;
            DATE.Font = new Font("Times New Roman", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            DATE.Location = new Point(643, 81);
            DATE.Margin = new Padding(4, 0, 4, 0);
            DATE.Name = "DATE";
            DATE.Size = new Size(209, 33);
            DATE.TabIndex = 1;
            DATE.Text = "DD/MM/YYYY";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // buttonfan
            // 
            buttonfan.BackColor = Color.Teal;
            buttonfan.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            buttonfan.ForeColor = SystemColors.ButtonHighlight;
            buttonfan.Location = new Point(1748, 211);
            buttonfan.Margin = new Padding(4, 2, 4, 2);
            buttonfan.Name = "buttonfan";
            buttonfan.Size = new Size(150, 111);
            buttonfan.TabIndex = 20;
            buttonfan.Text = "Manual";
            buttonfan.UseVisualStyleBackColor = false;
            buttonfan.Click += button3_Click;
            // 
            // btn_san4
            // 
            btn_san4.BackColor = Color.CornflowerBlue;
            btn_san4.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            btn_san4.ForeColor = SystemColors.ButtonHighlight;
            btn_san4.Location = new Point(1515, 642);
            btn_san4.Margin = new Padding(4, 2, 4, 2);
            btn_san4.Name = "btn_san4";
            btn_san4.Size = new Size(150, 55);
            btn_san4.TabIndex = 35;
            btn_san4.Text = "Đã Bật";
            btn_san4.UseVisualStyleBackColor = false;
            btn_san4.Click += btn_san4_Click;
            // 
            // btn_san3
            // 
            btn_san3.BackColor = Color.CornflowerBlue;
            btn_san3.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            btn_san3.ForeColor = SystemColors.ButtonHighlight;
            btn_san3.Location = new Point(1515, 211);
            btn_san3.Margin = new Padding(4, 2, 4, 2);
            btn_san3.Name = "btn_san3";
            btn_san3.Size = new Size(150, 55);
            btn_san3.TabIndex = 34;
            btn_san3.Text = "Đã Bật";
            btn_san3.UseVisualStyleBackColor = false;
            btn_san3.Click += btn_san3_Click;
            // 
            // btn_san2
            // 
            btn_san2.BackColor = Color.CornflowerBlue;
            btn_san2.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            btn_san2.ForeColor = SystemColors.ButtonHighlight;
            btn_san2.Location = new Point(700, 640);
            btn_san2.Margin = new Padding(4, 2, 4, 2);
            btn_san2.Name = "btn_san2";
            btn_san2.Size = new Size(150, 55);
            btn_san2.TabIndex = 33;
            btn_san2.Text = "Đã Bật";
            btn_san2.UseVisualStyleBackColor = false;
            btn_san2.Click += btn_san2_Click;
            // 
            // btn_san1
            // 
            btn_san1.BackColor = Color.CornflowerBlue;
            btn_san1.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
            btn_san1.ForeColor = SystemColors.ButtonHighlight;
            btn_san1.Location = new Point(700, 211);
            btn_san1.Margin = new Padding(4, 2, 4, 2);
            btn_san1.Name = "btn_san1";
            btn_san1.Size = new Size(150, 55);
            btn_san1.TabIndex = 32;
            btn_san1.Text = "Đã bật";
            btn_san1.UseVisualStyleBackColor = false;
            btn_san1.Click += btn_san1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(475, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(481, 50);
            label1.TabIndex = 36;
            label1.Text = "QUẢN LÝ SÂN CẦU LÔNG";
            // 
            // sButton1
            // 
            sButton1.BackColor = Color.Transparent;
            sButton1.Location = new Point(1978, 209);
            sButton1.Margin = new Padding(4, 2, 4, 2);
            sButton1.MinimumSize = new Size(45, 21);
            sButton1.Name = "sButton1";
            sButton1.OffBackColor = Color.Gray;
            sButton1.OffToggleColor = Color.Gainsboro;
            sButton1.OnBackColor = Color.MediumSlateBlue;
            sButton1.OnToggleColor = Color.WhiteSmoke;
            sButton1.Size = new Size(110, 49);
            sButton1.TabIndex = 39;
            sButton1.UseVisualStyleBackColor = false;
            sButton1.CheckedChanged += sButton1_CheckedChanged;
            // 
            // dgv_datsan
            // 
            dgv_datsan.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgv_datsan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_datsan.BackgroundColor = Color.White;
            dgv_datsan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_datsan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_datsan.ColumnHeadersHeight = 32;
            dgv_datsan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_datsan.Columns.AddRange(new DataGridViewColumn[] { id, ID_San, name, Number, email, People, dataGridViewTextBoxColumn1, TGBD, Column1, hour, Column2 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv_datsan.DefaultCellStyle = dataGridViewCellStyle3;
            dgv_datsan.Dock = DockStyle.Bottom;
            dgv_datsan.EnableHeadersVisualStyles = false;
            dgv_datsan.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_datsan.GridColor = Color.FromArgb(80, 160, 255);
            dgv_datsan.Location = new Point(0, 1066);
            dgv_datsan.Margin = new Padding(4, 2, 4, 2);
            dgv_datsan.Name = "dgv_datsan";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgv_datsan.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgv_datsan.RowHeadersWidth = 82;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dgv_datsan.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgv_datsan.RowTemplate.Height = 41;
            dgv_datsan.SelectedIndex = -1;
            dgv_datsan.Size = new Size(2564, 493);
            dgv_datsan.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgv_datsan.TabIndex = 40;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            id.DataPropertyName = "ID";
            id.HeaderText = "Mã Đặt";
            id.MinimumWidth = 10;
            id.Name = "id";
            id.Width = 164;
            // 
            // ID_San
            // 
            ID_San.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ID_San.DataPropertyName = "masan";
            ID_San.FillWeight = 78.74015F;
            ID_San.HeaderText = "Mã Sân";
            ID_San.MinimumWidth = 10;
            ID_San.Name = "ID_San";
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name.DataPropertyName = "TenKH";
            name.FillWeight = 150F;
            name.HeaderText = "Tên Khách Hàng";
            name.MinimumWidth = 10;
            name.Name = "name";
            // 
            // Number
            // 
            Number.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Number.DataPropertyName = "SDT";
            Number.FillWeight = 78.74015F;
            Number.HeaderText = "Số Điện Thoại";
            Number.MinimumWidth = 10;
            Number.Name = "Number";
            // 
            // email
            // 
            email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            email.DataPropertyName = "email";
            email.FillWeight = 78.74015F;
            email.HeaderText = "Email";
            email.MinimumWidth = 10;
            email.Name = "email";
            // 
            // People
            // 
            People.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            People.DataPropertyName = "SoNg";
            People.FillWeight = 78.74015F;
            People.HeaderText = "Số Người";
            People.MinimumWidth = 10;
            People.Name = "People";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.DataPropertyName = "NgayBD";
            dataGridViewTextBoxColumn1.FillWeight = 78.74015F;
            dataGridViewTextBoxColumn1.HeaderText = "Ngày Vào";
            dataGridViewTextBoxColumn1.MinimumWidth = 10;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // TGBD
            // 
            TGBD.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TGBD.DataPropertyName = "TGBD";
            TGBD.FillWeight = 78.74015F;
            TGBD.HeaderText = "Giờ Vào";
            TGBD.MinimumWidth = 10;
            TGBD.Name = "TGBD";
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.DataPropertyName = "TGKT";
            Column1.FillWeight = 78.74015F;
            Column1.HeaderText = "Giờ Ra";
            Column1.MinimumWidth = 10;
            Column1.Name = "Column1";
            // 
            // hour
            // 
            hour.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            hour.DataPropertyName = "SoGio";
            hour.FillWeight = 78.74015F;
            hour.HeaderText = "Số Giờ";
            hour.MinimumWidth = 10;
            hour.Name = "hour";
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.DataPropertyName = "TongTien";
            Column2.FillWeight = 78.74015F;
            Column2.HeaderText = "Tổng Tiền";
            Column2.MinimumWidth = 10;
            Column2.Name = "Column2";
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // pics1sang
            // 
            pics1sang.BackgroundImage = Properties.Resources.c1ume787;
            pics1sang.Location = new Point(104, 209);
            pics1sang.Margin = new Padding(4, 2, 4, 2);
            pics1sang.Name = "pics1sang";
            pics1sang.Size = new Size(589, 324);
            pics1sang.TabIndex = 41;
            pics1sang.Text = "SÂN 1";
            pics1sang.UseVisualStyleBackColor = true;
            // 
            // pics1toi
            // 
            pics1toi.Image = (Image)resources.GetObject("pics1toi.Image");
            pics1toi.Location = new Point(102, 209);
            pics1toi.Margin = new Padding(4, 2, 4, 2);
            pics1toi.Name = "pics1toi";
            pics1toi.Size = new Size(589, 324);
            pics1toi.TabIndex = 42;
            pics1toi.Text = "SÂN 1";
            pics1toi.UseVisualStyleBackColor = true;
            // 
            // pics4toi
            // 
            pics4toi.Image = Properties.Resources.toi;
            pics4toi.Location = new Point(906, 642);
            pics4toi.Margin = new Padding(4, 2, 4, 2);
            pics4toi.Name = "pics4toi";
            pics4toi.Size = new Size(589, 324);
            pics4toi.TabIndex = 43;
            pics4toi.Text = "SÂN 4";
            pics4toi.UseVisualStyleBackColor = true;
            // 
            // pics2toi
            // 
            pics2toi.Image = Properties.Resources.toi;
            pics2toi.Location = new Point(95, 640);
            pics2toi.Margin = new Padding(4, 2, 4, 2);
            pics2toi.Name = "pics2toi";
            pics2toi.Size = new Size(589, 324);
            pics2toi.TabIndex = 44;
            pics2toi.Text = "SÂN 2";
            pics2toi.UseVisualStyleBackColor = true;
            // 
            // pics3toi
            // 
            pics3toi.Image = Properties.Resources.toi;
            pics3toi.Location = new Point(906, 211);
            pics3toi.Margin = new Padding(4, 2, 4, 2);
            pics3toi.Name = "pics3toi";
            pics3toi.Size = new Size(589, 324);
            pics3toi.TabIndex = 45;
            pics3toi.Text = "SÂN 3";
            pics3toi.UseVisualStyleBackColor = true;
            // 
            // pics2sang
            // 
            pics2sang.BackgroundImage = Properties.Resources.c1ume787;
            pics2sang.Location = new Point(95, 640);
            pics2sang.Margin = new Padding(4, 2, 4, 2);
            pics2sang.Name = "pics2sang";
            pics2sang.Size = new Size(589, 324);
            pics2sang.TabIndex = 46;
            pics2sang.Text = "SÂN 2";
            pics2sang.UseVisualStyleBackColor = true;
            // 
            // pics3sang
            // 
            pics3sang.BackgroundImage = Properties.Resources.c1ume787;
            pics3sang.Location = new Point(908, 211);
            pics3sang.Margin = new Padding(4, 2, 4, 2);
            pics3sang.Name = "pics3sang";
            pics3sang.Size = new Size(589, 324);
            pics3sang.TabIndex = 47;
            pics3sang.Text = "SÂN 3";
            pics3sang.UseVisualStyleBackColor = true;
            // 
            // pics4sang
            // 
            pics4sang.BackgroundImage = Properties.Resources.c1ume787;
            pics4sang.Location = new Point(906, 640);
            pics4sang.Margin = new Padding(4, 2, 4, 2);
            pics4sang.Name = "pics4sang";
            pics4sang.Size = new Size(589, 324);
            pics4sang.TabIndex = 48;
            pics4sang.Text = "SÂN 4";
            pics4sang.UseVisualStyleBackColor = true;
            // 
            // muc0png
            // 
            muc0png.BackColor = Color.Transparent;
            muc0png.Image = (Image)resources.GetObject("muc0png.Image");
            muc0png.Location = new Point(1931, 271);
            muc0png.Margin = new Padding(4, 2, 4, 2);
            muc0png.Name = "muc0png";
            muc0png.Size = new Size(184, 194);
            muc0png.TabIndex = 49;
            muc0png.TabStop = false;
            // 
            // muc1png
            // 
            muc1png.BackColor = Color.Transparent;
            muc1png.Image = (Image)resources.GetObject("muc1png.Image");
            muc1png.Location = new Point(1931, 271);
            muc1png.Margin = new Padding(4, 2, 4, 2);
            muc1png.Name = "muc1png";
            muc1png.Size = new Size(184, 194);
            muc1png.TabIndex = 50;
            muc1png.TabStop = false;
            // 
            // muc2png
            // 
            muc2png.BackColor = Color.Transparent;
            muc2png.Image = (Image)resources.GetObject("muc2png.Image");
            muc2png.Location = new Point(1931, 271);
            muc2png.Margin = new Padding(4, 2, 4, 2);
            muc2png.Name = "muc2png";
            muc2png.Size = new Size(184, 194);
            muc2png.TabIndex = 51;
            muc2png.TabStop = false;
            // 
            // muc3png
            // 
            muc3png.BackColor = Color.Transparent;
            muc3png.Image = (Image)resources.GetObject("muc3png.Image");
            muc3png.Location = new Point(1931, 271);
            muc3png.Margin = new Padding(4, 2, 4, 2);
            muc3png.Name = "muc3png";
            muc3png.Size = new Size(184, 194);
            muc3png.TabIndex = 52;
            muc3png.TabStop = false;
            // 
            // autopng
            // 
            autopng.BackColor = Color.Transparent;
            autopng.Image = (Image)resources.GetObject("autopng.Image");
            autopng.Location = new Point(1931, 271);
            autopng.Margin = new Padding(4, 2, 4, 2);
            autopng.Name = "autopng";
            autopng.Size = new Size(184, 194);
            autopng.TabIndex = 53;
            autopng.TabStop = false;
            // 
            // uiLedDisplay1
            // 
            uiLedDisplay1.BackColor = Color.Black;
            uiLedDisplay1.ForeColor = Color.Lime;
            uiLedDisplay1.Location = new Point(1748, 81);
            uiLedDisplay1.Margin = new Padding(6, 6, 6, 6);
            uiLedDisplay1.Name = "uiLedDisplay1";
            uiLedDisplay1.Size = new Size(353, 73);
            uiLedDisplay1.TabIndex = 54;
            uiLedDisplay1.Text = "Nhietdo";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(2564, 1559);
            Controls.Add(uiLedDisplay1);
            Controls.Add(muc0png);
            Controls.Add(pics4sang);
            Controls.Add(pics3sang);
            Controls.Add(pics2sang);
            Controls.Add(pics3toi);
            Controls.Add(pics2toi);
            Controls.Add(pics4toi);
            Controls.Add(pics1sang);
            Controls.Add(dgv_datsan);
            Controls.Add(sButton1);
            Controls.Add(label1);
            Controls.Add(btn_san4);
            Controls.Add(btn_san3);
            Controls.Add(btn_san2);
            Controls.Add(btn_san1);
            Controls.Add(buttonfan);
            Controls.Add(DATE);
            Controls.Add(timer);
            Controls.Add(pics1toi);
            Controls.Add(autopng);
            Controls.Add(muc3png);
            Controls.Add(muc2png);
            Controls.Add(muc1png);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 2, 4, 2);
            Name = "Form1";
            Text = "Home";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_datsan).EndInit();
            ((System.ComponentModel.ISupportInitialize)muc0png).EndInit();
            ((System.ComponentModel.ISupportInitialize)muc1png).EndInit();
            ((System.ComponentModel.ISupportInitialize)muc2png).EndInit();
            ((System.ComponentModel.ISupportInitialize)muc3png).EndInit();
            ((System.ComponentModel.ISupportInitialize)autopng).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label timer;
        private Label DATE;
        private System.Windows.Forms.Timer timer1;
        private Button buttonfan;
        private Button btn_san4;
        private Button btn_san3;
        private Button btn_san2;
        private Button btn_san1;
        private Label label1;
        private SButton sButton1;
        private Sunny.UI.UIDataGridView dgv_datsan;
        private System.Windows.Forms.Timer timer2;
        private Button pics1sang;
        private Button pics1toi;
        private Button pics4toi;
        private Button pics2toi;
        private Button pics3toi;
        private Button pics2sang;
        private Button pics3sang;
        private Button pics4sang;
        private PictureBox muc0png;
        private PictureBox muc1png;
        private PictureBox muc2png;
        private PictureBox muc3png;
        private PictureBox autopng;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn ID_San;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn People;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn TGBD;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn hour;
        private DataGridViewTextBoxColumn Column2;
        private Sunny.UI.UILedDisplay uiLedDisplay1;
    }
}
