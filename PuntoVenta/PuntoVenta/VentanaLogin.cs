using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiLibreria;

namespace PuntoVenta
{
    public partial class VentanaLogin : FormBase
    {
        public VentanaLogin()
        {
            InitializeComponent();
        }

        public static String Codigo = "";
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = string.Format($"SELECT * FROM Usuarios WHERE Account= '{txtUsuario.Text.Trim()}' AND Password = '{txtPassword.Text.Trim()}'");
                DataSet Ds = Utilidades.Ejecutar(cmd);

                Codigo = Ds.Tables[0].Rows[0]["Id"].ToString().Trim();

                string usuario = Ds.Tables[0].Rows[0]["Account"].ToString().Trim();
                string password = Ds.Tables[0].Rows[0]["Password"].ToString().Trim();

                if (usuario == txtUsuario.Text.Trim() && password == txtPassword.Text.Trim())
                {
                    if (Convert.ToBoolean(Ds.Tables[0].Rows[0]["Estatus_Admin"])==true)
                    {
                        VentanaAdmin venAdmin = new VentanaAdmin();
                        this.Hide();
                        venAdmin.Show();
                    }
                    else
                    {
                        VentanaUser venUser = new VentanaUser();
                        this.Hide();
                        venUser.Show();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Usuario o contraseña incorrectos!");
            }
        }

        private void VentanaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
