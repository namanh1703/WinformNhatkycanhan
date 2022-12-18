namespace NhatKyCaNhan
{
    partial class Detail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Detail));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbdate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fullname = new System.Windows.Forms.Label();
            this.txtdata = new System.Windows.Forms.TextBox();
            this.afullname = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-12, -13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(903, 518);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(94, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngày viết:";
            // 
            // lbdate
            // 
            this.lbdate.AutoSize = true;
            this.lbdate.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lbdate.Location = new System.Drawing.Point(170, 140);
            this.lbdate.Name = "lbdate";
            this.lbdate.Size = new System.Drawing.Size(55, 21);
            this.lbdate.TabIndex = 2;
            this.lbdate.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ký tên:";
            // 
            // fullname
            // 
            this.fullname.AutoSize = true;
            this.fullname.Location = new System.Drawing.Point(650, 431);
            this.fullname.Name = "fullname";
            this.fullname.Size = new System.Drawing.Size(0, 15);
            this.fullname.TabIndex = 4;
            // 
            // txtdata
            // 
            this.txtdata.Location = new System.Drawing.Point(450, 57);
            this.txtdata.Multiline = true;
            this.txtdata.Name = "txtdata";
            this.txtdata.ReadOnly = true;
            this.txtdata.Size = new System.Drawing.Size(316, 346);
            this.txtdata.TabIndex = 5;
            this.txtdata.DoubleClick += new System.EventHandler(this.txtdata_DoubleClick);
            // 
            // afullname
            // 
            this.afullname.AutoSize = true;
            this.afullname.Location = new System.Drawing.Point(522, 421);
            this.afullname.Name = "afullname";
            this.afullname.Size = new System.Drawing.Size(56, 15);
            this.afullname.TabIndex = 6;
            this.afullname.Text = "Fullname";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(691, 431);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Quay lại";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lbTitle.Location = new System.Drawing.Point(157, 272);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(68, 25);
            this.lbTitle.TabIndex = 8;
            this.lbTitle.Text = "label3";
            this.lbTitle.DoubleClick += new System.EventHandler(this.lbTitle_DoubleClick);
            // 
            // Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 490);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.afullname);
            this.Controls.Add(this.txtdata);
            this.Controls.Add(this.fullname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Detail";
            this.Text = "Detail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Detail_FormClosing);
            this.Load += new System.EventHandler(this.Detail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label lbdate;
        private Label label2;
        private Label fullname;
        private TextBox txtdata;
        private Label afullname;
        private Button button1;
        private Label lbTitle;
    }
}