using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business
{
    public class OrderBus
    {

        string MsgError;
        public string create(Order order)
        {
            if (zeroValidator(order))
            {
                OrderDa orderDa = new OrderDa();
                if(orderDa.create(order))
                {
                    return "La orden fue agregada al sistema.";
                }
                else
                {
                    return "No se pudo agregar la orden al sistema, por favor revisar si el cliente existe y si el número de orden esta disponible.";
                }
            }
            else
            {
                return MsgError;
            }
        }

        public string update(Order order)
        {
            if (zeroValidator(order))
            {
                OrderDa orderDa = new OrderDa();
                if (orderDa.update(order))
                {
                    return "La orden se actualizo en el sistema.";
                }
                else
                {
                    return "No se pudo encontrar la (Orden #) a editar.";
                }
            }
            else
            {
                return MsgError;
            }
        }

        public string updateInvoice(Order order)
        {
            OrderDa orderDa = new OrderDa();

            if (orderDa.updateInvoice(order) && order.Number != 0)
            {
                return "El recibo se actualizo en el sistema.";
            }
            else
            {
                return "No se pudo actualizar el recibo.";
            }
        }

        public string delete(string number)
        {
            int newNumber = convertInt(number);
            OrderDa orderDa = new OrderDa();
            if(orderDa.delete(newNumber))
            {
                return "Orden borrada del sistema.";
            }
            else
            {
                return "No se pudo borrar del sistema.";
            }
            
        }

        public DataTable readForCustomerID(Order order)
        {
            OrderDa orderDa = new OrderDa();
            return orderDa.readForCustomerID(order);
        }

        public DataTable readForCustomerIDInv(Order order)
        {
            OrderDa orderDa = new OrderDa();
            return orderDa.readForCustomerIDInv(order);
        }

        public DataTable readForNumber(string number)
        {
            int newNumber = convertInt(number);
            OrderDa orderData = new OrderDa();
            return orderData.readForNumber(newNumber);
        }
        
        
        public int ultimateOrder()
        {
            try
            {
                OrderDa orderDa = new OrderDa();
                DataTable dt = orderDa.ultimateOrder();
                int next = 1 + (int)dt.Rows[0][0];
                return next;
            }
            catch(Exception)
            {
                return 0;
            }
        } 

        /********************   VALIDATORS *******************************/
        public bool zeroValidator(Order order)
        {
            if(order.Number == 0)
            {
                this.MsgError = "Por favor rellene correctamente el campo (Orden #).";
                return false;
            }
            else if(order.CustomerID == 0)
            {
                this.MsgError = "Por favor rellene correctamente el campo (Cédula).";
                return false;
            }
            return true;
        }

        public int convertInt(string number)
        {
            string patternNumbers = "^(0|[1-9][0-9]*)$";
            if (Regex.IsMatch(number, patternNumbers) != false)
            {
                return int.Parse(number);
            }
            return 0;
        }

        public byte[] validateDesign(byte[] design)
        {
            if(design == null)
            {
                byte[] emptyDesign = Encoding.ASCII.GetBytes(new string(' ', 0));
                return emptyDesign;
            }
            else
            {
                return design;
            }
        }

        public long convertLong(string number)
        {
            string patternNumbers = "^(0|[1-9][0-9]*)$";
            if (Regex.IsMatch(number, patternNumbers) != false)
            {
                return long.Parse(number);
            }
            return 0;
        }

        public float convertFloat(string number)
        {
            string patternNumbers = "^(0|[1-9][0-9]*)$";
            if (Regex.IsMatch(number, patternNumbers) != false)
            {
                return float.Parse(number);
            }
            return 0;
        }

        public string fillNulls()
        {
            return "";
        }

        public DataTable ListOrders()
        {
            OrderDa orderDa = new OrderDa();
            return orderDa.listOrders();
        }

        public DataTable ListOrdersInvoice()
        {
            OrderDa orderDa = new OrderDa();
            return orderDa.listOrdersInvoice();
        }

        public float calculateBalance(float price, float payment)
        {
            return price - payment;
        }

        /***** END ***/
    }
}
