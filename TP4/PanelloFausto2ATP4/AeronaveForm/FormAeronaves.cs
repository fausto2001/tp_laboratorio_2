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
    /// <summary>
    /// Form con el que se abre el programa, en el que se puede ver una lista de aeronaves, y los botones agregar, modificar, y
    /// eliminar, además de los de guardar, cargar, y análisis.
    /// </summary>
    public partial class FormAeronaves : Form
    {
        /// <summary>
        /// La variable MiLista es la que crea la lista de aeronaves, y es la que se desplega en el listBox.
        /// La variable ListaFile la uso para las funciones de guardar y cargar. Comienza en null.
        /// La variable bSave la uso para poder saber si el usuario tiene los datos que fue modificando guardados o sin guardar.
        /// La variable aux la uso para poder poner los contenidos de listaFile en la misma en algunos eventos.
        /// </summary>
        public Lista<Aeronave> MiLista;
        public string listaFile = null;
        private bool bSave = true;
        private string aux;

        /// <summary>
        /// Al comenzar el programa, se crea una lista de aeronaves con una capacidad por defecto de 50, y trae los datos de las
        /// aeronaves que haya en un servidor SQL.
        /// </summary>
        public FormAeronaves()
        {
            MiLista = new Lista<Aeronave>(50);
            AccesoDatos accesoDatos = new AccesoDatos();
            MiLista = accesoDatos.TraerDatos();
            InitializeComponent();
            CargarLista();
        }

        /// <summary>
        /// El boton guardar se fija que listaFile no esté vacía, que bSave esté en true (sino, no hay datos para guardar), y
        /// advierte al usuario si está guardando una lista vacía. Una vez que acepta guardar, llama a la función GuardarLista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            SelectFile();

            if(listaFile != "")
            { 
                if(!bSave)
                {
                    if(MiLista.Elementos.Count == 0)
                    {
                        if (MessageBox.Show("Esta guardando una lista vacía, desea guardar de todas maneras?", 
                            "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            GuardarLista();
                        }
                    }
                    else if (MessageBox.Show("Desea Guardar?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) 
                        == DialogResult.Yes)
                    {
                        GuardarLista();
                    }
                }
                else
                {
                    MessageBox.Show("No hay cambios que guardar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// El boton cargar abre un nuevo fileDialog con la función ShowDialog. Luego utilizo la variable previamente declarada
        /// aux para poner los datos de lista file ahí dentro, y luego reemplazo los de listaFile con los de la fileName elegida
        /// en la función ShowDialog. Si el nuevo listaFile no se puede cargar, entonces vuelvo a sobrescribir los datos de la
        /// variable con los que estaban previamente en el aux. Si no hay problema con eso, pregunta al usuario si desea cargar,
        /// y si acepta, finalmente llama a la función Load de la clase genérica Lista. Si todo funciona bien, llama a CargarLista,
        /// sino, se muestra un mensaje de error. Si se puede cargar todo, entonces se agregan a la base de datos SQL todas las
        /// aeronaves cargadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCargar_Click(object sender, EventArgs e)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            OpenFileDialog fd = new OpenFileDialog();

            fd.ShowDialog();

            aux = listaFile;
            listaFile = "";
            listaFile = fd.FileName;

            if(listaFile != "")
            { 
                if (MessageBox.Show("Desea Cargar?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string load = MiLista.Load(listaFile, 50, out MiLista);

                    foreach(Aeronave aeronave in MiLista.Elementos)
                    {
                        if(aeronave is Avion)
                        {
                            accesoDatos.AgregarAvion((Avion)aeronave);
                        }
                        else if(aeronave is Helicoptero)
                        {
                            accesoDatos.AgregarHelicoptero((Helicoptero)aeronave);
                        }
                        else
                        {
                            accesoDatos.AgregarGlobo((Globo)aeronave);
                        }
                    }

                    if (load == "")
                    {
                        CargarLista();
                    }
                    else
                    {
                        listaFile = aux;
                        MessageBox.Show("Error al cargar el archivo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    listaFile = aux;
                }
            }
            else
            {
                listaFile = aux;
            }
        }

        /// <summary>
        /// La función SelectFile es llamada en el evento del click del botón Guardar. Primero se fija que listaFile no sea null
        /// o empty, y que haya espacio en la lista. Luego crea una nueva SaveFileDialog, y antes de mostrarla con ShowDialog,
        /// procede a escribir el filtro que indica al usuario que debe ser una XML file la que se va a guardar, y además le agrega
        /// la extensión xml a la misma.
        /// </summary>
        private void SelectFile()
        {
            if (string.IsNullOrEmpty(listaFile) && MiLista.Elementos.Count >= 0)
            {
                SaveFileDialog sf = new SaveFileDialog();

                sf.Filter = "XML Files (*.xml)|*.xml";
                sf.DefaultExt = "xml";
                sf.AddExtension = true;
                sf.ShowDialog();

                listaFile = sf.FileName;
            }
        }

        /// <summary>
        /// GuardarLista llama a la función Save, y escribe en el título del forms el path de dónde se guardó, además de poner la
        /// variable bSave en true.
        /// </summary>
        private void GuardarLista()
        {
            MiLista.Save(listaFile, MiLista);
            this.Text = "Lista: " + listaFile;
            bSave = true;
        }

        /// <summary>
        /// La función CargarLista borra todos los ítems de la listBox de aeronaves, y los reescribe con la nueva lista cargada.
        /// Además, pone en el título del form el path de la lista actual, y la variable bSave en true.
        /// </summary>
        private void CargarLista()
        {
            LBAeronaves.Items.Clear();
            foreach (Aeronave a in MiLista.Elementos)
            {
                LBAeronaves.Items.Add(a.Descripcion());
            }
            this.Text = "Lista: " + listaFile;
            bSave = true;
        }

        /// <summary>
        /// Al hacer clic en el botón eliminar, se le pregunta al usuario si quiere realmente remover la aeronave, y luego de
        /// que ponga Yes, busca la aeronave en el índice seleccionado de la listBox, y la remueve con la función Remover de la
        /// clase genérica MiLista. Luego llama a la función CargarLista para poder remover todos los ítems de la listbox, y se
        /// informa al usuario que está sin guardar si había una lista previamente cargada, agregándolo en el título del form.
        /// Si se puede eliminar, elimina de SQL la aeronave elegida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (LBAeronaves.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Desea Remover la aeronave?", "Atencion", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Aeronave aeronave = MiLista.Elementos[LBAeronaves.SelectedIndex];
                    this.MiLista.Remover(aeronave);
                    AccesoDatos accesoDatos = new AccesoDatos();

                    if(aeronave is Avion)
                    {
                        accesoDatos.EliminarAvion(aeronave.Modelo);
                    }
                    else if(aeronave is Helicoptero)
                    {
                        accesoDatos.EliminarHelicoptero(aeronave.Modelo);
                    }
                    else
                    {
                        accesoDatos.EliminarGlobo(aeronave.Modelo);
                    }

                    CargarLista();
                    if(listaFile is not null)
                    {
                        this.Text = " [SIN GUARDAR] - Lista: " + listaFile;
                    }
                    else
                    {
                        this.Text = " [SIN GUARDAR] ";
                    }
                    bSave = false;
                }
            }
        }

        /// <summary>
        /// Al hacer clic en el botón agregar, se abre el formAgregar del tipo FormAgregarModificar, en modo Agregar. Luego de que
        /// el usuario elija la nueva aeronave a agregar, se fija si la variable BSave está en true o no, y muestra en el título del
        /// form que está sin guardar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarModificar formAgregar = new FormAgregarModificar(EModo.Agregar);
            formAgregar.ShowDialog();
            

            if (formAgregar.BSave)
            { 
                MiLista.Agregar(formAgregar.aeronave);
                LBAeronaves.Items.Add(formAgregar.aeronave.Descripcion());
                if(listaFile is not null)
                {
                    this.Text = " [SIN GUARDAR] - Lista: " + listaFile;
                }
                else
                {
                    this.Text = " [SIN GUARDAR] ";
                }
                bSave = false;
            }
        }

        /// <summary>
        /// Al hacer clic en el botón modificar, se abre el formModificar del tipo FormAgregarModificar, en modo Modificar, y con la
        /// aeronave seleccionada a modificar. Luego se verifica la variable BSave, y  muestra en el título del form que está sin
        /// guardar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if(LBAeronaves.SelectedIndex >= 0)
            {
                FormAgregarModificar formModificar = new FormAgregarModificar(EModo.Modificar, MiLista.Elementos[LBAeronaves.SelectedIndex]);
                //formModificar.aeronave = MiLista.Elementos[LBAeronaves.SelectedIndex];
                formModificar.ShowDialog();
                
                if (formModificar.BSave)
                {
                    MiLista.Modificar(LBAeronaves.SelectedIndex, formModificar.aeronave);
                    CargarLista();
                    if (listaFile is not null)
                    {
                        this.Text = " [SIN GUARDAR] - Lista: " + listaFile;
                    }
                    else
                    {
                        this.Text = " [SIN GUARDAR] ";
                    }
                    bSave = false;
                }
            }
        }

        /// <summary>
        /// El botón análisis abre un nuevo form de analisis sólo si hay al menos dos elementos comparables en la lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAnalisis_Click(object sender, EventArgs e)
        {
            if(MiLista.Elementos.Count > 1)
            { 
                FormAnalisis formAnalisis = new FormAnalisis(MiLista);
                formAnalisis.Enabled = true;
                formAnalisis.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe agregar al menos dos elementos en la lista", "Atencion",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void traerDatos_Click(object sender, EventArgs e)
        {

        }
    }
}
