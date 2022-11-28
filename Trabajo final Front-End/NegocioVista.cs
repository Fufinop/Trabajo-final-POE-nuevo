using Controladores;
using Entidad;
using Modelos;
using MySql.Data.MySqlClient;
using Negocio;
using System.Drawing.Imaging;

namespace Trabajo_final_Front_End
{

    public partial class NegocioVista : Form
    {
        CnNegocio cnNegocio = new CnNegocio();
        public NegocioVista()
        {   
            InitializeComponent();

            cbxEstatus.Text = "Activo";
            
        }
        private void cargarDatos()
        {
            dgvEmpleado.DataSource = cnNegocio.obtenerDatos().Tables["tb1"];
        }
        private void Modulo10_Load(object sender, EventArgs e)
        {
            cargarDatos();
            tabControl1.TabPages.Remove(tabPage1);
            btnEditar.Enabled = false;
            
        }
        private void limpiarForm()
        {
            nudNegocio.Value = 0;
            tbxCiudad.Text = string.Empty;
            tbxDireccion.Text = string.Empty;
            tbxSucursal.Text = string.Empty;
            cbxEstatus.Text = "Activo";
            
        }


        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            

            bool Resultado;
            CeNegocio ceNegocio = new CeNegocio();
            ceNegocio.Id = (int)nudNegocio.Value;
            ceNegocio.Ciudad = tbxCiudad.Text;
            ceNegocio.Direccion = tbxDireccion.Text;
            ceNegocio.Sucursal = tbxSucursal.Text;
            ceNegocio.Estatus = cbxEstatus.Text;
            Resultado = cnNegocio.validarDatos(ceNegocio);

            if (Resultado == false)
            {
                return;
            }

            if (ceNegocio.Id == 0)
            {
                cnNegocio.crearNegocio(ceNegocio);
            }
            else
            {
                cnNegocio.editarNegocio(ceNegocio);
            }


            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            cargarDatos();
            limpiarForm();
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage2);
            btnEditar.Enabled = false;
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
                CeNegocio cE = new CeNegocio();
                cnNegocio.eliminarNegocio(cE);
                cargarDatos();
                limpiarForm();
            }
        }

        

        private void btnNuevo_Click_2(object sender, EventArgs e)
        {
            limpiarForm();
            nudNegocio.Visible = false;
            lbIdSucursal.Visible = false;
            cbxEstatus.Visible = false;
            lbEstatus.Visible = false;
            btnEliminar.Visible = false;
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cbxEstatus.Visible = true;
            lbIdSucursal.Visible = true;
            cbxEstatus.Visible = true;
            lbEstatus.Visible = true;
            cbxEstatus.Enabled = true;
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
        }

        private void dgvEmpleado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            MessageBox.Show("Ya puedes Editar este campo");
            btnEditar.Enabled = true;
            btnNuevo.Enabled = false;

            nudNegocio.Value = (uint)dgvEmpleado.CurrentRow.Cells["IdNegocio"].Value;
            tbxCiudad.Text = dgvEmpleado.CurrentRow.Cells["Ciudad"].Value.ToString();
            tbxDireccion.Text = dgvEmpleado.CurrentRow.Cells["Direccion"].Value.ToString();
            tbxSucursal.Text = dgvEmpleado.CurrentRow.Cells["Sucursal"].Value.ToString();
            cbxEstatus.Text = dgvEmpleado.CurrentRow.Cells["Estatus"].Value.ToString();

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CeNegocio ceNegocio = new CeNegocio();
            ceNegocio.Busqueda = tbxPrueba.Text;

            if (tbxPrueba.Text != string.Empty)
            {
                CeNegocio cE = new CeNegocio();
                cnNegocio.buscarDatos(cE);
            }
            else
            {
                MessageBox.Show("Debes ingresar alguna busquedad en el campo");
            }

            cargarDatos();
            tbxPrueba.Text = string.Empty;
        }
        private void btnEliminar_Click_3(object sender, EventArgs e)
        {
            if (nudNegocio.Value == 0) return;

            if (MessageBox.Show("¿Seguro que deseas eliminar el registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                CeNegocio cE = new CeNegocio();
                cnNegocio.eliminarNegocio(cE);
                cargarDatos();
                limpiarForm();
            }

            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage2);
        }

        //Metodos sin usar
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {

        }
        private void lbImagen_Click(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {

        }
        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {

        }
        private void lbEmpleado_Click(object sender, EventArgs e)
        {

        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void tabPage2_Click_1(object sender, EventArgs e)
        {

        }
        private void btnNuevo_Click_1(object sender, EventArgs e)
        {

        }
        private void cbxEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void lbEmpleado_Click_1(object sender, EventArgs e)
        {

        }

        private void lbNombre_Click(object sender, EventArgs e)
        {

        }

        private void lbSalario_Click(object sender, EventArgs e)
        {

        }

        
    }
}
