using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrograIV_Examen_PT132129
{
    public partial class AddData : Form
    {
        public AddData()
        {
            InitializeComponent();
        }

        //Bandera publica si todos los datos estan correctos
        public bool bandera = true;
        string nombre = "", apellido ="";
        int edad = 0;
        double estatura =0;

        public string getname() {
            return nombre;
        }

        public string getLastName()
        {
            return apellido;
        }

        public int getAge()
        {
            return edad;
        }

        public double getHeight()
        {
            return estatura;
        }

        public bool getFlag()
        {
            return bandera;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Bandera por defecto true,. si en algun obtener valor encuentra error 
            bandera = true;

            //Validamos y obtenemos los valores
            nombre = TxtNotNull(txtNombre);
            apellido = TxtNotNull(txtApellido);
            edad = getInteger(txtEdad);
            estatura = obtener_valor(txtEstatura);

            if (bandera)
            {
                

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

        private void AddData_Load(object sender, EventArgs e)
        {

        }
    }
}
