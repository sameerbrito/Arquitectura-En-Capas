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
    public partial class Splash_Screen : Form
    {
        public Splash_Screen()
        {
            InitializeComponent();
        }

        private void Splash_Screen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Splash_Screen_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void btnMin_MouseEnter(object sender, EventArgs e)
        {
            btnMin.BackColor = Color.IndianRed;
        }

        private void btnMin_MouseLeave(object sender, EventArgs e)
        {
            btnMin.BackColor = Color.FromArgb(40, 40, 40);
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.White;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.Gray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.White;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.Gray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Conexion.conectar();
            string BUSCAR = "SELECT * FROM Entidades " +
                "WHERE UserNameEntidad='" + txtUser.Text + "' AND PassworEntidad='" + txtPass.Text + "'";

            SqlCommand cmd = new SqlCommand(BUSCAR, Conexion.conectar());

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Common.User = dr.GetString(16);
                Common.Direccion = dr.GetString(2);
                Common.Localidad = dr.GetString(3);
                Common.Telefono = dr.GetString(7);
                Common.Rol = dr.GetString(18);

                VenPrin VPrin = new VenPrin();
                VPrin.Show();
                VPrin.FormClosed += LogOut;
                this.Hide();
            }
            else
            {
                Error.Visible = true;
                Error.Text = "      Usuario o Contraseña son incorrectos";
            }
        }
        private void LogOut(Object Sender, FormClosedEventArgs e)
        {
            txtUser.Text = "Usuario";
            txtPass.Text = "Contraseña";
            txtUser.ForeColor = Color.Gray;
            txtPass.ForeColor = Color.Gray;
            txtPass.UseSystemPasswordChar = false;
            Error.Visible = false;
            this.Show();
        }
    }
}
