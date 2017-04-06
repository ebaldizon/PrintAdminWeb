using PrintAdminWebApp.App.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrintAdminWebApp.App
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["login"] = false;
            Session["login"] = null;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserLogin login = new UserLogin();
            if(login.SignIn(txtUser.Text, txtPassword.Text))
            {
                Session["login"] = true;
                lblMsg.Text = "Ingresando al sistema";
                lblMsg.ForeColor = System.Drawing.Color.Blue;
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblMsg.Text = "Usuario o contraseña incorrectos";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }                   
        }

    }
}