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

            //Instant for get file location
            string file = openFileDialog1.FileName;

            //MessageBox.Show(file);

            string texto;

            string[] split = null;

            int count = 4;
            
            //Adding encoding parameters for characters like í 
            StreamReader tr = new StreamReader(file, Encoding.Default, true);
           
            while ((texto = tr.ReadLine()) != null)
            {                        
                //this.textBoxPwd.Text += texto;                        
                split = texto.Split(new Char[] { ',' }, count);                        
                dataGridView1.Rows.Add(split[0], split[1], split[2], split[3]);                        
                split = null;                    
            }                        
            
            MessageBox.Show("Le archivo se cargo correctamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Values for combobox
            comboBox1.Items.Add("Nombre");
            comboBox1.Items.Add("Apellido");
            comboBox1.Items.Add("Edad");
            comboBox1.Items.Add("Estatura");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string metodo;
            string forma;

            //Para determinar el metodo de ordenamiento escogido por el usuario
            if (bsrbtn.Checked)
            {

                //Para determinar la forma de ordenar escodiga por el usuario
                if (asrbtn.Checked)
                {
                    //BubbleSort & Ascendente


                }
                else
                {
                    //BubbleSort & Descendente

                }
            
                
            }
            else 
            {
                //Para determinar la forma de ordenar escodiga por el usuario
                if (asrbtn.Checked)
                {
                    //SelectionSort & Ascendente

                }
                else
                {
                    //SelectionSort & Descendente

                }

            }

        }

    }
}
