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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

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

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            int num;
            if (Int32.TryParse(lblResultado.Text, out num))
            {
                lblResultado.Text = Operando.DecimalBinario(Convert.ToDouble(num));
            }
            else
            {
                lblResultado.Text = "Valor invalido";
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.SelectedIndex = 0;
            lblResultado.Text = "0";
        }


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
