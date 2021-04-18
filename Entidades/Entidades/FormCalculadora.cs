using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Al cargar el programa, las cajas de texto se comienzan en 0, el comboBox del operador en +, y el lblresultado en 0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            cmbOperador.Text = "+";
            lblResultado.Text = "0";
        }

        /// <summary>
        /// Cierra el programa con this.Close();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Iguala todas las cajas de texto, y el label del resultado a 0, y el comboBox del operador a +.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            cmbOperador.Text = "+";
            lblResultado.Text = "0";
        }

        /// <summary>
        /// Al hacer clic en el boton de Operar, se crean dos nuevas instancias de Numero de acuerdo a las cajas de texto,
        /// y se iguala el operador a la caja del comboOperador. Luego, ocurre la función Operar. En caso que Operar haya re-
        /// tornado MaxValue, el lblResultado va a mostrar "Error", en caso que Operar haya retornado MinValue, el lblResulta-
        /// do va a mostrar "No existe dividir por 0.".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonOperar_Click(object sender, EventArgs e)
        {
            Numero num1 = new Numero(txtNumero1.Text);
            Numero num2 = new Numero(txtNumero2.Text);
            string op = cmbOperador.Text;

            double res = Calculadora.Operar(num1, num2, op);

            if(res == double.MaxValue)
            {
                lblResultado.Text = "Error";
            }
            else if(res == double.MinValue)
            {
                lblResultado.Text = "No existe dividir por 0."; 
            }
            else
            {
                lblResultado.Text = Convert.ToString(res);
            }

            //Calculadora.Operar(num1, num2, op);
        }

        /// <summary>
        /// Clic en Decimal a Binario hace que ocurra la función Numero.DecimalBinario, y verifica si es un numero correcto
        /// con TryParse. En caso en que no sea un número correcto, mostrará un mensaje de error "Valor inválido".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonConvertirABinario_Click(object sender, EventArgs e)
        {
            int num;
            if(Int32.TryParse(lblResultado.Text, out num))
            {
                lblResultado.Text = Numero.DecimalBinario(Convert.ToDouble(num));
            }
            else
            {
                lblResultado.Text = "Valor inválido";
            }
        }

        /// <summary>
        /// Clic en BinarioDecimal convierte el número del lblResultado a decimal a través de la función BinarioDecimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }
    }
}
