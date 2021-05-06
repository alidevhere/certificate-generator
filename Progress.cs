using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace certificate_generator
{
    public partial class Progress : Form
    {

        List<Tuple<List<Tuple<string, Point, Font, Color>>, string>> dic;
        string img_path;
        string extension;
        string output_folder_path;
        string msg;
        
        public Progress(List<Tuple<List<Tuple<string, Point, Font, Color>>, string>> dic, string img_path, string extension, string output_folder_path)
        {
            InitializeComponent();
            this.dic = dic;
            this.img_path = img_path;
            this.extension = extension;
            this.output_folder_path = output_folder_path;
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            feed_back_lbl.Text = "Working...";
            bar.Maximum = dic.Count;
            bar.Value = 0;
            finish_btn.Enabled = false;
            bg_worker.RunWorkerAsync();
        }

        private void bg_worker_DoWork(object sender, DoWorkEventArgs e)
        {

            BackgroundWorker worker = sender as BackgroundWorker;
            
            int progress = 0;
            worker.ReportProgress(progress);
            msg = "Reading Files...";
            worker.ReportProgress(progress);

            foreach (var tpl1 in dic)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                //string img_path = tmplt_path_tb.Text;
                FileStream fs = new FileStream(img_path, FileMode.Open, FileAccess.Read);
                Image image = Image.FromStream(fs);
                fs.Close();
                
                Bitmap b = new Bitmap(image);
                Graphics graphics = Graphics.FromImage(b);
                msg = "Writing Text on files...";
                worker.ReportProgress(progress);

                foreach (Tuple<string, Point, Font, Color> tpl in tpl1.Item1)
                {

                    Brush brush = new SolidBrush(Color.FromName(tpl.Item4.Name));
                    if (!tpl.Item4.IsNamedColor)
                    {

                        MessageBox.Show("Not Valid color : " + tpl.Item4.Name);
                        brush = new SolidBrush(Color.FromName("Black"));
                    }

                    graphics.DrawString(tpl.Item1, tpl.Item3, brush, tpl.Item2.X, tpl.Item2.Y);

                }

                msg = "Image " + tpl1.Item2 + " saved";
                worker.ReportProgress(progress);
                //string extension = get_output_file_type();

                // ====  SAVING IMAGE FILE =========

                string output_path = output_folder_path + "\\" + tpl1.Item2;//without extension

                if (extension == ".pdf")
                {

                    msg = "Converting to PDF file...";
                    worker.ReportProgress(progress);
                    b.Save(output_path + ".png", image.RawFormat);
                    image.Dispose();
                    b.Dispose();
                    convert_to_pdf(output_path + ".png", output_path);
                    try
                    {
                        // Check if file exists with its full path    
                        if (File.Exists(output_path + ".png"))
                        {
                            // If file found, delete it    
                            File.Delete(output_path + ".png");

                            Console.WriteLine(tpl1.Item2 + "  deleted.");
                        }
                        else
                        {
                            MessageBox.Show("File not found");
                        }
                    }
                    catch (IOException ioExp)
                    {
                        MessageBox.Show(ioExp.Message);
                    }

                }
                else
                {
                    b.Save(output_path + extension, image.RawFormat);
                    image.Dispose();
                    b.Dispose();
                }
                progress += 1;
                worker.ReportProgress(progress);
            }

            // work finished
            //File.Delete(img_path);
        }

        private void bg_worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            bar.Value = e.ProgressPercentage;
            progress_lbl.Text = e.ProgressPercentage + "/" + dic.Count;
            feed_back_lbl.Text = msg;
            Console.WriteLine(e.ProgressPercentage+" % Progress...");
            
        }


        private void convert_to_pdf(string img_path, string pdf_path)
        {

            iTextSharp.text.Rectangle pageSize = null;

            using (var srcImage = new Bitmap(img_path))
            {
                pageSize = new iTextSharp.text.Rectangle(0, 0, srcImage.Width, srcImage.Height);
            }
            using (var ms = new MemoryStream())
            {
                var document = new iTextSharp.text.Document(pageSize, 0, 0, 0, 0);
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                document.Open();
                var pdf_img = iTextSharp.text.Image.GetInstance(img_path);
                document.Add(pdf_img);
                document.Close();

                File.WriteAllBytes(pdf_path + ".pdf", ms.ToArray());
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cncl_btn_Click(object sender, EventArgs e)
        {
            this.bg_worker.CancelAsync();
            cncl_btn.Enabled = false;

        }

        private void bg_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                finish_btn.Enabled = true;
                feed_back_lbl.Text = "Canceled";
            }
            else
            {
                feed_back_lbl.Text = "Completed !!";
                finish_btn.Enabled = true;
            }

        }
    }
}
