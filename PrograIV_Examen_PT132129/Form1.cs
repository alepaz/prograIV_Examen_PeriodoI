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

        public void BubbleSort(ref string[] s, ref int[] num) {
            string temp = string.Empty;
            int indiceTemp = 0;

            for (int i = 1; i < s.Length; i++)
                {
                    for (int j = 0; j < s.Length - i; j++)
                    {
                        if (s[j].CompareTo(s[j + 1]) > 0)
                        {
                            indiceTemp = num[j];
                            temp = s[j];

                            num[j] = num[j + 1];
                            s[j] = s[j + 1];

                            num[j + 1] = indiceTemp;
                            s[j + 1] = temp;
                        }
                    }
                }
            for (int i = 0; i < s.Length; i++)
            {
                MessageBox.Show(s[i] + " ");
                MessageBox.Show(num[i] + " ");
            }
            }

        public void BubbleSort(ref int[] s, ref int[] num)
        {
            int temp = 0;
            int indiceTemp = 0;

            for (int i = 1; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length - i; j++)
                {
                    if (s[j].CompareTo(s[j + 1]) > 0)
                    {
                        indiceTemp = num[j];
                        temp = s[j];

                        num[j] = num[j + 1];
                        s[j] = s[j + 1];

                        num[j + 1] = indiceTemp;
                        s[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                MessageBox.Show(s[i] + " ");
                MessageBox.Show(num[i] + " ");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //contador
            int i = 0;
            //arreglos, uno servira de espejo para realizar el merge en la 
            int[] arreglo_numeros = new int[dataGridView1.Rows.Count] ;
            //para almacenar los datos a ordenar
            string[] column0Array = new string[dataGridView1.Rows.Count];
            string[] column1Array = new string[dataGridView1.Rows.Count];
            int[] column2Array = new int[dataGridView1.Rows.Count];
            string[] column3Array = new string[dataGridView1.Rows.Count];

            //Arrays con los datos para limpiar el datagridview
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                column0Array[i] = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : string.Empty;
                MessageBox.Show(column0Array[i].ToString());
                column1Array[i] = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : string.Empty;
                column2Array[i] = row.Cells[2].Value != null ? int.Parse(row.Cells[2].Value.ToString()) : 0;
                column3Array[i] = row.Cells[3].Value != null ? row.Cells[3].Value.ToString() : string.Empty;
                arreglo_numeros[i] = i;
                MessageBox.Show(arreglo_numeros[i].ToString());
                i++;
                
            }

            //Para determinar el metodo de ordenamiento escogido por el usuario
            if (bsrbtn.Checked)
            {

                //Para determinar la forma de ordenar escodiga por el usuario
                if (asrbtn.Checked)
                {

                    BubbleSort(ref column0Array, ref arreglo_numeros);
                    //BubbleSort(ref column0Array);

                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();

                    for (i = 0; i < arreglo_numeros.Length; i++) {
                        dataGridView1.Rows.Add(column0Array[i], column1Array[arreglo_numeros[i]], column2Array[arreglo_numeros[i]], column3Array[arreglo_numeros[i]]);

                    }


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
