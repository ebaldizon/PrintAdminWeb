using Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrintAdminWebApp.App
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            UserBus userBus = new UserBus();
            string message = userBus.create(txtId.Text, txtName.Text, txtLastname.Text, txtEmail.Text,txtPassword.Text, txtxRepeatPwd.Text);
            lblMessage.Text = message;
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            UserBus userBus = new UserBus();
            DataTable dt = userBus.read(txtId.Text, txtName.Text, txtLastname.Text, txtEmail.Text, txtPassword.Text, txtxRepeatPwd.Text);
            if(dt != null)
            {
                //string table = ConvertDataTableToHTML(dt);
                //containerTblUsers.InnerHtml = table;
                /*
                dt.Columns["id"].ColumnName = "Cédula";
                dt.Columns["name"].ColumnName = "Nombre";
                dt.Columns["lastname"].ColumnName = "Apellido";
                dt.Columns["email"].ColumnName = "Correo";
                dt.Columns["password"].ColumnName = "Contraseña";
                */
                //gvUsers.Columns.Clear();
                gvUsers.DataSource = dt.DefaultView;
                gvUsers.DataBind();

            }
            else
            {
                DataTable dte = new DataTable();
                gvUsers.DataSource = dte.DefaultView;
                gvUsers.DataBind();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UserBus userBus = new UserBus();
            string message = userBus.update(txtId.Text, txtName.Text, txtLastname.Text, txtEmail.Text, txtPassword.Text, txtxRepeatPwd.Text);
            lblMessage.Text = message;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            UserBus userBus = new UserBus();
            string message = userBus.delete(txtId.Text, txtName.Text, txtLastname.Text, txtEmail.Text, txtPassword.Text, txtxRepeatPwd.Text);
            lblMessage.Text = message;
        }

        public static string ConvertDataTableToHTML(DataTable dt)
        {
            //string html = "<table>";
            string html = "";
            //add header row
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            //html += "</table>";
            html += "";
            return html;
        }

        protected void gvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId.Text =   gvUsers.SelectedRow.Cells[1].Text;
            txtName.Text = gvUsers.SelectedRow.Cells[2].Text;
            txtLastname.Text = gvUsers.SelectedRow.Cells[3].Text;
            txtEmail.Text = gvUsers.SelectedRow.Cells[4].Text;
            txtPassword.Text = gvUsers.SelectedRow.Cells[5].Text;
            txtxRepeatPwd.Text = gvUsers.SelectedRow.Cells[5].Text;
        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='#FFFF00';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        /*
        public static string ConvertDataTableToHTML(DataTable dt)
        {
            //string html = "<table>";
            string html = "";
            //add header row
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            //html += "</table>";
            html += "";
            return html;
        }*/
    }
}