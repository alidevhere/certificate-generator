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
namespace certificate_generator
{
    public partial class Form1 : Form
    {
        List<Label> ControlsList;
        private Control activeControl;
        private Point previousPosition;
        DataTable csvTable;
        List<Tuple<int, int>> mapping;
        
        public Form1()
        {
            InitializeComponent();
            ControlsList = new List<Label>();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            var f = Tools.load_file_labels(@"D:\Projects\certificate-generator\Sample\fie.csv");

            foreach (Label l in f)
            {
                Console.WriteLine(l.Text);
            }
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
            fontDlg.MaxSize = 40;
            
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                MessageBox.Show(sender.ToString());

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


        private void MyControl_remove_label_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                ContextMenu contextMenu = menuItem.GetContextMenu();
                Control lbl = contextMenu.SourceControl;
                pictureBox1.Controls.Remove(lbl);

            }


        }


        // ================    Functions =============


        //Load lables from csv file
        


            private void Add_labels_to_Template(string path)
            {
            /*
            Label lbl = new Label();
            lbl.Font = sample_txt.Font;
            lbl.ForeColor = sample_txt.ForeColor; 

            lbl.Text = name; //txt.Text;
            lbl.Location = new Point(30, 50);
            //myControl.Size = //new Size(50, 50);
            lbl.AutoSize = true;
            //lbl.Font = font;
            */
            Point lbl_location = new Point(30, 50);
            ContextMenu menu = new ContextMenu();
            //var menuItem = new MenuItem("Change Font");
            
            //menuItem.Click += new MouseEventHandler(MyControl_Change_Font_Click);
            menu.MenuItems.Add(new MenuItem("Change Font",new EventHandler(MyControl_Change_Font_Click)));
            menu.MenuItems.Add(new MenuItem("Remove", new EventHandler(MyControl_remove_label_Click)));

            foreach (Label lbl in Tools.load_file_labels(path))
            {
                lbl.Location = lbl_location;


                lbl.MouseDown += new MouseEventHandler(MyControl_MouseDown);
                lbl.MouseMove += new MouseEventHandler(MyControl_MouseMove);
                lbl.MouseUp += new MouseEventHandler(MyControl_MouseUp);
                //lbl.MouseDoubleClick += new MouseEventHandler(MyControl_DoubleClick);
                lbl.ContextMenu = menu;

                ControlsList.Add(lbl);
                pictureBox1.Controls.Add(lbl);

            }
            // Events

        }


        


        void Print_certificate()
        {
            Tools.get_labels_locations(pictureBox1.Controls.OfType<Label>());



            string img_path = tmplt_path_tb.Text;
            FileStream fs = new FileStream(img_path, FileMode.Open, FileAccess.Read);
            Image image = Image.FromStream(fs);
            fs.Close();

            Bitmap b = new Bitmap(image);
            Graphics graphics = Graphics.FromImage(b);

            
            foreach (Label lbl in ControlsList)
            {
                //Font font = new Font("Times New Roman", 15.0f);
                //MessageBox.Show("Added" + lbl.Text);
                float x = Math.Abs(lbl.Location.X - pictureBox1.Location.X);
                float y = Math.Abs(pictureBox1.Location.Y - lbl.Location.Y);
                MessageBox.Show("text " + lbl.Text + "post" + x + "  " + y + lbl.Font.ToString());

                graphics.DrawString(lbl.Text, lbl.Font, Brushes.Black, x, y);
            }
            b.Save(output_folder_path.Text + "\\out.png", image.RawFormat);

            image.Dispose();
            b.Dispose();
            MessageBox.Show("MessageBox");

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
        }

        private void save_Click(object sender, EventArgs e)
        {
            Dictionary<string, Point> d = Tools.get_labels_locations(pictureBox1.Controls.OfType<Label>());
            List<List<Tuple<string, Point>>> dic = Tools.map_lbl_to_file(csv_txt.Text, d);

            
                int i = 0;
            foreach (var lst in dic)
            {
                i++;
                string img_path = tmplt_path_tb.Text;
                FileStream fs = new FileStream(img_path, FileMode.Open, FileAccess.Read);
                Image image = Image.FromStream(fs);
                fs.Close();

                Bitmap b = new Bitmap(image);
                Graphics graphics = Graphics.FromImage(b);

                foreach (Tuple<string,Point> tpl in lst)
                {
                    Font font = new Font("Times New Roman", 15.0f);
                    graphics.DrawString(tpl.Item1, font, Brushes.Black, tpl.Item2.X, tpl.Item2.Y);

                }
                Console.WriteLine("Image "+i+" saved");
                b.Save(output_folder_path.Text + "\\"+i+".png", image.RawFormat);
                image.Dispose();
                b.Dispose();

                //Font font = new Font("Times New Roman", 15.0f);
                //MessageBox.Show("Added" + lbl.Text);
                /*
                                float x = Math.Abs(lbl.Location.X - pictureBox1.Location.X);
                                float y = Math.Abs(pictureBox1.Location.Y - lbl.Location.Y);
                                MessageBox.Show("text " + lbl.Text + "post" + x + "  " + y + lbl.Font.ToString());

                                graphics.DrawString(lbl.Text, lbl.Font, Brushes.Black, x, y);
                */
            }
            MessageBox.Show("Completed");

            //          b.Save(output_folder_path.Text + "\\out.png", image.RawFormat);

            //        image.Dispose();
            //      b.Dispose();


        }

        private void location_lbl_Click(object sender, EventArgs e)
        {

        }

        private void remove_txt_Click(object sender, EventArgs e)
        {
            pictureBox1.Controls.Clear();
            csv_txt.Text = "";
            location_lbl.Text = "-,-";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            tmplt_path_tb.Text = "";
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

        }
    }
}
