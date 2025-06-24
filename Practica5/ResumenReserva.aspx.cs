using Practica5;
using System;
using System.Linq;

namespace Practica5
{
    public partial class ResumenReserva : System.Web.UI.Page
    {
        
        TPDataContext db = new TPDataContext(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TicketMania;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int idReserva = int.Parse(Request.QueryString["id"]);
                    CargarDatosReserva(idReserva);
                }
            }
        }

        private void CargarDatosReserva(int idReserva)
        {
            var reserva = (from r in db.Reservas
                           join a in db.Actividades on r.IdActividad equals a.IdActividad
                           where r.Id == idReserva
                           select new
                           {
                               r.NombreCompleto,
                               r.DNI,
                               r.Email,
                               r.Telefono,
                               r.FechaNacimiento,
                               a.NombreActividad
                           }).FirstOrDefault();

            if (reserva != null)
            {
                string tabla = "<table border='1' cellpadding='10'>" +
                    "<tr><th>Nombre</th><td>" + reserva.NombreCompleto + "</td></tr>" +
                    "<tr><th>DNI</th><td>" + reserva.DNI + "</td></tr>" +
                    "<tr><th>Email</th><td>" + reserva.Email + "</td></tr>" +
                    "<tr><th>Teléfono</th><td>" + reserva.Telefono + "</td></tr>" +
                    "<tr><th>Fecha de Nacimiento</th><td>" + reserva.FechaNacimiento + "</td></tr>" +
                    "<tr><th>Actividad</th><td>" + reserva.NombreActividad + "</td></tr>" +
                    "</table>";

                litTabla.Text = tabla;

                // Guardar en ViewState los datos necesarios para insertar comentario
                ViewState["DNI"] = reserva.DNI;
                ViewState["Nombre"] = reserva.NombreCompleto;
            }
            else
            {
                litTabla.Text = "No se encontró la reserva.";
            }
        }

        protected void btnEnviarComentario_Click(object sender, EventArgs e)
        {
            string comentario = txtComentario.Text.Trim();

            if (string.IsNullOrEmpty(comentario))
            {
                return;
            }

            // Obtener datos desde ViewState
            string dni = ViewState["DNI"]?.ToString();
            string nombre = ViewState["Nombre"]?.ToString();

            if (!string.IsNullOrEmpty(dni) && !string.IsNullOrEmpty(nombre))
            {
                Comentarios nuevo = new Comentarios
                {
                    DNI = dni,
                    NombreCompleto = nombre,
                    Comentario = comentario,
                    Fecha = DateTime.Now
                };

                db.Comentarios.InsertOnSubmit(nuevo);
                db.SubmitChanges();

                Response.Redirect("ReservaEntradas.aspx");
            }
        }
    }
}


