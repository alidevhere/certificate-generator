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

        }

        private void load_img_btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // lblFileName.Text = Path.GetFileName(openFileDialog1.FileName);
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    tmplt_path_tb.Text = openFileDialog1.FileName;

                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ( (!String.IsNullOrEmpty(txt.Text) ) && (!String.IsNullOrWhiteSpace(txt.Text) ))
            {
                Add_Text_Control(txt.Text);
            }
            else 
            {
                MessageBox.Show("Please Enter a valid name for text field !!!");
            }
            txt.Text = "";


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

        }

        private void remove_txt_Click(object sender, EventArgs e)
        {
            if (ControlsList.Count < 1)
            {
                MessageBox.Show("Nothing to remove !!");
            }
            else
            {

                foreach (Label lbl in ControlsList)
                {
                    pictureBox1.Controls.Remove(lbl);
                }
                ControlsList.Clear();
            }
        }


        // ================    Functions =============


        //Load lables from csv file
        private void load_file_labels(string path)
        {
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(path)), true, ','))
            {
                csvTable = new DataTable();
                csvTable.Load(csvReader);

            }
        }



            private void Add_Text_Control(string name)
        {
            Label lbl = new Label();
            lbl.Font = sample_txt.Font;
            lbl.ForeColor = sample_txt.ForeColor; 

            lbl.Text = name; //txt.Text;
            lbl.Location = new Point(30, 50);
            //myControl.Size = //new Size(50, 50);
            lbl.AutoSize = true;
            //lbl.Font = new Font("Arial", 15);
            //lbl.Font = font;

            // Events
            lbl.MouseDown += new MouseEventHandler(MyControl_MouseDown);
            lbl.MouseMove += new MouseEventHandler(MyControl_MouseMove);
            lbl.MouseUp += new MouseEventHandler(MyControl_MouseUp);

            ControlsList.Add(lbl);
            pictureBox1.Controls.Add(lbl);

        }

        void Print_certificate()
        {
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

        private void save_Click(object sender, EventArgs e)
        {
            //@"D:\Projects\certificate-generator\Sample\sample_1.png"
            
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

        private void font_dlg_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            fontDlg.MaxSize = 40;
            fontDlg.MinSize = 12;
            //Font fnt = new Font();
            
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                sample_txt.Font = fontDlg.Font;
                //sample_txt.BackColor = fontDlg.Color;
                sample_txt.ForeColor = fontDlg.Color;
            }



        }

        private List<List<Tuple<string,Point>>> map_file(string path,List<Label> lbls)
        {
            List<List<Tuple<string, int, int>>> output_data;
            
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(path)),true,','))
            {
                csvTable = new DataTable();
                mapping = null;

                csvTable.Load(csvReader);


                if(ControlsList.Count==0)
                {
                    MessageBox.Show("No Labels in template found to be mapped !!");
                }

                if(csvTable.Columns.Count == ControlsList.Count)
                {
                    //Console.WriteLine();
                    
                    //string Row1 = csvTable.Rows[0][0].ToString();
                    //Console.WriteLine(Row1);
                    for ( int i=0;i< ControlsList.Count;i++)
                    {
                        for(int j= 0; j < csvTable.Columns.Count; j++)
                        {
                            if (ControlsList[i].Text == csvTable.Columns[j].ToString() )
                            {
                                //mapping.Add(Tuple.Create(i, j));//lable, file column

                            }
                        }

                         
                    }
                }    
                
            }

        }
         

        private void csv_dlg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // lblFileName.Text = Path.GetFileName(openFileDialog1.FileName);
                    csv_txt.Text = openFileDialog1.FileName;
                    map_file(csv_txt.Text);

                }
            }
        }
    }
}
