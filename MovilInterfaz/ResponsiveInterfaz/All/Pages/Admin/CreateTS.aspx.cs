using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.Admin
{
    public partial class CreateTS : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //si la pagina carga por primera vez.
            {
                List<servicioLogica.Linea> lineas = clienteLogica.ObtenerListaLineas().ToList(); //Se obtiene la lista de lineas
                foreach (servicioLogica.Linea linea in lineas) //Se carga lineas en el dropDpwnList
                {
                    DropDownList1.Items.Add(linea.nombre);
                }

                if (DropDownList1.Items.Count == 0) //Si no hay lineas en las listas desactiva los dropdown list
                {
                    DropDownList1.Enabled = false;
                }
                else
                {
                    DropDownList1.Enabled = true;
                }


            }

        }

        protected void Button1_Click(object sender, EventArgs e) //Selecciona La linea para crear trasbordo simple y llena el ddl para estaciones
        {
            DropDownList6.Items.Clear();
            if (DropDownList1.Enabled)
            {
                List<servicioLogica.Estacion> estaciones = clienteLogica.ObtenerListaEstaciones(DropDownList1.Text).ToList();

                if (estaciones.Count == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "La línea no contiene estaciones." + "');", true);
                    //La linea no contiene estaciones.
                }
                else
                {

                    foreach (servicioLogica.Estacion estacion in estaciones)
                    {
                        DropDownList6.Items.Add(estacion.nombreEstacion);
                    }
                }

                DropDownList6.Enabled = true;
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Ingrese una linea al sistema antes de continuar." + "');", true);

        }

        protected void Button2_Click(object sender, EventArgs e) //Selecciona la estacion y llen el listbox1 con las lineas disponibles
        {
            if (DropDownList6.Enabled == false)
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Seleccione una linea antes de continuar." + "');", true);
            else
            {

                List<servicioLogica.Linea> lineas = clienteLogica.ObtenerListaLineas().ToList();

                foreach (servicioLogica.Linea linea in lineas)
                {
                    if (!linea.nombre.Equals(DropDownList1.Text)) // Si el nombre de la linea no es la linea a la cual pertenece la estacion.
                        ListBox1.Items.Add(linea.nombre);
                }
                ListBox1.Visible = true;

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            List<string> lineas = new List<string>();
            lineas.Add(DropDownList1.Text);
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                    lineas.Add(item.Text);
            }

            if (lineas.Count == 1) // La linea a la que ya pertenece la estacion
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No se selecciono nada" + "');", true);
            else
            {
                if (clienteLogica.CrearTrasbordoSimple(DropDownList6.Text, lineas.ToArray()))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Se ha creado el trasbordo satisfactoriamente." + "');", true);
                    //Mensaje: Trasbordo creado exitosamente.
                    if (DropDownList1.Enabled)
                        DropDownList1.SelectedIndex = 0;
                    DropDownList6.Items.Clear();
                    ListBox1.Items.Clear();
                    DropDownList6.Enabled = false;
                    ListBox1.Visible = false;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Elemento ya existente o no se han seleccionado los campos requeridos." + "');", true);
                }
            }

        }


    }
}