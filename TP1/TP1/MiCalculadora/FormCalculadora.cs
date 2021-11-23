using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pregunta al usuario si quiere salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult pregunta = MessageBox.Show("Esta seguro que desea salir?", "Cuidado!", MessageBoxButtons.YesNo);
            if(pregunta == DialogResult.Yes)
            { 
                Application.Exit();
            }
        }

        /// <summary>
        /// Llama a la funcion limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Llama a la funcion operar, si esta funcion devolvio MinValue, muestra que no se puede dividir por 0, si devuelve
        /// MaxValue, muestra "Error". Luego imprime el resultado en el lblResultado y la operacion en el listBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            if (resultado == double.MinValue)
            {
                lblResultado.Text = "No se puede dividir por 0";
            }
            else if (resultado == double.MaxValue)
            {
                lblResultado.Text = "Error";
            }
            else
            {
                lblResultado.Text = Convert.ToString(resultado);
                lstOperaciones.Items.Add(txtNumero1.Text + " " + cmbOperador.Text + " " + txtNumero2.Text + " = " + lblResultado.Text);
            }
        }

        /// <summary>
        /// Llama a la funcion DecimalBinario, y la imprime en el lblResultado y en el lstOperaciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            int num = 0;
            int aux;
            if (Int32.TryParse(lblResultado.Text, out num))
            {
                aux = num;
                lblResultado.Text = Operando.DecimalBinario(Convert.ToDouble(num));
                lstOperaciones.Items.Add(aux + " a binario: " + lblResultado.Text);
            }
            else
            {
                lblResultado.Text = "Valor invalido";
            }
        }

        /// <summary>
        /// Llama a la funcion BinarioDecimal, y la imprime en el lblResultado y en el lstOperaciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string aux = lblResultado.Text;
            lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
            if(lblResultado.Text != "Valor inválido" && lblResultado.Text != "No se admiten negativos")
            {
                lstOperaciones.Items.Add(aux + " a decimal: " + lblResultado.Text);
            }
        }

        /// <summary>
        /// Al cargar la calculadora, llamo a la función limpiar para poder poner todo en 0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        
        /// <summary>
        /// Limpiar borra los txt, pone el operador en '+', y el resultado en 0. No limpia el lstOperaciones porque no lo
        /// pedía, pero por las dudas dejé comentada la función en caso que sea necesario.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = "0";
            //lstOperaciones.Items.Clear();
        }

        /// <summary>
        /// Operar recibe los numeros ingresados y el string, y llama a la función Calculadora.Operar.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);
            double resultado = Calculadora.Operar(num1, num2, Convert.ToChar(operador));
            return resultado;
        }

        //Esta seria mi manera de hacer el Operar previa validación de los valores, igualando los valores incorrectos a MaxValue para
        //que salte el mensaje de error que debería, ya que no me gusta que cuando escriba una letra, se iguale a 0. Si quieren, pueden
        //comentar el Operar anterior, y descomentar este para poder ver que funciona bien. De todas maneras dejé el de arriba para utilizar
        //el constructor que iguala a 0 cuando el valor no es correcto.
        /*
        private static double Operar(string numero1, string numero2, string operador)
        {
            double aux = 0;
            double aux2 = 0;
            double resultado;

            if (!double.TryParse(numero1, out aux))
            {
                aux = Double.MaxValue;
            }
            else if (!double.TryParse(numero2, out aux2))
            {
                aux = Double.MaxValue;
            }

            if (aux == Double.MaxValue)
            {
                resultado = Double.MaxValue;
            }
            else
            {
                Operando num1 = new Operando(aux);
                Operando num2 = new Operando(aux2);
                resultado = Calculadora.Operar(num1, num2, Convert.ToChar(operador));
            }

            return resultado;
        }
        */
    }
}
