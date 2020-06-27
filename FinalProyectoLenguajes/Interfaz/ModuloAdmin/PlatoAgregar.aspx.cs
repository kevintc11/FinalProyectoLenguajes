using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz
{
    public partial class AgregarPlato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloAdmin/PlatoMenu.aspx");
        }
    }
}