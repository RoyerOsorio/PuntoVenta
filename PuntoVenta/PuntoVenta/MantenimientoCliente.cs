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
    public partial class MantenimientoCliente : Mantenimiento
    {
        public MantenimientoCliente()
        {
            InitializeComponent();
        }

        public override Boolean Guardar()
        {
            try
            {
                string cmd = string.Format($"EXEC ActualizarClientes {txtId.Text.Trim()},{txtNombre.Text.Trim()},{txtApellidos.Text.Trim()}");
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("¡Cliente guardado correctamente!");
                return true;
            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error: " + error.Message);
                return false;
            }
        }

        public override void Eliminar()
        {
            try
            {
                string cmd = string.Format($"EXEC EliminarClientes {txtId.Text.Trim()}");
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("¡El Cliente se ha eliminado!");

            }
            catch (Exception error)
            {
                MessageBox.Show("Ha ocurrido un error: " + error.Message);
            }
        }

    }
}
