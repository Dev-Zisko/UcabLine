using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.User
{
    public partial class ViewL : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            GridView2.DataSource = null;
            GridView2.DataSource = clienteLogica.LlenarTablaLineas();
            GridView2.DataBind();

        }
    }
}