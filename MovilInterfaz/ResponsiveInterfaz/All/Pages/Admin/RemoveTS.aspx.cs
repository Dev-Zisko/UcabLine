using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.Admin
{
    public partial class RemoveTS : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<servicioLogica.TrasbordoSimple> lista2 = clienteLogica.ObtenerListaTrasbordoS().ToList(); //Obtiene la lista de trasbordos Simples

            foreach (servicioLogica.TrasbordoSimple tras in lista2)
            {
                DropDownList1.Items.Add(tras.estacion); //Llena el dropDownList de trasbordos Simples
            }

            if (DropDownList1.Items.Count == 0)
                DropDownList1.Enabled = false;
            else
                DropDownList1.Enabled = true;


        }

        protected void Button1_Click(object sender, EventArgs e) //Boton eliminarTrasbordo
        {
            if (DropDownList1.Items.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Verifique que existen trasbordos simples antes de eliminar." + "');", true);
            }
            if (ListBox1.SelectedItem != null) //Si se seleccionó un elemento del listbox1
            {
                if (clienteLogica.EliminarTrasbordoSimple(DropDownList1.Text, ListBox1.SelectedItem.Text)) //Se llama a la cadena de funciones booleanas q elimina el trasbordo simple.
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Se ha eliminado satisfactoriamente." + "');", true);
                    //Mensaje: Se ha eliminado correctamente.
                }
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Sleccione la linea a la que pertenecerá la estacion que ya no será trasbordo simple." + "');", true);

            ListBox1.Items.Clear();
            ListBox1.Visible = false;
            DropDownList1.Items.Clear();
            Page_Load(sender, e);
        }

        protected void Button3_Click(object sender, EventArgs e) //Boton Seleccionar trasbordo simple
        {
            if (DropDownList1.Enabled)
            {
                servicioLogica.TrasbordoSimple tras = clienteLogica.ObtenerTrasbordoS(DropDownList1.Text);
                List<string> lineas = tras.lineas.ToList();
                if (lineas.Count != 0)
                {
                    foreach (string linea in lineas)
                    {
                        ListBox1.Items.Add(linea);
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Seleccione la linea a la cual pertenecerá dicha estacion de ahora en adelante." + "');", true);
                    ListBox1.Visible = true;
                }
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Ingrese una línea al sistema antes de continuar." + "');", true);
        }

    }
}