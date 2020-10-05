using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaFinal.Administrador
{
    public partial class EditLogin : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        servicioLogica.Administrador admin = new servicioLogica.Administrador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                admin = clienteLogica.ObtenerAdministrador();
                TextBox1.Text = admin.username;
                TextBox2.Text = admin.password;
                TextBox1.Focus();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (clienteLogica.ValidarTextBoxVacio(TextBox1.Text) && clienteLogica.ValidarTextBoxVacio(TextBox2.Text))
            {
                string texto1 = TextBox1.Text;
                string texto2 = TextBox2.Text;
                admin = new servicioLogica.Administrador();
                admin.username = texto1;
                admin.password = texto2;
                clienteLogica.ModificarAdministrador(admin);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Se han cambiado los datos satisfactoriamente." + "');", true);

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Llene los campos requeridos para continuar." + "');", true);
                //Mensaje: Rellene los campos requeridos para continuar.
            }
        }
    }
}