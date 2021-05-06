using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace certificate_generator
{
    public static class Tools
    {
        public static List<Label> load_file_labels(string path)
        {
            List<Label> file_labels = new List<Label>();
            using (StreamReader reader = new StreamReader(path))
            {
                List<string> headers = reader.ReadLine().Split(',').ToList<string>();

                foreach (var col in headers)
                {
                    Label lbl = new Label();
                    lbl.Text = col.ToString();
                    lbl.AutoSize = true;
                    lbl.Font = new Font("Arial", 15);


                    file_labels.Add(lbl);
                }

            }

            return file_labels;
        }


        public static List<Tuple<List<Tuple<string, Point,Font,Color>>, string>> map_lbl_to_file(string path, Dictionary<string,Point> location,string f_name_col, Dictionary<string,Tuple<Font,Color>> fonts)
        {
            Console.WriteLine("Mapping....");
            List<Tuple<List<Tuple<string, Point,Font,Color>>,string>> output = new List<Tuple<List<Tuple<string, Point,Font,Color>>,string>>();

            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(path)), true, ','))
            {
                
                DataTable csvTable = new DataTable();
                csvTable.Load(csvReader);

                for(int i=0; i<csvTable.Rows.Count; i++)
                {
                    List <Tuple<string, Point,Font,Color>> l = new List<Tuple<string, Point,Font,Color>>();
                    string file_name = "";
                    for (int j=0;j<csvTable.Columns.Count;j++)
                    {
                        l.Add(new Tuple<string,Point,Font,Color>(csvTable.Rows[i][j].ToString(), location[csvTable.Columns[j].ColumnName], fonts[csvTable.Columns[j].ColumnName].Item1, fonts[csvTable.Columns[j].ColumnName].Item2));
                        
                        
                       if(f_name_col== csvTable.Columns[j].ColumnName)
                        {
                            file_name = csvTable.Rows[i][j].ToString();
                        }
                    }

                    if (f_name_col == "Default Numbering")
                    {
                        
                        int n = i + 1;
                        file_name = n.ToString();

                    }
                    output.Add(new Tuple<List<Tuple<string, Point,Font,Color>>,string>(l,file_name));
                    
                }
            }
            return output;
        }



        public static Dictionary<string, Point> get_labels_locations(IEnumerable<Label> labels)
        {
            Dictionary<string, Point> locations = new Dictionary<string, Point>();

            foreach (Label lbl in labels)
            {
                locations.Add(lbl.Text, lbl.Location);
             
            }
            return locations;

        }

        public static Dictionary<string, Tuple<Font,Color>> get_labels_fonts(IEnumerable<Label> labels)
        {
            Dictionary<string, Tuple<Font,Color>> fonts = new Dictionary<string, Tuple<Font,Color>>();

            foreach (Label lbl in labels)
            {
                fonts.Add(lbl.Text, new Tuple<Font,Color>(lbl.Font,lbl.ForeColor));

            }
            return fonts;

        }


    }
}
