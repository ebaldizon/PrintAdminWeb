using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserDa
    {
        public bool create(User user)
        {
            try
            { 
                DB db = new DB();
                string query = @"insert into Users(Id, Name, Lastname, Email, Password)values('"+ user.Id+"', '"+ user.Name+"', '"+ user.Lastname+"', '"+user.Mail+"', '"+user.Password+"')";
                return db.executeQuery(query);
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public DataTable read(User readUser)
        {
            try
            {
                DB db = new DB();
                string query = "select * from Users where id = (" + readUser.Id + ")" + 
                    "OR (Name LIKE '" + readUser.Name + "')"+
                    "OR (Lastname LIKE '" + readUser.Lastname + "')" +
                    "OR (Email LIKE '" + readUser.Mail + "')" +
                    "OR (Password LIKE '" + readUser.Password + "')";

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

        public bool update(User user)
        {
            try
            {
                DB db = new DB();
                db.connection();
                string query = "update Users set Name = '" + user.Name + "', Lastname = '"+ user.Lastname +"', Email = '"+ user.Mail +"', Password = '"+ user.Password +"' where Id = ("+ user.Id +")";
                return db.executeQuery(query);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool delete(User readUser)
        {
            try
            {
                DB db = new DB();
                string query = "DELETE FROM Users WHERE Id = (" + readUser.Id + ")";

                return db.executeQuery(query);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable listUsers()
        {
            try
            {
                DB db = new DB();
                string query = "select * from Users";
                DataTable dt = db.executeReadQuery(query);
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool login(User user)
        {
            try
            {
                DB db = new DB();
                string query = "select * from Users where Id = ("+ user.Id +") and Password = '"+ user.Password +"'";

                DataTable dt = db.executeReadQuery(query);

                if (dt.Rows[0]["Id"].ToString() != "")
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool recoverPassword(User user)
        {
            try
            {
                DB db = new DB();
                db.connection();
                string query = "update Users set Password = '" + user.Password + "' where Id = (" + user.Id + ")";
                return db.executeQuery(query);
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
