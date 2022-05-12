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
    public partial class Entidad : Form
    {
        public Entidad()
        {
            InitializeComponent();
        }

        private void Entidad_Load(object sender, EventArgs e)
        {
            Conexion.conectar();

            dataGridView1.DataSource = LlenarTable();

            llenarboxGrupoE();
        }
        public void llenarboxGrupoE()
        {
            Conexion.conectar();
            string Consulta = "SELECT IdGrupoEntidad FROM GruposEntidades";
            SqlCommand cmd = new SqlCommand(Consulta, Conexion.conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Conexion.close();

            DataRow fila = dt.NewRow();
            fila["IdGrupoEntidad"] = 0;
            dt.Rows.InsertAt(fila, 0);

            boxIDGrupsEntidad.ValueMember = "IdGrupoEntidad";
            boxIDGrupsEntidad.DisplayMember = "IdGrupoEntidad";
            boxIDGrupsEntidad.DataSource = dt;
        }
        public void llenarboxTipoE(int IdGrupoEntidad)
        {
            Conexion.conectar();
            string Consulta = "SELECT IdTipoEntidad FROM TiposEntidades WHERE IdGrupoEntidad = '"+ boxIDGrupsEntidad.Text + "'";
            SqlCommand cmd = new SqlCommand(Consulta, Conexion.conectar());
            cmd.Parameters.AddWithValue("IdGrupoEntidad", IdGrupoEntidad);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Conexion.close();

            DataRow dr = dt.NewRow();
            dr["IdTipoEntidad"] = 0;
            dt.Rows.InsertAt(dr, 0);

            boxIDTipoEntidad.ValueMember = "IdTipoEntidad";
            boxIDTipoEntidad.DisplayMember = "IdTipoEntidad";
            boxIDTipoEntidad.DataSource = dt;

        }
        private void boxIDGrupsEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxIDGrupsEntidad.SelectedValue != null)
            {
                int IdGrupoEntidad = boxIDGrupsEntidad.SelectedValue.GetHashCode();
                llenarboxTipoE(IdGrupoEntidad);
            }
        }
        private void horafecha_Tick(object sender, EventArgs e)
        {
        }
        public DataTable LlenarTable()
        {
            Conexion.conectar();
            DataTable dt = new DataTable();
            string Consulta = "SELECT IdEntidad,Descripcion,Direccion,Localidad,TipoEntidad," +
                "TipoDocumento,NumeroDocumento,Telefono,urlPaginaWeb,urlFacebook," +
                "urlInstagram,urlTwitter,urlTiktok," +
                "IdGrupoEntidad,IdTipoEntidad,LimiteCredito," +
                "UserNameEntidad,RollUserEntidad,Comentario,Status,Noeliminable,FechaRegistro " +
                "FROM Entidades";
            SqlCommand cmd = new SqlCommand(Consulta, Conexion.conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            return dt;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtPass.Enabled = false;

            Conexion.conectar();
            string NUEVO = "INSERT INTO Entidades VALUES " +
                "('" + txtDescripcion.Text + "'," +
                "'" + txtDireccion.Text + "'," +
                "'" + txtLocalidad.Text + "'," +
                "'" + boxTipoEntidad.Text + "'," +
                "'" + boxTipoDoc.Text + "'," +
                "'" + txtDoc.Text + "'," +
                "'" + txtCel.Text + "'," +
                "'" + txtWeb.Text + "'," +
                "'" + txtFacebook.Text + "'," +
                "'" + txtInsta.Text + "'," +
                "'" + txtTwitter.Text + "'," +
                "'" + txtTiktok.Text + "'," +
                "'" + boxIDGrupsEntidad.Text + "'," +
                "'" + boxIDTipoEntidad.Text + "'," +
                "'" + txtCredito.Text + "'," +
                "'" + txtUser.Text + "'," +
                "'" + txtPass.Text + "'," +
                "'" + boxRol.Text + "'," +
                "'" + txtComentario.Text + "'," +
                "'" + boxStatus.Text + "'," +
                "'" + NoEliminable.Checked + "'," +
                "'" + DateTime.Now.ToShortDateString() + "')";

            SqlCommand cmd = new SqlCommand(NUEVO, Conexion.conectar());

            cmd.ExecuteNonQuery();
            MessageBox.Show("Entidad creada exitosamente");


            txtID.Text = "000";
            txtDescripcion.Text = "";
            txtDireccion.Text = "";
            txtLocalidad.Text = "";
            boxTipoEntidad.Text = "Juridica";
            boxTipoDoc.Text = "RNC";
            txtDoc.Text = "";
            txtCel.Text = "";
            txtWeb.Text = "Url Pagina Web";
            txtFacebook.Text = "Url Facebook";
            txtInsta.Text = "Url Instagram";
            txtTwitter.Text = "Url Twitter";
            txtTiktok.Text = "Url TikTok";
            boxIDGrupsEntidad.Text = "";
            boxIDTipoEntidad.Text = "";
            txtCredito.Text = "";
            txtUser.Text = "";
            txtUser.Text = "";
            txtUser.Enabled = false;
            boxRol.Text = "User";
            txtComentario.Text = "";
            boxStatus.Text = "Activa";
            NoEliminable.Checked = false;
            txtFecha.Text = "00/00/0000";

            dataGridView1.DataSource = LlenarTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtPass.Enabled = false;

            Conexion.conectar();
            string EDITAR = "UPDATE Entidades SET " +
                "Descripcion='" + txtDescripcion.Text + "'," +
                "Direccion='" + txtDireccion.Text + "'," +
                "Localidad='" + txtLocalidad.Text + "'," +
                "TipoEntidad='" + boxTipoEntidad.Text + "'," +
                "TipoDocumento='" + boxTipoDoc.Text + "'," +
                "NumeroDocumento='" + txtDoc.Text + "'," +
                "Telefono='" + txtCel.Text + "'," +
                "urlPaginaWeb='" + txtWeb.Text + "'," +
                "urlFacebook='" + txtFacebook.Text + "'," +
                "urlInstagram='" + txtInsta.Text + "'," +
                "urlTwitter='" + txtTwitter.Text + "'," +
                "urlTiktok='" + txtTiktok.Text + "'," +
                "IdGrupoEntidad='" + boxIDGrupsEntidad.Text + "'," +
                "IdTipoEntidad='" + boxIDTipoEntidad.Text + "'," +
                "LimiteCredito='" + txtCredito.Text + "'," +
                "UserNameEntidad='" + txtUser.Text + "'," +
                "RollUserEntidad='" + boxRol.Text + "'," +
                "Comentario='" + txtComentario.Text + "'," +
                "Status='" + boxStatus.Text + "'," +
                "Noeliminable='" + NoEliminable.Checked + "'" +
                " WHERE IdEntidad='" + txtID.Text + "'";

            SqlCommand cmd = new SqlCommand(EDITAR, Conexion.conectar());

            cmd.ExecuteNonQuery();
            MessageBox.Show("Entidad actualizada exitosamente");

            dataGridView1.DataSource = LlenarTable();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.conectar();
            string Consulta = "SELECT * FROM Entidades WHERE IdEntidad ='"+ txtID.Text + "'";
            SqlCommand cmd = new SqlCommand(Consulta, Conexion.conectar());


            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                if (NoEliminable.Checked != true) 
                {
                    Conexion.conectar();
                    string ELIMINAR = "DELETE FROM Entidades WHERE IdEntidad='" + txtID.Text + "'";

                    SqlCommand cmd1 = new SqlCommand(ELIMINAR, Conexion.conectar());

                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Los datos se eliminaron correctamente");

                    txtID.Text = "000";
                    txtDescripcion.Text = "";
                    txtDireccion.Text = "";
                    txtLocalidad.Text = "";
                    boxTipoEntidad.Text = "Juridica";
                    boxTipoDoc.Text = "RNC";
                    txtDoc.Text = "";
                    txtCel.Text = "";
                    txtWeb.Text = "Url Pagina Web";
                    txtFacebook.Text = "Url Facebook";
                    txtInsta.Text = "Url Instagram";
                    txtTwitter.Text = "Url Twitter";
                    txtTiktok.Text = "Url TikTok";
                    boxIDGrupsEntidad.Text = "";
                    boxIDTipoEntidad.Text = "";
                    txtCredito.Text = "";
                    txtUser.Text = "";
                    boxRol.Text = "User";
                    txtComentario.Text = "";
                    boxStatus.Text = "Activa";
                    NoEliminable.Checked = false;
                    txtFecha.Text = "00/00/0000";

                    dataGridView1.DataSource = LlenarTable();
                }
                else 
                {
                    MessageBox.Show("Entidad No Esta Autorizada Para Eliminar");
                }   
            }
            else
            {
                MessageBox.Show("Entidad No Encontrado");
            }


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            {

                txtPass.Enabled= true;

                txtID.Text = "000";
                txtDescripcion.Text = "";
                txtDireccion.Text = "";
                txtLocalidad.Text = "";
                boxTipoEntidad.Text = "Juridica";
                boxTipoDoc.Text = "RNC";
                txtDoc.Text = "";
                txtCel.Text = "";
                txtWeb.Text = "Url Pagina Web";
                txtFacebook.Text = "Url Facebook";
                txtInsta.Text = "Url Instagram";
                txtTwitter.Text = "Url Twitter";
                txtTiktok.Text = "Url TikTok";
                boxIDGrupsEntidad.Text = "";
                boxIDTipoEntidad.Text = "";
                txtCredito.Text = "";
                txtUser.Text = "";
                boxRol.Text = "User";
                txtComentario.Text = "";
                boxStatus.Text = "Activa";
                NoEliminable.Checked = false;
                txtFecha.Text = "00/00/0000";
            }
        }

        private void txtWeb_MouseEnter(object sender, EventArgs e)
        {
            if (txtWeb.Text == "Url Pagina Web")
            {
                txtWeb.Text = "";
            }
        }

        private void txtWeb_MouseLeave(object sender, EventArgs e)
        {
            if (txtWeb.Text == "")
            {
                txtWeb.Text = "Url Pagina Web";
            }
        }

        private void txtFacebook_MouseEnter(object sender, EventArgs e)
        {
            if (txtFacebook.Text == "Url Facebook")
            {
                txtFacebook.Text = "";
            }
        }

        private void txtFacebook_MouseLeave(object sender, EventArgs e)
        {
            if (txtFacebook.Text == "")
            {
                txtFacebook.Text = "Url Facebook";
            }
        }

        private void txtInsta_MouseEnter(object sender, EventArgs e)
        {
            if (txtInsta.Text == "Url Instagram")
            {
                txtInsta.Text = "";
            }
        }

        private void txtInsta_MouseLeave(object sender, EventArgs e)
        {
            if (txtInsta.Text == "")
            {
                txtInsta.Text = "Url Instagram";
            }
        }

        private void txtTwitter_MouseEnter(object sender, EventArgs e)
        {
            if (txtTwitter.Text == "Url Twitter")
            {
                txtTwitter.Text = "";
            }
        }

        private void txtTwitter_MouseLeave(object sender, EventArgs e)
        {
            if (txtTwitter.Text == "")
            {
                txtTwitter.Text = "Url Twitter";
            }
        }

        private void txtTiktok_MouseEnter(object sender, EventArgs e)
        {
            if (txtTiktok.Text == "Url TikTok")
            {
                txtTiktok.Text = "";
            }
        }

        private void txtTiktok_MouseLeave(object sender, EventArgs e)
        {
            if (txtTiktok.Text == "")
            {
                txtTiktok.Text = "Url TikTok";
            }
        }

        int indice = 0;
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
                indice = dataGridView1.CurrentRow.Index;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtLocalidad.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                boxTipoEntidad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                boxTipoDoc.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtDoc.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtCel.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtWeb.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtFacebook.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                txtInsta.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                txtTwitter.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                txtTiktok.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                boxIDGrupsEntidad.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                boxIDTipoEntidad.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                txtCredito.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                txtUser.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
                boxRol.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
                txtComentario.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
                boxStatus.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
                NoEliminable.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[20].Value);
                txtFecha.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
            }
            catch
            {
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Conexion.conectar();
            string consulta = "select * from Entidades where IdEntidad = " + textbuscar.Text + "";
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conexion.conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            SqlDataReader leer;

            leer = cmd.ExecuteReader();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LlenarTable();
        }
    }
}

