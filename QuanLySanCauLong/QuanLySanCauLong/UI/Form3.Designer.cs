namespace QuanLySanCauLong.UI
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            btn_san = new Button();
            uiLabel1 = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(32, 241);
            button1.Margin = new Padding(4, 2, 4, 2);
            button1.Name = "button1";
            button1.Size = new Size(150, 233);
            button1.TabIndex = 0;
            button1.Text = "ĐẶT SÂN";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(256, 250);
            button2.Margin = new Padding(4, 2, 4, 2);
            button2.Name = "button2";
            button2.Size = new Size(150, 215);
            button2.TabIndex = 1;
            button2.Text = "TRANG CHỦ";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(496, 258);
            button3.Margin = new Padding(4, 2, 4, 2);
            button3.Name = "button3";
            button3.Size = new Size(150, 215);
            button3.TabIndex = 2;
            button3.Text = "SÂN TRỐNG";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // btn_san
            // 
            btn_san.Location = new Point(732, 258);
            btn_san.Margin = new Padding(4, 2, 4, 2);
            btn_san.Name = "btn_san";
            btn_san.Size = new Size(150, 215);
            btn_san.TabIndex = 3;
            btn_san.Text = "DANH SÁCH SÂN";
            btn_san.UseVisualStyleBackColor = true;
            btn_san.Click += btn_san_Click;
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(277, 19);
            uiLabel1.Margin = new Padding(4, 0, 4, 0);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(410, 47);
            uiLabel1.TabIndex = 4;
            uiLabel1.Text = "PHẦN MỀM QUẢN LÝ SÂN CẦU LÔNG THÔNG MINH";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 502);
            Controls.Add(uiLabel1);
            Controls.Add(btn_san);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 2, 4, 2);
            Name = "Form3";
            Text = "QUẢN LÝ SÂN CẦU LÔNG THÔNG MINH";
            FormClosing += Form3_FormClosing;
            Load += Form3_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button btn_san;
        private Sunny.UI.UILabel uiLabel1;
    }
}