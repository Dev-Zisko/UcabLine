using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaFinal
{
    public partial class _Default : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            GridView2.DataSource = null;
            GridView2.DataSource = clienteLogica.LlenarTablaLineas();
            GridView2.DataBind();

            GridView3.DataSource = null;
            GridView3.DataSource = clienteLogica.LlenarTablaTrasbordosDobles();
            GridView3.DataBind();

            List<servicioLogica.Linea> lineas = clienteLogica.ObtenerListaLineas().ToList();
            foreach(servicioLogica.Linea linea in lineas)
            {
                DropDownList1.Items.Add(linea.nombre);
            }

            List<servicioLogica.TrasbordoSimple> simples = clienteLogica.ObtenerListaTrasbordoS().ToList();
            foreach (servicioLogica.TrasbordoSimple tras in simples)
            {
                DropDownList2.Items.Add(tras.estacion);
            }

            if (DropDownList1.Items.Count == 0)
                DropDownList1.Enabled = false;
            else
                DropDownList1.Enabled = true;

            if (DropDownList2.Items.Count == 0)
                DropDownList2.Enabled = false;
            else
                DropDownList2.Enabled = true;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(DropDownList1.Enabled)
            {
                string texto1 = DropDownList1.Text;
                string texto2 = DropDownList2.Text;
                DropDownList1.Items.Clear();
                DropDownList2.Items.Clear();
                Page_Load(sender, e);
                DropDownList1.Text = texto1;
                DropDownList2.Text = texto2;
                GridView1.DataSource = null;
                GridView1.DataSource = clienteLogica.LlenarTablaEstaciones(DropDownList1.Text);
                GridView1.DataBind();
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No hay líneas para ver." + "');", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (DropDownList2.Enabled)
            {
                ListBox1.Visible = true;
                ListBox1.Items.Clear();
                string texto1 = DropDownList1.Text;
                string texto2 = DropDownList2.Text;
                DropDownList1.Items.Clear();
                DropDownList2.Items.Clear();
                Page_Load(sender, e);
                DropDownList1.Text = texto1;
                DropDownList2.Text = texto2;
                List<string> lineas = clienteLogica.ObtenerTrasbordoS(DropDownList2.Text).lineas.ToList();
                foreach (string linea in lineas)
                {
                    ListBox1.Items.Add(linea);
                }
            }
            else//mensaje
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "No hay trasbordos para ver." + "');", true);
        }
    }
}