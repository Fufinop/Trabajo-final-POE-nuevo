using Controladores;
using Datos;
using Entidad;
using Modelos;
using MySql.Data.MySqlClient;
using Negocio;
using System.Drawing.Imaging;

namespace Trabajo_final_Front_End
{

    public partial class ClientesVista : Form
    {
        CnCliente cnCliente = new CnCliente();
        public ClientesVista()
        {
            InitializeComponent();

            cbxEstatus.Text = "Activo";
            
        }
        private void cargarDatos()
        {
            try
            {
                dgvCliente.DataSource = cnCliente.obtenerDatos().Tables["tb1"];
                DataGridViewImageColumn column = (DataGridViewImageColumn)dgvCliente.Columns[7];
                column.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }
            catch (Exception)
            {

            }
            

            
        }
        private void Modulo10_Load(object sender, EventArgs e)
        {
            cargarDatos();
            tabControl1.TabPages.Remove(tabPage1);
            btnEditar.Enabled = false;
            pictureBox1 = null;
        }
        private void limpiarForm()
        {
            nudCliente.Value = 0;
            tbxNombre.Text = "";
            tbxApellidos.Text = "";
            tbxDireccion.Text = "";
            cbxCedula.Text = "";
            cbxTelefono.Text = "";
            tbxEmail.Text = "";
            cbxEstatus.Text = "Activo";
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            bool Resultado;
            CeCliente ceCliente = new CeCliente();
            ceCliente.Id = (int)nudCliente.Value;
            ceCliente.Nombre = tbxNombre.Text;
            ceCliente.Apellidos = tbxApellidos.Text;
            ceCliente.Direccion = tbxDireccion.Text;
            ceCliente.Cedula = cbxCedula.Text;
            ceCliente.Telefono = cbxTelefono.Text;
            ceCliente.Email = tbxEmail.Text;
            ceCliente.Estatus = cbxEstatus.Text;
            if (pictureBox2.Image != null)
            {
                ceCliente.Imagen = Imagen.imgToByte(pictureBox2.Image);
            }


            Resultado = cnCliente.validarDatos(ceCliente);

            if (Resultado == false)
            {
                return;
            }

            if (ceCliente.Id == 0)
            {
                cnCliente.crearCliente(ceCliente);
            }
            else
            {
                cnCliente.editarCliente(ceCliente);
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
                CeCliente cE = new CeCliente();
                cnCliente.eliminarDatos(cE);
                cargarDatos();
                limpiarForm();
            }
        }

        

        private void btnNuevo_Click_2(object sender, EventArgs e)
        {
            limpiarForm();
            nudCliente.Visible = false;
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

            nudCliente.Value = (uint)dgvCliente.CurrentRow.Cells["IdCliente"].Value;
            tbxNombre.Text = dgvCliente.CurrentRow.Cells["Nombre"].Value.ToString();
            tbxApellidos.Text = dgvCliente.CurrentRow.Cells["Apellido"].Value.ToString();
            tbxDireccion.Text = dgvCliente.CurrentRow.Cells["Direccion"].Value.ToString();
            cbxCedula.Text = dgvCliente.CurrentRow.Cells["Cedula"].Value.ToString();
            cbxTelefono.Text = dgvCliente.CurrentRow.Cells["Telefono"].Value.ToString();
            tbxEmail.Text = dgvCliente.CurrentRow.Cells["E-mail"].Value.ToString();
            pictureBox2.Image = Image.FromStream(Imagen.byteToImg(dgvCliente.CurrentRow.Cells["Foto"].Value as byte[]));
            cbxEstatus.Text = dgvCliente.CurrentRow.Cells["Estatus"].Value.ToString();
           
            
            
            
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CeCliente ceCliente = new CeCliente();
            ceCliente.Busqueda = tbxPrueba.Text;
            try
            {
                dgvCliente.DataSource = cnCliente.buscarDatos(ceCliente).Tables["tb1"];
                DataGridViewImageColumn column = (DataGridViewImageColumn)dgvCliente.Columns[7];
                column.ImageLayout = DataGridViewImageCellLayout.Zoom;

            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            
        }
        private void btnEliminar_Click_3(object sender, EventArgs e)
        {
            if (nudCliente.Value == 0) return;

            if (MessageBox.Show("¿Seguro que deseas eliminar el registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                CeCliente cE = new CeCliente();
                cnCliente.eliminarCliente(cE);
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

        private void lbEstatus_Click(object sender, EventArgs e)
        {

        }

        private void nudEmpleado_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tbxApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxSalario_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbSalario_Click(object sender, EventArgs e)
        {

        }

        private void lbEmpleado_Click(object sender, EventArgs e)
        {

        }

        private void lbNombre_Click(object sender, EventArgs e)
        {

        }

        private void lbApellidos_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
