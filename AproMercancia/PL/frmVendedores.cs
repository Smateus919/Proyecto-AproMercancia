using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AproMercancia.DLL;
using AproMercancia.DAL;

namespace AproMercancia.PL
{
    public partial class frmVendedores : Form
    {
        VendedoresDAL oVendedoresDAL;
        public frmVendedores()
        {
            oVendedoresDAL = new VendedoresDAL();
            InitializeComponent();
            FillGrid();
            CleanIntro();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Conexion: " + oVendedoresDAL.addVendedores(getInformation()));
            FillGrid();
            CleanIntro();
        }
        private VendedorBLL getInformation()
        {
            VendedorBLL oVendedor = new VendedorBLL();

            int Ref = 0; int.TryParse(txtRef.Text, out Ref);
            int Cedula = 0; int.TryParse(txtCedula.Text, out Cedula);
            int Fecha = 0; int.TryParse(txtDate.Text, out Fecha);

            oVendedor.Referencia = Ref;
            oVendedor.Nombre = txtNombre.Text;
            oVendedor.Cedula = Cedula;
            oVendedor.Fecha = Fecha;

            int idTienda = 0; int.TryParse(cbxTienda.SelectedIndex.ToString(), out idTienda);
            oVendedor.Tienda = idTienda + 1;

            return oVendedor;
        }
        private void FillGrid()
        {
            dgvVendedores.DataSource = oVendedoresDAL.ShowEmpleados().Tables[0];

            dgvVendedores.Columns[0].HeaderText = "Ref.";
            dgvVendedores.Columns[1].HeaderText = "Nombre";
            dgvVendedores.Columns[2].HeaderText = "Cedula";
            dgvVendedores.Columns[3].HeaderText = "Fecha Ingreso";
            dgvVendedores.Columns[4].HeaderText = "Ciudad";
            dgvVendedores.Columns[5].HeaderText = "Direccion";
        }
        private void frmVendedores_Load(object sender, EventArgs e)
        {
            TiendasDAL oTiendasDAL = new TiendasDAL();
            cbxTienda.DataSource = oTiendasDAL.ShowStores().Tables[0];
            cbxTienda.DisplayMember = "direccion";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dgvVendedores.ClearSelection();

            if (indice>=0)
            {

                txtDate.Enabled = false;
                txtRef.Text = dgvVendedores.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dgvVendedores.Rows[indice].Cells[1].Value.ToString();
                txtCedula.Text = dgvVendedores.Rows[indice].Cells[2].Value.ToString();
                txtDate.Text = dgvVendedores.Rows[indice].Cells[3].Value.ToString();

                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnBorrar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Conexion: " + oVendedoresDAL.removeVendedores(getInformation()));
            FillGrid();
            CleanIntro();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Conexion: " + oVendedoresDAL.updateVendedores(getInformation()));
            FillGrid();
            CleanIntro();
        }
        private void CleanIntro()
        {
            txtRef.Text = "";
            txtNombre.Text = "";
            txtCedula.Text = "";
            txtDate.Text = "";
            cbxTienda.Text = "";

            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;
            btnCancelar.Enabled = false;
            txtDate.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CleanIntro();
        }
    }
}
