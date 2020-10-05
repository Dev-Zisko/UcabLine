using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.Admin
{
    public partial class ModifyS : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) //Si la pagina carga por primera vez
            {
                List<servicioLogica.Linea> lineas = clienteLogica.ObtenerListaLineas().ToList(); //Se obtiene la lista de lineas

                //Se cargan lineas en el dropDpwnList
                foreach (servicioLogica.Linea linea in lineas)
                {
                    DropDownList1.Items.Add(linea.nombre);

                }

                if (DropDownList1.Items.Count == 0)
                    DropDownList1.Enabled = false;
                else
                    DropDownList1.Enabled = true;
            }
        }






        protected void Button1_Click(object sender, EventArgs e) //Boton Editar Estación
        {
            if (clienteLogica.ValidarTextBoxCaracteresEsp(TextBox1.Text) && clienteLogica.ValidarTextBoxVacio(TextBox1.Text)) //si la cadena se cumplen las validadciones correspondientes
            {
                string cadena = clienteLogica.ValidarNombres(TextBox1.Text); //Transforma la cadena a formato de Titulos (Con las primeras letras en mayuscula)
                if (clienteLogica.ModificarEstacion(DropDownList1.Text, DropDownList2.Text, cadena)) //Llama al conjunto de cadenas booleanas que modifican el nombre del a estacion
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "La estación se ha modificado satisfactoriamente." + "');", true);

                    TextBox1.Enabled = false;
                    TextBox1.Text = "";

                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Llene los requisitos correspondientes para continuar." + "');", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e) //Boton Seleccionar Linea
        {

            if (DropDownList1.Enabled)
            {
                List<servicioLogica.Estacion> estaciones = clienteLogica.ObtenerListaEstaciones(DropDownList1.Text).ToList();
                DropDownList2.Items.Clear();
                foreach (servicioLogica.Estacion estacion in estaciones)
                {
                    DropDownList2.Items.Add(estacion.nombreEstacion); //Llena el dropdownlist de estaciones
                }
                DropDownList2.Enabled = true;
                TextBox1.Text = "";
                TextBox1.Enabled = false;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Compruebe si existen lineas." + "');", true);
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (clienteLogica.ComprobarEstacion(DropDownList1.Text, DropDownList2.Text)) //Comprueba que la estacion este en la linea seleccionada
            {
                if (DropDownList2.Enabled == true)
                {
                    servicioLogica.Estacion estacion = clienteLogica.ObtenerEstacion(DropDownList1.Text, DropDownList2.Text); // Obtiene los datos actuales de la estacion a modificar.
                    TextBox1.Text = DropDownList2.Text;
                    TextBox1.Enabled = true;
                    TextBox1.Focus();
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Seleccione una línea antes de continuar." + "');", true);
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Seleccione una línea valida antes de continuar." + "');", true);
        }



    }
}