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

        //Bandera publica si todos los datos estan correctos
        public bool bandera = true;
        string nombre = "", apellido = "";
        int edad = 0;
        double estatura = 0;

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
            //Al cargar un nuevo archivo se borran todos, pues podria cargar un repetido
            ClearDataGrid();

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
            try
            {
                while ((texto = tr.ReadLine()) != null)
                {
                    //this.textBoxPwd.Text += texto;                        
                    split = texto.Split(new Char[] { ',' }, count);
                    dataGridView1.Rows.Add(split[0], split[1], split[2], split[3]);
                    split = null;
                }

                MessageBox.Show("Le archivo se cargo correctamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch {
                MessageBox.Show("El archivo tiene el formato adecuado?");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Values for combobox
            cbxRegistro.Items.Add("Nombre");
            cbxRegistro.Items.Add("Apellido");
            cbxRegistro.Items.Add("Edad");
            cbxRegistro.Items.Add("Estatura");
        }

        public void BubbleSort(ref string[] s, ref int[] num, bool band) {
            string temp = string.Empty;
            int indiceTemp = 0;
            //Para cambiar los indices

            //Si es ascendentemente
            if (band) { 
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
            }else { //Descendente
            for (int i = 0; i < s.Length - 1; i++)
                for (int j = i + 1; j < s.Length; j++)
                    if (s[i].CompareTo(s[j]) < 0)
                    {
                        indiceTemp = num[i];
                        temp = s[i];

                        num[i] = num[j];
                        s[i] = s[j];

                        num[j] = indiceTemp;
                        s[j] = temp;
                    }
            }
            /*for (int i = 0; i < s.Length; i++)
            {
                MessageBox.Show(s[i] + " ");
                MessageBox.Show(num[i] + " ");
            }*/
        }

        public void SelectionSort(ref string[] s, ref int[] num, bool band)
        {
            string temp = string.Empty;
            int indiceTemp = 0;
            int pos_min;
            //Para cambiar los indices

            //Si es ascendentemente
            if (band)
            {
                for (int i = 0; i < s.Length - 1; i++)
                {
                    pos_min = i; //set pos_min to the current index of array

                    for (int j = i + 1; j < s.Length; j++)
                    {
                        // We now use 'CompareTo' instead of '<'
                        if (s[j].CompareTo(s[pos_min]) < 0)
                        {
                            //pos_min will keep track of the index that min is in, this is needed when a swap happens
                            pos_min = j;
                        }
                    }

                    //if pos_min no longer equals i than a smaller value must have been found, so a swap must occur
                    if (pos_min != i)
                    {
                        indiceTemp = num[i];
                        temp = s[i];

                        num[i] = num[pos_min];
                        s[i] = s[pos_min];

                        num[pos_min] = indiceTemp;
                        s[pos_min] = temp;
                    }
                }
            }
            else
            { //Descendente

                for (int i = 0; i < s.Length - 1; i++)
                {
                    int maxIndex = i;
                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (s[j].CompareTo(s[maxIndex]) > 0) maxIndex = j;
                    }

                    //Swap for i and index
                    indiceTemp = num[i];
                    temp = s[i];

                    num[i] = num[maxIndex];
                    s[i] = s[maxIndex];

                    num[maxIndex] = indiceTemp;
                    s[maxIndex] = temp;
                }

            }
            /*for (int i = 0; i < s.Length; i++)
            {
                MessageBox.Show(s[i] + " ");
                MessageBox.Show(num[i] + " ");
            }*/
        }

        public void ClearDataGrid() {
            //Limpiamos y refrescamos
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
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
            string[] column2Array = new string[dataGridView1.Rows.Count];
            string[] column3Array = new string[dataGridView1.Rows.Count];

            //Arrays con los datos para limpiar el datagridview
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                column0Array[i] = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : string.Empty;
                column1Array[i] = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : string.Empty;
                column2Array[i] = row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : string.Empty;
                column3Array[i] = row.Cells[3].Value != null ? row.Cells[3].Value.ToString() : string.Empty;
                arreglo_numeros[i] = i;
                i++;
                
            }

            //Para determinar el metodo de ordenamiento escogido por el usuario
            if (bsrbtn.Checked)
            {

                //Para determinar la forma de ordenar escodiga por el usuario
                if (asrbtn.Checked)
                {

                    try
                    {

                        switch (cbxRegistro.SelectedItem.ToString())
                        {
                            case "Nombre":
                                BubbleSort(ref column0Array, ref arreglo_numeros, true);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByNameUsingBubbleSortAscend.txt", true)) {

                                    //En caso que sea ordenado por nombre
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[i] + " , " + column1Array[arreglo_numeros[i]] + " , " + column2Array[arreglo_numeros[i]] + " , " + column3Array[arreglo_numeros[i]]);
                                        dataGridView1.Rows.Add(column0Array[i], column1Array[arreglo_numeros[i]], column2Array[arreglo_numeros[i]], column3Array[arreglo_numeros[i]]);

                                    }
                                }

                                break;
                            case "Apellido":
                                BubbleSort(ref column1Array, ref arreglo_numeros, true);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByLastNameUsingBubbleSortAscend.txt", true))
                                {


                                    //En caso que sea ordenado por apellido
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[arreglo_numeros[i]] + " , " + column1Array[i] + " , " + column2Array[arreglo_numeros[i]] + " , " + column3Array[arreglo_numeros[i]]);
                                        dataGridView1.Rows.Add(column0Array[arreglo_numeros[i]], column1Array[i], column2Array[arreglo_numeros[i]], column3Array[arreglo_numeros[i]]);

                                    }
                                }
                                break;
                            case "Edad":

                                BubbleSort(ref column2Array, ref arreglo_numeros, true);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByAgeUsingBubbleSortAscend.txt", true))
                                {

                                    //En caso que sea ordenado por edad
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[arreglo_numeros[i]] + " , " + column1Array[arreglo_numeros[i]] + " , " + column2Array[i] + " , " + column3Array[arreglo_numeros[i]]);
                                        dataGridView1.Rows.Add(column0Array[arreglo_numeros[i]], column1Array[arreglo_numeros[i]], column2Array[i], column3Array[arreglo_numeros[i]]);

                                    }
                                }
                                break;
                            case "Estatura":
                                BubbleSort(ref column3Array, ref arreglo_numeros, true);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByHeightUsingBubbleSortAscend.txt", true))
                                {

                                    //En caso que sea ordenado por altura
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[arreglo_numeros[i]] + " , " + column1Array[arreglo_numeros[i]] + " , " + column2Array[arreglo_numeros[i]] + " , " + column3Array[i]);
                                        dataGridView1.Rows.Add(column0Array[arreglo_numeros[i]], column1Array[arreglo_numeros[i]], column2Array[arreglo_numeros[i]], column3Array[i]);

                                    }
                                }
                                break;
                            default:
                                MessageBox.Show("opcion incorrecta");
                                break;
                        }

                    }
                    catch {
                        MessageBox.Show("Por favor seleccione el dato por el que desea ordenarlo");
                    }
                }
                else
                {
                    //BubbleSort & Descendente
                    try
                    {

                        switch (cbxRegistro.SelectedItem.ToString())
                        {
                            case "Nombre":
                                BubbleSort(ref column0Array, ref arreglo_numeros, false);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByNameUsingBubbleSortDescend.txt", true))
                                {

                                    //En caso que sea ordenado por nombre
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[i] + " , " + column1Array[arreglo_numeros[i]] + " , " + column2Array[arreglo_numeros[i]] + " , " + column3Array[arreglo_numeros[i]]);
                                        dataGridView1.Rows.Add(column0Array[i], column1Array[arreglo_numeros[i]], column2Array[arreglo_numeros[i]], column3Array[arreglo_numeros[i]]);

                                    }
                                }

                                    break;
                            case "Apellido":
                                BubbleSort(ref column1Array, ref arreglo_numeros, false);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByLastNameUsingBubbleSortDescend.txt", true))
                                {

                                    //En caso que sea ordenado por apellido
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[arreglo_numeros[i]] + " , " + column1Array[i] + " , " + column2Array[arreglo_numeros[i]] + " , " + column3Array[arreglo_numeros[i]]);
                                        dataGridView1.Rows.Add(column0Array[arreglo_numeros[i]], column1Array[i], column2Array[arreglo_numeros[i]], column3Array[arreglo_numeros[i]]);

                                    }
                                }
                                break;
                            case "Edad":

                                BubbleSort(ref column2Array, ref arreglo_numeros, false);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByAgeUsingBubbleSortDescend.txt", true))
                                {

                                    //En caso que sea ordenado por edad
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[arreglo_numeros[i]] + " , " + column1Array[arreglo_numeros[i]] + " , " + column2Array[i] + " , " + column3Array[arreglo_numeros[i]]);
                                        dataGridView1.Rows.Add(column0Array[arreglo_numeros[i]], column1Array[arreglo_numeros[i]], column2Array[i], column3Array[arreglo_numeros[i]]);

                                    }
                                }
                                break;
                            case "Estatura":
                                BubbleSort(ref column3Array, ref arreglo_numeros, false);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByHeightUsingBubbleSortDescend.txt", true))
                                {

                                    //En caso que sea ordenado por altura
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[arreglo_numeros[i]] + " , " + column1Array[arreglo_numeros[i]] + " , " + column2Array[arreglo_numeros[i]] + " , " + column3Array[i]);
                                        dataGridView1.Rows.Add(column0Array[arreglo_numeros[i]], column1Array[arreglo_numeros[i]], column2Array[arreglo_numeros[i]], column3Array[i]);

                                    }
                                }
                                break;
                            default:
                                MessageBox.Show("opcion incorrecta");
                                break;
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Por favor seleccione el dato por el que desea ordenarlo");
                    }

                }
            
                
            }
            else 
            {
                //Para determinar la forma de ordenar escodiga por el usuario
                if (asrbtn.Checked)
                {
                    //SelectionSort & Ascendente

                    try
                    {

                        switch (cbxRegistro.SelectedItem.ToString())
                        {
                            case "Nombre":
                                SelectionSort(ref column0Array, ref arreglo_numeros, true);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByNameUsingSelectionSortAscend.txt", true))
                                {

                                    //En caso que sea ordenado por nombre
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[i] + " , " + column1Array[arreglo_numeros[i]] + " , " + column2Array[arreglo_numeros[i]] + " , " + column3Array[arreglo_numeros[i]]);
                                        dataGridView1.Rows.Add(column0Array[i], column1Array[arreglo_numeros[i]], column2Array[arreglo_numeros[i]], column3Array[arreglo_numeros[i]]);

                                    }
                                }

                                break;
                            case "Apellido":
                                SelectionSort(ref column1Array, ref arreglo_numeros, true);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByLastNameUsingSelectionSortAscend.txt", true))
                                {


                                    //En caso que sea ordenado por apellido
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[arreglo_numeros[i]] + " , " + column1Array[i] + " , " + column2Array[arreglo_numeros[i]] + " , " + column3Array[arreglo_numeros[i]]);
                                        dataGridView1.Rows.Add(column0Array[arreglo_numeros[i]], column1Array[i], column2Array[arreglo_numeros[i]], column3Array[arreglo_numeros[i]]);

                                    }
                                }
                                break;
                            case "Edad":

                                SelectionSort(ref column2Array, ref arreglo_numeros, true);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByAgeUsingSelectionSortAscend.txt", true))
                                {

                                    //En caso que sea ordenado por edad
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[arreglo_numeros[i]] + " , " + column1Array[arreglo_numeros[i]] + " , " + column2Array[i] + " , " + column3Array[arreglo_numeros[i]]);
                                        dataGridView1.Rows.Add(column0Array[arreglo_numeros[i]], column1Array[arreglo_numeros[i]], column2Array[i], column3Array[arreglo_numeros[i]]);

                                    }
                                }
                                break;
                            case "Estatura":
                                SelectionSort(ref column3Array, ref arreglo_numeros, true);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByHeightUsingSelectionSortAscend.txt", true))
                                {

                                    //En caso que sea ordenado por altura
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[arreglo_numeros[i]] + " , " + column1Array[arreglo_numeros[i]] + " , " + column2Array[arreglo_numeros[i]] + " , " + column3Array[i]);
                                        dataGridView1.Rows.Add(column0Array[arreglo_numeros[i]], column1Array[arreglo_numeros[i]], column2Array[arreglo_numeros[i]], column3Array[i]);

                                    }
                                }
                                break;
                            default:
                                MessageBox.Show("opcion incorrecta");
                                break;
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Por favor seleccione el dato por el que desea ordenarlo");
                    }


                }
                else
                {
                    //SelectionSort & Descendente

                    try
                    {

                        switch (cbxRegistro.SelectedItem.ToString())
                        {
                            case "Nombre":
                                SelectionSort(ref column0Array, ref arreglo_numeros, false);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByNameUsingSelectionSortDescend.txt", true))
                                {

                                    //En caso que sea ordenado por nombre
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[i] + " , " + column1Array[arreglo_numeros[i]] + " , " + column2Array[arreglo_numeros[i]] + " , " + column3Array[arreglo_numeros[i]]);
                                        dataGridView1.Rows.Add(column0Array[i], column1Array[arreglo_numeros[i]], column2Array[arreglo_numeros[i]], column3Array[arreglo_numeros[i]]);

                                    }
                                }

                                break;
                            case "Apellido":
                                SelectionSort(ref column1Array, ref arreglo_numeros, false);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByLastNameUsingSelectionSortDescend.txt", true))
                                {

                                    //En caso que sea ordenado por apellido
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[arreglo_numeros[i]] + " , " + column1Array[i] + " , " + column2Array[arreglo_numeros[i]] + " , " + column3Array[arreglo_numeros[i]]);
                                        dataGridView1.Rows.Add(column0Array[arreglo_numeros[i]], column1Array[i], column2Array[arreglo_numeros[i]], column3Array[arreglo_numeros[i]]);

                                    }
                                }
                                break;
                            case "Edad":

                                SelectionSort(ref column2Array, ref arreglo_numeros, false);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByAgeUsingSelectionSortDescend.txt", true))
                                {

                                    //En caso que sea ordenado por edad
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[arreglo_numeros[i]] + " , " + column1Array[arreglo_numeros[i]] + " , " + column2Array[i] + " , " + column3Array[arreglo_numeros[i]]);
                                        dataGridView1.Rows.Add(column0Array[arreglo_numeros[i]], column1Array[arreglo_numeros[i]], column2Array[i], column3Array[arreglo_numeros[i]]);

                                    }
                                }
                                break;
                            case "Estatura":
                                SelectionSort(ref column3Array, ref arreglo_numeros, false);

                                //Limpiamos el datagridview
                                ClearDataGrid();

                                //Creacion del archivo
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\SorterByHeightUsingSelectionSortDescend.txt", true))
                                {

                                    //En caso que sea ordenado por altura
                                    for (i = 0; i < arreglo_numeros.Length; i++)
                                    {
                                        file.WriteLine(column0Array[arreglo_numeros[i]] + " , " + column1Array[arreglo_numeros[i]] + " , " + column2Array[arreglo_numeros[i]] + " , " + column3Array[i]);
                                        dataGridView1.Rows.Add(column0Array[arreglo_numeros[i]], column1Array[arreglo_numeros[i]], column2Array[arreglo_numeros[i]], column3Array[i]);

                                    }
                                }
                                break;
                            default:
                                MessageBox.Show("opcion incorrecta");
                                break;
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Por favor seleccione el dato por el que desea ordenarlo");
                    }

                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        { }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //contador
            int contadora = 0;

            //Bandera por defecto true,. si en algun obtener valor encuentra error 
            bandera = true;

            //Validamos y obtenemos los valores
            nombre = TxtNotNull(txtNombre);
            apellido = TxtNotNull(txtApellido);
            edad = getInteger(txtEdad);
            estatura = obtener_valor(txtEstatura);

            if (bandera)
            {
                dataGridView1.Rows.Add(nombre, apellido, edad, estatura);

                int count = dataGridView1.Rows.Count;

                //Creacion del archivo
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TEMP\datos.txt", true))
                {
                    
                    for (int row = 0; row < count; row++)
                    {
                        int colCount = dataGridView1.Rows[row].Cells.Count;
                        for (int col = 0; col < colCount; col++)
                        {
                            if(contadora > 0) { 
                            file.Write(" , ");
                            }
                            file.Write(dataGridView1.Rows[row].Cells[col].Value.ToString());
                            contadora++;
                        }

                        //no iria coma a continuacion
                        contadora = 0;

                        file.WriteLine();
                        // record seperator could be written here.
                    }

                }
            }

            limpiar_pantalla();
        }

        public void limpiar_pantalla()
        {
            //Para limpiar los textboxs

            txtApellido.Text = "";
            txtEdad.Text = "";
            txtEstatura.Text = "";
            txtNombre.Text = "";

        }

        public string TxtNotNull(TextBox t1)
        { //Para transformar lo que se digite en el textbox a formato
            //numerico
            string valor = "";

            //Si el control esta vacio
            if (t1.Text.Length > 0)
            {
                valor = t1.Text;
            }
            else
            {
                bandera = false;
                MessageBox.Show("El control se encuentra vacio");
            }

            return valor;

        }

        public int getInteger(TextBox t1)
        { //Para transformar lo que se digite en el textbox a formato
            //numerico
            int valor = 0;

            //Si el control esta vacio
            if (t1.Text.Length > 0)
            {
                //Si el control tiene caracteres
                if (int.TryParse(t1.Text, out valor))
                {
                    if (double.Parse(t1.Text) >= 0)
                    {
                        valor = Convert.ToInt32(t1.Text);
                    }
                    else
                    {
                        bandera = false;
                        MessageBox.Show("El valor debe >=0");
                    }
                }
                else
                {
                    bandera = false;
                    MessageBox.Show("El valor debe ser numerico");
                }

            }
            else
            {
                bandera = false;
                MessageBox.Show("El control se encuentra vacio");
            }

            return valor;

        }

        public double obtener_valor(TextBox t1)
        { //Para transformar lo que se digite en el textbox a formato
            //numerico
            double valor = 0;

            //Si el control esta vacio
            if (t1.Text.Length > 0)
            {
                //Si el control tiene caracteres
                if (double.TryParse(t1.Text, out valor))
                {
                    if (double.Parse(t1.Text) >= 0)
                    {
                        valor = Convert.ToDouble(t1.Text);
                    }
                    else
                    {
                        bandera = false;
                        MessageBox.Show("El valor debe >=0");
                    }
                }
                else
                {
                    bandera = false;
                    MessageBox.Show("El valor debe ser numerico");
                }

            }
            else
            {
                bandera = false;
                MessageBox.Show("El control se encuentra vacio");
            }

            return valor;

        }
    }
}
