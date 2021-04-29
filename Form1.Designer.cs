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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 481);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // load_img_btn
            // 
            this.load_img_btn.Location = new System.Drawing.Point(120, 510);
            this.load_img_btn.Name = "load_img_btn";
            this.load_img_btn.Size = new System.Drawing.Size(105, 39);
            this.load_img_btn.TabIndex = 1;
            this.load_img_btn.Text = "Load Template";
            this.load_img_btn.UseVisualStyleBackColor = true;
            this.load_img_btn.Click += new System.EventHandler(this.load_img_btn_Click);
            // 
            // remove_txt
            // 
            this.remove_txt.Location = new System.Drawing.Point(886, 510);
            this.remove_txt.Name = "remove_txt";
            this.remove_txt.Size = new System.Drawing.Size(131, 39);
            this.remove_txt.TabIndex = 4;
            this.remove_txt.Text = "Remove All Labels";
            this.remove_txt.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(1159, 510);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(105, 39);
            this.save.TabIndex = 5;
            this.save.Text = "Create Certificates";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // tmplt_path_tb
            // 
            this.tmplt_path_tb.Location = new System.Drawing.Point(270, 520);
            this.tmplt_path_tb.Name = "tmplt_path_tb";
            this.tmplt_path_tb.Size = new System.Drawing.Size(173, 20);
            this.tmplt_path_tb.TabIndex = 7;
            // 
            // output_folder_path
            // 
            this.output_folder_path.Location = new System.Drawing.Point(930, 296);
            this.output_folder_path.Name = "output_folder_path";
            this.output_folder_path.Size = new System.Drawing.Size(173, 20);
            this.output_folder_path.TabIndex = 8;
            // 
            // choose_fldr_dlg
            // 
            this.choose_fldr_dlg.Location = new System.Drawing.Point(1145, 286);
            this.choose_fldr_dlg.Name = "choose_fldr_dlg";
            this.choose_fldr_dlg.Size = new System.Drawing.Size(119, 39);
            this.choose_fldr_dlg.TabIndex = 9;
            this.choose_fldr_dlg.Text = "Choose Output Folder";
            this.choose_fldr_dlg.UseVisualStyleBackColor = true;
            this.choose_fldr_dlg.Click += new System.EventHandler(this.choose_fldr_dlg_Click);
            // 
            // csv_dlg
            // 
            this.csv_dlg.Location = new System.Drawing.Point(1151, 372);
            this.csv_dlg.Name = "csv_dlg";
            this.csv_dlg.Size = new System.Drawing.Size(105, 39);
            this.csv_dlg.TabIndex = 12;
            this.csv_dlg.Text = "Load Data";
            this.csv_dlg.UseVisualStyleBackColor = true;
            this.csv_dlg.Click += new System.EventHandler(this.csv_dlg_Click);
            // 
            // csv_txt
            // 
            this.csv_txt.Location = new System.Drawing.Point(936, 382);
            this.csv_txt.Name = "csv_txt";
            this.csv_txt.Size = new System.Drawing.Size(173, 20);
            this.csv_txt.TabIndex = 13;
            // 
            // location_lbl
            // 
            this.location_lbl.AutoSize = true;
            this.location_lbl.Location = new System.Drawing.Point(895, 145);
            this.location_lbl.Name = "location_lbl";
            this.location_lbl.Size = new System.Drawing.Size(35, 13);
            this.location_lbl.TabIndex = 14;
            this.location_lbl.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 576);
            this.Controls.Add(this.location_lbl);
            this.Controls.Add(this.csv_txt);
            this.Controls.Add(this.csv_dlg);
            this.Controls.Add(this.choose_fldr_dlg);
            this.Controls.Add(this.output_folder_path);
            this.Controls.Add(this.tmplt_path_tb);
            this.Controls.Add(this.save);
            this.Controls.Add(this.remove_txt);
            this.Controls.Add(this.load_img_btn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

