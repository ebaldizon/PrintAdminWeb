using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrintAdminWebApp.App
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            CustomerBus customerBus = new CustomerBus();
            Customer customer = new Customer();

            customer.Id = customerBus.convertLong(txtId.Text);
            customer.Name = txtName.Text;
            customer.Telephone1 = customerBus.convertInt(txtTelephone1.Text);
            customer.Telephone2 = customerBus.convertInt(txtTelephone1.Text);
            customer.Email = txtEmail.Text;
            customer.Address = txtAddress.Text;

            lblMessage.Text = customerBus.create(customer);
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            CustomerBus customerBus = new CustomerBus();
            Customer customer = new Customer();

            customer.Id = customerBus.convertLong(txtId.Text);
            customer.Name = txtName.Text;
            customer.Telephone1 = customerBus.convertInt(txtTelephone1.Text);
            customer.Telephone2 = customerBus.convertInt(txtTelephone1.Text);
            customer.Email = txtEmail.Text;
            customer.Address = txtAddress.Text;

            DataTable dt = customerBus.read(customer);
            if(dt != null)
            {
                gvCustomers.DataSource = dt.DefaultView;
                gvCustomers.DataBind();
            }
            else
            {
                DataTable dte = new DataTable();
                gvCustomers.DataSource = dte.DefaultView;
                gvCustomers.DataBind();
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            CustomerBus customerBus = new CustomerBus();
            Customer customer = new Customer();

            customer.Id = customerBus.convertLong(txtId.Text);
            customer.Name = txtName.Text;
            customer.Telephone1 = customerBus.convertInt(txtTelephone1.Text);
            customer.Telephone2 = customerBus.convertInt(txtTelephone1.Text);
            customer.Email = txtEmail.Text;
            customer.Address = txtAddress.Text;

            lblMessage.Text = customerBus.update(customer);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CustomerBus customerBus = new CustomerBus();
            Customer customer = new Customer();

            customer.Id = customerBus.convertLong(txtId.Text);
            customer.Name = txtName.Text;
            customer.Telephone1 = customerBus.convertInt(txtTelephone1.Text);
            customer.Telephone2 = customerBus.convertInt(txtTelephone1.Text);
            customer.Email = txtEmail.Text;
            customer.Address = txtAddress.Text;

            lblMessage.Text = customerBus.delete(customer);
        }

        protected void gvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId.Text = gvCustomers.SelectedRow.Cells[1].Text;
            txtName.Text = gvCustomers.SelectedRow.Cells[2].Text;
            txtTelephone1.Text = gvCustomers.SelectedRow.Cells[3].Text;
            txtTelephone2.Text = gvCustomers.SelectedRow.Cells[4].Text;
            txtEmail.Text = gvCustomers.SelectedRow.Cells[5].Text;
            txtAddress.Text = gvCustomers.SelectedRow.Cells[6].Text;
        }

        protected void gvCustomers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='#FFFF00';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }
    }
}