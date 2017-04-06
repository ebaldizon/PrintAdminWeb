using Entities;
using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;

namespace Business
{
    public class CustomerBus
    {
        private string msgError;
        /*************************    CRUD   ****************************************/
        public string create(Customer customer)
        {
            if(generalValidator(customer))
            {

                CustomerDa customerDa = new CustomerDa();
                if (customerDa.create(customer))
                {
                    return "Cliente añadido exitosamente";
                }
                else
                {
                    return "El cliente no se pudo añadir al sistema";
                }
                
            }
            else
            {
                return msgError;
            }
           
        }

        public string  update(Customer customer)
        {
            if (generalValidator(customer))
            {
               
                CustomerDa customerDa = new CustomerDa();

                if (customerDa.update(customer))
                {
                    return "Cliente actualizado exitosamente";
                }
                return "No se pudo actualizar el cliente";
            }
            else
            {
                return msgError;
            }
        }

        public DataTable read(Customer customer)
        {
            CustomerDa customerDa =  new CustomerDa();
            return customerDa.read(customer);
        }

        public DataTable readForId(string id)
        {
            CustomerDa customerDa = new CustomerDa();
            long newID = validateInt(id);
            return customerDa.readForId(newID);
        }

        public string delete(Customer customer)
        {
            if (generalValidator(customer))
            {
                CustomerDa customerDa = new CustomerDa();

                if (customerDa.delete(customer))
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

        public DataTable listCustomers()
        {
            CustomerDa customerDa = new CustomerDa();
            DataTable dt = customerDa.listCustomers();

            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        /*************************    VALIDATORS   ****************************************/

        private Customer  fillCustomers(string id, string name, string telephone1, string telephone2, string email)
        {
            Customer customer = new Customer();
            if (CanConvert<long>(id) == false)
            {
                customer.Id = 0;
            }
            else
            {
                customer.Id = long.Parse(id);
            }

            if (CanConvert<Int32>(telephone1) == false)
            {
                customer.Telephone1 = 0;
            }
            else
            {
                customer.Telephone1 = Int32.Parse(telephone1);
            }

            if (CanConvert<Int32>(telephone2) == false)
            {
                customer.Telephone2 = 0;
            }
            else
            {
                customer.Telephone2 = Int32.Parse(telephone2);
            }
            customer.Name = name;
            customer.Email = email;
            return customer;
        }

        private bool generalValidator(Customer customer)
        {
            if (emptyValidator(customer) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool emptyValidator(Customer customer)
        {

            if (customer.Id == 0)
            {
                this.msgError = "Por favor rellena *Cédula";
                return false;
            }
            else if (customer.Name == "")
            {
                this.msgError = "Por favor rellenar *Nombre";
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool expressionsValidator(string id, string name, string telephone1, string telephone2, string email)
        {
            string patternNumbers = "^(0|[1-9][0-9]*)$";
            //string patternLettersNumbers = "^[a-zA-Z0-9]*$";
            string patternEmail = "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$";

            if (Regex.IsMatch(id, patternNumbers) == false)
            {
                this.msgError = "Por favor use solamente números para el campo cédula";
                return false;		 			
            }
            else if (Regex.IsMatch(telephone1, patternNumbers) == false)
            {
                this.msgError = "Por favor use solamente números para el campo Teléfono 1";
                return false;
            }
            else if (Regex.IsMatch(telephone2, patternNumbers) == false)
            {
                this.msgError = "Por favor use solamente números para el campo Teléfono 2";
                return false;
            }
            else if (Regex.IsMatch(email, patternEmail) == false)
            {
                this.msgError = "Por favor ingrese un correo valido";
                return false;
            }
            return true;
        }

        public long convertLong(string number)
        {
            if (CanConvert<long>(number))
            {
                return long.Parse(number);
            }
            else
            {
                return 0;
            }
        }

        public int convertInt(string number)
        {
            if (CanConvert<int>(number))
            {
                return int.Parse(number);
            }
            else
            {
                return 0;
            }
        }


        public long validateInt(string number)
        {
            string patternNumbers = "^(0|[1-9][0-9]*)$";
            if (Regex.IsMatch(number, patternNumbers) != false)
            {
                return long.Parse(number);
            }
            return 0;
        }

        public bool CanConvert<T>(string data)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            return converter.IsValid(data);
        }

    }
}
