using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.User
{
    public partial class ViewS : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<servicioLogica.Linea> lineas = clienteLogica.ObtenerListaLineas().ToList();
            foreach (servicioLogica.Linea linea in lineas)
            {
                DropDownList1.Items.Add(linea.nombre);
            }
          if (DropDownList1.Items.Count == 0)
                DropDownList1.Enabled = false;
            else
                DropDownList1.Enabled = true;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(DropDownList1.Enabled)
            {
                string texto1 = DropDownList1.Text;
                DropDownList1.Items.Clear();
                Page_Load(sender, e);
                DropDownList1.Text = texto1;
                GridView1.DataSource = null;
                GridView1.DataSource = clienteLogica.LlenarTablaEstaciones(DropDownList1.Text);
                GridView1.DataBind();
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No hay líneas para ver." + "');", true);
        }

        }
    }
}