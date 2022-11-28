using Controladores;
using Entidad;
using Modelos;
using MySql.Data.MySqlClient;
using Negocio;
using System.Drawing.Imaging;

namespace Trabajo_final_Front_End
{

    public partial class VentasVista : Form
    {
        CnVentas cnVentas = new CnVentas();
        public VentasVista()
        {
            InitializeComponent();

            cbxEstatus.Text = "Activo";
            
        }
        private void cargarDatos()
        {
            dgvVentas.DataSource = cnVentas.obtenerDatos().Tables["tb1"];
        }
        private void Modulo10_Load(object sender, EventArgs e)
        {
            cargarDatos();
            tabControl1.TabPages.Remove(tabPage1);
            btnEditar.Enabled = false;
        }
        private void limpiarForm()
        {
            nudVenta.Value = 0;
            tbxNombre.Text = string.Empty;
            tbxPrecio.Text = string.Empty;
            tbxProducto.Text = string.Empty;
            cbxEstatus.Text = "Activo";
            
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            bool Resultado;
            CeVentas ceVentas = new CeVentas();
            ceVentas.Id = (int)nudVenta.Value;
            ceVentas.Cliente = tbxNombre.Text;
            ceVentas.PrecioVenta = tbxPrecio.Text;
            ceVentas.Producto = tbxProducto.Text;
            ceVentas.Estatus = cbxEstatus.Text;

            Resultado = cnVentas.validarDatos(ceVentas);

            if (Resultado == false)
            {
                return;
            }

            if (ceVentas.Id == 0)
            {
                cnVentas.crearEmpleado(ceVentas);
            }
            else
            {
                cnVentas.editarEmpleado(ceVentas);
            }


            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            cargarDatos();
            limpiarForm();
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage2);
        }

        

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage2);
        }

        private void btnLimpiar_Click_2(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar todos los datos?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                CeVentas cE = new CeVentas();
                cnVentas.eliminarDatos(cE);
                cargarDatos();
                limpiarForm();
            }
        }

        

        private void btnNuevo_Click_2(object sender, EventArgs e)
        {
            limpiarForm();
            nudVenta.Visible = false;
            lbVenta.Visible = false;
            cbxEstatus.Visible = false;
            lbEstatus.Visible = false;
            btnEliminar.Visible = false;
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cbxEstatus.Visible = true;
            lbVenta.Visible = true;
            nudVenta.Visible = true;
            lbEstatus.Visible = true;
            cbxEstatus.Enabled = true;
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
        }

        private void dgvEmpleado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            MessageBox.Show("Ya puedes Editar este campo");
            lbVenta.Visible = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = true;

            nudVenta.Value = (uint)dgvVentas.CurrentRow.Cells["IdVenta"].Value;
            tbxNombre.Text = dgvVentas.CurrentRow.Cells["cliente"].Value.ToString();
            tbxPrecio.Text = dgvVentas.CurrentRow.Cells["PrecioVenta"].Value.ToString();
            tbxProducto.Text = dgvVentas.CurrentRow.Cells["Producto"].Value.ToString();
            cbxEstatus.Text = dgvVentas.CurrentRow.Cells["Estatus"].Value.ToString();
            
            
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }
        private void btnEliminar_Click_3(object sender, EventArgs e)
        {
            if (nudVenta.Value == 0) return;

            if (MessageBox.Show("¿Seguro que deseas eliminar el registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                CeVentas cE = new CeVentas();
                cnVentas.eliminarEmpleado(cE);
                cargarDatos();
                limpiarForm();
            }

            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage2);
        }

        //Metodos sin usar
        
        
        private void lbImagen_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        
        private void tabPage2_Click_1(object sender, EventArgs e)
        {

        }
        
        
        

        private void EmpleadosVista_Load(object sender, EventArgs e)
        {

        }

        private void lbSalario_Click(object sender, EventArgs e)
        {

        }
    }
}
