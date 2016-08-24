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

namespace PrograIV_Examen_PT132129
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Show dialog to recibe file
            DialogResult result = openFileDialog1.ShowDialog();

            string file = openFileDialog1.FileName;

            DataTable tbl = new DataTable();

            MessageBox.Show(file);

            string texto;

            string[] split = null;

            int count = 4;

            var encoding = Encoding.UTF8;

            StreamReader tr = new StreamReader(file, Encoding.Default, true);

            //var content = File.ReadAllText(file, encoding);
            
            while ((texto = tr.ReadLine()) != null)
            {                        
                //this.textBoxPwd.Text += texto;                        
                split = texto.Split(new Char[] { ',' }, count);                        
                dataGridView1.Rows.Add(split[0], split[1], split[2], split[3]);                        
                split = null;                    
            }                        
            
            MessageBox.Show("Le archivo se cargo correctamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }
    }
}
