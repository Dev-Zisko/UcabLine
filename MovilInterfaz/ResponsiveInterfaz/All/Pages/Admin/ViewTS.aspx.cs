using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.Admin
{
    public partial class ViewTS : System.Web.UI.Page
    {
       servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                List<servicioLogica.TrasbordoSimple> simples = clienteLogica.ObtenerListaTrasbordoS().ToList();
                if (simples.Count > 0)
                {
                    foreach (servicioLogica.TrasbordoSimple tras in simples)
                    {
                        DropDownList3.Items.Add(tras.estacion);
                    }
                  
                }
                if (DropDownList3.Items.Count == 0)
                    DropDownList3.Enabled = false;
                else
                    DropDownList3.Enabled = true;
            }
        }

        protected void Button3_Click(object sender, EventArgs e) //Boton seleccionar trasbordos Simples
        {

            if (DropDownList3.Enabled == true)
            {

                ListBox1.Items.Clear();
                servicioLogica.TrasbordoSimple tras = clienteLogica.ObtenerTrasbordoS(DropDownList3.Text);

                List<string> lineas = tras.lineas.ToList();

                foreach (string linea in lineas)
                {
                    ListBox1.Items.Add(linea);
                }

                ListBox1.Visible = true;
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Ingrese Trasbordos simples al sistema antes de continuar." + "');", true);
            
        }
    }
}
}