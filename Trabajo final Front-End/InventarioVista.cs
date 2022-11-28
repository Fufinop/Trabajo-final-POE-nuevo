using Controladores;
using Entidad;
using Modelos;
using MySql.Data.MySqlClient;
using Negocio;
using System.Drawing.Imaging;

namespace Trabajo_final_Front_End
{

    public partial class InventarioVista : Form
    {
        CnInventario cnInventario = new CnInventario();
        public InventarioVista()
        {
            InitializeComponent();

            cbxEstatus.Text = "Activo";
            
        }
        private void cargarDatos()
        {
            dgvEmpleado.DataSource = cnInventario.obtenerDatos().Tables["tb1"];
            DataGridViewImageColumn column = (DataGridViewImageColumn)dgvEmpleado.Columns[5];
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
            nudEmpleado.Value = 0;
            tbxCodigo.Text = string.Empty;
            tbxNombre.Text = string.Empty;
            tbxDescripcion.Text = string.Empty;
            tbxStock.Text = string.Empty;

            cbxEstatus.Text = "Activo";
            //pictureBox1 = null;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            bool Resultado;
            CeInventario ceInventario = new CeInventario();
            ceInventario.ID = (int)nudEmpleado.Value;
            ceInventario.Codigo = tbxCodigo.Text;
            ceInventario.Nombre = tbxNombre.Text;
            ceInventario.Descripcion = tbxDescripcion.Text;
            ceInventario.Stock = tbxStock.Text;
            ceInventario.Estatus = cbxEstatus.Text;
            if (pictureBox2.Image != null)
            {
                ceInventario.Imagen = Imagen.imgToByte(pictureBox2.Image);
            }


            Resultado = cnInventario.validarDatos(ceInventario);

            if (Resultado == false)
            {
                return;
            }

            if (ceInventario.ID == 0)
            {
                cnInventario.crearEmpleado(ceInventario);
            }
            else
            {
                cnInventario.editarEmpleado(ceInventario);
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
                CeInventario cE = new CeInventario();
                cnInventario.eliminarDatos(cE);
                cargarDatos();
                limpiarForm();
            }
        }

        

        private void btnNuevo_Click_2(object sender, EventArgs e)
        {
            limpiarForm();
            nudEmpleado.Visible = false;
            lbEmpleado.Visible = false;
            cbxEstatus.Visible = false;
            lbEstatus.Visible = false;
            btnEliminar.Visible = false;
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cbxEstatus.Visible = true;
            lbEmpleado.Visible = true;
            cbxEstatus.Visible = true;
            lbEstatus.Visible = true;
            cbxEstatus.Enabled = true;
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Add(tabPage1);
        }

        private void dgvEmpleado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            MessageBox.Show("Ya puedes Editar este campo");
            lbEmpleado.Visible = false;
            btnNuevo.Enabled = false;
            btnEditar.Enabled = true;

            nudEmpleado.Value = (uint)dgvEmpleado.CurrentRow.Cells["IdProducto"].Value;
            tbxCodigo.Text = dgvEmpleado.CurrentRow.Cells["Codigo Producto"].Value.ToString();
            tbxNombre.Text = dgvEmpleado.CurrentRow.Cells["Nombre"].Value.ToString();
            tbxDescripcion.Text = dgvEmpleado.CurrentRow.Cells["Descripcion"].Value.ToString();
            tbxStock.Text = dgvEmpleado.CurrentRow.Cells["Stock"].Value.ToString();
            cbxEstatus.Text = dgvEmpleado.CurrentRow.Cells["Estatus"].Value.ToString();
            pictureBox2.Image = Image.FromStream(Imagen.byteToImg(dgvEmpleado.CurrentRow.Cells["Foto"].Value as byte[]));
            
            
            
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }
        private void btnEliminar_Click_3(object sender, EventArgs e)
        {
            if (nudEmpleado.Value == 0) return;

            if (MessageBox.Show("¿Seguro que deseas eliminar el registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                CeInventario cE = new CeInventario();
                cnInventario.eliminarEmpleado(cE);
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



        private void EmpleadosVista_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
