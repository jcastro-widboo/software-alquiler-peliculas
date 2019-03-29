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
    public partial class ZonaClientes : Form
    {

        string connstr = AlquilerPeliculas.Conexion.GetConnectionString();
        string myString = "";
        string myString2 = "";
        string sesionabierta;

        public ZonaClientes()
        {
            InitializeComponent();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnFindByOrderID_Click(object sender, EventArgs e)
        {

            int index = comboBox1.FindString(BUSCAR.Text);
            comboBox1.SelectedIndex = index;

        }
              

        private void Form4_Load(object sender, EventArgs e)
        {

            timer1.Start();
            llenacombobox();
            imagenusuario();
            perfilusuario();
            llenacomboboxalquiler();
            peliculascliente();
            peliculashistorial();

        }


        //método llenacombobox
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
            SqlCommand da = new SqlCommand("SELECT * FROM CLIENTE WHERE CEDULA_CLIENTE = '" + sesionabierta + "'", conn);
            conn.Open();

            SqlDataReader leer = da.ExecuteReader();
            if (leer.Read() == true)
            {

                nombreusuario.Text = leer["NOMBRE_CLIENTE"].ToString().ToUpper() + " " + leer["APELLIDO_CLIENTE"].ToString().ToUpper();
                direccionusuario.Text = leer["DIRECCION_CLIENTE"].ToString();
                telefonousuario.Text = leer["TELEFONO_CLIENTE"].ToString();
                correousuario.Text = leer["CORREO_CLIENTE"].ToString();
                usuario.Text = leer["CEDULA_CLIENTE"].ToString();

            }
            else
            {


            }
            conn.Close();


        }

        public void imagenusuario()
        {

            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand da = new SqlCommand("SELECT IMAGEN_CLIENTE FROM CLIENTE WHERE CEDULA_CLIENTE = '" + sesionabierta + "'", conn);

            conn.Open();
            byte[] arrImg = (byte[])da.ExecuteScalar();

            MemoryStream ms;
            ms = new MemoryStream(arrImg);
            Image IMG = Image.FromStream(ms);
            ms.Close();
            pictureBox3.Image = IMG;

            conn.Close();

        }

        public void sesion(ref string sesion)
        {

            sesionabierta = sesion;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           myString = comboBox1.GetItemText(comboBox1.SelectedItem);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog DIALOG = new OpenFileDialog();

            DialogResult result = DIALOG.ShowDialog();

            if (result == DialogResult.OK)
            {

                pictureBox1.Image = Image.FromFile(DIALOG.FileName);

            }

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {

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
            pictureBox1.Image = IMG;

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

        private void button1_Click_1(object sender, EventArgs e)
        {

             imagen(myString);
             peli();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = DateTime.Now.ToString();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {



        }

        private void nombreusuario_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            OpenFileDialog DIALOG = new OpenFileDialog();

            DialogResult result = DIALOG.ShowDialog();

            if (result == DialogResult.OK)
            {

                pictureBox3.Image = Image.FromFile(DIALOG.FileName);

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connstr);

                SqlCommand da = new SqlCommand("UPDATE CLIENTE SET IMAGEN_CLIENTE = @IMAGEN_CLIENTE WHERE CEDULA_CLIENTE = '" + usuario.Text + "'", conn);

                // Creando los parámetros necesarios
                da.Parameters.Add("@IMAGEN_CLIENTE", System.Data.SqlDbType.Image);

                // Stream usado como buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                // Se guarda la imagen en el buffer
                pictureBox3.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
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

            MessageBox.Show("Foto de Perfil actualizada con éxito!", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void button4_Click(object sender, EventArgs e)
        {


        if (VerificarUpdate() == true){

          try
            {
                SqlConnection conn = new SqlConnection(connstr);
                
                SqlCommand da = new SqlCommand("UPDATE CLIENTE SET CONTRASENA_CLIENTE = @CONTRASENA_CLIENTE WHERE CEDULA_CLIENTE = '" + usuario.Text + "'", conn);

                da.Parameters.AddWithValue("@CONTRASENA_CLIENTE", contraseñanueva.Text);

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

                SqlCommand comando = new SqlCommand("SELECT CONTRASENA_CLIENTE FROM CLIENTE WHERE CEDULA_CLIENTE = '" + usuario.Text + "'", miConecion);

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
                if ((contraseñaactual.Text == DR["CONTRASENA_CLIENTE"].ToString()))
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

        private void Sinopsis_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

                SqlConnection conn = new SqlConnection(connstr);

                try
                {

                    SqlCommand cmd = new SqlCommand("INSERT INTO ALQUILER(ID_ALQUILER, CEDULA_CLIENTE, FECHAALQUILER_PELICULA) VALUES ((SELECT MAX(ID_ALQUILER)+1 FROM ALQUILER), @CEDULA_CLIENTE, @FECHAALQUILER_PELICULA)", conn);
                    cmd.Parameters.AddWithValue("@CEDULA_CLIENTE", usuario.Text);
                    cmd.Parameters.AddWithValue("@FECHAALQUILER_PELICULA", DateTime.Now);
                    cmd.Parameters.AddWithValue("@TITULO_PELICULA", myString);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    actualizarid();

                }
                catch
                {

                  
                }
                finally
                {

                    conn.Close();

                }

        }


        public void actualizarid(){

              SqlConnection conn = new SqlConnection(connstr);

                try
                {

                    SqlCommand cmd = new SqlCommand("UPDATE PELICULA SET ID_ALQUILER = (SELECT MAX(ID_ALQUILER) FROM ALQUILER) WHERE TITULO_PELICULA = @TITULO_PELICULA", conn);
                    cmd.Parameters.AddWithValue("@TITULO_PELICULA", myString);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pelicula alquilada con éxito!");

                    Factura fac = new Factura();
                    string sesion = usuario.Text;
                    fac.sesion(ref sesion);
                    fac.Show();


                }
                catch
                {

                    MessageBox.Show("No se pudo alquilar la pelicula!");

                }
                finally
                {

                    conn.Close();

                }

        }

        //método llenacombobox
        public void llenacomboboxalquiler()
        {

            SqlConnection conn = new SqlConnection(connstr);
            //se indica la cadena de conexion
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT TITULO_PELICULA FROM PELICULA JOIN ALQUILER ON PELICULA.ID_ALQUILER=ALQUILER.ID_ALQUILER where CEDULA_CLIENTE = '"+ usuario.Text + "'", conn);
            //se indica el nombre de la tabla
            da.Fill(ds, "TITULO_PELICULA");
            comboBox2.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox2.ValueMember = "TITULO_PELICULA";

            if (comboBox2.ValueMember == "TITULO_PELICULA")
            {

                SqlDataAdapter de = new SqlDataAdapter("SELECT TITULO_PELICULA FROM PELICULA JOIN ALQUILER ON PELICULA.ID_ALQUILER=ALQUILER.ID_ALQUILER where CEDULA_CLIENTE = '"+ usuario.Text + "'", conn);

            }

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            actualizarpelicula();
            actualizarfecha();

        }

        public void actualizarpelicula()
        {

            try
            {
                SqlConnection conn = new SqlConnection(connstr);

                SqlCommand da = new SqlCommand("UPDATE PELICULA SET ID_ALQUILER = @ID_ALQUILER WHERE TITULO_PELICULA = '" + myString2 + "'", conn);

                da.Parameters.AddWithValue("@ID_ALQUILER", DBNull.Value);

                conn.Open();
                da.ExecuteNonQuery();
                conn.Close();

            }

            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

            
        }

        public void actualizarfecha()
        {

            try
            {
                SqlConnection conn = new SqlConnection(connstr);

                SqlCommand da = new SqlCommand("SELECT FECHADEVOLUCION_PELICULA FROM PELICULA JOIN ALQUILER ON PELICULA.ID_ALQUILER = ALQUILER.ID_ALQUILER where CEDULA_cliente = '"+ usuario.Text + "' UPDATE ALQUILER SET FECHADEVOLUCION_PELICULA = @FECHADEVOLUCION_PELICULA", conn);

                da.Parameters.AddWithValue("@FECHADEVOLUCION_PELICULA", DateTime.Now);

                conn.Open();
                da.ExecuteNonQuery();
                conn.Close();

            }

            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

            MessageBox.Show("Gracias por su devolución!", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            myString2 = comboBox1.GetItemText(comboBox1.SelectedItem);
            
        }

        public void peliculascliente()
        {

            SqlConnection conn = new SqlConnection(connstr);

            try
            {

                SqlCommand cmd = new SqlCommand("SELECT TITULO_PELICULA AS PELICULA, DIRECTOR_PELICULA AS DIRECTOR, GENERO_PELICULA AS GÉNERO, SINOPSIS_PELICULA AS SINOPSIS FROM PELICULA JOIN ALQUILER ON PELICULA.ID_ALQUILER = ALQUILER.ID_ALQUILER WHERE CEDULA_CLIENTE = @CEDULA_CLIENTE", conn);
                cmd.Parameters.AddWithValue("@CEDULA_CLIENTE", sesionabierta);

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

        public void peliculashistorial()
        {

            SqlConnection conn = new SqlConnection(connstr);

            try
            {

                SqlCommand cmd = new SqlCommand("SELECT TITULO_PELICULA AS PELICULA, DIRECTOR_PELICULA AS DIRECTOR, GENERO_PELICULA AS GÉNERO, SINOPSIS_PELICULA AS SINOPSIS FROM PELICULA", conn);

                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                dataGridView2.DataSource = dt;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca acerca = new Acerca();
            acerca.Show();
        }

    }

}

