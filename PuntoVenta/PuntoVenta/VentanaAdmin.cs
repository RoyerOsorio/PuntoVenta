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
    public partial class VentanaAdmin : FormBase
    {
        public VentanaAdmin()
        {
            InitializeComponent();
        }

        private void VentanaAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void VentanaAdmin_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM Usuarios WHERE ID=" + VentanaLogin.Codigo;

            DataSet DS = Utilidades.Ejecutar(cmd);

            txtNombre.Text = DS.Tables[0].Rows[0]["Nombre"].ToString();
            txtUsuario.Text = DS.Tables[0].Rows[0]["Account"].ToString();
            txtCodigo.Text = DS.Tables[0].Rows[0]["Id"].ToString();
            string url = DS.Tables[0].Rows[0]["Foto"].ToString();

            pictureBox1.Image = Image.FromFile(url);
        }

        private void btnContenedorPrincipal_Click(object sender, EventArgs e)
        {
            ContenedorPrincipal contPrin = new ContenedorPrincipal();
            this.Hide();
            contPrin.Show();
        }
    }
}
