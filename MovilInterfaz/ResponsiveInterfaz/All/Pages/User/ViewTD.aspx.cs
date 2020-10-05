using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.User
{
    public partial class ViewTD : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            GridView3.DataSource = null;
            GridView3.DataSource = clienteLogica.LlenarTablaTrasbordosDobles();
            GridView3.DataBind();

        }
    }
}