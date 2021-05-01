namespace certificate_generator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.load_img_btn = new System.Windows.Forms.Button();
            this.remove_txt = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.tmplt_path_tb = new System.Windows.Forms.TextBox();
            this.output_folder_path = new System.Windows.Forms.TextBox();
            this.choose_fldr_dlg = new System.Windows.Forms.Button();
            this.csv_dlg = new System.Windows.Forms.Button();
            this.csv_txt = new System.Windows.Forms.TextBox();
            this.location_lbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.img_dim_lbl = new System.Windows.Forms.Label();
            this.reset_btn = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(802, 485);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // load_img_btn
            // 
            this.load_img_btn.Location = new System.Drawing.Point(266, 251);
            this.load_img_btn.Name = "load_img_btn";
            this.load_img_btn.Size = new System.Drawing.Size(119, 39);
            this.load_img_btn.TabIndex = 1;
            this.load_img_btn.Text = "Load Template";
            this.load_img_btn.UseVisualStyleBackColor = true;
            this.load_img_btn.Click += new System.EventHandler(this.load_img_btn_Click);
            // 
            // remove_txt
            // 
            this.remove_txt.Location = new System.Drawing.Point(153, 448);
            this.remove_txt.Name = "remove_txt";
            this.remove_txt.Size = new System.Drawing.Size(112, 39);
            this.remove_txt.TabIndex = 4;
            this.remove_txt.Text = "Remove All Labels";
            this.remove_txt.UseVisualStyleBackColor = true;
            this.remove_txt.Click += new System.EventHandler(this.remove_txt_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(266, 322);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(119, 39);
            this.save.TabIndex = 5;
            this.save.Text = "Create Certificates";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // tmplt_path_tb
            // 
            this.tmplt_path_tb.Location = new System.Drawing.Point(23, 270);
            this.tmplt_path_tb.Name = "tmplt_path_tb";
            this.tmplt_path_tb.Size = new System.Drawing.Size(201, 20);
            this.tmplt_path_tb.TabIndex = 7;
            // 
            // output_folder_path
            // 
            this.output_folder_path.Location = new System.Drawing.Point(23, 100);
            this.output_folder_path.Name = "output_folder_path";
            this.output_folder_path.Size = new System.Drawing.Size(201, 20);
            this.output_folder_path.TabIndex = 8;
            // 
            // choose_fldr_dlg
            // 
            this.choose_fldr_dlg.Location = new System.Drawing.Point(266, 81);
            this.choose_fldr_dlg.Name = "choose_fldr_dlg";
            this.choose_fldr_dlg.Size = new System.Drawing.Size(119, 39);
            this.choose_fldr_dlg.TabIndex = 9;
            this.choose_fldr_dlg.Text = "Choose Output Folder";
            this.choose_fldr_dlg.UseVisualStyleBackColor = true;
            this.choose_fldr_dlg.Click += new System.EventHandler(this.choose_fldr_dlg_Click);
            // 
            // csv_dlg
            // 
            this.csv_dlg.Location = new System.Drawing.Point(266, 164);
            this.csv_dlg.Name = "csv_dlg";
            this.csv_dlg.Size = new System.Drawing.Size(119, 39);
            this.csv_dlg.TabIndex = 12;
            this.csv_dlg.Text = "Load Data";
            this.csv_dlg.UseVisualStyleBackColor = true;
            this.csv_dlg.Click += new System.EventHandler(this.csv_dlg_Click);
            // 
            // csv_txt
            // 
            this.csv_txt.Location = new System.Drawing.Point(23, 183);
            this.csv_txt.Name = "csv_txt";
            this.csv_txt.Size = new System.Drawing.Size(201, 20);
            this.csv_txt.TabIndex = 13;
            // 
            // location_lbl
            // 
            this.location_lbl.AutoSize = true;
            this.location_lbl.Location = new System.Drawing.Point(113, 31);
            this.location_lbl.Name = "location_lbl";
            this.location_lbl.Size = new System.Drawing.Size(16, 13);
            this.location_lbl.TabIndex = 14;
            this.location_lbl.Text = "-,-";
            this.location_lbl.Click += new System.EventHandler(this.location_lbl_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.domainUpDown1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.reset_btn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.img_dim_lbl);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tmplt_path_tb);
            this.panel1.Controls.Add(this.location_lbl);
            this.panel1.Controls.Add(this.load_img_btn);
            this.panel1.Controls.Add(this.remove_txt);
            this.panel1.Controls.Add(this.save);
            this.panel1.Controls.Add(this.csv_txt);
            this.panel1.Controls.Add(this.output_folder_path);
            this.panel1.Controls.Add(this.csv_dlg);
            this.panel1.Controls.Add(this.choose_fldr_dlg);
            this.panel1.Location = new System.Drawing.Point(819, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 543);
            this.panel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Location :";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(3, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(810, 543);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1240, 558);
            this.panel3.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 39);
            this.button1.TabIndex = 16;
            this.button1.Text = "Remove Template";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Image Dimensions : ";
            // 
            // img_dim_lbl
            // 
            this.img_dim_lbl.AutoSize = true;
            this.img_dim_lbl.Location = new System.Drawing.Point(325, 31);
            this.img_dim_lbl.Name = "img_dim_lbl";
            this.img_dim_lbl.Size = new System.Drawing.Size(30, 13);
            this.img_dim_lbl.TabIndex = 17;
            this.img_dim_lbl.Text = "0 x 0";
            // 
            // reset_btn
            // 
            this.reset_btn.Location = new System.Drawing.Point(41, 505);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(106, 39);
            this.reset_btn.TabIndex = 19;
            this.reset_btn.Text = "Reset";
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(189, 344);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(45, 17);
            this.radioButton1.TabIndex = 20;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "jpeg";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(95, 342);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(43, 17);
            this.radioButton2.TabIndex = 21;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "png";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(144, 342);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(39, 17);
            this.radioButton3.TabIndex = 22;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "jpg";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Output File Type";
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Location = new System.Drawing.Point(27, 389);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(120, 20);
            this.domainUpDown1.TabIndex = 1;
            this.domainUpDown1.Text = "domainUpDown1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 558);
            this.Controls.Add(this.panel3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button load_img_btn;
        private System.Windows.Forms.Button remove_txt;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox tmplt_path_tb;
        private System.Windows.Forms.TextBox output_folder_path;
        private System.Windows.Forms.Button choose_fldr_dlg;
        private System.Windows.Forms.Button csv_dlg;
        private System.Windows.Forms.TextBox csv_txt;
        private System.Windows.Forms.Label location_lbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label img_dim_lbl;
        private System.Windows.Forms.Button reset_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
    }
}

