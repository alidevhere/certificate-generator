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


        public static List<List<Tuple<string, Point>>> map_lbl_to_file(string path, Dictionary<string,Point> location)
        {
            Console.WriteLine("Mapping....");
            List<List<Tuple<string, Point>>> output = new List<List<Tuple<string, Point>>>();

            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(path)), true, ','))
            {
                
                DataTable csvTable = new DataTable();
                csvTable.Load(csvReader);

                for(int i=0; i<csvTable.Rows.Count; i++)
                {
                    List <Tuple<string, Point>> l = new List<Tuple<string, Point>>();

                    for (int j=0;j<csvTable.Columns.Count;j++)
                    {
                        l.Add(new Tuple<string,Point>(csvTable.Rows[i][j].ToString(), location[csvTable.Columns[j].ColumnName]));
                        
                    }
                    output.Add(l);
                    
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
                //MessageBox.Show("HERE"+lbl.Text+ lbl.Location.X+ lbl.Location.Y);

            }
            return locations;

        }


    }
}
