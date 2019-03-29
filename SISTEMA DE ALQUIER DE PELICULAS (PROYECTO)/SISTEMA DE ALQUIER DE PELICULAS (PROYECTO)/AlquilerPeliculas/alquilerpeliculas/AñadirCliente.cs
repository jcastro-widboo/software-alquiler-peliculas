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
    public partial class AñadirCliente : Form
    {

        string connstr = AlquilerPeliculas.Conexion.GetConnectionString();
        string sesionabierta;

        public AñadirCliente()
        {
            InitializeComponent();
        }

        private void AñadirCliente_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
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
            reiniciar();
            this.Close();

        }

        private void Cedula_KeyPress(object sender, KeyPressEventArgs e)
        {

            Validacion.solonumeros(e);

        }

        private void Telefono_KeyPress(object sender, KeyPressEventArgs e)
        {

            Validacion.solonumeros(e);

        }

        private void Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {

            Validacion.sololetras(e);

        }

        private void Apellido_KeyPress(object sender, KeyPressEventArgs e)
        {

            Validacion.sololetras(e);

        }

        public void registroimagen()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connstr);

                SqlCommand da = new SqlCommand("UPDATE CLIENTE SET IMAGEN_CLIENTE = @IMAGEN_CLIENTE WHERE CEDULA_CLIENTE = '" + Cedula.Text + "'", conn);

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

            MessageBox.Show("Registro exitoso!", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        public void registrodatos()
        {

            if (Validacion.VerificarCedula(Cedula.Text) != false)
            {

                try
                {
                    SqlConnection conn = new SqlConnection(connstr);

                    SqlCommand da = new SqlCommand("INSERT INTO CLIENTE (CEDULA_CLIENTE, CEDULA_ADMINISTRADOR, NOMBRE_CLIENTE, APELLIDO_CLIENTE, DIRECCION_CLIENTE, TELEFONO_CLIENTE, CORREO_CLIENTE, CONTRASENA_CLIENTE, ESTADO_USUARIO) VALUES (@CEDULA_CLIENTE, @CEDULA_ADMINISTRADOR, @NOMBRE_CLIENTE, @APELLIDO_CLIENTE, @DIRECCION_CLIENTE, @TELEFONO_CLIENTE, @CORREO_CLIENTE, @CONTRASENA_CLIENTE, @ESTADO_USUARIO)", conn);

                    da.Parameters.AddWithValue("@CEDULA_CLIENTE", Cedula.Text);
                    da.Parameters.AddWithValue("@CEDULA_ADMINISTRADOR", sesionabierta);
                    da.Parameters.AddWithValue("@NOMBRE_CLIENTE", Nombre.Text);
                    da.Parameters.AddWithValue("@APELLIDO_CLIENTE", Apellido.Text);
                    da.Parameters.AddWithValue("@DIRECCION_CLIENTE", Direccion.Text);
                    da.Parameters.AddWithValue("@TELEFONO_CLIENTE", Telefono.Text);
                    da.Parameters.AddWithValue("@CORREO_CLIENTE", Correo.Text);
                    da.Parameters.AddWithValue("@CONTRASENA_CLIENTE", Contraseña.Text);
                    da.Parameters.AddWithValue("@ESTADO_USUARIO", "Cliente");

                    conn.Open();
                    da.ExecuteNonQuery();
                    conn.Close();

                    registroimagen();

                }

                catch (System.Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }

            }
            else
            {

                MessageBox.Show("La cédula ingresada no pudo ser verificada!", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void reiniciar()
        {

            Nombre.Text = "";
            Apellido.Text = "";
            Cedula.Text = "";
            Direccion.Text = "";
            Telefono.Text = "";
            Correo.Text = "";
            Contraseña.Text = "";
            pictureBox2 = null;

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void sesion(ref string sesion)
        {

            sesionabierta = sesion;

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca acerca = new Acerca();
            acerca.Show();
        }

    }
}
