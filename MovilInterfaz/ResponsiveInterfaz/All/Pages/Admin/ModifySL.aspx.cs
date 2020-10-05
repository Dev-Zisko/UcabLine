using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.Admin
{
    public partial class ModifySL : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataSource = clienteLogica.LlenarTablaLineas();

            GridView1.DataBind();


            DropDownList2.Visible = true;
            Button1.Visible = true;
            List<servicioLogica.Linea> lineas = clienteLogica.ObtenerListaLineas().ToList();
            foreach (servicioLogica.Linea linea in lineas)
            {
                DropDownList2.Items.Add(linea.nombre);
            }
            if (DropDownList2.Items.Count == 0)
                DropDownList2.Enabled = false;
            else
                DropDownList2.Enabled = true;

        }

        protected void Button1_Click(object sender, EventArgs e) //Boton Modificar estados de operatividad
        {

            string texto = DropDownList2.Text;
            DropDownList2.Items.Clear();

            if (DropDownList2.Enabled)
            {
                if (clienteLogica.ModificarEstadoLinea(texto))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Se ha cambiado el estado de la línea satisfactoriamente." + "');", true);
                    //Mensaje de Se cambio el estado de la linea
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "La línea no contiene estaciones, por lo tanto la linea esta inoperativa. Agregue una estación primero por favor." + "');", true);
                    // La linea no contienen Estaciones por lo tanto la linea esta inoperativa, agregue estaciones primero.
                }

                Page_Load(sender, e);
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Ingrese una línea al sistema antes de continuar." + "');", true);

        }
    }
}