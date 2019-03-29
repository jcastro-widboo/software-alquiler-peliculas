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

namespace AlquilerPeliculas
{
    public partial class AñadirPelicula : Form
    {

        string connstr = AlquilerPeliculas.Conexion.GetConnectionString();
        string sesionabierta;

        public AñadirPelicula()
        {
            InitializeComponent();
        }

        private void AñadirPelicula_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public void sesion(ref string sesion)
        {

            sesionabierta = sesion;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog DIALOG = new OpenFileDialog();

            DialogResult result = DIALOG.ShowDialog();

            if (result == DialogResult.OK)
            {

                pictureBox2.Image = Image.FromFile(DIALOG.FileName);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            registrodatos();
            registroimagen();
            reiniciar();
            Close();

        }

        public void registroimagen()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connstr);

                SqlCommand da = new SqlCommand("UPDATE PELICULA SET IMAGEN_PELICULA = @IMAGEN_PELICULA WHERE TITULO_PELICULA = '" + nombrepelicula.Text + "'", conn);

                // Creando los parámetros necesarios
                da.Parameters.Add("@IMAGEN_PELICULA", System.Data.SqlDbType.Image);

                // Stream usado como buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                // Se guarda la imagen en el buffer
                pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                // Se extraen los bytes del buffer para asignarlos como valor para el
                // parámetro.
                da.Parameters["@IMAGEN_PELICULA"].Value = ms.GetBuffer();

                conn.Open();
                da.ExecuteNonQuery();
                conn.Close();

            }

            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

            MessageBox.Show("Pelicula agregada con éxito!", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        public void registrodatos()
        {

            try
            {
                SqlConnection conn = new SqlConnection(connstr);

                SqlCommand da = new SqlCommand("INSERT INTO PELICULA (TITULO_PELICULA, CEDULA_ADMINISTRADOR, DIRECTOR_PELICULA, ANIOESTRENO_PELICULA, GENERO_PELICULA, ACTORES_PELICULA, SINOPSIS_PELICULA, COPIA_PELICULA, PRECIO_PELICULA) VALUES (@TITULO_PELICULA, @CEDULA_ADMINISTRADOR, @DIRECTOR_PELICULA, @ANIOESTRENO_PELICULA, @GENERO_PELICULA, @ACTORES_PELICULA, @SINOPSIS_PELICULA, @COPIA_PELICULA, @PRECIO_PELICULA)", conn);

                da.Parameters.AddWithValue("@TITULO_PELICULA", nombrepelicula.Text);
                da.Parameters.AddWithValue("@CEDULA_ADMINISTRADOR", sesionabierta);
                da.Parameters.AddWithValue("@DIRECTOR_PELICULA", director.Text);
                da.Parameters.AddWithValue("@ANIOESTRENO_PELICULA", dateTimePicker1.Value.Date);
                da.Parameters.AddWithValue("@GENERO_PELICULA", genero.Text);
                da.Parameters.AddWithValue("@ACTORES_PELICULA", actores.Text);
                da.Parameters.AddWithValue("@SINOPSIS_PELICULA", sinopsis.Text);
                da.Parameters.AddWithValue("@COPIA_PELICULA", copias.Text);
                da.Parameters.AddWithValue("@PRECIO_PELICULA", precio.Text);

                conn.Open();
                da.ExecuteNonQuery();
                conn.Close();

            }

            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        public void reiniciar()
        {

            nombrepelicula.Text = "";
            director.Text = "";
            genero.Text = "";
            actores.Text = "";
            sinopsis.Text = "";
            copias.Text = "";
            precio.Text = "";
            pictureBox2 = null;

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca acerca = new Acerca();
            acerca.Show();
        }

    }
}
