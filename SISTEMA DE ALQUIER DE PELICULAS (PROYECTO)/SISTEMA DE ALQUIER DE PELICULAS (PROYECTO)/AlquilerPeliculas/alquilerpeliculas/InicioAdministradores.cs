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

namespace AlquilerPeliculas
{
    public partial class Form3 : Form
    {

        string connstr = AlquilerPeliculas.Conexion.GetConnectionString();
        string sesion;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                //creando la conexion
                SqlConnection miConecion = new SqlConnection(connstr);
                //abriendo conexion
                miConecion.Open();

                SqlCommand comando = new SqlCommand("SELECT CEDULA_ADMINISTRADOR, CONTRASENA_ADMINISTRADOR FROM ADMINISTRADOR WHERE CEDULA_ADMINISTRADOR = '" + textBox1.Text + "'AND CONTRASENA_ADMINISTRADOR = '" + textBox2.Text + "' ", miConecion);

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
                if ((textBox1.Text == DR["CEDULA_ADMINISTRADOR"].ToString()) || (textBox2.Text == DR["CONTRASENA_ADMINISTRADOR"].ToString()))
                {
                    ZonaAdministradores f5 = new ZonaAdministradores();
                    sesion = textBox1.Text;
                    f5.sesion(ref sesion);
                    f5.Show();//abriendo el formulario principal
                    this.Hide();//esto sirve para ocultar el formulario de login
                }

            }
            catch
            {
                //en caso que la contraseña sea erronea mostrara un mensaje
                //dentro de los parentesis va: "Mensaje a mostrar","Titulo de la ventana",botones a mostrar en ste caso OK, icono a mostrar en este caso uno de error
                MessageBox.Show("Usuario o Contraseña incorrectos! Intentelo de nuevo.", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();

        }
    }
}
