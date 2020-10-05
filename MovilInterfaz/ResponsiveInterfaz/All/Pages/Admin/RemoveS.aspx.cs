using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.Admin
{
    public partial class RemoveS : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<servicioLogica.Linea> lineas = clienteLogica.ObtenerListaLineas().ToList(); //Se obtiene la lista de lineas

                foreach (servicioLogica.Linea linea in lineas) //Se carga lineas en el dropDpwnList
                {
                    DropDownList1.Items.Add(linea.nombre);

                }

                if (DropDownList1.Items.Count == 0)
                    DropDownList1.Enabled = false;
                else
                    DropDownList1.Enabled = true;
            }
        }

        protected void Button2_Click(object sender, EventArgs e) //Boton Seleccionar Linea
        {

            DropDownList2.Items.Clear(); //Se limpia el dropdonwList de estaciones en caso de que ya haya sido llenado
            if (DropDownList1.Enabled)
            {
                //Se llena el dropdownList de estaciones correspondientes a la linea seleccionada
                List<servicioLogica.Estacion> estaciones = clienteLogica.ObtenerListaEstaciones(DropDownList1.Text).ToList();
                foreach (servicioLogica.Estacion estacion in estaciones)
                {
                    DropDownList2.Items.Add(estacion.nombreEstacion);
                }

                if (DropDownList2.Items.Count != 0)
                    DropDownList2.Enabled = true;
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "La línea esta vacia. Cree estaciones para eliminar." + "');", true);
                    //Mensaje: Linea Vacia, inserte estaciones para poder eliminar.
                }
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Ingrese una línea al sistema antes de continuar." + "');", true);
        }

        protected void Button1_Click(object sender, EventArgs e) //Boton eliminar estacion
        {
            if (DropDownList2.Enabled == false)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Seleccione la línea antes de continuar." + "');", true);
            }
            if (clienteLogica.EliminarEstacion(DropDownList1.Text, DropDownList2.Text)) //Llama a la cadena de funciones booleanas que eliminan la estación.
            {
                DropDownList1.SelectedIndex = 0;
                DropDownList2.Items.Clear();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Estación eliminada satisfactoriamente." + "');", true);
                //Mensaje: Estacion eliminada exitosamente.
            }
        }
    }
}