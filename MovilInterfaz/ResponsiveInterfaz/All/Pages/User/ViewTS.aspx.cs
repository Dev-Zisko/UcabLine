using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.User
{
    public partial class ViewTS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<servicioLogica.TrasbordoSimple> simples = clienteLogica.ObtenerListaTrasbordoS().ToList();
            foreach (servicioLogica.TrasbordoSimple tras in simples)
            {
                DropDownList2.Items.Add(tras.estacion);
            }
            if (DropDownList2.Items.Count == 0)
                DropDownList2.Enabled = false;
            else
                DropDownList2.Enabled = true;
            
        }
                protected void Button2_Click(object sender, EventArgs e)
        {
            if (DropDownList2.Enabled)
            {
                ListBox1.Visible = true;
                ListBox1.Items.Clear();
                string texto2 = DropDownList2.Text;
                DropDownList2.Items.Clear();
                Page_Load(sender, e);
                DropDownList2.Text = texto2;
                List<string> lineas = clienteLogica.ObtenerTrasbordoS(DropDownList2.Text).lineas.ToList();
                foreach (string linea in lineas)
                {
                    ListBox1.Items.Add(linea);
                }
            }
            else//mensaje
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No hay trasbordos para ver." + "');", true);
        }
        }
    }
}