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
    public partial class GrupoEntidades : Form
    {
        public GrupoEntidades()
        {
            InitializeComponent();
            txtComentario.ScrollBars = ScrollBars.Both;
            txtDescripcion.ScrollBars = ScrollBars.Both;
        }

        private void GrupoEntidades_Load(object sender, EventArgs e)
        {
            Conexion.conectar();

            dataGridView1.DataSource = LlenarTable();
        }
        public DataTable LlenarTable()
        {
            Conexion.conectar();
            DataTable dt = new DataTable();
            string Consulta = "SELECT * FROM GruposEntidades";
            SqlCommand cmd = new SqlCommand(Consulta, Conexion.conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            return dt;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            Conexion.conectar();
            string Consulta = "SELECT * FROM GruposEntidades WHERE IdGrupoEntidad ='" + txtID.Text + "'";
            SqlCommand cmd = new SqlCommand(Consulta, Conexion.conectar());


            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                Conexion.conectar();
                string consulta = "UPDATE GruposEntidades SET " +
                    "Descripcion = '" + txtDescripcion.Text + "'," +
                    "Comentario ='" + txtComentario.Text + "'," +
                    "Status ='" + BoxStatus.Text + "'," +
                    "Noeliminable ='" + NoEliminable.Checked + "'" +
                    "where IdGrupoEntidad ='" + txtID.Text + "'";


                SqlCommand cmd1 = new SqlCommand(consulta, Conexion.conectar());

                cmd1.ExecuteNonQuery();
                MessageBox.Show("Grupo Entidad Editado");

                dataGridView1.DataSource = LlenarTable();
            }
            else
            {
                MessageBox.Show("Entidad No Encontrada");
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            Conexion.conectar();
            string Consulta = "SELECT * FROM GruposEntidades WHERE IdGrupoEntidad ='" + txtID.Text + "'";
            SqlCommand cmd = new SqlCommand(Consulta, Conexion.conectar());


            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                if (NoEliminable.Checked != true)
                {
                    Conexion.conectar();
                    string consulta = "DELETE  FROM GruposEntidades where  IdGrupoEntidad = ' " + txtID.Text + " ' ";
                    SqlCommand cmd1 = new SqlCommand(consulta, Conexion.conectar());
                    cmd1.ExecuteNonQuery();


                    MessageBox.Show("Los datos fueron eliminados correctamente");
                    dataGridView1.DataSource = LlenarTable();
                }
                else 
                {
                    MessageBox.Show("Grupo Entidad No Autorizada Para Eliminar");
                }
            }
            else
            {
                MessageBox.Show("Entidad No Encontrada");
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtDescripcion.Text = "";
            txtComentario.Text = "";
            BoxStatus.Text = "Activa";
            NoEliminable.Checked = false;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            Conexion.conectar();
            string NUEVO = "INSERT INTO GruposEntidades  VALUES " +
                "('" + txtDescripcion.Text + "'," +
                "'" + txtComentario.Text + "'," +
                "'" + BoxStatus.Text + "'," +
                "'" + NoEliminable.Checked + "'," +
                "'" + DateTime.Now.ToShortDateString() + "')";


            SqlCommand cmd = new SqlCommand(NUEVO, Conexion.conectar());

            cmd.ExecuteNonQuery();
            MessageBox.Show(" Los datos fueron Guardados correctamente ");
            dataGridView1.DataSource = LlenarTable();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtComentario.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                BoxStatus.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                BoxStatus.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                NoEliminable.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value);
                txtFecha.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch
            {
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Conexion.conectar();
            string consulta = "select * from GruposEntidades  where IdGrupoEntidad = " + textbuscar.Text + "";
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
