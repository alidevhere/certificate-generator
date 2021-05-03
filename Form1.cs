using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*

1- Check for unique columns and add only those columns to "Name output files according to Drop down list"

*/



namespace certificate_generator
{
    public partial class Form1 : Form
    {
        private Control activeControl;
        private Point previousPosition;
        private int increment;
        public Form1()
        {
            InitializeComponent();
        }

        
        private void load_img_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Templates |*.png;*.jpg;*.jpeg;";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Image img = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = img;
                    img_dim_lbl.Text = img.Width + " x " + img.Height;
                    tmplt_path_tb.Text = openFileDialog1.FileName;

                }
            }

        }

        

        private void MyControl_MouseDown(Object sender ,MouseEventArgs e)
        {
            activeControl = sender as Control;
            previousPosition = e.Location;
            Cursor = Cursors.Hand;
        }


        private void MyControl_MouseUp(Object sender, MouseEventArgs e)
        {
            activeControl = null;
            Cursor = Cursors.Default;
            
        }

        private void MyControl_MouseMove(Object sender, MouseEventArgs e)
        {
            if(activeControl == null || activeControl !=sender )
            {
                return;
            }
            var location = activeControl.Location;
            location.Offset(e.Location.X - previousPosition.X, e.Location.Y - previousPosition.Y);
            activeControl.Location = location;
            
            Control s = sender as Control;
            location_lbl.Text = s.Location.X + " , " + s.Location.Y;

        }

        private void MyControl_Change_Font_Click(Object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowEffects = true;
            fontDlg.MaxSize = 100;
            
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {  
                MenuItem menuItem = sender as MenuItem;
                if(menuItem != null)
                {
                    ContextMenu contextMenu =  menuItem.GetContextMenu();
                    Control lbl = contextMenu.SourceControl;
                    lbl.Font = fontDlg.Font;
                    lbl.ForeColor = fontDlg.Color;
                }

            }
        }



         private void Add_labels_to_Template(string path)
          {
            
                Point lbl_location = new Point(30, 50);
                ContextMenu menu = new ContextMenu();
            
                menu.MenuItems.Add(new MenuItem("Change Font",new EventHandler(MyControl_Change_Font_Click)));
            
                foreach (Label lbl in Tools.load_file_labels(path))
                {
                    lbl.Location = lbl_location;

                    lbl.MouseDown += new MouseEventHandler(MyControl_MouseDown);
                    lbl.MouseMove += new MouseEventHandler(MyControl_MouseMove);
                    lbl.MouseUp += new MouseEventHandler(MyControl_MouseUp);
                    lbl.ContextMenu = menu;

                    pictureBox1.Controls.Add(lbl);
                    file_names_dd.Items.Add(lbl.Text);
                }

         }

        
        private void choose_fldr_dlg_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Choose Folder for saving certificates";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                output_folder_path.Text = fbd.SelectedPath;
            }
        }

         

        private void csv_dlg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "CSV files (*.csv)|*.csv";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    csv_txt.Text = openFileDialog1.FileName;
                    Add_labels_to_Template(csv_txt.Text);

                }
            }

            file_names_dd.SelectedIndex = 0;
        }

        private bool check_validations()
        {
            string a = output_folder_path.Text;
            string b = csv_txt.Text;
            string c = tmplt_path_tb.Text;
            return (!String.IsNullOrWhiteSpace(a) && !String.IsNullOrWhiteSpace(b) && !String.IsNullOrWhiteSpace(c));
            
        }



        

    

        private void remove_txt_Click(object sender, EventArgs e)
        {
            pictureBox1.Controls.Clear();
            csv_txt.Text = "";
            location_lbl.Text = "-,-";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = null;
            tmplt_path_tb.Text = "";
            pictureBox1.Controls.Clear();

            if (!String.IsNullOrWhiteSpace(csv_txt.Text))
            {
                Add_labels_to_Template(csv_txt.Text);
            }
        
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            location_lbl.Text = "-,-";
            img_dim_lbl.Text = "0 x 0";
            output_folder_path.Text = "";
            csv_txt.Text = "";
            tmplt_path_tb.Text = "";
            pictureBox1.Controls.Clear();
            file_names_dd.Items.Clear();
            file_names_dd.Items.Add("Default Numbering");
            file_names_dd.SelectedIndex = 0;
            png_rb.Checked = true;

        }


        private string get_output_file_type()
        {
            string output_ext = "";
            if(png_rb.Checked)
            {
                output_ext = ".png";
            }
            else if(jpeg_rb.Checked)
            {
                output_ext = ".jpeg";

            }else if(jpg_rb.Checked)
            {
                output_ext = ".jpg";
            }
            else if (pdf_rb.Checked)
            {
                output_ext = ".pdf";
            }

            return output_ext;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            file_names_dd.SelectedIndex = 0;

        }


        private void save_Click(object sender, EventArgs e)
        {
            if (check_validations())
            {
                
                Dictionary<string, Point> d = Tools.get_labels_locations(pictureBox1.Controls.OfType<Label>());
                Dictionary<string, Tuple<Font, Color>> fonts = Tools.get_labels_fonts(pictureBox1.Controls.OfType<Label>());
                List<Tuple<List<Tuple<string, Point, Font, Color>>, string>> dic = Tools.map_lbl_to_file(csv_txt.Text, d, file_names_dd.Text, fonts);
                
                Progress p = new Progress(dic, tmplt_path_tb.Text, get_output_file_type(), output_folder_path.Text);
                p.ShowDialog();
                
                //Tuple<List<Tuple<List<Tuple<string, Point, Font, Color>>, string>>, string, string, string> data = new Tuple<List<Tuple<List<Tuple<string, Point, Font, Color>>, string>>, string, string, string>(dic, tmplt_path_tb.Text, get_output_file_type(), output_folder_path.Text);
                //increment = 100 / dic.Count;
                //bg_worker.RunWorkerAsync(data);
                //p.Show();

            }
            else
            {
                MessageBox.Show("Please choose all options");

            }

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





        
    }
}
