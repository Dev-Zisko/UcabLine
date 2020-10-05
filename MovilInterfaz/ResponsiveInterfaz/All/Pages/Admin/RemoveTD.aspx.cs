using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.Admin
{
    public partial class RemoveTD : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> lista1 = clienteLogica.ObtenerListaStringTransbordoD().ToList(); //Obtiene la lista de Trasbordos Dobles

            foreach (string s in lista1)
            {
                DropDownList2.Items.Add(s); //Llena el dropDownList de trasbordosD
            }

            if (DropDownList2.Items.Count == 0) //si no hay trasbordos dobles
                DropDownList2.Enabled = false;
            else
                DropDownList2.Enabled = true;


        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            if (DropDownList2.Items.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Verifique que existen trasbordos dobles antes de eliminar." + "');", true);
            }
            else if (clienteLogica.EliminarTransbordoDoble(DropDownList2.Text)) //Llama al conjunto de funciones booleanas que elimina el trasbordo doble especificado
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Se ha eliminado satisfactoriamente." + "');", true);
                //Mensaje: Se ha eliminado correctamente

            }
            DropDownList2.Items.Clear();
            Page_Load(sender, e);
        }

    }
}