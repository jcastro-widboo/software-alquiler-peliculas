using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AlquilerPeliculas
{
    internal class Conexion
    {

        internal static string GetConnectionString()
        {

            string returnValue = null;

            ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings["AlquilerPeliculas.Properties.Settings.connString"];

            if (settings != null)

                returnValue = settings.ConnectionString;

            return returnValue;

        }

    }

}