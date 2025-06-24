using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica5
{
    public partial class ReservaEntradas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarActividades();
            }
        }
        protected void btnReservar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string nombre = txtNombre.Text.Trim();
                string dni = txtDNI.Text.Trim();
                string email = txtEmail.Text.Trim();
                int idActividad = Convert.ToInt32(ddlActividad.SelectedValue);
                string telefono = txtTelefono.Text.Trim();
                string nacimiento = txtNacimiento.Text.Trim();

                using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TicketMania;Integrated Security=True"))
                {
                    conn.Open();

                    // 1. Verificar si hay disponibilidad
                    string checkDisponibilidad = "SELECT Disponible FROM Actividades WHERE IdActividad = @idAct";
                    SqlCommand cmdCheck = new SqlCommand(checkDisponibilidad, conn);
                    cmdCheck.Parameters.AddWithValue("@idAct", idActividad);
                    int disponible = Convert.ToInt32(cmdCheck.ExecuteScalar());

                    if (disponible > 0)
                    {
                        // 2. Insertar reserva y obtener ID
                        string insert = "INSERT INTO Reservas (NombreCompleto, DNI, Email, Telefono, FechaNacimiento, IdActividad) " +
                                        "VALUES (@nombre, @dni, @email, @telefono, @nacimiento, @idAct); SELECT SCOPE_IDENTITY();";

                        SqlCommand cmdInsert = new SqlCommand(insert, conn);
                        cmdInsert.Parameters.AddWithValue("@nombre", nombre);
                        cmdInsert.Parameters.AddWithValue("@dni", dni);
                        cmdInsert.Parameters.AddWithValue("@email", email);
                        cmdInsert.Parameters.AddWithValue("@telefono", telefono);
                        cmdInsert.Parameters.AddWithValue("@nacimiento", nacimiento);
                        cmdInsert.Parameters.AddWithValue("@idAct", idActividad);

                        int idReserva = Convert.ToInt32(cmdInsert.ExecuteScalar());

                        // 3. Actualizar disponibilidad
                        string update = "UPDATE Actividades SET Disponible = Disponible - 1 WHERE IdActividad = @idAct";
                        SqlCommand cmdUpdate = new SqlCommand(update, conn);
                        cmdUpdate.Parameters.AddWithValue("@idAct", idActividad);
                        cmdUpdate.ExecuteNonQuery();

                        // Redirigir a la página de resumen
                        Response.Redirect("ResumenReserva.aspx?id=" + idReserva);
                    }
                    else
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Text = "No hay disponibilidad para esta actividad. Por favor, elegí otra.";
                    }
                }
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Por favor, completá todos los campos obligatorios.";
            }
        }


        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtDNI.Text = "";
            ddlActividad.SelectedIndex = 0;
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtNacimiento.Text = "";
        }

        protected void btnAdmin_Page(object sender, EventArgs e)
        {
            Response.Redirect("ListadoComentarios.aspx");
        }

        private void CargarActividades()
        {
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TicketMania;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string query = "SELECT IdActividad, NombreActividad FROM Actividades WHERE Disponible > 0";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                ddlActividad.DataSource = reader;
                ddlActividad.DataTextField = "NombreActividad";
                ddlActividad.DataValueField = "IdActividad";
                ddlActividad.DataBind();

                reader.Close();
            }
        }

    }
}