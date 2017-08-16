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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = string.Format($"SELECT * FROM Usuarios WHERE Account= '{txtUsuario.Text.Trim()}' AND Password = '{txtPassword.Text.Trim()}'");
                DataSet Ds = Utilidades.Ejecutar(cmd);

                string usuario = Ds.Tables[0].Rows[0]["Account"].ToString().Trim();
                string password = Ds.Tables[0].Rows[0]["Password"].ToString().Trim();

                if (usuario == txtUsuario.Text.Trim() && password == txtPassword.Text.Trim())
                {
                    MessageBox.Show("Se ha iniciado sesion");
                }
            }
            catch
            {
                MessageBox.Show("Usuario o contraseña incorrectos!");
            }
        }
    }
}
