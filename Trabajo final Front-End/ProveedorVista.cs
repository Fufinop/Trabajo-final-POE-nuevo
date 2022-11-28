using Controladores;
using Entidad;
using Modelos;
using MySql.Data.MySqlClient;
using Negocio;
using System.Drawing.Imaging;

namespace Trabajo_final_Front_End
{

    public partial class ProveedorVista : Form
    {
        CnProveedor cnProveedor = new CnProveedor();
        public ProveedorVista()
        {
            InitializeComponent();

            cbxEstatus.Text = "Activo";
            
        }
        private void cargarDatos()
        {
            dgvProveedor.DataSource = cnProveedor.obtenerDatos().Tables["tb1"];
            DataGridViewImageColumn column = (DataGridViewImageColumn)dgvProveedor.Columns[8];
            column.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
        private void Modulo10_Load(object sender, EventArgs e)
        {
            cargarDatos();
            tabControl1.TabPages.Remove(tabPage1);
            pictureBox1 = null;
            btnEditar.Enabled = false;
        }
        private void limpiarForm()
        {
            nudProveedor.Value = 0;
            tbxCodigoProveedor.Text = string.Empty;
            tbxCodigoCiudad.Text= string.Empty;
            tbxNombre.Text= string.Empty;
            tbxDireccion.Text= string.Empty;
            tbxtelefono.Text= string.Empty;
            tbxEmail.Text= string.Empty;
            tbxProducto.Text= string.Empty;
            //pictureBox2= null;
            cbxEstatus.Text = "Activo";

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            bool Resultado;
            CeProveedor ceProveedor = new CeProveedor();
            ceProveedor.ID = (int)nudProveedor.Value;
            ceProveedor.CodigoProveedor = tbxCodigoProveedor.Text;
            ceProveedor.CodigoCiudad = tbxCodigoCiudad.Text;
            ceProveedor.Nombre = tbxNombre.Text;    
            ceProveedor.Direccion= tbxDireccion.Text;
            ceProveedor.Telefono = tbxtelefono.Text;
            ceProveedor.EMail = tbxEmail.Text;
            ceProveedor.Producto = tbxProducto.Text;
            ceProveedor.Estatus = cbxEstatus.Text;

            if (pictureBox2.Image != null)
            {
                ceProveedor.Foto = Imagen.imgToByte(pictureBox2.Image);
            }


            Resultado = cnProveedor.validarDatos(ceProveedor);

            if (Resultado == false)
            {
                return;
            }

            if (ceProveedor.ID == 0)
            {
                cnProveedor.crearEmpleado(ceProveedor);
            }
            else
            {
                cnProveedor.editarEmpleado(ceProveedor);
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
                CeProveedor cE = new CeProveedor();
                cnProveedor.eliminarDatos(cE);
                cargarDatos();
                limpiarForm();
            }
        }

        

        private void btnNuevo_Click_2(object sender, EventArgs e)
        {
            limpiarForm();
            nudProveedor.Visible = false;
            lbProveedor.Visible = false;
            cbxEstatus.Visible = false;
            lbEstatus.Visible = false;
            btnEliminar.Visible = false;
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cbxEstatus.Visible = true;
            lbProveedor.Visible = true;
            cbxEstatus.Visible = true;
            lbEstatus.Visible = true;
            cbxEstatus.Enabled = true;
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
        }

        private void dgvEmpleado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            MessageBox.Show("Ya puedes Editar este campo");
            lbProveedor.Visible = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = true;

            nudProveedor.Value = (uint)dgvProveedor.CurrentRow.Cells["IdProveedor"].Value;
            tbxCodigoProveedor.Text = dgvProveedor.CurrentRow.Cells["CodigoProvedor"].Value.ToString();
            tbxCodigoCiudad.Text = dgvProveedor.CurrentRow.Cells["CodigoCiudad"].Value.ToString();
            tbxNombre.Text = dgvProveedor.CurrentRow.Cells["Nombre"].Value.ToString();
            tbxDireccion.Text = dgvProveedor.CurrentRow.Cells["Direccion"].Value.ToString();
            tbxtelefono.Text = dgvProveedor.CurrentRow.Cells["Telefono"].Value.ToString();
            tbxEmail.Text = dgvProveedor.CurrentRow.Cells["E-mail"].Value.ToString();
            tbxProducto.Text = dgvProveedor.CurrentRow.Cells["Producto"].Value.ToString();
            cbxEstatus.Text = dgvProveedor.CurrentRow.Cells["Estatus"].Value.ToString();
            pictureBox2.Image = Image.FromStream(Imagen.byteToImg(dgvProveedor.CurrentRow.Cells["Foto"].Value as byte[]));
            
            
            
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }
        private void btnEliminar_Click_3(object sender, EventArgs e)
        {
            if (nudProveedor.Value == 0) return;

            if (MessageBox.Show("¿Seguro que deseas eliminar el registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                CeProveedor cE = new CeProveedor();
                cnProveedor.eliminarEmpleado(cE);
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
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();

            ofdSeleccionar.Filter = "Imagenes | jpg; *.png;";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox2.Image = Image.FromFile(ofdSeleccionar.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.ToString);
                    throw;
                }
                
            }


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
