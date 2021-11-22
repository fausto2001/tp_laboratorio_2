﻿using System;
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
    public partial class FormAnalisis : Form
    {
        public Lista<Aeronave> listaAnalisis;

        //En este form, se pueden comparar dos aeronaves de la lista, y cuál es la diferencia entre cada variable de cada una.
        //El constructor de este forms, recibe una lista de aeronaves, y procede a agregar cada una dentro del comboBox. Luego
        //llama a la variable comparación para las primeras dos aeronaves elegidas por defecto en los índices 0 y 1.
        public FormAnalisis(Lista<Aeronave> MiLista)
        {
            listaAnalisis = MiLista;
            InitializeComponent();
            foreach (Aeronave a in listaAnalisis.Elementos)
            {
                cmbAeronaves1.Items.Add(a.Descripcion());
                cmbAeronaves2.Items.Add(a.Descripcion());
            }
            cmbAeronaves1.SelectedIndex = 0;
            cmbAeronaves2.SelectedIndex = 1;
            Comparacion(listaAnalisis, cmbAeronaves1.SelectedIndex, cmbAeronaves2.SelectedIndex);
            Promedios(listaAnalisis);
        }

        //Cambiar el índice elegido de cmbAeronaves1 llama a la función comparación para poder realizarla con la nueva aeronave.
        private void cmbAeronaves1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbAeronaves2.SelectedIndex != -1)
            { 
                Comparacion(listaAnalisis, cmbAeronaves1.SelectedIndex, cmbAeronaves2.SelectedIndex);
            }
        }

        //Cambiar el índice elegido de cmbAeronaves2 llama a la función comparación para poder realizarla con la nueva aeronave.
        private void cmbAeronaves2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Comparacion(listaAnalisis, cmbAeronaves1.SelectedIndex, cmbAeronaves2.SelectedIndex);
        }

        /// <summary>
        /// La función comparación recibe la lista en la que se están comparando las aeronaves, y dos índices. Primero, llena los
        /// labels de cada variable con el Convert.ToString, y luego hace la resta entre la primera aeronave y la segunda. Si el
        /// valor de la variable siendo comparada en la primera aeronave es mayor al de la segunda, el lblRes se pone en verde,
        /// sino en rojo.
        /// </summary>
        /// <param name="listaAnalisis"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        private void Comparacion(Lista<Aeronave> listaAnalisis, int index1, int index2)
        {
            lblVelocidadMaxima1.Text = Convert.ToString(listaAnalisis.Elementos[index1].VelocidadMaxima) + " km/h";
            lblVelocidadMaxima2.Text = Convert.ToString(listaAnalisis.Elementos[index2].VelocidadMaxima) + " km/h";
            lblResVelocidadMaxima.Text = Convert.ToString(listaAnalisis.Elementos[index1].VelocidadMaxima - listaAnalisis.Elementos[index2].VelocidadMaxima) + " km/h";
            if(lblResVelocidadMaxima.Text.Contains('-'))
            {
                lblResVelocidadMaxima.ForeColor = Color.Red;
            }
            else
            {
                lblResVelocidadMaxima.ForeColor = Color.Green;
            }

            lblAlturaMaxima1.Text = Convert.ToString(listaAnalisis.Elementos[index1].AlturaMaxima) + " m";
            lblAlturaMaxima2.Text = Convert.ToString(listaAnalisis.Elementos[index2].AlturaMaxima) + " m";
            lblResAlturaMaxima.Text = Convert.ToString(listaAnalisis.Elementos[index1].AlturaMaxima - listaAnalisis.Elementos[index2].AlturaMaxima) + " m";
            if (lblResAlturaMaxima.Text.Contains('-'))
            {
                lblResAlturaMaxima.ForeColor = Color.Red;
            }
            else
            {
                lblResAlturaMaxima.ForeColor = Color.Green;
            }

            lblPeso1.Text = Convert.ToString(listaAnalisis.Elementos[index1].Peso) + " kg";
            lblPeso2.Text = Convert.ToString(listaAnalisis.Elementos[index2].Peso) + " kg";
            lblResPeso.Text = Convert.ToString(listaAnalisis.Elementos[index1].Peso - listaAnalisis.Elementos[index2].Peso) + " kg";
            if (lblResPeso.Text.Contains('-'))
            {
                lblResPeso.ForeColor = Color.Red;
            }
            else
            {
                lblResPeso.ForeColor = Color.Green;
            }

            lblLargo1.Text = Convert.ToString(listaAnalisis.Elementos[index1].Largo) + " m";
            lblLargo2.Text = Convert.ToString(listaAnalisis.Elementos[index2].Largo) + " m";
            lblResLargo.Text = Convert.ToString(System.Math.Round(listaAnalisis.Elementos[index1].Largo - listaAnalisis.Elementos[index2].Largo, 2)) + "m";
            if (lblResLargo.Text.Contains('-'))
            {
                lblResLargo.ForeColor = Color.Red;
            }
            else
            {
                lblResLargo.ForeColor = Color.Green;
            }

            lblAncho1.Text = Convert.ToString(listaAnalisis.Elementos[index1].Ancho) + " m";
            lblAncho2.Text = Convert.ToString(listaAnalisis.Elementos[index2].Ancho) + " m";
            lblResAncho.Text = Convert.ToString(System.Math.Round(listaAnalisis.Elementos[index1].Ancho - listaAnalisis.Elementos[index2].Ancho, 2)) + "m";
            if (lblResAncho.Text.Contains('-'))
            {
                lblResAncho.ForeColor = Color.Red;
            }
            else
            {
                lblResAncho.ForeColor = Color.Green;
            }
        }

        /// <summary>
        /// Calcula los promedios de todas las aeronaves.
        /// </summary>
        /// <param name="listaAnalisis"></param>
        private void Promedios(Lista<Aeronave> listaAnalisis)
        {
            float VMHelicopteros = 0;
            float AMHelicopteros = 0;
            float PHelicopteros = 0;
            float LHelicopteros = 0;
            float AHelicopteros = 0;

            float VMAviones = 0;
            float AMAviones = 0;
            float PAviones = 0;
            float LAviones = 0;
            float AAviones = 0;

            float VMGlobos = 0;
            float AMGlobos = 0;
            float PGlobos = 0;
            float LGlobos = 0;
            float AGlobos = 0;

            int countHelicoptero = 0;
            int countAvion = 0;
            int countGlobo = 0;

            int countVSonido = 0;
            int countTonelada = 0;

            foreach(Aeronave a in listaAnalisis.Elementos)
            {
                if (a.VelocidadMaxima > 1225)
                {
                    countVSonido++;
                }

                if(a.Peso > 1000)
                {
                    countTonelada++;
                }

                if (a is Helicoptero)
                {
                    countHelicoptero++;
                    VMHelicopteros = (VMHelicopteros + (float)a.VelocidadMaxima) / countHelicoptero;
                    AMHelicopteros = (AMHelicopteros + (float)a.AlturaMaxima) / countHelicoptero;
                    PHelicopteros = (PHelicopteros + (float)a.Peso) / countHelicoptero;
                    LHelicopteros = (LHelicopteros + (float)a.Largo) / countHelicoptero;
                    AHelicopteros = (AHelicopteros + (float)a.Ancho) / countHelicoptero;
                }
                else if (a is Avion)
                {
                    countAvion++;
                    VMAviones = (VMAviones + (float)a.VelocidadMaxima) / countAvion;
                    AMAviones = (AMAviones + (float)a.AlturaMaxima) / countAvion;
                    PAviones = (PAviones + (float)a.Peso) / countAvion;
                    LAviones = (LAviones + (float)a.Largo) / countAvion;
                    AAviones = (AAviones + (float)a.Ancho) / countAvion;
                }
                else if(a is Globo)
                {
                    countGlobo++;
                    VMGlobos = (VMGlobos + (float)a.VelocidadMaxima) / countGlobo;
                    AMGlobos = (AMGlobos + (float)a.AlturaMaxima) / countGlobo;
                    PGlobos = (PGlobos + (float)a.Peso) / countGlobo;
                    LGlobos = (LGlobos + (float)a.Largo) / countGlobo;
                    AGlobos = (AGlobos + (float)a.Ancho) / countGlobo;
                }
            }

            if(countHelicoptero != 0)
            {
                lblHelicopteros.Visible = true;
                lblVelocidadMaximaHelicopteros.Visible = true;
                lblAlturaMaximaHelicopteros.Visible = true;
                lblAnchoHelicopteros.Visible = true;
                lblLargoHelicopteros.Visible = true;

                lblVelocidadMaximaHelicopteros.Text = Convert.ToString(System.Math.Round(VMHelicopteros, 2)) + " km/h";
                lblAlturaMaximaHelicopteros.Text = Convert.ToString(System.Math.Round(AMHelicopteros, 2)) + " m";
                lblPesoHelicopteros.Text = Convert.ToString(System.Math.Round(PHelicopteros, 2)) + " kg";
                lblAnchoHelicopteros.Text = Convert.ToString(System.Math.Round(AHelicopteros, 2)) + " m";
                lblLargoHelicopteros.Text = Convert.ToString(System.Math.Round(LHelicopteros, 2)) + " m";
            }
            else
            {
                lblPesoHelicopteros.Text = "No hay helicopteros.";
            }

            if(countAvion != 0)
            {
                lblAviones.Visible = true;
                lblVelocidadMaximaAviones.Visible = true;
                lblAlturaMaximaAviones.Visible = true;
                lblAnchoAviones.Visible = true;
                lblLargoAviones.Visible = true;

                lblVelocidadMaximaAviones.Text = Convert.ToString(System.Math.Round(VMAviones, 2)) + " km/h";
                lblAlturaMaximaAviones.Text = Convert.ToString(System.Math.Round(AMAviones, 2)) + " m";
                lblPesoAviones.Text = Convert.ToString(System.Math.Round(PAviones, 2)) + " kg";
                lblAnchoAviones.Text = Convert.ToString(System.Math.Round(AAviones, 2)) + " m";
                lblLargoAviones.Text = Convert.ToString(System.Math.Round(LAviones, 2)) + " m";
            }
            else
            {
                lblPesoAviones.Text = "No hay aviones.";
            }

            if(countGlobo != 0)
            {
                lblGlobos.Visible = true;
                lblVelocidadMaximaGlobos.Visible = true;
                lblAlturaMaximaGlobos.Visible = true;
                lblAnchoGlobos.Visible = true;
                lblLargoGlobos.Visible = true;

                lblVelocidadMaximaGlobos.Text = Convert.ToString(System.Math.Round(VMGlobos, 2)) + " km/h";
                lblAlturaMaximaGlobos.Text = Convert.ToString(System.Math.Round(AMGlobos, 2)) + " m";
                lblPesoGlobos.Text = Convert.ToString(System.Math.Round(PGlobos, 2)) + " kg";
                lblAnchoGlobos.Text = Convert.ToString(System.Math.Round(AGlobos, 2)) + " m";
                lblLargoGlobos.Text = Convert.ToString(System.Math.Round(LGlobos, 2)) + " m";
            }
            else
            {
                lblPesoGlobos.Text = "No hay globos";
            }
            
            float porcentajeSonido = ((float)countVSonido / (float)listaAnalisis.Elementos.Count) * 100;
            float porcentajeTonelada = ((float)countTonelada / (float)listaAnalisis.Elementos.Count) * 100;
            float porcentajeGlobos = ((float)countGlobo / (float)listaAnalisis.Elementos.Count) * 100;

            //Algunos datos extra!
            lblSonido.Text = "El " + System.Math.Round(porcentajeSonido, 2) + " % de las aeronaves puede viajar a la velocidad del sonido.";
            lblPesoTonelada.Text = "El " + System.Math.Round(porcentajeTonelada, 2) + " % de las aeronaves pesa más de una tonelada.";
            lblGlobosPorcentaje.Text = "El " + System.Math.Round(porcentajeGlobos, 2) + " % de las aeronaves son globos.";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Obtiene los indices de las aeronaves, y manda las mismas al FormCarrera.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCarrera_Click(object sender, EventArgs e)
        {
            int index1 = cmbAeronaves1.SelectedIndex;
            int index2 = cmbAeronaves2.SelectedIndex;
            FormCarrera formCarrera = new FormCarrera(listaAnalisis.Elementos[index1], listaAnalisis.Elementos[index2]);
            formCarrera.ShowDialog();
        }
    }
}
