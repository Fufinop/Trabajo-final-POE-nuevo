using Controladores;
using Entidad;
using Modelos;
using MySql.Data.MySqlClient;
using Negocio;
using System.Drawing.Imaging;

namespace Trabajo_final_Front_End
{

    public partial class EmpleadosVista : Form
    {
        CnEmpleado cnEmpleado = new CnEmpleado();
        public EmpleadosVista()
        {
            InitializeComponent();

            cbxEstatus.Text = "Activo";
            
        }
        private void cargarDatos()
        {
            dgvEmpleado.DataSource = cnEmpleado.obtenerDatos().Tables["tb1"];
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
            tbxNombre.Text = string.Empty;
            tbxApellidos.Text = string.Empty;
            tbxSalario.Text = string.Empty;
            cbxTipo.Text = string.Empty;
            cbxEstatus.Text = "Activo";
            //pictureBox1 = null;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            bool Resultado;
            CeEmpleado ceEmpleado = new CeEmpleado();
            ceEmpleado.Id = (int)nudEmpleado.Value;
            ceEmpleado.Nombre = tbxNombre.Text;
            ceEmpleado.Apellidos = tbxApellidos.Text;
            ceEmpleado.Salario = tbxSalario.Text;
            ceEmpleado.Tipo = cbxTipo.Text;
            ceEmpleado.Estatus = cbxEstatus.Text;
            if (pictureBox2.Image != null)
            {
                ceEmpleado.Imagen = Imagen.imgToByte(pictureBox2.Image);
            }


            Resultado = cnEmpleado.validarDatos(ceEmpleado);

            if (Resultado == false)
            {
                return;
            }

            if (ceEmpleado.Id == 0)
            {
                cnEmpleado.crearEmpleado(ceEmpleado);
            }
            else
            {
                cnEmpleado.editarEmpleado(ceEmpleado);
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
                CeEmpleado cE = new CeEmpleado();
                cnEmpleado.eliminarDatos(cE);
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

            nudEmpleado.Value = (uint)dgvEmpleado.CurrentRow.Cells["IdEmpleado"].Value;
            tbxNombre.Text = dgvEmpleado.CurrentRow.Cells["Nombres"].Value.ToString();
            tbxApellidos.Text = dgvEmpleado.CurrentRow.Cells["Apellidos"].Value.ToString();
            tbxSalario.Text = dgvEmpleado.CurrentRow.Cells["Salario"].Value.ToString();
            cbxTipo.Text = dgvEmpleado.CurrentRow.Cells["Tipo"].Value.ToString();
            cbxEstatus.Text = dgvEmpleado.CurrentRow.Cells["Estatus"].Value.ToString();
            pictureBox2.Image = Image.FromStream(Imagen.byteToImg(dgvEmpleado.CurrentRow.Cells["Foto"].Value as byte[]));
            
            
            
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (tbxPrueba.Text != "")
            {
                CeEmpleado cE = new CeEmpleado();
                cnEmpleado.buscarEm(cE);
                cargarDatos();
            }
            CeEmpleado ceEmpleado = new CeEmpleado();
            ceEmpleado.Busqueda = tbxPrueba.Text;

            MessageBox.Show("" + ceEmpleado.Busqueda);
        }
        private void btnEliminar_Click_3(object sender, EventArgs e)
        {
            if (nudEmpleado.Value == 0) return;

            if (MessageBox.Show("¿Seguro que deseas eliminar el registro?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                CeEmpleado cE = new CeEmpleado();
                cnEmpleado.eliminarEmpleado(cE);
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

        
    }
}
