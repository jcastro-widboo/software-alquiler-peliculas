using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Drawing.Printing;

namespace AlquilerPeliculas
{
    public partial class Factura : Form
    {

        string connstr = AlquilerPeliculas.Conexion.GetConnectionString();
        string sesionabierta;

        public Factura()
        {
            InitializeComponent();
        }

        private void Factura_Load(object sender, EventArgs e)
        {

            datosfactura();
            nombre();

        }

        public void sesion(ref string sesion)
        {

            sesionabierta = sesion;

        }

        public void datosfactura()
        {

            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand da = new SqlCommand("SELECT TITULO_PELICULA, PRECIO_PELICULA, CEDULA_CLIENTE, FECHAALQUILER_PELICULA, FECHADEVOLUCION_PELICULA FROM PELICULA JOIN ALQUILER ON PELICULA.ID_ALQUILER = ALQUILER.ID_ALQUILER WHERE CEDULA_CLIENTE = '" + sesionabierta + "'", conn);
            conn.Open();

            SqlDataReader leer = da.ExecuteReader();
            if (leer.Read() == true)
            {

                Pelicula.Text = leer["TITULO_PELICULA"].ToString().ToUpper();
                PrecioU.Text = leer["PRECIO_PELICULA"].ToString();
                PrecioT.Text = leer["PRECIO_PELICULA"].ToString();
                PrecioVT.Text = leer["PRECIO_PELICULA"].ToString();
                PrecioNP.Text = leer["PRECIO_PELICULA"].ToString();
                Efectivo.Text = leer["PRECIO_PELICULA"].ToString();
                FechaAlquiler.Text = leer["FECHAALQUILER_PELICULA"].ToString();
                FechaDevolucion.Text = leer["FECHADEVOLUCION_PELICULA"].ToString();
                Cedula.Text = leer["CEDULA_CLIENTE"].ToString();

            }
            else
            {


            }

            conn.Close();


        }

        public void nombre()
        {

            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand da = new SqlCommand("SELECT NOMBRE_CLIENTE, APELLIDO_CLIENTE FROM CLIENTE WHERE CEDULA_CLIENTE = '" + sesionabierta + "'", conn);
            conn.Open();

            SqlDataReader leer = da.ExecuteReader();
            if (leer.Read() == true)
            {

                Cliente.Text = leer["NOMBRE_CLIENTE"].ToString() + " "+ leer["APELLIDO_CLIENTE"].ToString();

            }
            else
            {


            }

            conn.Close();

        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PrecioVT_Click(object sender, EventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca acerca = new Acerca();
            acerca.Show();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Show();
        }

    }
}
