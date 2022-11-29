using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using Entidad;
using FontAwesome.Sharp;

namespace Trabajo_final_Front_End
{
    public partial class Principal : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        public object Tipo { get; }

        public Principal()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(10, 60);
            pnLateral.Controls.Add(leftBorderBtn);
            
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered= true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        public Principal(object tipo)
        {
            Tipo = tipo;
        }

        //Struct
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(255, 190, 11);
            public static Color color2 = Color.FromArgb(255, 84, 0);
            public static Color color3 = Color.FromArgb(255, 0, 84);
            public static Color color4 = Color.FromArgb(131, 56, 236);
            public static Color color5 = Color.FromArgb(58, 134, 255);
            public static Color color6 = Color.FromArgb(125, 133, 151);
            public static Color color7 = Color.FromArgb(38, 166, 154);
        }
        //Metodos 
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn; 
                currentBtn.BackColor = Color.FromArgb(37,36,81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0,currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Icon Current Child Form
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void abriFormHijo(Form childForm)
        {
            if (currentChildForm != null)
            {
                //Abrir un solo form
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnEscritorio.Controls.Add(childForm);       
            pnEscritorio.Tag= childForm;
            childForm.BringToFront();
            childForm.Show();
            lbTituloFormHijo.Text = childForm.Text;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            abriFormHijo(new EmpleadosVista());

        }

        private void ibtnClientes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            abriFormHijo(new ClientesVista());
        }

        private void ibtnProveedor_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            abriFormHijo(new ProveedorVista());
        }
        private void ibtnVentas_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            abriFormHijo(new VentasVista());
        }

        private void ibtnInventario_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            abriFormHijo(new InventarioVista());
        }

        private void ibtnNegocio_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            abriFormHijo(new NegocioVista());
        }
        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
            abriFormHijo(new Login());

            ibtnEmpleados.Enabled = true;
            ibtnClientes.Enabled = true;
            ibtnProveedor.Enabled = true;
            ibtnVentas.Enabled = true;
            ibtnInventario.Enabled = true;
            ibtnNegocio.Enabled = true;
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentChildForm.Enabled)
                {
                    currentChildForm.Close();
                }
                
                Reset();
            }
            catch (Exception)
            {
                
            }
            
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.DarkCyan;
            lbTituloFormHijo.Text = "Home";
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void BarraDeTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            try
            {
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //Eventos sin usar

        private void lbTituloFormHijo_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pnEscritorio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Principal_Load(object sender, EventArgs e)
        {
        }

        
    }
}
