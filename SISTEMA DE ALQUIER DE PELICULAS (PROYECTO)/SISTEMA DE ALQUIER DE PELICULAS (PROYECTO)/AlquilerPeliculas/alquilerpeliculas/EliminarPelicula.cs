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
    public partial class EliminarPelicula : Form
    {

        string connstr = AlquilerPeliculas.Conexion.GetConnectionString();
        string myString = "";

        public EliminarPelicula()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            myString = comboBox1.GetItemText(comboBox1.SelectedItem);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void EliminarPelicula_Load(object sender, EventArgs e)
        {
            timer1.Start();
            llenacombobox();
            cargardata();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(connstr);

            try
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM PELICULA " + "WHERE TITULO_PELICULA = @TITULO_PELICULA", conn);
                cmd.Parameters.AddWithValue("@TITULO_PELICULA", myString);

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Pelicula eliminada con éxito!");
                Close();

            }
            catch
            {

                MessageBox.Show("No se pudo eliminar la pelicula!");

            }
            finally
            {

                conn.Close();

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void cargardata()
        {

            SqlConnection conn = new SqlConnection(connstr);

            try
            {

                SqlCommand cmd = new SqlCommand("SELECT TITULO_PELICULA AS PELICULA, DIRECTOR_PELICULA AS DIRECTOR, ANIOESTRENO_PELICULA AS ESTRENO, GENERO_PELICULA AS GENERO, ACTORES_PELICULA AS ACTORES, SINOPSIS_PELICULA AS SINOPSIS, COPIA_PELICULA AS COPIAS, PRECIO_PELICULA AS PRECIO FROM PELICULA", conn);

                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                dataGridView1.DataSource = dt;

            }
            catch
            {

                MessageBox.Show("No se pudo cargar algunos datos!");

            }
            finally
            {

                conn.Close();

            }

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
