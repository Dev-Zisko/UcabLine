using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.Admin
{
    public partial class CreateTD : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //si la pagina carga por primera vez.
            {
                List<servicioLogica.Linea> lineas = clienteLogica.ObtenerListaLineas().ToList(); //Se obtiene la lista de lineas
                foreach (servicioLogica.Linea linea in lineas) //Se carga lineas en el dropDpwnList
                {
                    DropDownList2.Items.Add(linea.nombre);
                    DropDownList3.Items.Add(linea.nombre);
                }

                if (DropDownList2.Items.Count == 0 || DropDownList3.Items.Count == 0) //Si no hay lineas en las listas desactiva los dropdown list
                {
                    DropDownList2.Enabled = false;
                    DropDownList3.Enabled = false;
                }
                else
                {
                    DropDownList2.Enabled = true;
                    DropDownList3.Enabled = true;
                }


            }

        }

        protected void Button4_Click(object sender, EventArgs e) // Seleccionar Linea1
        {
            if (DropDownList2.Enabled)
            {
                List<servicioLogica.Estacion> estaciones1 = clienteLogica.ObtenerListaEstaciones(DropDownList2.Text).ToList();
                if (estaciones1.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "La línea de origen no contiene estaciones." + "');", true);
                    //La linea1 no contiene estaciones
                }
                DropDownList4.Items.Clear();
                foreach (servicioLogica.Estacion estacion1 in estaciones1)
                {
                    DropDownList4.Items.Add(estacion1.nombreEstacion);
                }

                DropDownList4.Enabled = true;
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Ingrese una linea al sistema antes de continuar." + "');", true);
        }



        protected void Button5_Click(object sender, EventArgs e) //Seleccionar Linea2
        {
            if (DropDownList3.Enabled)
            {

                List<servicioLogica.Estacion> estaciones2 = clienteLogica.ObtenerListaEstaciones(DropDownList3.Text).ToList();

                if (estaciones2.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "La línea de destino no contiene estaciones." + "');", true);
                    //La linea2 no contiene estaciones.
                }
                DropDownList5.Items.Clear();
                foreach (servicioLogica.Estacion estacion2 in estaciones2)
                {
                    DropDownList5.Items.Add(estacion2.nombreEstacion);
                }
                DropDownList5.Enabled = true;
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Ingrese una linea al sistema antes de continuar." + "');", true);
        }



        protected void Button6_Click(object sender, EventArgs e)
        {
            if (DropDownList4.Enabled == false || DropDownList5.Enabled == false)
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Seleccione ambas estaciones antes de continuar." + "');", true);

            else if (DropDownList2.Text != DropDownList3.Text)
            {
                if (!DropDownList4.Text.Equals("") && !DropDownList5.Text.Equals(""))
                {
                    if (clienteLogica.CrearTrasbordoDoble(DropDownList2.Text, DropDownList4.Text, DropDownList3.Text, DropDownList5.Text))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Se ha creado el trasbordo doble satisfactoriamente." + "');", true);
                        //Mensaje: Trasbordo doble creado exitosamente.
                        DropDownList2.SelectedIndex = 0;
                        DropDownList4.Items.Clear();
                        DropDownList3.SelectedIndex = 0;
                        DropDownList5.Items.Clear();
                        DropDownList4.Enabled = false;
                        DropDownList5.Enabled = false;

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + " Trasbordo ya existe en el archivo" + "');", true);
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Error. Trasbordo ya existe en el archivo." + "');", true);
                        //Mensaje: Error. Trasbordo ya existe en el archivo.
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Seleccione al menos dos lineas y dos estaciones." + "');", true);
                    //Mensaje: Seleccione almenos 2 Lineas y 2 estaciones.
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "El trasbordo no se puede crear en la misma linea." + "');", true);
                //mensaje: El trasbordo no se puede crear en la misma linea
            }
        }
    }
}