using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlquilerPeliculas
{
    class Validacion
    {

        public static bool VerificarCedula(string ced)
        {

            int isNumeric;
            var total = 0;
            const int tamanoLongitudCedula = 10;
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            const int numeroProvicinas = 24;
            const int tercerDigito = 6;

            if(int.TryParse(ced, out isNumeric) && ced.Length == tamanoLongitudCedula){

                var provincia = Convert.ToInt32(string.Concat(ced[0], ced[1], string.Empty));
                var digitoTres = Convert.ToInt32(ced[2] + string.Empty);
                if((provincia > 0 && provincia <= numeroProvicinas) && digitoTres < tercerDigito){

                    var digitoVerificadorRecibido = Convert.ToInt32(ced[9] + string.Empty);

                    for (var k = 0; k < coeficientes.Length; k++)
                    {

                        var valor = Convert.ToInt32(coeficientes[k] + string.Empty) * Convert.ToInt32(ced[k] + string.Empty);
                        total = valor >= 10 ? total + (valor - 9) : total + valor;

                    }

                    var digitoVerificadorObtenido = total >= 10 ? (total%10) != 0 ? 10 - (total%10) : (total%10) : total;

                    return digitoVerificadorObtenido == digitoVerificadorRecibido;

                }

                return false;

            }

            return false;

        }


        static public void solonumeros(KeyPressEventArgs e)
        {

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permite el ingreso de numeros!", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Handled = true;
                return;
            }

        }


        static public void sololetras(KeyPressEventArgs e)
        {

            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permite el ingreso de letras!", "Video Club", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Handled = true;
                return;
            }

        }

    }

}
