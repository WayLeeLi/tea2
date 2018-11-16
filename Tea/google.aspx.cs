using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tea.Web.UI;
using Tea.Common;
using MultiOAuth.Core;
using MultiOAuth.Core.Service;
using MultiOAuth.Core.Client;

public partial class google : Tea.Web.UI.ShopPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = MultiOAuthContext.Create(MultiOAuthFactroy.CreateClient<GoogleClinet>("Google"));
        try
        {
            context.BeginAuth();
        }
        catch (Exception)
        {

            throw;
        }
    }
}