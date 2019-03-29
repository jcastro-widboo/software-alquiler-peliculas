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
    public partial class ActualizarPelicula : Form
    {

        string connstr = AlquilerPeliculas.Conexion.GetConnectionString();
        string sesionabierta;
        string myString = "";

        public ActualizarPelicula()
        {
            InitializeComponent();
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

                SqlCommand da = new SqlCommand("UPDATE PELICULA SET IMAGEN_PELICULA = @IMAGEN_PELICULA WHERE TITULO_PELICULA = '" + myString + "'", conn);

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

            MessageBox.Show("Pelicula actualizada con éxito!", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        public void sesion(ref string sesion)
        {

            sesionabierta = sesion;

        }

        public void cargarimagen(){

            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand da = new SqlCommand("SELECT IMAGEN_PELICULA FROM PELICULA WHERE TITULO_PELICULA = '" + myString + "'", conn);

            conn.Open();
            byte[] arrImg = (byte[])da.ExecuteScalar();

            MemoryStream ms;
            ms = new MemoryStream(arrImg);
            Image IMG = Image.FromStream(ms);
            ms.Close();
            pictureBox2.Image = IMG;

            conn.Close();


        }

        public void cargardatos()
        {

            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand da = new SqlCommand("SELECT * FROM PELICULA WHERE TITULO_PELICULA = '" + myString + "'", conn);
            conn.Open();

            SqlDataReader leer = da.ExecuteReader();
            if (leer.Read() == true)
            {

                añoestreno.Text = leer["ANIOESTRENO_PELICULA"].ToString();
                director.Text = leer["DIRECTOR_PELICULA"].ToString();
                genero.Text = leer["GENERO_PELICULA"].ToString();
                actores.Text = leer["ACTORES_PELICULA"].ToString();
                sinopsis.Text = leer["SINOPSIS_PELICULA"].ToString();
                copias.Text = leer["COPIA_PELICULA"].ToString();
                precio.Text = leer["PRECIO_PELICULA"].ToString();

            }
            else
            {


            }
            conn.Close();

        }

        public void registrodatos()
        {

            try
            {
                SqlConnection conn = new SqlConnection(connstr);

                SqlCommand da = new SqlCommand("UPDATE PELICULA SET TITULO_PELICULA = @TITULO_PELICULA, CEDULA_ADMINISTRADOR = @CEDULA_ADMINISTRADOR, DIRECTOR_PELICULA = @DIRECTOR_PELICULA, ANIOESTRENO_PELICULA = @ANIOESTRENO_PELICULA, GENERO_PELICULA = @GENERO_PELICULA, ACTORES_PELICULA = @ACTORES_PELICULA, SINOPSIS_PELICULA = @SINOPSIS_PELICULA, COPIA_PELICULA = @COPIA_PELICULA, PRECIO_PELICULA = @PRECIO_PELICULA WHERE TITULO_PELICULA = @TITULO_PELICULA", conn);

                da.Parameters.AddWithValue("@TITULO_PELICULA", myString);
                da.Parameters.AddWithValue("@CEDULA_ADMINISTRADOR", sesionabierta);
                da.Parameters.AddWithValue("@DIRECTOR_PELICULA", director.Text);
                da.Parameters.AddWithValue("@ANIOESTRENO_PELICULA", añoestreno.Text);
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

            director.Text = "";
            añoestreno.Text = "";
            genero.Text = "";
            actores.Text = "";
            sinopsis.Text = "";
            copias.Text = "";
            precio.Text = "";
            pictureBox2 = null;

        }


        public void llenacombobox()
        {

            SqlConnection conn = new SqlConnection(connstr);
            //se indica la cadena de conexion
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT TITULO_PELICULA FROM PELICULA", conn);
            //se indica el nombre de la tabla
            da.Fill(ds, "TITULO_PELICULA");
            comboBox1.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox1.ValueMember = "TITULO_PELICULA";

            if (comboBox1.ValueMember == "TITULO_PELICULA")
            {

                SqlDataAdapter de = new SqlDataAdapter("SELECT TITULO_PELICULA FROM PELICULA", conn);

            }

        }

        private void ActualizarPelicula_Load(object sender, EventArgs e)
        {
            timer1.Start();
            llenacombobox();
            cargardatos();
            cargarimagen();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            myString = comboBox1.GetItemText(comboBox1.SelectedItem);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void copias_KeyPress(object sender, KeyPressEventArgs e)
        {

            Validacion.solonumeros(e);

        }

        private void genero_KeyPress(object sender, KeyPressEventArgs e)
        {

            Validacion.sololetras(e);

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca acerca = new Acerca();
            acerca.Show();
        }

    }
}
