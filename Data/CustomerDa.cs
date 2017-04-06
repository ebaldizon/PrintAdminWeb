using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CustomerDa
    {
        public bool create(Customer customer)
        {
            try
            {
                DB db = new DB();
                string query = @"insert into Customers(Id, Name, Telephone1, Telephone2, Email)values('" + customer.Id + "', '" + customer.Name + "', '" + customer.Telephone1 + "', '" + customer.Telephone2 + "', '" + customer.Email + "')";
                return db.executeQuery(query);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable read(Customer customer)
        {
            try
            {
                DB db = new DB();
                
                string query = "select  * from Customers where (Id = ("+ customer.Id +")) or (Name like '"+ customer.Name +"') or (Telephone1 =("+ customer.Telephone1+")) or (Telephone2 =("+ customer.Telephone2 +")) or (Email =('"+ customer.Email+"'))";
                DataTable dt = db.executeReadQuery(query);

                if (dt.Rows[0]["Id"].ToString() != "")
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

        public DataTable readForId(long id)
        {
            try
            {
                DB db = new DB();

                string query = "select * from Customers where Id = ("+ id +")";
                DataTable dt = db.executeReadQuery(query);

                if (dt.Rows[0]["Id"].ToString() != "")
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

        public bool update(Customer customer)
        {
            try
            {
                DB db = new DB();
                db.connection();
                string query = "update Customers set Name = '" + customer.Name + "', Telephone1 = (" + customer.Telephone1 + "), Telephone2 = (" + customer.Telephone2 + "), Email = '" + customer.Email + "' where id = (" + customer.Id + ")";
                return db.executeQuery(query);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool delete(Customer customer)
        {
            try
            {
                DB db = new DB();
                string query = "DELETE FROM Customers WHERE id = (" + customer.Id + ")" +
                    "AND (Name LIKE '" + customer.Name + "')" +
                    "AND (Telephone1 = (" + customer.Telephone1 + "))" +
                    "AND (Telephone2 = (" + customer.Telephone2 + "))" +
                    "AND (Email LIKE '" + customer.Email + "')";
                return db.executeQuery(query);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable listCustomers()
        {
            try
            {
                DB db = new DB();
                string query = "select * from Customers";
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
