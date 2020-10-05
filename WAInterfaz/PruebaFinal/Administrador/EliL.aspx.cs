using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaFinal.Administrador
{
    public partial class EliL : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
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

        protected void Button1_Click(object sender, EventArgs e) //Boton Eliminar Linea
        {
            if (clienteLogica.EliminarLinea(DropDownList1.Text))
            {
                DropDownList1.Items.Clear(); //Borra el dropDownList de lineas
                
                Page_Load(sender, e); // Carga la pagina de nuevo

                if (DropDownList1.Items.Count > 0) // si queda mas de un elemento
                {
                    DropDownList1.SelectedIndex = 0;
                }
               
             
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "La línea se ha eliminado satisfactoriamente." + "');", true);
                //mensaje de se elimino exitosamente
            }
           
            else
            {

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Error. Verifique que la línea existe." + "');", true);
                //mensaje de error: Ha ocurrido un error al eliminar Linea, por favor verifique que la linea existe.
            }
                
        }
    }
}