using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrintAdminWebApp.App.Account
{
    public class UserLogin
    {
        public bool SignIn(string username, string password)
        {
            UserBus userBus = new UserBus();
            return userBus.login(username, password);
        }
    }
}