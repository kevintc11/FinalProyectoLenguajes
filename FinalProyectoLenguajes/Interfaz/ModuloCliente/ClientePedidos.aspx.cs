﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;

namespace Interfaz.ModuloCliente
{
    public partial class ClientePedidos : System.Web.UI.Page
    {
        AdministracionPlatos platos = new AdministracionPlatos();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ModuloCliente/ClienteMainMenu.aspx?usuario=" + (String)Session["temporal1"]);
        }

        protected void bt_Click(object sender, EventArgs e)
        {


            if(espaciosVacios())
            {

                Type cstype = this.GetType();

                ClientScriptManager cs = Page.ClientScript;

                if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                {
                    String cstext = "alert('Platillo Agregado Correctamente');";
                    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                }
            }
        }

        public Boolean espaciosVacios()
        {
            if (tbDishID.Text == "" || tbCant.Text == "")
            {
                Type cstype = this.GetType();

                ClientScriptManager cs = Page.ClientScript;

                if (!cs.IsStartupScriptRegistered(cstype, "PopupScript"))
                {
                    String cstext = "alert('Debe de Llenar Correctamente Todos los Datos Requeridos');";
                    cs.RegisterStartupScript(cstype, "PopupScript", cstext, true);
                }
                return false;
            }
            return true;
        }
    }
}