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
    public partial class MantenimientoProducto : Mantenimiento
    {
        public MantenimientoProducto()
        {
            InitializeComponent();
        }


        public override Boolean Guardar()
        {
            if (Utilidades.ValidarFormulario(this, errorProvider1) == false)
            {
                try
                {
                    string cmd = string.Format($"EXEC ActualizarArticulos {txtId.Text.Trim()},{txtDescripcion.Text.Trim()},{txtPrecio.Text.Trim()}");
                    Utilidades.Ejecutar(cmd);
                    MessageBox.Show("¡Artículo guardado correctamente!");
                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ha ocurrido un error: " + error.Message);
                    return false;
                }
            }
            else{
                return false;
            }
        }

        public override void Eliminar()
        {
            try
            {
                string cmd = string.Format($"EXEC EliminarArticulos {txtId.Text.Trim()}");
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("¡El artículo se ha eliminado!");

            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error: " + error.Message);
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}
