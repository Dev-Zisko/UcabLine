using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.Admin
{
    public partial class ModifySS : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                List<servicioLogica.Linea> lineas = clienteLogica.ObtenerListaLineas().ToList(); //Se obtiene la lista de lineas
                if (lineas.Count > 0)
                {
                    foreach (servicioLogica.Linea linea in lineas) //Se carga lineas en el dropDownList
                    {
                        DropDownList1.Items.Add(linea.nombre);
                    }
                }

                if (DropDownList1.Items.Count == 0)
                    DropDownList1.Enabled = false;
                else
                    DropDownList1.Enabled = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e) //Botón seleccionar Linea
        {
            DropDownList2.Items.Clear();
            Button2.Visible = false;
            DropDownList2.Visible = false;

            GridView1.DataSource = null;
            GridView1.DataSource = clienteLogica.LlenarTablaEstaciones(DropDownList1.Text);
            GridView1.DataBind();
            if (DropDownList1.Enabled == true)
            {
                List<servicioLogica.Estacion> estaciones = clienteLogica.ObtenerListaEstaciones(DropDownList1.Text).ToList(); //Se obtiene la lista de lineas


                foreach (servicioLogica.Estacion estacion in estaciones) //Se carga lineas en el dropDownList
                {
                    DropDownList2.Items.Add(estacion.nombreEstacion);
                }

                Button2.Visible = true;
                DropDownList2.Visible = true;

                if (DropDownList2.Items.Count == 0)
                    DropDownList2.Enabled = false;
                else
                    DropDownList2.Enabled = true;
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Ingrese lineas al sistema antes de continuar." + "');", true);
        }

        protected void Button2_Click(object sender, EventArgs e) //boton Cambiar estado de estación
        {
            clienteLogica.ModificarEstadoEstacion(DropDownList2.Text);
            Button1_Click(sender, e);
            if (DropDownList2.Enabled)
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Se cambio el estado satisfactoriamente." + "');", true);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Ingrese estaciones al sistema antes de continuar." + "');", true);
        }
    }
}