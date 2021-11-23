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
using System.Threading;

namespace AeronaveForm
{
    public delegate void DelegadoNombresAeronaves(object param);


    public partial class FormCarrera : Form
    {
        public Aeronave aeronave1;
        public Aeronave aeronave2;
        protected Task thread;
        int time1;
        float total = 0;
        float total2 = 0;

        /// <summary>
        /// Constructor del FormCarrera, que recibe dos aeronaves. El manejador del thread funciona de acuerdo al evento
        /// btnEmpezar.Click.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public FormCarrera(Aeronave a, Aeronave b)
        {
            aeronave1 = a;
            aeronave2 = b;
            InitializeComponent();
            this.Text = "Comparacion en tiempo real!!";
            this.lblAeronave1.Text = a.Marca + " " + a.Modelo;
            this.lblAeronave2.Text = b.Marca + " " + b.Modelo;
            this.btnEmpezar.Click += new System.EventHandler(this.Manejador);
            this.lblDistancia1.Text = "0";
            this.lblDistancia2.Text = "0";
        }


        /// <summary>
        /// Manejador, que corre el thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Manejador(object sender, EventArgs e)
        {
            this.thread = Task.Run(() => this.HacerCarrera(aeronave1));
        }

        /// <summary>
        /// HacerCarrera verifica el invokeRequired de cada uno de los labels que cambia para verificar que se pueda realizar
        /// la operación cross-thread. Luego instancia un nuevo delegado, y lo invoca dentro de un do while, que solo termina
        /// cuando la variable time1, que aumenta de a 10 cada 10 milisegundos (por el Thread.Sleep), llega a 10000 milisegundos.
        /// A medida que va avanzando el time1, hace las cuentas necesarias para poder calcular la cantidad de metros que
        /// recorrieron las aeronaves dadas en la cantidad de milisegundos transcurridos.
        /// </summary>
        /// <param name="param"></param>
        public void HacerCarrera(object param)
        {
            if(this.lblDistancia1.InvokeRequired && this.lblDistancia2.InvokeRequired && this.lblTimer.InvokeRequired)
            {
                bool seguir = true;
                DelegadoNombresAeronaves delegado = new DelegadoNombresAeronaves(this.HacerCarrera);
                time1 = 0;
                do
                {
                    
                    object[] parametro = new object[] { param };
                    time1 += 10;

                    try
                    {
                        this.Invoke(delegado, parametro);
                    }
                    catch (Exception) { } //este catch es necesario para que no tire una exception cuando se cierra el programa
                                          //abruptamente.

                    if (time1 >= 10000)
                    {
                        seguir = false;
                    }

                    Thread.Sleep(10);
                } while (seguir);


            }
            else
            {
                total += ((float)aeronave1.VelocidadMaxima * (float)time1 / 1000) / 1000;
                this.lblDistancia1.Text = total.ToString("0.00") + " m";
                total2 += ((float)aeronave2.VelocidadMaxima * (float)time1 / 1000) / 1000;
                this.lblDistancia2.Text = total2.ToString("0.00") + " m";
                lblTimer.Text = Convert.ToString(time1);
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEmpezar_Click(object sender, EventArgs e)
        {

        }
    }
}
