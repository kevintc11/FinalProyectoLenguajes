using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class AdministrarPlatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string enlace = "~/BuscarPlatos.aspx";
            Response.Redirect(enlace);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string enlace = "~/ModificarPlato.aspx";
            Response.Redirect(enlace);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string enlace = "~/EliminarPlato.aspx";
            Response.Redirect(enlace);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string enlace = "~/AgregarPlato.aspx";
            Response.Redirect(enlace);
        }
    }
}