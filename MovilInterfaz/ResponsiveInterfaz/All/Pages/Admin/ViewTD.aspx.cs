using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResponsiveInterfaz.All.Pages.Admin
{
    public partial class ViewTD : System.Web.UI.Page
    {
        servicioLogica.ServicioLogicaClient clienteLogica = new servicioLogica.ServicioLogicaClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                GridView2.DataSource = clienteLogica.LlenarTablaTrasbordosDobles();
                GridView2.DataBind();
            }
        }
    }
}