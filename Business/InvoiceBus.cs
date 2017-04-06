using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business
{
    public class InvoiceBus
    {
        private string msgError;
        /*********   CRUD ****************/
        public string create(string invoiceNumber, string customerId, string subtotal, string tax, string total, string order)
        {
            if(generalValidator(invoiceNumber, customerId, subtotal, tax, total, order))
            {
                Invoice invoice = new Invoice();
                invoice.InvoiceNumber = Int32.Parse(invoiceNumber);
                invoice.CustomerID = Int32.Parse(customerId);
                invoice.Subtotal = Int32.Parse(subtotal);
                invoice.Tax = Int32.Parse(tax);
                invoice.Total = Int32.Parse(total);

                InvoiceDa invoiceDa = new InvoiceDa();
                if(invoiceDa.create(invoice))
                {
                    return "Factura registrada correctamente";
                }
                else
                {
                    return "No se pudo registrar la factura";
                }
            }
            return msgError;
        }

        public DataTable read(string invoiceNumber, string customerID, string subtotal, string tax, string total, string order)
        {
            InvoiceDa invoiceDa = new InvoiceDa();
            DataTable dt;

            dt = invoiceDa.read(fillInvoices(invoiceNumber, customerID, subtotal, tax, total, order));
            if(dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        public string update(string invoiceNumber, string customerID, string subtotal, string tax, string total, string order)
        {
            if (generalValidator(invoiceNumber, customerID, subtotal, tax, total, order))
            {
                Invoice invoice = new Invoice();
                invoice.InvoiceNumber = Int32.Parse(invoiceNumber);
                invoice.CustomerID = Int32.Parse(customerID);
                invoice.Subtotal = float.Parse(subtotal);
                invoice.Tax = float.Parse(tax);
                invoice.Total = float.Parse(total);

                InvoiceDa invoiceDa = new InvoiceDa();

                if (invoiceDa.update(invoice))
                {
                    return "Factura actualizada exitosamente";
                }
                return "No se pudo actualizar la factura";
            }
            else
            {
                return msgError;
            }
        }

        public string delete(string invoiceNumber, string customerId, string subtotal, string tax, string total, string order)
        {
            if (generalValidator(invoiceNumber, customerId, subtotal, tax, total, order))
            {
                Invoice invoice = new Invoice();
                invoice.InvoiceNumber = Int32.Parse(invoiceNumber);
                invoice.CustomerID = Int32.Parse(customerId);
                invoice.Subtotal = float.Parse(subtotal);
                invoice.Tax = float.Parse(tax);
                invoice.Total = float.Parse(total);


                InvoiceDa invoiceDa = new InvoiceDa();

                if (invoiceDa.delete(invoice))
                {
                    return "Usuario borrado exitosamente";
                }
                else
                {
                    return "No se pudo borrar el usuario";
                }

            }
            else
            {
                return msgError;
            }
        }

        public DataTable listInvoices()
        {
            InvoiceDa invoiceDa = new InvoiceDa();
            DataTable dt = invoiceDa.listInvoices();

            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        /********  VALIDATORS  *************/

        /*Metodo fillInvoices rellenamos una objeto invoice con el fin de utilizarlo como medio de busqueda cuando no se completaron todos los espacios de los textbox */
        private Invoice fillInvoices(string invoiceNumber, string customerId, string subtotal, string tax, string total, string order)
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceNumber = 0;
            invoice.CustomerID = 0;
            invoice.Subtotal = 0;
            invoice.Tax = 0;
            invoice.Total = 0;

            if (CanConvert<Int32>(invoiceNumber) == true)
            {
                invoice.InvoiceNumber = Int32.Parse(invoiceNumber);
            }
            else if(CanConvert<Int32>(customerId) == true)
            {
                invoice.CustomerID = Int32.Parse(customerId);
            }
            else if (CanConvert<Int32>(subtotal) == true)
            {
                invoice.Subtotal = Int32.Parse(subtotal);
            }
            else if (CanConvert<Int32>(tax) == true)
            {
                invoice.Tax = Int32.Parse(tax);
            }
            else if (CanConvert<Int32>(total) == true)
            {
                invoice.Total = Int32.Parse(total);
            }
            return invoice;
        }

        private bool generalValidator(string invoiceNumber, string customerId, string subtotal, string tax, string total, string order)
        {
            if (emptyValidator(invoiceNumber, customerId, subtotal, tax, total, order) == false)
            {

                return false;
            }
            else if (expressionsValidator(invoiceNumber,  customerId, subtotal, tax, total, order) == false)
            {

                return false;
            }
            else
            {
                return true;
            }
        }

        private bool emptyValidator(string invoiceNumber, string customerId, string subTotal, string tax, string total, string order)
        {
            if (invoiceNumber == "")
            {
                this.msgError = "Por favor rellena * Número de factura";
                return false;
            }
            else if (customerId == "")
            {
                this.msgError = "Por favor rellenar * Cédula";
                return false;
            }
            else if (subTotal == "")
            {
                this.msgError = "Por favor rellenar * SubTotal";
                return false;
            }
            else if (tax == "")
            {
                this.msgError = "Por favor rellenar * IVA";
                return false;
            }
            else if (total == "")
            {
                this.msgError = "Por favor rellenar * Total";
                return false;
            }
            else if (order == "")
            {
                this.msgError = "Por favor rellenar * Ordenes";
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool expressionsValidator(string invoiceNumber, string customerId, string subTotal, string tax, string total, string order)
        {
            string patternNumbers = "^(0|[1-9][0-9]*)$";
            //string patternLettersNumbers = "^[a-zA-Z0-9]*$";
            //string patternEmail = "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$";

            if (Regex.IsMatch(customerId, patternNumbers) == false)
            {
                this.msgError = "Por favor use solamente números para el campo cédula";
                return false;
            }
            else if (Regex.IsMatch(subTotal, patternNumbers) == false)
            {
                this.msgError = "Por favor use solamente números para el campo Sub Total";
                return false;
            }
            else if (Regex.IsMatch(tax, patternNumbers) == false)
            {
                this.msgError = "Por favor use solamente números para el campo IVA";
                return false;
            }
            else if (Regex.IsMatch(total, patternNumbers) == false)
            {
                this.msgError = "Por favor use solamente números para el campo Total";
                return false;
            }
            else if (Regex.IsMatch(order, patternNumbers) == false)
            {
                this.msgError = "Por favor use solamente números para el campo Orden N";
                return false;
            }
            return true;
        }

        public bool CanConvert<T>(string data)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            return converter.IsValid(data);
        }
    }

}
