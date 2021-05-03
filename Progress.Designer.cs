namespace certificate_generator
{
    partial class Progress
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
            this.bar = new System.Windows.Forms.ProgressBar();
            this.progress_lbl = new System.Windows.Forms.Label();
            this.feed_back_lbl = new System.Windows.Forms.Label();
            this.finish_btn = new System.Windows.Forms.Button();
            this.cncl_btn = new System.Windows.Forms.Button();
            this.bg_worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // bar
            // 
            this.bar.Location = new System.Drawing.Point(52, 43);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(542, 23);
            this.bar.TabIndex = 0;
            // 
            // progress_lbl
            // 
            this.progress_lbl.AutoSize = true;
            this.progress_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progress_lbl.Location = new System.Drawing.Point(622, 50);
            this.progress_lbl.Name = "progress_lbl";
            this.progress_lbl.Size = new System.Drawing.Size(26, 16);
            this.progress_lbl.TabIndex = 1;
            this.progress_lbl.Text = "0/0";
            // 
            // feed_back_lbl
            // 
            this.feed_back_lbl.AutoSize = true;
            this.feed_back_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feed_back_lbl.Location = new System.Drawing.Point(49, 86);
            this.feed_back_lbl.Name = "feed_back_lbl";
            this.feed_back_lbl.Size = new System.Drawing.Size(82, 16);
            this.feed_back_lbl.TabIndex = 2;
            this.feed_back_lbl.Text = "Feed back : ";
            // 
            // finish_btn
            // 
            this.finish_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finish_btn.Location = new System.Drawing.Point(541, 104);
            this.finish_btn.Name = "finish_btn";
            this.finish_btn.Size = new System.Drawing.Size(122, 35);
            this.finish_btn.TabIndex = 3;
            this.finish_btn.Text = "Finish";
            this.finish_btn.UseVisualStyleBackColor = true;
            this.finish_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // cncl_btn
            // 
            this.cncl_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cncl_btn.Location = new System.Drawing.Point(379, 104);
            this.cncl_btn.Name = "cncl_btn";
            this.cncl_btn.Size = new System.Drawing.Size(122, 35);
            this.cncl_btn.TabIndex = 4;
            this.cncl_btn.Text = "Cancel";
            this.cncl_btn.UseVisualStyleBackColor = true;
            this.cncl_btn.Click += new System.EventHandler(this.cncl_btn_Click);
            // 
            // bg_worker
            // 
            this.bg_worker.WorkerReportsProgress = true;
            this.bg_worker.WorkerSupportsCancellation = true;
            this.bg_worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_worker_DoWork);
            this.bg_worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg_worker_ProgressChanged);
            this.bg_worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_worker_RunWorkerCompleted);
            // 
            // Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 167);
            this.ControlBox = false;
            this.Controls.Add(this.cncl_btn);
            this.Controls.Add(this.finish_btn);
            this.Controls.Add(this.feed_back_lbl);
            this.Controls.Add(this.progress_lbl);
            this.Controls.Add(this.bar);
            this.Name = "Progress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress";
            this.Load += new System.EventHandler(this.Progress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar bar;
        private System.Windows.Forms.Label progress_lbl;
        private System.Windows.Forms.Label feed_back_lbl;
        private System.Windows.Forms.Button finish_btn;
        private System.Windows.Forms.Button cncl_btn;
        private System.ComponentModel.BackgroundWorker bg_worker;
    }
}