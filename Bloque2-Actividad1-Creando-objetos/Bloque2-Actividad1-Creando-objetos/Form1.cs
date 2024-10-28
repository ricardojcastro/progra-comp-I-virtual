using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bloque2_Actividad1_Creando_objetos
{
    public partial class Form1 : Form
    {
        db_conexion objConexion = new db_conexion();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public int posicion = 0;
        string accion = "nuevo";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            obtenerDatos();
        }
        private void obtenerDatos()
        {
            ds = objConexion.obtenerdatos();
            dt = ds.Tables["peliculas"];
            dt.PrimaryKey = new DataColumn[] { dt.Columns["idPeliculas"] };

            mostrarDatos();
        }
        private void mostrarDatos()
        {
            txtTitulo.Text = dt.Rows[posicion].ItemArray[1].ToString();
            txtAutor.Text = dt.Rows[posicion].ItemArray[2].ToString();
            txtSinopsis.Text = dt.Rows[posicion].ItemArray[3].ToString();
            txtDuracion.Text = dt.Rows[posicion].ItemArray[4].ToString();
            txtclasificacion.Text = dt.Rows[posicion].ItemArray[5].ToString();
            lblRegistro.Text = (posicion + 1) + " de " + dt.Rows.Count;
            activarDesBtnNevegacion(true);
        }
        private void activarDesBtnNevegacion(Boolean estado)
        {

            bool est = (posicion > 0 && posicion <= dt.Rows.Count - 1) || !estado;
            btnAnterior.Enabled = est;
            btnPrimero.Enabled = est;

            btnSiguiente.Enabled = estado;
            btnUltimo.Enabled = estado;
        }
        private void habDesControles(Boolean estado)
        {

            grbNavegacion.Enabled = !estado;
            btnEliminar.Enabled = !estado;
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (posicion < dt.Rows.Count - 1)
            {

                posicion += 1;
                mostrarDatos();
            }
            else
            {
                activarDesBtnNevegacion(false);
            }
        }
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            posicion = dt.Rows.Count - 1;
            mostrarDatos();
        }
        private void btnPrimero_Click(object sender, EventArgs e)
        {
            posicion = 0;
            mostrarDatos();
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                posicion -= 1;
                mostrarDatos();
            }
            else
            {
                activarDesBtnNevegacion(true);
            }
        }
        private void limpiarCajas()
        {
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtSinopsis.Text = "";
            txtDuracion.Text = "";
            txtclasificacion.Text = "";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text == "Nuevo")
            {
                btnNuevo.Text = "Guardar";
                btnModificar.Text = "Cancelar";
                limpiarCajas();
                accion = "nuevo";
                habDesControles(true);

            }
            else
            {//Guardar
                string[] datos = {
                    accion,
                    dt.Rows[posicion].ItemArray[0].ToString(), //idAlumno
                    txtTitulo.Text,
                    txtAutor.Text,
                    txtSinopsis.Text,
                    txtDuracion.Text,
                    txtclasificacion.Text
                    };
                String response = objConexion.administrarPeliculas(datos);
                if (response != "1")
                {
                    MessageBox.Show("Error: " + response, "Registrando datos de peliculas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    obtenerDatos();
                    habDesControles(false);
                    btnNuevo.Text = "Nuevo";
                    btnModificar.Text = "Modificar";

                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (btnModificar.Text == "Modificar")
            {
                btnModificar.Text = "Cancelar";
                btnNuevo.Text = "Guardar";
                accion = "Modificar";
                habDesControles(true);

            }
            else
            {//Cancelar
                mostrarDatos();
                habDesControles(false);
                btnModificar.Text = "Modificar";
                btnNuevo.Text = "Nuevo";
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Esta seguro de eliminar a: " + txtTitulo.Text, "Eliminando Peliculas",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String[] datos = {
                    "eliminar", dt.Rows[posicion].ItemArray[0].ToString(), //idpeliculas
                };
                String response = objConexion.administrarpeliculas(datos);
                if (response != "1")
                {
                    MessageBox.Show("Error: " + response, "Eliminando datos de alumnos", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                } else {
                    obtenerDatos();
                }
            }

        }
    }
}


