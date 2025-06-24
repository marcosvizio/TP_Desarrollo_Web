using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace Practica5
{
    public partial class ListadoComentarios : System.Web.UI.Page
    {

        TPDataContext db = new TPDataContext(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TicketMania;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComentarios();
            }
        }

        private void CargarComentarios()
        {
            var datos = from c in db.Comentarios
                        join r in db.Reservas on c.IdReserva equals r.Id
                        join a in db.Actividades on r.IdActividad equals a.IdActividad
                        select new
                        {
                            c.IdComentario,
                            c.DNI,
                            c.NombreCompleto,
                            Comentario = c.Comentario,
                            Actividad = a.NombreActividad
                        };

            gvComentarios.DataSource = datos.ToList();
            gvComentarios.DataBind();
        }

        protected void gvComentarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvComentarios.EditIndex = e.NewEditIndex;
            CargarComentarios();
        }

        protected void gvComentarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvComentarios.EditIndex = -1;
            CargarComentarios();
        }

        protected void gvComentarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idComentario = Convert.ToInt32(gvComentarios.DataKeys[e.RowIndex].Value);
            string nuevoComentario = ((TextBox)gvComentarios.Rows[e.RowIndex].Cells[2].Controls[0]).Text;

            var comentario = db.Comentarios.FirstOrDefault(c => c.IdComentario == idComentario);
            if (comentario != null)
            {
                comentario.Comentario = nuevoComentario;
                db.SubmitChanges();
            }

            gvComentarios.EditIndex = -1;
            CargarComentarios();
        }

        protected void gvComentarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idComentario = Convert.ToInt32(gvComentarios.DataKeys[e.RowIndex].Value);
            var comentario = db.Comentarios.FirstOrDefault(c => c.IdComentario == idComentario);
            if (comentario != null)
            {
                db.Comentarios.DeleteOnSubmit(comentario);
                db.SubmitChanges();
            }

            CargarComentarios();
        }
    }
}
