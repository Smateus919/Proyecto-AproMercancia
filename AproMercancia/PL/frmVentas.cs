using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AproMercancia.BLL;
using AproMercancia.DAL;


namespace AproMercancia.PL
{
    public partial class frmVentas : Form
    {
        VentasDAL oVentasDAL;
        public frmVentas()
        {
            oVentasDAL = new VentasDAL();
            InitializeComponent();
            FillGrid();
        }
        private VentasBLL getInformation()
        {
            VentasBLL oVentasBLL = new VentasBLL();
            int RefProduc = 0; int.TryParse(cbxProducto.SelectedIndex.ToString(), out RefProduc);
            oVentasBLL.Producto = RefProduc+1;

            int RefEmpleado = 0; int.TryParse(cbxEmpleados.SelectedIndex.ToString(), out RefEmpleado);
            oVentasBLL.Empleado = RefEmpleado+1;

            int CantVentas = 0; int.TryParse(txtCantidad.Text, out CantVentas);
            oVentasBLL.Cantidad = CantVentas;

            return oVentasBLL;
        }
        private void FillGrid()
        {
            dgvVentas.DataSource = oVentasDAL.ShowVentas().Tables[0];
        }
        private void Ventas_Load(object sender, EventArgs e)
        {
            ProductosDAL oProductoDAL = new ProductosDAL();
            cbxProducto.DataSource = oProductoDAL.ShowProducts().Tables[0];
            cbxProducto.DisplayMember = "nombre";

            EmpleadosDAL oEmpleadosDAL = new EmpleadosDAL();
            cbxEmpleados.DataSource = oEmpleadosDAL.ShowEmpleados().Tables[0];
            cbxEmpleados.DisplayMember = "nombre";

            btnAgregar.Enabled = true;
            btnBorrar.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Conexion: " + oVentasDAL.addVentas(getInformation()));
            FillGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Actualización: " + oVentasDAL.Eliminar(getInformation()));
            FillGrid();
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            cbxProducto.Text = dgvVentas.Rows[indice].Cells[0].Value.ToString();
            cbxEmpleados.Text = dgvVentas.Rows[indice].Cells[1].Value.ToString();
            txtCantidad.Text = dgvVentas.Rows[indice].Cells[2].Value.ToString();
        }
    }
}
