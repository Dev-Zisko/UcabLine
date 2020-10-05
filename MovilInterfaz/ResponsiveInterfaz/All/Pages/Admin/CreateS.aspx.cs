using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.Admin
{
    public partial class CreateS : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Focus();
            if (!Page.IsPostBack) //si es la primera vez que carga la pagina
            {



                List<servicioLogica.Linea> lineas = clienteLogica.ObtenerListaLineas().ToList(); //Se obtiene la lista de lineas
                foreach (servicioLogica.Linea linea in lineas) //Se carga lineas en el dropDpwnList
                {
                    DropDownList1.Items.Add(linea.nombre);

                }
                if (DropDownList1.Items.Count == 0) //Verifica que haya lineas en los archivos 
                    DropDownList1.Enabled = false;
                else
                    DropDownList1.Enabled = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e) //boton Guardar de crear Linea
        {
            if (clienteLogica.ValidarTextBoxVacio(TextBox1.Text) && clienteLogica.ValidarTextBoxCaracteresEsp(TextBox1.Text)) //Si se cumplen las validaciones de los textos
            {
                string cadena = clienteLogica.ValidarNombres(TextBox1.Text);
                if (DropDownList1.Enabled) //Si hay lineas en los archivos
                {
                    bool x = clienteLogica.CrearEstacion(DropDownList1.Text, cadena);
                    if (x == true)
                    {
                        TextBox1.Text = "";
                        DropDownList1.SelectedIndex = 0;
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Se ha creado la estación satisfactoriamente." + "');", true);
                        //Mensaje de todo correcto
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Error al crear la estación. Vuelva a intentar." + "');", true);
                        // Error al crear estacion, intente nuevamente.
                    }
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Ingrese lineas al sistema antes de continuar." + "');", true);

            }
            else
            {
                TextBox1.Focus();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Llene los campos requeridos correctamente." + "');", true);
                //Mensaje LLene los campos requeridos correctamente.
            }

        }


    }
}