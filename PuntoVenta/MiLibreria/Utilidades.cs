using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MiLibreria
{
    public class Utilidades
    {
        public static DataSet Ejecutar(string cmd)
        {
            SqlConnection conexion = new SqlConnection("Data Source=ROYEROSORIO19\\ROYERSQLSERVER;Initial Catalog=PuntoVenta;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conexion.Open();

            DataSet Ds = new DataSet();
            SqlDataAdapter Da = new SqlDataAdapter(cmd, conexion);
            Da.Fill(Ds);

            conexion.Close();

            return Ds;
        }
    }
}
