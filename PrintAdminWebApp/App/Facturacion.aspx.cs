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
    public partial class Facturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtNumber.Attributes.Add("readonly", "readonly");
            txtCustomerName.Attributes.Add("readonly", "readonly");
            txtDate.Attributes.Add("readonly", "readonly");
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
        }

        protected void gvInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumber.Text = gvInvoices.SelectedRow.Cells[1].Text;
            txtDate.Text = gvInvoices.SelectedRow.Cells[2].Text;
            txtCustomerName.Text = gvInvoices.SelectedRow.Cells[4].Text;
            txtPrice.Text = gvInvoices.SelectedRow.Cells[8].Text;
            txtPayment.Text = gvInvoices.SelectedRow.Cells[9].Text;
            txtBalance.Text = gvInvoices.SelectedRow.Cells[10].Text;
        }

        protected void gvInvoices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='#FFFF00';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPrice.Text == "")
            {
                lblMessage.Text = "Por favor rellene campo Valor.";
            }
            else if (txtPayment.Text == "")
            {
                lblMessage.Text= "Por favor rellene campo Adelanto.";
            }
            else
            {
                try
                {
                    Order order = new Order();
                    OrderBus orderBus = new OrderBus();
                    order.Number = orderBus.convertInt(txtNumber.Text);
                    order.Price = orderBus.convertFloat(txtPrice.Text);
                    order.Payment = orderBus.convertFloat(txtPayment.Text);
                    order.Balance = orderBus.calculateBalance(order.Price, order.Payment);
                    lblMessage.Text = orderBus.updateInvoice(order);
                }
                catch (Exception)
                {
                    lblMessage.Text = "Error - No se pudieron guardar los cambios";
                }
            }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Order order = new Order();
                OrderBus orderBus = new OrderBus();
                order.Number = orderBus.convertInt(txtNumber.Text);
                order.Price = 0;
                order.Payment = 0;
                order.Balance = 0;
                lblMessage.Text = orderBus.updateInvoice(order);
            }
            catch (Exception)
            {
                lblMessage.Text = "No se pudo eliminar los valores.";
            }
        }

        protected void btnSearchForID_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                lblMessage2.Text = "Por favor rellene el campo de Cédula.";
            }
            else
            {
                OrderBus orderBus = new OrderBus();
                Order order = new Order();
                order.CustomerID = orderBus.convertLong(txtId.Text);

                DataTable dt = orderBus.readForCustomerIDInv(order);

                if (dt != null)
                {
                    gvInvoices.DataSource = dt.DefaultView;
                    gvInvoices.DataBind();
                }
                else
                {
                    lblMessage2.Text = "No se pudo encontra una Orden";
                }
            }
        }
    }
}