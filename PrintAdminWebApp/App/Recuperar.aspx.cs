using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrintAdminWebApp.App
{
    public partial class Recuperar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecoverPassword_Click(object sender, EventArgs e)
        {
            User user = new User();

            user.Id = Int32.Parse(txtCustomerID.Text);
            user.Mail = txtEmail.Text;
            UserBus userBus = new UserBus();

            if (userBus.recoverPassword(user))
            {
                lblMessage.Text = "Nueva contraseña enviada al correo";
            }
            else
            {
                lblMessage.Text = "No se pudo generar la nueva contraseña";
            }
        }
    }
}