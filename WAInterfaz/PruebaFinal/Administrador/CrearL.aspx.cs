using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PruebaFinal.Administrador
{
    public partial class CrearL : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e) //Boton de guardar la linea.
        {
            if (clienteLogica.ValidarTextBoxVacio(TextBox1.Text) && clienteLogica.ValidarTextBoxCaracteresEsp(TextBox1.Text) && clienteLogica.ValidarTextBoxVacio(TextBox2.Text) && clienteLogica.ValidarTextBoxNumeros(TextBox2.Text)) //si las cadenas cumplen con los requisitos de validación
            {
                string cadena = clienteLogica.ValidarNombres(TextBox1.Text);
                if (clienteLogica.CrearLinea(cadena, int.Parse(TextBox2.Text), DropDownList1.Text))
                {
                    //Se borran los textbox y se coloca el dropDownList en el primer valor
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    DropDownList1.SelectedIndex = 0;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Se ha creado la línea satisfactoriamente." + "');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Error al crear la línea. Verifique que la linea no existe y vuelva a intentar." + "');", true);
                    // Error al crear estacion, intente nuevamente.
                }

            }
            else
            {
                TextBox1.Focus();
                TextBox2.Focus();
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Llene los campos requeridos correctamente." + "');", true);
                //Mensaje LLene los campos requeridos correctamente.
            }
            

            
                      
        }
    }
}