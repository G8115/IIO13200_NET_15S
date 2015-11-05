using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Levykauppa2 : System.Web.UI.Page
{
    public string xpath;
    protected void Page_Load(object sender, EventArgs e)
    {
        xpath = "Records/genre[@name='Pop']/record[@ISBN='" + Request.QueryString["id"] + "']";
    }
}