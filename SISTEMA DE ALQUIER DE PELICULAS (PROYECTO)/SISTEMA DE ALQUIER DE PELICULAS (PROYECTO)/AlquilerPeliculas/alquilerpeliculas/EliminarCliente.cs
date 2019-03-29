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
    public partial class EliminarCliente : Form
    {

        string connstr = AlquilerPeliculas.Conexion.GetConnectionString();
        string myString = "";

        public EliminarCliente()
        {
            InitializeComponent();
        }

        private void EliminarCliente_Load(object sender, EventArgs e)
        {
            timer1.Start();
            llenacombobox();
            cargardata();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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

                SqlCommand cmd = new SqlCommand("DELETE FROM CLIENTE " + "WHERE CEDULA_CLIENTE = @CEDULA_CLIENTE", conn);
                cmd.Parameters.AddWithValue("@CEDULA_CLIENTE", myString);

                conn.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Cliente eliminado con éxito!");
                Close();

            }
            catch
            {

                MessageBox.Show("No se pudo eliminar el cliente!");

            }
            finally
            {

                conn.Close();

            }
        }

        public void cargardata()
        {

            SqlConnection conn = new SqlConnection(connstr);

            try
            {

                SqlCommand cmd = new SqlCommand("SELECT CEDULA_CLIENTE AS CEDULA, NOMBRE_CLIENTE AS NOMBRE, APELLIDO_CLIENTE AS APELLIDO, DIRECCION_CLIENTE AS DIRECCIÓN, TELEFONO_CLIENTE AS TELEFONO, CORREO_CLIENTE AS CORREO FROM CLIENTE", conn);

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            myString = comboBox1.GetItemText(comboBox1.SelectedItem);
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

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acerca acerca = new Acerca();
            acerca.Show();
        }

    }
}
