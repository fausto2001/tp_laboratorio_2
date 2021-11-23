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

namespace AeronaveForm
{
    //EModo agregar modificar se utiliza para saber si el FormAgregarModificar que está abriendo el usuario es para agregar una
    //aeronave nueva, o si es para modificar una ya previamente existente.
    public enum EModo
    {
        Agregar,
        Modificar
    }

    public partial class FormAgregarModificar : Form
    {
        //Declaro todas las variables de una aeronave.
        private string marca;
        private string modelo;
        private int velocidadMaxima;
        private int alturaMaxima;
        private float peso;
        private float largo;
        private float ancho;
        private int anio;
        private int rotores;
        private EHelicoptero tipoHelicoptero;
        private EMotores motores;
        private EAvion tipo;
        private int capacidadAire;
        private int pasajeros;

        //Creo una aeronave.
        public Aeronave aeronave;

        private bool bSave = false;
        


        public bool BSave
        {
            set { this.bSave = value; }
            get { return this.bSave; }
        }


        /// <summary>
        /// El constructor del FormAgregarModificar recibe el EModo (agregar o modificar), y un parámetro por defecto, que si no se
        /// llama en el constructor, se crea automáticamente en null. Si el EModo es agregar, entonces se abre el form por defecto,
        /// sino verifica qué tipo es, y settea todos los datos de la aeronave dada a cada uno de los elementos del form (nombre, 
        /// modelo, altura, etc.).
        /// </summary>
        /// <param name="modo"></param>
        /// <param name="aeronave"></param>
        public FormAgregarModificar(EModo modo, Aeronave aeronave = null)
        {
            InitializeComponent();
            if (modo == EModo.Agregar)
            { 
                CMBAeronave.SelectedIndex = 0;
                HideAvion();
                HideGlobo();
                ShowHelicoptero();
            }
            else
            {
                this.aeronave = aeronave;
                if(aeronave is Helicoptero)
                {
                    HideAvion();
                    HideGlobo();
                    ShowHelicoptero();
                    CMBAeronave.SelectedIndex = 0;

                    TXTMarca.Text = aeronave.Marca;

                    TXTModelo.Text = aeronave.Modelo;

                    trackVelocidad.Value = (int)aeronave.VelocidadMaxima;
                    lblTrackVelocidad.Text = trackVelocidad.Value + " km/h ";

                    trackAltura.Value = (int)aeronave.AlturaMaxima;
                    lblTrackAltura.Text = trackAltura.Value + " m ";

                    lblTrackPeso.Text = (float)aeronave.Peso + " kg ";

                    lblTrackAncho.Text = (float)aeronave.Ancho + " m ";

                    lblTrackLargo.Text = (float)aeronave.Largo + " m ";

                    txtAnio.Text = Convert.ToString(aeronave.Anio);
                }
                else if(aeronave is Avion)
                {
                    HideGlobo();
                    HideHelicoptero();
                    ShowAvion();
                    CMBAeronave.SelectedIndex = 1;
                    TXTMarca.Text = aeronave.Marca;
                    TXTModelo.Text = aeronave.Modelo;

                    trackVelocidad.Value = (int)aeronave.VelocidadMaxima;
                    lblTrackVelocidad.Text = trackVelocidad.Value + " km/h ";

                    trackAltura.Value = (int)aeronave.AlturaMaxima;
                    lblTrackAltura.Text = trackAltura.Value + " m ";

                    lblTrackPeso.Text = (float)aeronave.Peso + " kg ";

                    lblTrackAncho.Text = (float)aeronave.Ancho + " m ";

                    lblTrackLargo.Text = (float)aeronave.Largo + " m ";

                    txtAnio.Text = Convert.ToString(aeronave.Anio);
                }
                else
                {
                    HideAvion();
                    HideHelicoptero();
                    ShowGlobo();
                    CMBAeronave.SelectedIndex = 2;

                    TXTMarca.Text = aeronave.Marca;

                    TXTModelo.Text = aeronave.Modelo;

                    trackVelocidad.Value = (int)aeronave.VelocidadMaxima;
                    lblTrackVelocidad.Text = trackVelocidad.Value + " km/h ";

                    trackAltura.Value = (int)aeronave.AlturaMaxima;
                    lblTrackAltura.Text = trackAltura.Value + " m ";

                    lblTrackPeso.Text = (float)aeronave.Peso + " kg ";

                    lblTrackAncho.Text = (float)aeronave.Ancho + " m ";

                    lblTrackLargo.Text = (float)aeronave.Largo + " m ";

                    txtAnio.Text = Convert.ToString(aeronave.Anio);
                }
            }

        }

        /// <summary>
        /// Si el índice del comboBox que indica Avion, Helicoptero, y Globo cambia, llamo a las funciones que ocultan los otros
        /// tipos, y la que la muestra el tipo actualmente elegido.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CMBAeronave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CMBAeronave.SelectedIndex == 0)
            {
                HideAvion();
                HideGlobo();
                ShowHelicoptero();
            }
            else if(CMBAeronave.SelectedIndex == 1)
            {
                HideHelicoptero();
                HideGlobo();
                ShowAvion();
            }
            else
            {
                HideHelicoptero();
                HideAvion();
                ShowGlobo();
            }
        }

        private void FormAgregarModificar_Load(object sender, EventArgs e)
        {

        }

        //Todos los trackers para que el texto quede igual al valor que está siendo elegido. En el caso de largo y ancho, tengo
        //que dividir el valor elegido en el tracker por 100 porque no acepta float el tracker.

        private void trackVelocidad_Scroll(object sender, EventArgs e)
        {
            lblTrackVelocidad.Text = trackVelocidad.Value + " km/h ";
        }

        private void trackAltura_Scroll(object sender, EventArgs e)
        {
            lblTrackAltura.Text = trackAltura.Value + " m ";
        }

        private void trackLargo_Scroll(object sender, EventArgs e)
        {
            lblTrackLargo.Text = (float)trackLargo.Value / 100 + " m ";
        }

        private void trackAncho_Scroll(object sender, EventArgs e)
        {
            lblTrackAncho.Text = (float)trackAncho.Value / 100 + " m ";
        }

        /// <summary>
        /// El trackPeso verifica si el índice elegido de motor es de Jet o no. Si no es de Jet, verifica si es menor
        /// a 5670 kg (valor en el que normalmente se hace la diferencia entre un avión ligero y uno no ligero), y decide si el 
        /// tipo del avión que está siendo creado o modificado es ligero o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackPeso_Scroll(object sender, EventArgs e)
        {
            lblTrackPeso.Text = trackPeso.Value + " kg ";
            if(cmbMotor.SelectedIndex != 0)
            {
                if(trackPeso.Value < 5670)
                {
                    lblTipoAvion.Text = EAvion.Ligero.ToString();
                    tipo = EAvion.Ligero;
                }
                else
                {
                    lblTipoAvion.Text = EAvion.Comercial.ToString();
                    tipo = EAvion.Comercial;
                }
            }
        }

        /// <summary>
        /// Cuando el usuario cambia el comboBox de motor, si el índice seleccionado es el del motor de reacción, entonces el
        /// avión se pone automáticamente en tipo jet. Sino, verifica si el peso del avión es menor a 5670 kg (valor en el que 
        /// normalmente se hace la diferencia entre un avión ligero y uno no ligero), y si es así, iguala el tipo a Ligero, sino
        /// lo iguala a Comercial, y lo muestra en el lblTipoAvion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMotor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMotor.SelectedIndex == 0)
            {
                lblTipoAvion.Text = EAvion.Jet.ToString();
                tipo = EAvion.Jet;
            }
            else if (trackPeso.Value < 5670)
            {
                lblTipoAvion.Text = EAvion.Ligero.ToString();
                tipo = EAvion.Ligero;
            }
            else
            {
                lblTipoAvion.Text = EAvion.Comercial.ToString();
                tipo = EAvion.Comercial;
            }
        }

        private void trackCapacidadAire_Scroll(object sender, EventArgs e)
        {
            lblTrackCapacidadAire.Text = trackCapacidadAire.Value + " kg ";
        }

        /// <summary>
        /// ShowHelicoptero muestra todas las variables particulares de un helicóptero en el form, y settea todos los trackers.
        /// </summary>
        private void ShowHelicoptero()
        {
            lblRotores.Visible = true;
            lblTipo.Visible = true;
            txtRotores.Visible = true;
            cmbTipo.Visible = true;
            cmbTipo.SelectedIndex = 0;
            TrackersHelicoptero();
        }

        /// <summary>
        /// HideHelicoptero oculta todas las variables particulares de un helicóptero en el form.
        /// </summary>
        private void HideHelicoptero()
        {
            lblRotores.Visible = false;
            lblTipo.Visible = false;
            txtRotores.Visible = false;
            cmbTipo.Visible = false;
        }

        /// <summary>
        /// ShowAvion muestra todas las variables particulares de un avión en el form, y settea todos los trackers.
        /// </summary>
        private void ShowAvion()
        {
            lblMotor.Visible = true;
            cmbMotor.Visible = true;
            lblTipo.Visible = true;
            lblTipoAvion.Visible = true;
            cmbMotor.SelectedIndex = 0;
            TrackersAvion();
        }

        /// <summary>
        /// HideAvion oculta todas las variables particulares de un avión en el form.
        /// </summary>
        private void HideAvion()
        {
            lblMotor.Visible = false;
            cmbMotor.Visible = false;
            lblTipo.Visible = false;
            lblTipoAvion.Visible = false;
        }

        /// <summary>
        /// ShowGlobo muestra todas las variables particulares de un globo en el form, y settea todos los trackers.
        /// </summary>
        private void ShowGlobo()
        {
            lblCapacidadAire.Visible = true;
            trackCapacidadAire.Visible = true;
            lblPasajeros.Visible = true;
            txtPasajeros.Visible = true;
            lblTrackCapacidadAire.Visible = true;
            TrackersGlobo();
        }

        /// <summary>
        /// HideGlobo oculta todas las variables particulares de un globo en el form.
        /// </summary>
        private void HideGlobo()
        {
            lblCapacidadAire.Visible = false;
            trackCapacidadAire.Visible = false;
            lblPasajeros.Visible = false;
            txtPasajeros.Visible = false;
            lblTrackCapacidadAire.Visible = false;
        }


        //Las aeronaves helicoptero, avión, y globo son muy muy diferentes entre sí. Entonces no tendría sentido que el usuario
        //pueda escribir, por ejemplo, un globo que pese 500.000 kg. Es por eso que están todos los trackers de acuerdo a cada
        //tipo de aeronave, para que los datos ingresados por el usuario tengan sentido sí o sí.
        //Los trackers no aceptan float, entonces para poder escribir el largo y ancho de una aeronave con la cantidad de metros
        //y centimetros, divido los valores que están siendo asignados en el tracker por 100.
        private void TrackersHelicoptero()
        {
            trackVelocidad.Minimum = 80;
            trackVelocidad.Maximum = 450;
            trackVelocidad.Value = 80;
            lblTrackVelocidad.Text = trackVelocidad.Value + " km/h ";

            trackAltura.Minimum = 400;
            trackAltura.Maximum = 7600;
            trackAltura.Value = 400;
            lblTrackAltura.Text = trackAltura.Value + " m ";

            trackLargo.Minimum = 600;
            trackLargo.Maximum = 3200;
            trackLargo.Value = 600;
            lblTrackLargo.Text = (float)trackLargo.Value / 100 + " m ";

            trackAncho.Minimum = 100;
            trackAncho.Maximum = 400;
            trackAncho.Value = 100;
            lblTrackAncho.Text = (float)trackAncho.Value / 100 + " m ";

            trackPeso.Minimum = 600;
            trackPeso.Maximum = 7500;
            trackPeso.Value = 600;
            lblTrackPeso.Text = trackPeso.Value + " kg ";
        }

        private void TrackersAvion()
        {
            trackVelocidad.Minimum = 120;
            trackVelocidad.Maximum = 3500;
            trackVelocidad.Value = 120;
            lblTrackVelocidad.Text = trackVelocidad.Value + " km/h ";

            trackAltura.Minimum = 150;
            trackAltura.Maximum = 27000;
            trackAltura.Value = 150;
            lblTrackAltura.Text = trackAltura.Value + " m ";

            trackLargo.Minimum = 400;
            trackLargo.Maximum = 92000;
            trackLargo.Value = 400;
            lblTrackLargo.Text = (float)trackLargo.Value / 100 + " m ";

            trackAncho.Minimum = 100;
            trackAncho.Maximum = 110000;
            trackAncho.Value = 100;
            lblTrackAncho.Text = (float)trackAncho.Value / 100 + " m ";

            trackPeso.Minimum = 160;
            trackPeso.Maximum = 720000;
            trackPeso.Value = 160;
            trackPeso.SmallChange = 200;
            trackPeso.LargeChange = 1000;
            lblTrackPeso.Text = trackPeso.Value + " kg ";
        }

        private void TrackersGlobo()
        {
            trackVelocidad.Minimum = 10;
            trackVelocidad.Maximum = 380;
            trackVelocidad.Value = 10;
            lblTrackVelocidad.Text = trackVelocidad.Value + " km/h ";

            trackAltura.Minimum = 40;
            trackAltura.Maximum = 21000;
            trackAltura.Value = 40;
            lblTrackAltura.Text = trackAltura.Value + " m ";

            trackLargo.Minimum = 700;
            trackLargo.Maximum = 15000;
            trackLargo.Value = 700;
            lblTrackLargo.Text = (float)trackLargo.Value / 100 + " m ";

            trackAncho.Minimum = 500;
            trackAncho.Maximum = 20000;
            trackAncho.Value = 500;
            lblTrackAncho.Text = (float)trackAncho.Value / 100 + " m ";

            trackPeso.Minimum = 250;
            trackPeso.Maximum = 600;
            trackPeso.Value = 250;
            lblTrackPeso.Text = trackPeso.Value + " kg ";

            trackCapacidadAire.Minimum = 300;
            trackCapacidadAire.Maximum = 2000;
            trackPeso.Value = 300;
            lblTrackCapacidadAire.Text = trackCapacidadAire.Value + " kg ";
        }

        /// <summary>
        /// Botón cancelar, cierra el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// El botón guardar intenta validar que las variables de texto no estén vacías, e intenta pasar la variable anio a
        /// int también. Una vez que está todo correctamente verificado, las variables declaradas al comienzo del FormAgregarModificar
        /// que corresponden a las de todas las aeronaves, son igualadas a las que el usuario escribió. Luego se verifican las variables
        /// de texto particulares de cada aeronave (por ejemplo, los rotores de un helicóptero), y una vez que está todo verificado,
        /// se crea una nueva aeronave del tipo indicado, y la variable BSave a true, para luego poder informar al usuario que están
        /// los nuevos datos sin guardar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                anio = Convert.ToInt32(txtAnio.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Escriba un numero en año.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtAnio.Text == "" || TXTMarca.Text == "" || TXTModelo.Text == "")
            {
                MessageBox.Show("Una o más opciones están vacías.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                marca = TXTMarca.Text;
                modelo = TXTModelo.Text;
                velocidadMaxima = trackVelocidad.Value;
                alturaMaxima = trackAltura.Value;
                peso = trackPeso.Value;
                largo = (float)trackLargo.Value / 100;
                ancho = (float)trackAncho.Value / 100;
            }

            if(CMBAeronave.SelectedIndex == 0)
            {
                if(txtRotores.Text == "")
                { 
                    MessageBox.Show("Una o más opciones están vacías.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    rotores = Convert.ToInt32(txtRotores.Text);
                }
                catch(Exception)
                {
                    MessageBox.Show("Escriba un numero en rotores.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tipoHelicoptero = (EHelicoptero)cmbTipo.SelectedIndex;

                aeronave = new Helicoptero(marca, modelo, velocidadMaxima, alturaMaxima, peso, largo,
                    ancho, anio, rotores, tipoHelicoptero);
                BSave = true;
            }

            else if(CMBAeronave.SelectedIndex == 1)
            {
                motores = (EMotores)cmbMotor.SelectedIndex;

                aeronave = new Avion(marca, modelo, velocidadMaxima, alturaMaxima, peso, largo, ancho,
                    anio, tipo, motores);
                BSave = true;
            }

            else if(CMBAeronave.SelectedIndex == 2)
            {
                if(txtPasajeros.Text == "")
                { 
                    MessageBox.Show("Una o más opciones están vacías.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    pasajeros = Convert.ToInt32(txtPasajeros.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Escriba un numero en pasajeros.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                capacidadAire = trackCapacidadAire.Value;

                aeronave = new Globo(marca, modelo, velocidadMaxima, alturaMaxima, peso, largo, ancho,
                    anio, capacidadAire, pasajeros);
                BSave = true;
            }
            this.Close();
        }
    }
}
