using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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

        public static Boolean ValidarFormulario(Control objeto, ErrorProvider ErrorProvider)
        {
            Boolean HayErrores = false;

            foreach (Control item in objeto.Controls)
            {
                if (item is ErrorTxtBox)
                {
                    ErrorTxtBox obj = (ErrorTxtBox)item;
                    if (obj.Validar == true)
                    {
                        if (string.IsNullOrEmpty(obj.Text.Trim()))
                        {
                            ErrorProvider.SetError(obj, "No puede estar vacio");
                            HayErrores = true;
                        }
                    }

                    if (obj.SoloNumeros == true)
                    {
                        int contador = 0, LetrasEncontradas = 0;

                        foreach (char letra in obj.Text.Trim())
                        {
                            if (char.IsLetter(obj.Text.Trim(),contador))
                            {
                                LetrasEncontradas++;
                            }
                            contador++;
                        }

                        if (LetrasEncontradas != 0)
                        {
                            HayErrores = true;
                            ErrorProvider.SetError(obj, "Sólo números");
                        }
                    }
                    
                }
            }
            return HayErrores;
        }
    }
}
