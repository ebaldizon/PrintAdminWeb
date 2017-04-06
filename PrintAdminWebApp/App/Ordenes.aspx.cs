using Business;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrintAdminWebApp.App
{
    public partial class Ordenes : System.Web.UI.Page
    {
        Byte[] DesignArray;
        Design DesignInvoice;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtDateOrder.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDeliveryDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.DesignInvoice = new Design();
            txtFileName.Attributes.Add("readonly", "readonly");
        }

        protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.backgroundColor='#FFFF00';";
                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='white';";
                e.Row.ToolTip = "Click last column for selecting this row.";
            }
        }

        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
            if (e.CommandName == "Design")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvOrders.Rows[index];
                string order = row.Cells[1].Text;

                OrderBus orderBus = new OrderBus();
                DataTable dtOrder = orderBus.readForNumber(order);

                byte[] DesignA = (byte[])dtOrder.Rows[0]["design"];
                if (DesignA != null)
                {
                    
                    byte[] buffer = (byte[])dtOrder.Rows[0][27];
                    string startupPath = Server.MapPath("~/App/Temp/");
                    deleteAllFilesFromPath(startupPath);

                    string fileName = dtOrder.Rows[0][26].ToString();

                    System.IO.File.WriteAllBytes(startupPath+fileName, buffer);

                    System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
                    response.ClearContent();
                    response.Clear();
                    response.ContentType = "text/plain";
                    response.AddHeader("Content-Disposition",
                                       "attachment; filename=" + fileName + ";");

                    
                    response.TransmitFile(startupPath + fileName);
                    response.Flush();
                    response.End();

                }
                else
                {
                    lblMessage.Text = "Para descargar el diseño por favor seleccione un cliente de la lista";
                }
            }
        }

        protected void deleteAllFilesFromPath(string path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        protected void gvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

            OrderBus orderBus = new OrderBus();
            DataTable dtOrder = orderBus.readForNumber(gvOrders.SelectedRow.Cells[1].Text); /***/

            try
            {
                txtNumberOrder.Text = dtOrder.Rows[0]["number"].ToString();
                txtDateOrder.Text = dtOrder.Rows[0]["dateOrder"].ToString();
                txtCustomerID.Text = dtOrder.Rows[0]["customerID"].ToString();
                txtDeliveryDate.Text = dtOrder.Rows[0]["dateDelivery"].ToString();
                txtDeliveredBy.Text = dtOrder.Rows[0]["deliveredBy"].ToString();
                txtWorkType.Text = dtOrder.Rows[0]["workType"].ToString();
                txtComputer.Text = dtOrder.Rows[0]["computer"].ToString();
                chkIron.Checked = Convert.ToBoolean(dtOrder.Rows[0]["iron"].ToString());
                chkPaper.Checked = Convert.ToBoolean(dtOrder.Rows[0]["paper"].ToString());
                txtQuantity.Text = dtOrder.Rows[0]["quantity"].ToString();
                txtInk.Text = dtOrder.Rows[0]["ink"].ToString();
                txtSheets.Text = dtOrder.Rows[0]["sheets"].ToString();
                txtTrait1.Text = dtOrder.Rows[0]["trait1"].ToString();
                txtTrait2.Text = dtOrder.Rows[0]["trait2"].ToString();
                txtTrait3.Text = dtOrder.Rows[0]["trait3"].ToString();
                txtTrait4.Text = dtOrder.Rows[0]["trait4"].ToString();
                txtTrait5.Text = dtOrder.Rows[0]["trait5"].ToString();
                txtTrait6.Text = dtOrder.Rows[0]["trait6"].ToString();
                txtSize.Text = dtOrder.Rows[0]["size"].ToString();
                chkGlued.Checked = Convert.ToBoolean(dtOrder.Rows[0]["glued"].ToString());
                chkPerforated.Checked = Convert.ToBoolean(dtOrder.Rows[0]["perforated"].ToString());
                chkChanges.Checked = Convert.ToBoolean(dtOrder.Rows[0]["changes"].ToString());
                chkHoles.Checked = Convert.ToBoolean(dtOrder.Rows[0]["holes"].ToString());
                txtInitialNum.Text = dtOrder.Rows[0]["initialNum"].ToString();
                txtEndNum.Text = dtOrder.Rows[0]["endNum"].ToString();
                txtObservations.Text = dtOrder.Rows[0]["observations"].ToString();
                txtFileName.Text = dtOrder.Rows[0]["nameDesign"].ToString();
                
                this.DesignInvoice.FileName = dtOrder.Rows[0]["nameDesign"].ToString();
                this.DesignInvoice.Content = (byte[])dtOrder.Rows[0]["design"];
                //this.DesignArray = (byte[])dtOrder.Rows[0]["design"];

                txtPrice.Text = dtOrder.Rows[0]["price"].ToString();
                txtPayment.Text = dtOrder.Rows[0]["payment"].ToString();
                txtBalance.Text = dtOrder.Rows[0]["balance"].ToString();

                CustomerBus customerBus = new CustomerBus();
                DataTable dtc = customerBus.readForId(txtCustomerID.Text);
                try
                {
                    txtCustomerName.Text = dtc.Rows[0][1].ToString();
                }
                catch (Exception)
                {
                    lblMessage.Text = "Nombre de cliente no encontrado";
                }          
            }
            catch (Exception)
            {
                lblMessage.Text = "Para cargar el detalle de la Orden por favor seleccione un cliente de la lista";
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            Design D = getDesign();

            Order order = new Order();
            OrderBus orderBus = new OrderBus();

            order.Number = orderBus.convertInt(txtNumberOrder.Text);
            order.DateOrder = DateTime.ParseExact(txtDateOrder.Text, "dd/MM/yyyy", null);
            order.CustomerID = orderBus.convertLong(txtCustomerID.Text);
            order.DateDelivery = DateTime.ParseExact(txtDeliveryDate.Text, "dd/MM/yyyy", null);
            order.DeliveredBy = txtDeliveredBy.Text;
            order.WorkType = txtWorkType.Text;
            order.Computer = txtComputer.Text;
            order.Iron = chkIron.Checked;
            order.Paper = chkPaper.Checked;
            order.Quantity = txtQuantity.Text;
            order.Ink = txtInk.Text;
            order.Sheets = txtSheets.Text;
            order.Trait1 = txtTrait1.Text;
            order.Trait2 = txtTrait2.Text;
            order.Trait3 = txtTrait3.Text;
            order.Trait4 = txtTrait4.Text;
            order.Trait5 = txtTrait5.Text;
            order.Trait6 = txtTrait6.Text;
            order.Size = txtSize.Text;
            order.Glued = chkGlued.Checked;
            order.Perforated = chkPerforated.Checked;
            order.Changes = chkChanges.Checked;
            order.Holes = chkHoles.Checked;
            order.InitialNum = orderBus.convertInt(txtInitialNum.Text);
            order.EndNum = orderBus.convertInt(txtEndNum.Text);
            order.Observations = txtObservations.Text;
            //order.Design = this.Design;
            //order.NameDesign = txtFileName.Text;
            order.Design = orderBus.validateDesign(D.Content);
            order.NameDesign = D.FileName;

            float price = orderBus.convertFloat(txtPrice.Text);
            float payment = orderBus.convertFloat(txtPayment.Text);
            float balance = orderBus.calculateBalance(price, payment);

            lblMessage.Text = orderBus.create(order);
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            if(txtCustomerID.Text != "")
            {
                OrderBus orderBus = new OrderBus();
                Order order = new Order();
                order.CustomerID = orderBus.convertLong(txtCustomerID.Text);

                DataTable dt = orderBus.readForCustomerID(order);

                if (dt != null)
                {
                    gvOrders.DataSource = dt.DefaultView;
                    gvOrders.DataBind();
                }
                else
                {
                    lblMessage.Text = "No se pudo encontrar la Orden";
                }

            }
            else
            {
                   lblMessage.Text = "Por favor rellene el campo (Cédula)";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            OrderBus orderBus = new OrderBus();
            Design D = getDesign();

            order.Number = orderBus.convertInt(txtNumberOrder.Text);
            order.DateOrder = DateTime.ParseExact(txtDateOrder.Text, "dd/MM/yyyy", null);
            order.CustomerID = orderBus.convertLong(txtCustomerID.Text);
            order.DateDelivery = DateTime.ParseExact(txtDeliveryDate.Text, "dd/MM/yyyy", null);
            order.DeliveredBy = txtDeliveredBy.Text;
            order.WorkType = txtWorkType.Text;
            order.Computer = txtComputer.Text;
            order.Iron = chkIron.Checked;
            order.Paper = chkPaper.Checked;
            order.Quantity = txtQuantity.Text;
            order.Ink = txtInk.Text;
            order.Sheets = txtSheets.Text;
            order.Trait1 = txtTrait1.Text;
            order.Trait2 = txtTrait2.Text;
            order.Trait3 = txtTrait3.Text;
            order.Trait4 = txtTrait4.Text;
            order.Trait5 = txtTrait5.Text;
            order.Trait6 = txtTrait6.Text;
            order.Size = txtSize.Text;
            order.Glued = chkGlued.Checked;
            order.Perforated = chkPerforated.Checked;
            order.Changes = chkChanges.Checked;
            order.Holes = chkHoles.Checked;
            order.InitialNum = orderBus.convertInt(txtInitialNum.Text);
            order.EndNum = orderBus.convertInt(txtEndNum.Text);
            order.Observations = txtObservations.Text;
            //order.Design = orderBus.validateDesign(this.DesignArray); 

            order.NameDesign = D.FileName;
            order.Design = orderBus.validateDesign(D.Content);

            order.Price = orderBus.convertFloat(txtPrice.Text);
            order.Payment = orderBus.convertFloat(txtPayment.Text);
            order.Balance = orderBus.convertFloat(txtBalance.Text);

            lblMessage.Text = orderBus.update(order);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OrderBus orderBus = new OrderBus();
            lblMessage.Text = orderBus.delete(txtNumberOrder.Text);
        }

        public Design getDesign()
        {
            Design D = new Entities.Design();
            if (fuDesign.HasFile)
            {
                //fuDesign.SaveAs(Server.MapPath("~/App/Images/" + fuDesign.FileName));

                Stream stream = fuDesign.FileContent;
                //Stream stream = fuDesign.PostedFile.InputStream;
                D.Content = ReadFully(stream);
                D.FileName = fuDesign.FileName;
                return D;
            }
            else
            {
                OrderBus orderBus = new OrderBus();
                DataTable dtOrder = orderBus.readForNumber(txtNumberOrder.Text);
                D.FileName = dtOrder.Rows[0]["nameDesign"].ToString();
                D.Content = (byte[])dtOrder.Rows[0]["design"];
                return D;
            }
        }

        /*
        public Design getDesign()
        {
            Design D = new Entities.Design();

            if (fuDesign.HasFile)
            {
                //fuDesign.SaveAs(Server.MapPath("~/App/Images/" + fuDesign.FileName));

                Stream stream = fuDesign.FileContent;
                //Stream stream = fuDesign.PostedFile.InputStream;
                D.Content = ReadFully(stream);
                D.FileName = fuDesign.FileName;
                return D;
            }
            else
            {
                try
                {
                    D.FileName = this.DesignInvoice.FileName;
                    D.Content = this.DesignInvoice.Content;
                }
                catch(Exception e)
                {
                    D.FileName = "Ninguno";
                }
                return D;
            }
        }*/

        protected void btnDesign_Click(object sender, EventArgs e)
        {
            if(fuDesign.HasFile)
            {
                fuDesign.SaveAs(Server.MapPath("~/App/Images/"+ fuDesign.FileName));

                Stream stream = fuDesign.FileContent;
                //Stream stream = fuDesign.PostedFile.InputStream;
                this.DesignArray = ReadFully(stream);
                txtFileName.Text = fuDesign.FileName;
            }
            else
            {
                txtFileName.Text = "";
            }
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        protected void btnDownloadDesign_Click(object sender, EventArgs e)
        {

        }

        protected void btnCustomerIDSearch_Click(object sender, EventArgs e)
        {
            if (txtCustomerIDSearch.Text != "")
            {
                OrderBus orderBus = new OrderBus();
                Order order = new Order();
                order.CustomerID = orderBus.convertLong(txtCustomerIDSearch.Text);

                DataTable dt = orderBus.readForCustomerID(order);

                if (dt != null)
                {
                    gvOrders.DataSource = dt.DefaultView;
                    gvOrders.DataBind();
                }
                else
                {
                    DataTable dte = new DataTable();
                    gvOrders.DataSource = dte.DefaultView;
                    gvOrders.DataBind();
                }

            }
            else
            {
               msgCustomerSearch.Text ="Por favor rellene el campo Cédula";
            }
        }
    }
}