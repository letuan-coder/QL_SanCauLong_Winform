namespace QuanLySanCauLong.UI
{
    partial class DatSan
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatSan));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            txb_id = new TextBox();
            txb_people = new TextBox();
            cb_idsan = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            txb_name = new TextBox();
            txb_phonenumber = new TextBox();
            groupBox1 = new GroupBox();
            dtp_checkout = new DateTimePicker();
            dtp_checkin = new DateTimePicker();
            label9 = new Label();
            label8 = new Label();
            dtp_date = new DateTimePicker();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btn_reset = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            btn_add = new Sunny.UI.UISymbolButton();
            uiScrollBar1 = new Sunny.UI.UIScrollBar();
            btn_delete = new Sunny.UI.UISymbolButton();
            btn_edit = new Sunny.UI.UISymbolButton();
            uiSymbolButton4 = new Sunny.UI.UISymbolButton();
            btn_search = new Sunny.UI.UISymbolButton();
            dgv_datsan = new Sunny.UI.UIDataGridView();
            id = new DataGridViewTextBoxColumn();
            ID_San = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            Number = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            People = new DataGridViewTextBoxColumn();
            date = new DataGridViewTextBoxColumn();
            TGBD = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            hour = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            roundedButton1 = new RoundedButton();
            txb_total = new TextBox();
            uiLabel1 = new Sunny.UI.UILabel();
            txb_email = new TextBox();
            txb_sogio = new TextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            uiLabel5 = new Sunny.UI.UILabel();
            uiLabel6 = new Sunny.UI.UILabel();
            btn_san1 = new Button();
            btn_San4 = new Button();
            btn_san3 = new Button();
            btn_San2 = new Button();
            button1 = new Button();
            Export_Excel = new RoundedButton();
            roundedButton2 = new RoundedButton();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_datsan).BeginInit();
            SuspendLayout();
            // 
            // txb_id
            // 
            txb_id.Enabled = false;
            txb_id.Location = new Point(232, 49);
            txb_id.Margin = new Padding(4, 2, 4, 2);
            txb_id.Name = "txb_id";
            txb_id.Size = new Size(201, 39);
            txb_id.TabIndex = 4;
            // 
            // txb_people
            // 
            txb_people.Location = new Point(232, 386);
            txb_people.Margin = new Padding(4, 2, 4, 2);
            txb_people.Name = "txb_people";
            txb_people.Size = new Size(201, 39);
            txb_people.TabIndex = 7;
            // 
            // cb_idsan
            // 
            cb_idsan.FormattingEnabled = true;
            cb_idsan.Location = new Point(232, 117);
            cb_idsan.Margin = new Padding(4, 2, 4, 2);
            cb_idsan.Name = "cb_idsan";
            cb_idsan.Size = new Size(201, 40);
            cb_idsan.TabIndex = 8;
            cb_idsan.SelectedIndexChanged += cb_idsan_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(95, 290);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(0, 32);
            label5.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(550, 51);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(0, 32);
            label6.TabIndex = 11;
            // 
            // txb_name
            // 
            txb_name.Location = new Point(232, 179);
            txb_name.Margin = new Padding(4, 2, 4, 2);
            txb_name.Name = "txb_name";
            txb_name.Size = new Size(201, 39);
            txb_name.TabIndex = 16;
            // 
            // txb_phonenumber
            // 
            txb_phonenumber.Location = new Point(232, 245);
            txb_phonenumber.Margin = new Padding(4, 2, 4, 2);
            txb_phonenumber.Name = "txb_phonenumber";
            txb_phonenumber.Size = new Size(201, 39);
            txb_phonenumber.TabIndex = 17;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtp_checkout);
            groupBox1.Controls.Add(dtp_checkin);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(dtp_date);
            groupBox1.Location = new Point(548, 41);
            groupBox1.Margin = new Padding(4, 2, 4, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 2, 4, 2);
            groupBox1.Size = new Size(457, 188);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chọn Ngày ";
            // 
            // dtp_checkout
            // 
            dtp_checkout.Format = DateTimePickerFormat.Time;
            dtp_checkout.Location = new Point(256, 137);
            dtp_checkout.Margin = new Padding(4, 2, 4, 2);
            dtp_checkout.Name = "dtp_checkout";
            dtp_checkout.Size = new Size(173, 39);
            dtp_checkout.TabIndex = 50;
            dtp_checkout.Value = new DateTime(2024, 5, 6, 8, 0, 0, 0);
            // 
            // dtp_checkin
            // 
            dtp_checkin.Format = DateTimePickerFormat.Time;
            dtp_checkin.Location = new Point(19, 137);
            dtp_checkin.Margin = new Padding(4, 2, 4, 2);
            dtp_checkin.Name = "dtp_checkin";
            dtp_checkin.Size = new Size(193, 39);
            dtp_checkin.TabIndex = 50;
            dtp_checkin.Value = new DateTime(2024, 5, 6, 7, 0, 0, 0);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(256, 100);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(147, 32);
            label9.TabIndex = 16;
            label9.Text = "Chọn Giờ Ra";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(19, 100);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(160, 32);
            label8.TabIndex = 13;
            label8.Text = "Chọn Giờ Vào";
            // 
            // dtp_date
            // 
            dtp_date.Location = new Point(6, 51);
            dtp_date.Margin = new Padding(4, 2, 4, 2);
            dtp_date.Name = "dtp_date";
            dtp_date.Size = new Size(431, 39);
            dtp_date.TabIndex = 10;
            // 
            // btn_reset
            // 
            btn_reset.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_reset.Location = new Point(1025, 350);
            btn_reset.Margin = new Padding(4, 2, 4, 2);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(201, 68);
            btn_reset.TabIndex = 25;
            btn_reset.Text = "Reset";
            btn_reset.UseVisualStyleBackColor = true;
            btn_reset.Click += btn_reset_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // btn_add
            // 
            btn_add.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_add.Location = new Point(550, 245);
            btn_add.Margin = new Padding(4, 2, 4, 2);
            btn_add.MinimumSize = new Size(2, 0);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(215, 68);
            btn_add.TabIndex = 28;
            btn_add.Text = "ĐẶT SÂN";
            btn_add.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_add.Click += uiSymbolButton1_Click;
            // 
            // uiScrollBar1
            // 
            uiScrollBar1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiScrollBar1.Location = new Point(1272, 284);
            uiScrollBar1.Margin = new Padding(4, 2, 4, 2);
            uiScrollBar1.MinimumSize = new Size(2, 0);
            uiScrollBar1.Name = "uiScrollBar1";
            uiScrollBar1.Size = new Size(7, 9);
            uiScrollBar1.TabIndex = 29;
            uiScrollBar1.Text = "uiScrollBar1";
            // 
            // btn_delete
            // 
            btn_delete.FillColor = Color.FromArgb(230, 80, 80);
            btn_delete.FillColor2 = Color.FromArgb(230, 80, 80);
            btn_delete.FillHoverColor = Color.FromArgb(230, 80, 80);
            btn_delete.FillPressColor = Color.FromArgb(230, 80, 80);
            btn_delete.FillSelectedColor = Color.FromArgb(230, 80, 80);
            btn_delete.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_delete.Image = (Image)resources.GetObject("btn_delete.Image");
            btn_delete.Location = new Point(787, 243);
            btn_delete.Margin = new Padding(4, 2, 4, 2);
            btn_delete.MinimumSize = new Size(2, 0);
            btn_delete.Name = "btn_delete";
            btn_delete.RectColor = Color.FromArgb(230, 80, 80);
            btn_delete.RectHoverColor = Color.FromArgb(230, 80, 80);
            btn_delete.RectPressColor = Color.FromArgb(230, 80, 80);
            btn_delete.RectSelectedColor = Color.FromArgb(230, 80, 80);
            btn_delete.Size = new Size(219, 70);
            btn_delete.TabIndex = 30;
            btn_delete.Text = "HỦY ĐẠT";
            btn_delete.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_delete.Click += uiSymbolButton2_Click;
            // 
            // btn_edit
            // 
            btn_edit.FillColor = Color.FromArgb(110, 190, 40);
            btn_edit.FillColor2 = Color.FromArgb(110, 190, 40);
            btn_edit.FillHoverColor = Color.FromArgb(139, 203, 83);
            btn_edit.FillPressColor = Color.FromArgb(88, 152, 32);
            btn_edit.FillSelectedColor = Color.FromArgb(88, 152, 32);
            btn_edit.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_edit.Image = (Image)resources.GetObject("btn_edit.Image");
            btn_edit.Location = new Point(548, 350);
            btn_edit.Margin = new Padding(4, 2, 4, 2);
            btn_edit.MinimumSize = new Size(2, 0);
            btn_edit.Name = "btn_edit";
            btn_edit.RectColor = Color.FromArgb(110, 190, 40);
            btn_edit.RectHoverColor = Color.FromArgb(139, 203, 83);
            btn_edit.RectPressColor = Color.FromArgb(88, 152, 32);
            btn_edit.RectSelectedColor = Color.FromArgb(88, 152, 32);
            btn_edit.Size = new Size(217, 70);
            btn_edit.TabIndex = 31;
            btn_edit.Text = "SỬA ";
            btn_edit.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_edit.Click += uiSymbolButton3_Click;
            // 
            // uiSymbolButton4
            // 
            uiSymbolButton4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiSymbolButton4.Image = (Image)resources.GetObject("uiSymbolButton4.Image");
            uiSymbolButton4.Location = new Point(787, 350);
            uiSymbolButton4.Margin = new Padding(4, 2, 4, 2);
            uiSymbolButton4.MinimumSize = new Size(2, 0);
            uiSymbolButton4.Name = "uiSymbolButton4";
            uiSymbolButton4.Size = new Size(219, 70);
            uiSymbolButton4.TabIndex = 32;
            uiSymbolButton4.Text = "LƯU";
            uiSymbolButton4.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            uiSymbolButton4.Click += uiSymbolButton4_Click;
            // 
            // btn_search
            // 
            btn_search.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btn_search.Image = (Image)resources.GetObject("btn_search.Image");
            btn_search.Location = new Point(1025, 245);
            btn_search.Margin = new Padding(4, 2, 4, 2);
            btn_search.MinimumSize = new Size(2, 0);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(201, 70);
            btn_search.TabIndex = 33;
            btn_search.Text = "TÌM";
            btn_search.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_search.Click += uiSymbolButton5_Click;
            // 
            // dgv_datsan
            // 
            dgv_datsan.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgv_datsan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_datsan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            dgv_datsan.Columns.AddRange(new DataGridViewColumn[] { id, ID_San, name, Number, email, People, date, TGBD, Column1, hour, Column2 });
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
            dgv_datsan.Location = new Point(0, 572);
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
            dgv_datsan.Size = new Size(2564, 488);
            dgv_datsan.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgv_datsan.TabIndex = 34;
            dgv_datsan.CellClick += dgv_datsan_CellClick;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            id.DataPropertyName = "ID";
            id.FillWeight = 50F;
            id.HeaderText = "Mã Đặt";
            id.MinimumWidth = 10;
            id.Name = "id";
            id.Width = 164;
            // 
            // ID_San
            // 
            ID_San.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ID_San.DataPropertyName = "masan";
            ID_San.HeaderText = "Mã Sân";
            ID_San.MinimumWidth = 10;
            ID_San.Name = "ID_San";
            ID_San.ReadOnly = true;
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name.DataPropertyName = "TenKH";
            name.HeaderText = "Tên Khách Hàng";
            name.MinimumWidth = 10;
            name.Name = "name";
            // 
            // Number
            // 
            Number.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Number.DataPropertyName = "SDT";
            Number.HeaderText = "Số Điện Thoại";
            Number.MinimumWidth = 10;
            Number.Name = "Number";
            // 
            // email
            // 
            email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            email.DataPropertyName = "email";
            email.HeaderText = "Email";
            email.MinimumWidth = 10;
            email.Name = "email";
            // 
            // People
            // 
            People.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            People.DataPropertyName = "SoNg";
            People.HeaderText = "Số Người";
            People.MinimumWidth = 10;
            People.Name = "People";
            // 
            // date
            // 
            date.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            date.DataPropertyName = "NgayBD";
            date.HeaderText = "Ngày Vào";
            date.MinimumWidth = 10;
            date.Name = "date";
            // 
            // TGBD
            // 
            TGBD.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TGBD.DataPropertyName = "TGBD";
            TGBD.HeaderText = "Giờ Vào";
            TGBD.MinimumWidth = 10;
            TGBD.Name = "TGBD";
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.DataPropertyName = "TGKT";
            Column1.HeaderText = "Giờ Ra";
            Column1.MinimumWidth = 10;
            Column1.Name = "Column1";
            // 
            // hour
            // 
            hour.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            hour.DataPropertyName = "SoGio";
            hour.HeaderText = "Số Giờ";
            hour.MinimumWidth = 10;
            hour.Name = "hour";
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.DataPropertyName = "TongTien";
            Column2.HeaderText = "Tổng Tiền";
            Column2.MinimumWidth = 10;
            Column2.Name = "Column2";
            // 
            // roundedButton1
            // 
            roundedButton1.BackColor = Color.OrangeRed;
            roundedButton1.FlatAppearance.BorderColor = Color.Black;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            roundedButton1.Location = new Point(945, 442);
            roundedButton1.Margin = new Padding(4, 2, 4, 2);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(280, 90);
            roundedButton1.TabIndex = 36;
            roundedButton1.Text = "XUẤT HÓA ĐƠN GỬI EMAIL";
            roundedButton1.UseVisualStyleBackColor = false;
            roundedButton1.Click += roundedButton1_Click;
            // 
            // txb_total
            // 
            txb_total.Location = new Point(815, 670);
            txb_total.Margin = new Padding(4, 2, 4, 2);
            txb_total.Name = "txb_total";
            txb_total.Size = new Size(201, 39);
            txb_total.TabIndex = 37;
            txb_total.Visible = false;
            // 
            // uiLabel1
            // 
            uiLabel1.BackColor = SystemColors.ButtonHighlight;
            uiLabel1.Font = new Font("Microsoft Sans Serif", 7.875F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(97, 322);
            uiLabel1.Margin = new Padding(4, 0, 4, 0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(72, 47);
            uiLabel1.TabIndex = 38;
            uiLabel1.Text = "Email";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txb_email
            // 
            txb_email.Location = new Point(232, 322);
            txb_email.Margin = new Padding(4, 2, 4, 2);
            txb_email.Name = "txb_email";
            txb_email.Size = new Size(201, 39);
            txb_email.TabIndex = 39;
            // 
            // txb_sogio
            // 
            txb_sogio.Location = new Point(576, 670);
            txb_sogio.Margin = new Padding(4, 2, 4, 2);
            txb_sogio.Name = "txb_sogio";
            txb_sogio.Size = new Size(201, 39);
            txb_sogio.TabIndex = 40;
            txb_sogio.Visible = false;
            txb_sogio.TextChanged += txb_sogio_TextChanged;
            // 
            // uiLabel2
            // 
            uiLabel2.BackColor = SystemColors.ButtonHighlight;
            uiLabel2.Font = new Font("Microsoft Sans Serif", 7.875F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(95, 47);
            uiLabel2.Margin = new Padding(4, 0, 4, 0);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(93, 47);
            uiLabel2.TabIndex = 41;
            uiLabel2.Text = "Mã Đặt";
            uiLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            uiLabel3.BackColor = SystemColors.ButtonHighlight;
            uiLabel3.Font = new Font("Microsoft Sans Serif", 7.875F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(85, 115);
            uiLabel3.Margin = new Padding(4, 0, 4, 0);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(106, 47);
            uiLabel3.TabIndex = 42;
            uiLabel3.Text = "Mã Sân";
            uiLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            uiLabel4.BackColor = Color.Transparent;
            uiLabel4.Font = new Font("Microsoft Sans Serif", 7.875F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(24, 177);
            uiLabel4.Margin = new Padding(4, 0, 4, 0);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(180, 55);
            uiLabel4.TabIndex = 43;
            uiLabel4.Text = "Tên Khách Hàng";
            uiLabel4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            uiLabel5.Font = new Font("Microsoft Sans Serif", 7.875F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(100, 256);
            uiLabel5.Margin = new Padding(4, 0, 4, 0);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(67, 47);
            uiLabel5.TabIndex = 44;
            uiLabel5.Text = "SĐT";
            uiLabel5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            uiLabel6.Font = new Font("Microsoft Sans Serif", 7.875F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel6.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel6.Location = new Point(74, 384);
            uiLabel6.Margin = new Padding(4, 0, 4, 0);
            uiLabel6.Name = "uiLabel6";
            uiLabel6.Size = new Size(115, 47);
            uiLabel6.TabIndex = 45;
            uiLabel6.Text = "Số Người";
            uiLabel6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn_san1
            // 
            btn_san1.Location = new Point(24, 463);
            btn_san1.Margin = new Padding(4, 2, 4, 2);
            btn_san1.Name = "btn_san1";
            btn_san1.Size = new Size(85, 47);
            btn_san1.TabIndex = 46;
            btn_san1.Text = "Sân 1";
            btn_san1.UseVisualStyleBackColor = true;
            btn_san1.Click += btn_san1_Click;
            // 
            // btn_San4
            // 
            btn_San4.Location = new Point(420, 463);
            btn_San4.Margin = new Padding(4, 2, 4, 2);
            btn_San4.Name = "btn_San4";
            btn_San4.Size = new Size(85, 47);
            btn_San4.TabIndex = 47;
            btn_San4.Text = "Sân 4";
            btn_San4.UseVisualStyleBackColor = true;
            btn_San4.Click += btn_San4_Click;
            // 
            // btn_san3
            // 
            btn_san3.Location = new Point(282, 463);
            btn_san3.Margin = new Padding(4, 2, 4, 2);
            btn_san3.Name = "btn_san3";
            btn_san3.Size = new Size(85, 47);
            btn_san3.TabIndex = 48;
            btn_san3.Text = "Sân 3";
            btn_san3.UseVisualStyleBackColor = true;
            btn_san3.Click += btn_san3_Click;
            // 
            // btn_San2
            // 
            btn_San2.Location = new Point(149, 463);
            btn_San2.Margin = new Padding(4, 2, 4, 2);
            btn_San2.Name = "btn_San2";
            btn_San2.Size = new Size(89, 47);
            btn_San2.TabIndex = 49;
            btn_San2.Text = "Sân 2";
            btn_San2.UseVisualStyleBackColor = true;
            btn_San2.Click += btn_San2_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(1024, 61);
            button1.Margin = new Padding(4, 2, 4, 2);
            button1.Name = "button1";
            button1.Size = new Size(201, 171);
            button1.TabIndex = 55;
            button1.Text = "SÂN TRỐNG";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Export_Excel
            // 
            Export_Excel.BackColor = Color.OrangeRed;
            Export_Excel.FlatAppearance.BorderColor = Color.Black;
            Export_Excel.FlatStyle = FlatStyle.Flat;
            Export_Excel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Export_Excel.Location = new Point(548, 442);
            Export_Excel.Margin = new Padding(4, 2, 4, 2);
            Export_Excel.Name = "Export_Excel";
            Export_Excel.Size = new Size(280, 90);
            Export_Excel.TabIndex = 56;
            Export_Excel.Text = "Xuất File Excel";
            Export_Excel.UseVisualStyleBackColor = false;
            Export_Excel.Click += Export_Excel_Click;
            // 
            // roundedButton2
            // 
            roundedButton2.BackColor = Color.OrangeRed;
            roundedButton2.FlatAppearance.BorderColor = Color.Black;
            roundedButton2.FlatStyle = FlatStyle.Flat;
            roundedButton2.Location = new Point(1699, 355);
            roundedButton2.Name = "roundedButton2";
            roundedButton2.Size = new Size(8, 8);
            roundedButton2.TabIndex = 57;
            roundedButton2.Text = "roundedButton2";
            roundedButton2.UseVisualStyleBackColor = false;
            // 
            // DatSan
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(2564, 1060);
            Controls.Add(roundedButton2);
            Controls.Add(dgv_datsan);
            Controls.Add(Export_Excel);
            Controls.Add(btn_search);
            Controls.Add(button1);
            Controls.Add(btn_San2);
            Controls.Add(btn_san3);
            Controls.Add(btn_San4);
            Controls.Add(btn_san1);
            Controls.Add(uiLabel6);
            Controls.Add(uiLabel5);
            Controls.Add(uiLabel4);
            Controls.Add(uiLabel3);
            Controls.Add(uiLabel2);
            Controls.Add(txb_email);
            Controls.Add(uiLabel1);
            Controls.Add(roundedButton1);
            Controls.Add(uiSymbolButton4);
            Controls.Add(btn_edit);
            Controls.Add(btn_delete);
            Controls.Add(uiScrollBar1);
            Controls.Add(btn_add);
            Controls.Add(btn_reset);
            Controls.Add(groupBox1);
            Controls.Add(txb_phonenumber);
            Controls.Add(txb_name);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cb_idsan);
            Controls.Add(txb_people);
            Controls.Add(txb_id);
            Controls.Add(txb_total);
            Controls.Add(txb_sogio);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 2, 4, 2);
            Name = "DatSan";
            Text = " QUẢN LÝ ĐẶT SÂN";
            Load += DatSan_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_datsan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txb_id;
        private TextBox txb_people;
        private ComboBox cb_idsan;
        private Label label5;
        private Label label6;
        private TextBox txb_name;
        private TextBox txb_phonenumber;
        private GroupBox groupBox1;
        private DateTimePicker dtp_date;
        private Label label8;
        private Label label9;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btn_reset;
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UISymbolButton btn_add;
        private Sunny.UI.UIScrollBar uiScrollBar1;
        private Sunny.UI.UISymbolButton btn_delete;
        private Sunny.UI.UISymbolButton btn_edit;
        private Sunny.UI.UISymbolButton uiSymbolButton4;
        private Sunny.UI.UISymbolButton btn_search;
        private Sunny.UI.UIDataGridView dgv_datsan;
        private RoundedButton roundedButton1;
        private TextBox txb_total;
        private Sunny.UI.UILabel uiLabel1;
        private TextBox txb_email;
        private TextBox txb_sogio;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel6;
        private Button btn_san1;
        private Button btn_San4;
        private Button btn_san3;
        private Button btn_San2;
        private DateTimePicker dtp_checkin;
        private DateTimePicker dtp_checkout;
        private Button button1;
        private RoundedButton Export_Excel;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn ID_San;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn People;
        private DataGridViewTextBoxColumn date;
        private DataGridViewTextBoxColumn TGBD;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn hour;
        private DataGridViewTextBoxColumn Column2;
        private RoundedButton roundedButton2;
    }
}