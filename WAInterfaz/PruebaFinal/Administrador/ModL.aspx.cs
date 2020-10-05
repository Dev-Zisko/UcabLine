using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaFinal.Administrador
{

    public partial class ModL : System.Web.UI.Page
    {
        string texto;
        
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        
        protected void Page_Load(object sender, EventArgs e)
        {

            List<servicioLogica.Linea> lineas = clienteLogica.ObtenerListaLineas().ToList(); //Se obtiene la lista de lineas
            foreach(servicioLogica.Linea linea in lineas)
            {
                DropDownList1.Items.Add(linea.nombre);
            }
            if (DropDownList1.Items.Count == 0)
                DropDownList1.Enabled = false;
            else
                DropDownList1.Enabled = true;
        }


       
     
        protected void Button2_Click(object sender, EventArgs e) //Boton Seleccionar linea.
        {
            texto = DropDownList1.Text;
            DropDownList1.Items.Clear();
            if (DropDownList1.Enabled)
            {
                servicioLogica.Linea linea = clienteLogica.ObtenerLinea(texto);
                TextBox1.Enabled = true;
                TextBox2.Enabled = true;
                TextBox1.Text = linea.nombre;
                TextBox2.Text = linea.numeroTrenes.ToString();
                Page_Load(sender, e);
                DropDownList1.Text = texto;
                TextBox1.Focus();
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Ingrese una linea al sistema ates de modificar." + "');", true);
           
            
            

        }

        protected void Button1_Click1(object sender, EventArgs e) //Boton Editar
        {
            if (clienteLogica.ValidarTextBoxVacio(TextBox1.Text) && clienteLogica.ValidarTextBoxCaracteresEsp(TextBox1.Text) && clienteLogica.ValidarTextBoxVacio(TextBox2.Text) && clienteLogica.ValidarTextBoxNumeros(TextBox2.Text))
            {
                string cadena = clienteLogica.ValidarNombres(TextBox1.Text);
                if (clienteLogica.ModificarLinea(DropDownList1.Text, cadena, int.Parse(TextBox2.Text), DropDownList2.Text))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Se ha modificado la línea satisfactoriamente." + "');", true);
                    //Mensaje de exito
                    DropDownList1.Items.Clear();
                    Page_Load(sender, e);
                    TextBox1.Enabled = false;
                    TextBox2.Enabled = false;
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    DropDownList2.SelectedIndex = 0;
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Llene los campos requeridos para continuar." + "');", true);
                //Mensaje de llene los campos requeridos correctamente.
            }
            
        }
    }
}