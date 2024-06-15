namespace QuanLySanCauLong.UI
{
    partial class SanTrong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SanTrong));
            dgv_santrong = new DataGridView();
            button1 = new Button();
            dtp_date = new DateTimePicker();
            button2 = new Button();
            txb_masan = new TextBox();
            dtp_checkin = new DateTimePicker();
            dtp_checkout = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgv_santrong).BeginInit();
            SuspendLayout();
            // 
            // dgv_santrong
            // 
            dgv_santrong.AllowUserToAddRows = false;
            dgv_santrong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_santrong.Dock = DockStyle.Bottom;
            dgv_santrong.Location = new Point(0, 50);
            dgv_santrong.Margin = new Padding(2, 1, 2, 1);
            dgv_santrong.Name = "dgv_santrong";
            dgv_santrong.RowHeadersWidth = 82;
            dgv_santrong.RowTemplate.Height = 41;
            dgv_santrong.Size = new Size(695, 210);
            dgv_santrong.TabIndex = 0;
            dgv_santrong.CellClick += dgv_santrong_CellClick;
            // 
            // button1
            // 
            button1.Location = new Point(287, 13);
            button1.Margin = new Padding(2, 1, 2, 1);
            button1.Name = "button1";
            button1.Size = new Size(142, 22);
            button1.TabIndex = 1;
            button1.Text = "TÌM SÂN TRỐNG";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dtp_date
            // 
            dtp_date.Location = new Point(23, 16);
            dtp_date.Margin = new Padding(2, 1, 2, 1);
            dtp_date.Name = "dtp_date";
            dtp_date.Size = new Size(217, 23);
            dtp_date.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(492, 15);
            button2.Margin = new Padding(2, 1, 2, 1);
            button2.Name = "button2";
            button2.Size = new Size(158, 22);
            button2.TabIndex = 3;
            button2.Text = "ĐẶT SÂN";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txb_masan
            // 
            txb_masan.Location = new Point(150, 88);
            txb_masan.Margin = new Padding(2, 1, 2, 1);
            txb_masan.Name = "txb_masan";
            txb_masan.Size = new Size(110, 23);
            txb_masan.TabIndex = 4;
            txb_masan.Visible = false;
            // 
            // dtp_checkin
            // 
            dtp_checkin.Format = DateTimePickerFormat.Time;
            dtp_checkin.Location = new Point(276, 77);
            dtp_checkin.Margin = new Padding(2, 1, 2, 1);
            dtp_checkin.Name = "dtp_checkin";
            dtp_checkin.Size = new Size(106, 23);
            dtp_checkin.TabIndex = 5;
            dtp_checkin.Value = new DateTime(2024, 5, 21, 7, 0, 0, 0);
            dtp_checkin.Visible = false;
            // 
            // dtp_checkout
            // 
            dtp_checkout.Format = DateTimePickerFormat.Time;
            dtp_checkout.Location = new Point(394, 77);
            dtp_checkout.Margin = new Padding(2, 1, 2, 1);
            dtp_checkout.Name = "dtp_checkout";
            dtp_checkout.Size = new Size(106, 23);
            dtp_checkout.TabIndex = 6;
            dtp_checkout.Value = new DateTime(2024, 5, 21, 8, 0, 0, 0);
            dtp_checkout.Visible = false;
            // 
            // SanTrong
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(695, 260);
            Controls.Add(button2);
            Controls.Add(dtp_date);
            Controls.Add(button1);
            Controls.Add(dgv_santrong);
            Controls.Add(dtp_checkout);
            Controls.Add(dtp_checkin);
            Controls.Add(txb_masan);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 1, 2, 1);
            Name = "SanTrong";
            Text = "SanTrong";
            Load += SanTrong_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_santrong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_santrong;
        private Button button1;
        private DateTimePicker dtp_date;
        private Button button2;
        private TextBox txb_masan;
        private DateTimePicker dtp_checkin;
        private DateTimePicker dtp_checkout;
    }
}