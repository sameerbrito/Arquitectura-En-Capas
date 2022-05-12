using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Proyecto_Final_Pro
{
    public partial class VenPrin : Form
    {
        public VenPrin()
        {
            InitializeComponent();
        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
        }

        private void Datos()
        {
            tssUserDa.Text = " "+ Common.User
                + " | " + Common.Direccion 
                + " | " + Common.Localidad
                + " | " + Common.Telefono 
                + " | " + Common.Rol;
        }
        private void Inicio(Object Form)
        {
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);

            Form Ven = Form as Form;
            Ven.TopLevel = false;
            Ven.Dock = DockStyle.Fill;
            Ven.MdiParent = this;
            this.Contenedor.Controls.Add(Ven);
            this.Contenedor.Tag = Ven;
            Ven.Show();
        }
        private void VenPrin_Load(object sender, EventArgs e)
        {
            tssTime.Text = DateTime.Now.ToShortTimeString();
            tssDate.Text = DateTime.Now.ToShortDateString();
            Datos();
            Inicio(new Inicio());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GrupoEntidades(Object Form)
        {
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);

            Form Ven = Form as Form;
            Ven.TopLevel = false;
            Ven.Dock = DockStyle.Fill;
            Ven.MdiParent = this;
            this.Contenedor.Controls.Add(Ven);
            this.Contenedor.Tag = Ven;
            Ven.Show();
        }
        private void TipoEntidad(Object Form)
        {
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);

            Form Ven = Form as Form;
            Ven.TopLevel = false;
            Ven.Dock = DockStyle.Fill;
            Ven.MdiParent = this;
            this.Contenedor.Controls.Add(Ven);
            this.Contenedor.Tag = Ven;
            Ven.Show();
        }
        private void Entidad(Object Form)
        {
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);

            Form Ven = Form as Form;
            Ven.TopLevel = false;
            Ven.Dock = DockStyle.Fill;
            Ven.MdiParent = this;
            this.Contenedor.Controls.Add(Ven);
            this.Contenedor.Tag = Ven;
            Ven.Show();
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            GrupoEntidades(new GrupoEntidades());
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            TipoEntidad(new TipoEntidad());
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Entidad(new Entidad());
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.FromArgb(0, 122, 204);
        }
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            btnMin.BackColor = Color.LightGray;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            btnMin.BackColor = Color.FromArgb(0, 122, 204);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panellateral_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel13_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void LogIn(Object Form)
        {
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);
             
            Form Ven = Form as Form;
            Ven.TopLevel = false;
            Ven.Dock = DockStyle.Fill;
            Ven.MdiParent = this;
            this.Contenedor.Controls.Add(Ven);
            this.Contenedor.Tag = Ven;
            Ven.Show();
        }
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void AcercaDe(Object Form)
        {
            if (this.Contenedor.Controls.Count > 0)
                this.Contenedor.Controls.RemoveAt(0);

            Form Ven = Form as Form;
            Ven.TopLevel = false;
            Ven.Dock = DockStyle.Fill;
            Ven.MdiParent = this;
            this.Contenedor.Controls.Add(Ven);
            this.Contenedor.Tag = Ven;
            Ven.Show();
        }
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            AcercaDe(new AcercaDe());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Inicio(new Inicio());
        }
    }
}
