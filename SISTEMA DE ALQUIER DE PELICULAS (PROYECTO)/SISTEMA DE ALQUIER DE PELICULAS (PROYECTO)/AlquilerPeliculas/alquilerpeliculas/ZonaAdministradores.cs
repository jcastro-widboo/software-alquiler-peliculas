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
    public partial class ZonaAdministradores : Form
    {

        string connstr = AlquilerPeliculas.Conexion.GetConnectionString();
        string myString = "";
        string sesionabierta;

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

        public void perfilusuario()
        {

            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand da = new SqlCommand("SELECT * FROM ADMINISTRADOR WHERE CEDULA_ADMINISTRADOR = '" + sesionabierta + "'", conn);
            conn.Open();

            SqlDataReader leer = da.ExecuteReader();
            if (leer.Read() == true)
            {

                nombreusuario.Text = leer["NOMBRE_ADMINISTRADOR"].ToString().ToUpper() + " " + leer["APELLIDO_ADMINISTRADOR"].ToString().ToUpper();
                direccionusuario.Text = leer["DIRECCION_ADMINISTRADOR"].ToString();
                telefonousuario.Text = leer["TELEFONO_ADMINISTRADOR"].ToString();
                correousuario.Text = leer["CORREO_ADMINISTRADOR"].ToString();
                usuario.Text = leer["CEDULA_ADMINISTRADOR"].ToString();

            }
            else
            {


            }
            conn.Close();


        }

        public void imagenusuario()
        {

            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand da = new SqlCommand("SELECT IMAGEN_ADMINISTRADOR FROM ADMINISTRADOR WHERE CEDULA_ADMINISTRADOR = '" + sesionabierta + "'", conn);

            conn.Open();
            byte[] arrImg = (byte[])da.ExecuteScalar();

            MemoryStream ms;
            ms = new MemoryStream(arrImg);
            Image IMG = Image.FromStream(ms);
            ms.Close();
            pictureBox3.Image = IMG;

            conn.Close();

        }


        public ZonaAdministradores()
        {
            InitializeComponent();
        }

        private void ZonaAdministradores_Load(object sender, EventArgs e)
        {

            timer1.Start();
            llenacombobox();
            imagenusuario();
            perfilusuario();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            OpenFileDialog DIALOG = new OpenFileDialog();

            DialogResult result = DIALOG.ShowDialog();

            if (result == DialogResult.OK)
            {

                pictureBox2.Image = Image.FromFile(DIALOG.FileName);

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connstr);

                SqlCommand da = new SqlCommand("UPDATE ADMINISTRADOR SET IMAGEN_ADMINISTRADOR = @IMAGEN_ADMINISTRADOR WHERE CEDULA_ADMINISTRADOR = '" + usuario.Text + "'", conn);

                // Creando los parámetros necesarios
                da.Parameters.Add("@IMAGEN_ADMINISTRADOR", System.Data.SqlDbType.Image);

                // Stream usado como buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                // Se guarda la imagen en el buffer
                pictureBox3.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                // Se extraen los bytes del buffer para asignarlos como valor para el
                // parámetro.
                da.Parameters["@IMAGEN_ADMINISTRADOR"].Value = ms.GetBuffer();

                conn.Open();
                da.ExecuteNonQuery();
                conn.Close();

            }

            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

            MessageBox.Show("Foto de Perfil actualizada con éxito!", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (VerificarUpdate() == true)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(connstr);

                    SqlCommand da = new SqlCommand("UPDATE ADMINISTRADOR SET CONTRASENA_ADMINISTRADOR = @CONTRASENA_ADMINISTRADOR WHERE CEDULA_ADMINISTRADOR = '" + usuario.Text + "'", conn);

                    da.Parameters.AddWithValue("@CONTRASENA_ADMINISTRADOR", contraseñanueva.Text);

                    conn.Open();
                    da.ExecuteNonQuery();
                    conn.Close();

                }

                catch (System.Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }

                MessageBox.Show("Contraseña actualizada con éxito!", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                contraseñaactual.Text = "";
                contraseñanueva.Text = "";

            }

        }


        private bool VerificarUpdate()
        {

            try
            {
                //creando la conexion
                SqlConnection miConecion = new SqlConnection(connstr);
                //abriendo conexion
                miConecion.Open();

                SqlCommand comando = new SqlCommand("SELECT CONTRASENA_ADMINISTRADOR FROM ADMINISTRADOR WHERE CEDULA_ADMINISTRADOR = '" + usuario.Text + "'", miConecion);

                //ejecuta una instruccion de sql devolviendo el numero de las filas afectadas
                comando.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comando);

                //Llenando el dataAdapter
                da.Fill(ds, "Tblusuario");
                //utilizado para representar una fila de la tabla q necesitas en este caso usuario
                DataRow DR;
                DR = ds.Tables["Tblusuario"].Rows[0];

                //evaluando que la contraseña y usuario sean correctos
                if ((contraseñaactual.Text == DR["CONTRASENA_ADMINISTRADOR"].ToString()))
                {

                    return true;

                }
                else
                {

                    MessageBox.Show("Contraseña actual incorrecta! Intentelo de nuevo.", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch
            {
                //en caso que la contraseña sea erronea mostrara un mensaje
                //dentro de los parentesis va: "Mensaje a mostrar","Titulo de la ventana",botones a mostrar en ste caso OK, icono a mostrar en este caso uno de error
                MessageBox.Show("Contraseña actual incorrecta! Intentelo de nuevo.", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            return false;

        }

        private void AnioEstreno_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        public void sesion(ref string sesion)
        {

            sesionabierta = sesion;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            myString = comboBox1.GetItemText(comboBox1.SelectedItem);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            imagen(myString);
            peli();
        }

        private void btnFindByOrderID_Click(object sender, EventArgs e)
        {
            int index = comboBox1.FindString(BUSCAR.Text);
            comboBox1.SelectedIndex = index;
        }

        public void imagen(string myString)
        {

            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand da = new SqlCommand("SELECT IMAGEN_PELICULA FROM PELICULA WHERE TITULO_PELICULA = '" + myString  + "'", conn);

            conn.Open();
            byte[] arrImg = (byte[])da.ExecuteScalar();
            conn.Close();

            MemoryStream ms = new MemoryStream(arrImg);
            Image IMG = Image.FromStream(ms);
            ms.Close();
            pictureBox2.Image = IMG;

        }

        public void peli()
        {

            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand da = new SqlCommand("SELECT * FROM PELICULA WHERE TITULO_PELICULA = '" + myString + "'", conn);
            conn.Open();

            SqlDataReader leer = da.ExecuteReader();
            if (leer.Read() == true)
            {

                TituloPelicula.Text = leer["TITULO_PELICULA"].ToString().ToUpper();
                Sinopsis.Text = leer["SINOPSIS_PELICULA"].ToString();
                Genero.Text = leer["GENERO_PELICULA"].ToString();
                Director.Text = leer["DIRECTOR_PELICULA"].ToString();
                Actores.Text = leer["ACTORES_PELICULA"].ToString();
                Estreno.Text = leer["ANIOESTRENO_PELICULA"].ToString();
                Alquiler.Text = leer["PRECIO_PELICULA"].ToString();

            }
            else
            {


            }
            conn.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {


            AñadirPelicula añadirpelicula = new AñadirPelicula();
            string sesion = usuario.Text;
            añadirpelicula.sesion(ref sesion);
            añadirpelicula.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            ActualizarPelicula actualizarpelicula = new ActualizarPelicula();
            string sesion = usuario.Text;
            actualizarpelicula.sesion(ref sesion);
            actualizarpelicula.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {

            EliminarPelicula eliminarpelicula = new EliminarPelicula();
            eliminarpelicula.Show();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BUSCAR_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            AñadirCliente añadircliente = new AñadirCliente();
            string sesion = usuario.Text;
            añadircliente.sesion(ref sesion);
            añadircliente.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ActualizarCliente actualizarcliente = new ActualizarCliente();
            string sesion = usuario.Text;
            actualizarcliente.sesion(ref sesion);
            actualizarcliente.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            EliminarCliente eliminarcliente = new EliminarCliente();
            eliminarcliente.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (Validacion.VerificarCedula(textBox1.Text) != false)
            {

                SqlConnection conn = new SqlConnection(connstr);

                try
                {

                    SqlCommand cmd = new SqlCommand("SELECT CEDULA_CLIENTE AS CEDULA, NOMBRE_CLIENTE AS NOMBRE, APELLIDO_CLIENTE AS APELLIDO, DIRECCION_CLIENTE AS DIRECCIÓN, TELEFONO_CLIENTE AS TELEFONO, CORREO_CLIENTE AS CORREO FROM CLIENTE WHERE CEDULA_CLIENTE = @CEDULA_CLIENTE", conn);

                    cmd.Parameters.AddWithValue("@CEDULA_CLIENTE", textBox1.Text);

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
            else
            {

                MessageBox.Show("La cédula ingresada no pudo ser verificada!", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            Validacion.solonumeros(e);

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca acerca = new Acerca();
            acerca.Show();
        }

    }
}
