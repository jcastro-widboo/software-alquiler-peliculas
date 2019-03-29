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
    public partial class ActualizarCliente : Form
    {

        string connstr = AlquilerPeliculas.Conexion.GetConnectionString();
        string sesionabierta;
        string myString = "";

        public ActualizarCliente()
        {
            InitializeComponent();
        }

        private void ActualizarCliente_Load(object sender, EventArgs e)
        {
            timer1.Start();
            llenacombobox();
            cargardatos();
            cargarimagen();
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

                SqlCommand da = new SqlCommand("UPDATE CLIENTE SET IMAGEN_CLIENTE = @IMAGEN_CLIENTE WHERE CEDULA_CLIENTE = '" + Nombre.Text + "'", conn);

                // Creando los parámetros necesarios
                da.Parameters.Add("@IMAGEN_CLIENTE", System.Data.SqlDbType.Image);

                // Stream usado como buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                // Se guarda la imagen en el buffer
                pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                // Se extraen los bytes del buffer para asignarlos como valor para el
                // parámetro.
                da.Parameters["@IMAGEN_CLIENTE"].Value = ms.GetBuffer();

                conn.Open();
                da.ExecuteNonQuery();
                conn.Close();

            }

            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

            MessageBox.Show("Cliente actualizado con éxito!", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        public void cargarimagen()
        {

            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand da = new SqlCommand("SELECT IMAGEN_CLIENTE FROM CLIENTE WHERE CEDULA_CLIENTE = '" + myString + "'", conn);

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
            SqlCommand da = new SqlCommand("SELECT * FROM CLIENTE WHERE CEDULA_CLIENTE = '" + myString + "'", conn);
            conn.Open();

            SqlDataReader leer = da.ExecuteReader();
            if (leer.Read() == true)
            {

                Nombre.Text = leer["NOMBRE_CLIENTE"].ToString();
                Apellido.Text = leer["APELLIDO_CLIENTE"].ToString();
                Direccion.Text = leer["DIRECCION_CLIENTE"].ToString();
                Telefono.Text = leer["TELEFONO_CLIENTE"].ToString();
                Correo.Text = leer["CORREO_CLIENTE"].ToString();
                Contraseña.Text = leer["CONTRASENA_CLIENTE"].ToString();

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

                SqlCommand da = new SqlCommand("UPDATE CLIENTE SET CEDULA_ADMINISTRADOR = @CEDULA_ADMINISTRADOR, NOMBRE_CLIENTE = @NOMBRE_CLIENTE, APELLIDO_CLIENTE = @APELLIDO_CLIENTE, DIRECCION_CLIENTE = @DIRECCION_CLIENTE, TELEFONO_CLIENTE = @TELEFONO_CLIENTE, CORREO_CLIENTE = @CORREO_CLIENTE, CONTRASENA_CLIENTE = @CONTRASENA_CLIENTE, COPIA_PELICULA = @COPIA_PELICULA, PRECIO_PELICULA = @PRECIO_PELICULA WHERE CEDULA_CLIENTE = @CEDULA_CLIENTE", conn);

                da.Parameters.AddWithValue("@CEDULA_CLIENTE", myString);
                da.Parameters.AddWithValue("@CEDULA_ADMINISTRADOR", sesionabierta);
                da.Parameters.AddWithValue("@NOMBRE_CLIENTE", Nombre.Text);
                da.Parameters.AddWithValue("@APELLIDO_CLIENTE", Apellido.Text);
                da.Parameters.AddWithValue("@DIRECCION_CLIENTE", Direccion.Text);
                da.Parameters.AddWithValue("@TELEFONO_CLIENTE", Telefono.Text);
                da.Parameters.AddWithValue("@CORREO_CLIENTE", Correo.Text);
                da.Parameters.AddWithValue("@CONTRASENA_CLIENTE", Contraseña.Text);

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

            Apellido.Text = "";
            Nombre.Text = "";
            Direccion.Text = "";
            Telefono.Text = "";
            Correo.Text = "";
            Contraseña.Text = "";
            pictureBox2 = null;

        }


        public void llenacombobox()
        {

            SqlConnection conn = new SqlConnection(connstr);
            //se indica la cadena de conexion
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT CEDULA_CLIENTE FROM CLIENTE", conn);
            //se indica el nombre de la tabla
            da.Fill(ds, "CEDULA_CLIENTE");
            comboBox1.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox1.ValueMember = "CEDULA_CLIENTE";

            if (comboBox1.ValueMember == "CEDULA_CLIENTE")
            {

                SqlDataAdapter de = new SqlDataAdapter("SELECT CEDULA_CLIENTE FROM CLIENTE", conn);

            }

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

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {

            Validacion.solonumeros(e);

        }

        private void Apellido_KeyPress(object sender, KeyPressEventArgs e)
        {

            Validacion.sololetras(e);

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
            this.Refresh();
        }

        private void Nombre_KeyPress(object sender, KeyPressEventArgs e)
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
