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
    public partial class frmProductos : Form
    {
        ProductosDAL ProductosDAL;
        public frmProductos()
        {
            ProductosDAL = new ProductosDAL();
            InitializeComponent();
            FillGrid();
            CleanIntro();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Conexion: " + ProductosDAL.Agregar(getInformation()));
            FillGrid();
            CleanIntro();
        }
        private ProductosBLL getInformation()
        {
            ProductosBLL oProductosBLL = new ProductosBLL();

            int Ref = 0; int.TryParse(txtReferencia.Text, out Ref);
            int Valor = 0; int.TryParse(txtValor.Text, out Valor);
            int CantTienda = 0; int.TryParse(txtCantTienda.Text, out CantTienda);
            int CantBodega = 0; int.TryParse(txtCantBodega.Text, out CantBodega);

            oProductosBLL.Referencia = Ref;
            oProductosBLL.Nombre = txtNombre.Text;
            oProductosBLL.Valor = Valor;
            oProductosBLL.cantTienda = CantTienda;
            oProductosBLL.cantBodega = CantBodega;
            oProductosBLL.cantTotal = CantTienda + CantBodega;

            int idCategoria = 0;
            int.TryParse(cbxCategoria.SelectedIndex.ToString(), out idCategoria);

            oProductosBLL.Categoria = idCategoria+1;

            return oProductosBLL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dgvProductos.ClearSelection();

            if (indice>=0)
            {
                txtReferencia.Text = dgvProductos.Rows[indice].Cells[0].Value.ToString();
                txtNombre.Text = dgvProductos.Rows[indice].Cells[1].Value.ToString();
                txtValor.Text = dgvProductos.Rows[indice].Cells[2].Value.ToString();
                txtCantTienda.Text = dgvProductos.Rows[indice].Cells[3].Value.ToString();
                txtCantBodega.Text = dgvProductos.Rows[indice].Cells[4].Value.ToString();

                btnAgregar.Enabled = false;
                btnEditar.Enabled = true;
                btnBorrar.Enabled = true;
                btnCancelar.Enabled = true;
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Borrado: " + ProductosDAL.Eliminar(getInformation()));
            FillGrid();
            CleanIntro();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Actualización: " + ProductosDAL.Modificar(getInformation()));
            FillGrid();
            CleanIntro();
        }
        private void CleanIntro()
        {
            txtReferencia.Text = "";
            txtNombre.Text = "";
            txtValor.Text = "";
            txtCantBodega.Text = "";
            txtCantTienda.Text = "";
            cbxCategoria.Text = "";

            btnAgregar.Enabled = true;
            btnEditar.Enabled = false;
            btnBorrar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void FillGrid()
        {
            dgvProductos.DataSource = ProductosDAL.ShowProducts().Tables[0];

            dgvProductos.Columns[0].HeaderText = "Ref.";
            dgvProductos.Columns[1].HeaderText = "Nombre";
            dgvProductos.Columns[2].HeaderText = "Valor";
            dgvProductos.Columns[3].HeaderText = "Cant. Tienda";
            dgvProductos.Columns[4].HeaderText = "Cant. Bodega";
            dgvProductos.Columns[5].HeaderText = "Categoria";

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CleanIntro();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            CategoriasDAL objCategoriasDAL = new CategoriasDAL();
            cbxCategoria.DataSource = objCategoriasDAL.ShowCategories().Tables[0];
            cbxCategoria.DisplayMember = "nombre";
        }
    }
}
