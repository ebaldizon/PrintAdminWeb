using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class InvoiceDa
    {
        public bool create(Invoice invoice)
        {
            try
            {
                DB db = new Data.DB();
                string query = "INSERT INTO Invoices(number, CustomerID , orderNum, subtotal, tax, total) VALUES("+invoice.InvoiceNumber+", "+ invoice.CustomerID+", 1, "+ invoice.Subtotal +", "+ invoice.Tax +", "+ invoice.Total +")";
                return db.executeQuery(query);
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public DataTable read(Invoice invoice)
        {
            try
            {
                DB db = new DB();

                string query = "select * from Invoices where (number = "+ invoice.InvoiceNumber +") or (customerID = "+ invoice.CustomerID + ")  or (subtotal = "+ invoice.Subtotal +") or (tax = "+ invoice.Tax + ") or (total = " + invoice.Total + ")";
                DataTable dt = db.executeReadQuery(query);

                if (dt.Rows[0]["number"].ToString() != "")
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool update(Invoice invoice)
        {
            try
            {
                DB db = new DB();
                db.connection();
                string query = "UPDATE Invoices SET customerID = "+ invoice.CustomerID +", subtotal = "+ invoice.Subtotal +", tax = "+ invoice.Tax +", total=3 where number = "+ invoice.InvoiceNumber +"";
                return db.executeQuery(query);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool delete(Invoice invoice)
        {
            try
            {
                DB db = new DB();

                string query = "DELETE FROM Invoices WHERE (number = "+ invoice.InvoiceNumber +") AND (customerID = "+ invoice.CustomerID +") AND (subtotal = "+ invoice.Subtotal +") AND (tax = "+ invoice.Tax +") AND (total= "+ invoice.Total +")";

                return db.executeQuery(query);
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        public DataTable listInvoices()
        {
            try
            {
                DB db = new DB();
                string query = "select number, dateOrder, name, price, payment, balance from Invoices";
                DataTable dt = db.executeReadQuery(query);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
