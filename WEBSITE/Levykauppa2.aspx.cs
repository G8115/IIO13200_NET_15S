using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Levykauppa2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        xmlLevyt.XPath = "Records/genre/record[@ISBN='" + Request.QueryString["id"] + "']/song";
        xmlLevyt2.XPath = "Records/genre/record[@ISBN='" + Request.QueryString["id"] + "']";
    }
}