namespace QuanLySanCauLong.UI
{
    partial class send_email
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(send_email));
            uiButton1 = new Sunny.UI.UIButton();
            to = new TextBox();
            from = new TextBox();
            pass = new TextBox();
            subj = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            uiSmoothLabel1 = new Sunny.UI.UISmoothLabel();
            noidung = new RichTextBox();
            SuspendLayout();
            // 
            // uiButton1
            // 
            uiButton1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiButton1.Location = new Point(589, 119);
            uiButton1.Margin = new Padding(4, 2, 4, 2);
            uiButton1.MinimumSize = new Size(2, 0);
            uiButton1.Name = "uiButton1";
            uiButton1.Size = new Size(201, 70);
            uiButton1.TabIndex = 0;
            uiButton1.Text = "GỬI EMAIL";
            uiButton1.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            uiButton1.Click += uiButton1_Click;
            // 
            // to
            // 
            to.Location = new Point(145, 119);
            to.Margin = new Padding(4, 2, 4, 2);
            to.Name = "to";
            to.Size = new Size(398, 39);
            to.TabIndex = 1;
            // 
            // from
            // 
            from.Location = new Point(145, 209);
            from.Margin = new Padding(4, 2, 4, 2);
            from.Name = "from";
            from.Size = new Size(398, 39);
            from.TabIndex = 2;
            // 
            // pass
            // 
            pass.Location = new Point(598, 247);
            pass.Margin = new Padding(4, 2, 4, 2);
            pass.Name = "pass";
            pass.Size = new Size(145, 39);
            pass.TabIndex = 3;
            pass.Visible = false;
            // 
            // subj
            // 
            subj.Location = new Point(145, 294);
            subj.Margin = new Padding(4, 2, 4, 2);
            subj.Name = "subj";
            subj.Size = new Size(398, 39);
            subj.TabIndex = 5;
            subj.Text = "GỬI HÓA ĐƠN ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 119);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(73, 32);
            label1.TabIndex = 6;
            label1.Text = "ĐẾN :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 363);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(130, 32);
            label2.TabIndex = 7;
            label2.Text = "NỘI DUNG";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(589, 213);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(133, 32);
            label3.TabIndex = 8;
            label3.Text = "MẬT KHẨU";
            label3.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 213);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(56, 32);
            label4.TabIndex = 9;
            label4.Text = "TỪ :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 294);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(109, 32);
            label5.TabIndex = 10;
            label5.Text = "TIÊU ĐỀ :";
            // 
            // uiSmoothLabel1
            // 
            uiSmoothLabel1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            uiSmoothLabel1.Location = new Point(106, 9);
            uiSmoothLabel1.Margin = new Padding(4, 0, 4, 0);
            uiSmoothLabel1.Name = "uiSmoothLabel1";
            uiSmoothLabel1.Size = new Size(600, 77);
            uiSmoothLabel1.TabIndex = 11;
            uiSmoothLabel1.Text = "XUẤT HÓA ĐƠN ĐỎ VÀ GỬI EMAIL";
            // 
            // noidung
            // 
            noidung.Dock = DockStyle.Bottom;
            noidung.Location = new Point(0, 412);
            noidung.Margin = new Padding(4, 2, 4, 2);
            noidung.Name = "noidung";
            noidung.Size = new Size(800, 356);
            noidung.TabIndex = 12;
            noidung.Text = "";
            // 
            // send_email
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 768);
            Controls.Add(noidung);
            Controls.Add(uiSmoothLabel1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(subj);
            Controls.Add(pass);
            Controls.Add(from);
            Controls.Add(to);
            Controls.Add(uiButton1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 2, 4, 2);
            Name = "send_email";
            Text = "send_email";
            Load += send_email_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Sunny.UI.UIButton uiButton1;
        private TextBox to;
        private TextBox from;
        private TextBox pass;
        private TextBox subj;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Sunny.UI.UISmoothLabel uiSmoothLabel1;
        private RichTextBox noidung;
    }
}