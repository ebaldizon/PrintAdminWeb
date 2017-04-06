using Entities;
using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data;

namespace Business
{
    public class UserBus
    {
        private string msgError;

        public string create(string id, string name, string lastname, string mail, string password, string confirmPassword)
        {
            if(generalValidator(id, name, lastname, mail, password, confirmPassword))
            {
                User user = new User();
                user.Id = long.Parse(id);
                user.Name = name;
                user.Lastname = lastname;
                user.Mail = mail;
                user.Password = encrypt(password);

                UserDa userDa = new UserDa();
                if(userDa.create(user))
                {

                    return "Usuario creado exitosamente";
                }
                return "No se pudo crear el usuario";
            }
            else
            {
                return msgError;
            }
        }

        public DataTable read(string id, string name, string lastname, string mail, string password, string confirmPassword)
        {
            UserDa userDa = new UserDa();

            /*Creamos un usuario llamado readUser, lo llenamos con los datos provinientes de la funcion fillUser y se los enviamos a UserDa para buscar sus valores
             en la base de datos*/
            User readUser = new User();
            readUser = fillUser(id, name, lastname, mail, encrypt(password));


            User user = new User();

            DataTable dt = userDa.read(readUser);

            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        public string update(string id, string name, string lastname, string mail, string password, string confirmPassword)
        {
            if (generalValidator(id, name, lastname, mail, password, confirmPassword))
            {
                User user = new User();
                user.Id = long.Parse(id);
                user.Name = name;
                user.Lastname = lastname;
                user.Mail = mail;
                user.Password = encrypt(password);

                UserDa userDa = new UserDa();
                if (userDa.update(user))
                {
                    return "Usuario actualizado exitosamente";
                }
                return "No se pudo actualizar el usuario";
            }
            else
            {
                return msgError;
            }
        }

        public string delete(string id, string name, string lastname, string mail, string password, string confirmPassword)
        {
            if (generalValidator(id, name, lastname, mail, password, confirmPassword))
            {
                User user = new User();
                user.Id = long.Parse(id);
                user.Name = name;
                user.Lastname = lastname;
                user.Mail = mail;
                user.Password = encrypt(password);

                UserDa userDa = new UserDa();

                if(userDa.delete(user))
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

        public DataTable listUsers()
        {
            UserDa userDa = new UserDa();
            DataTable dt = userDa.listUsers();

            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        public bool login(string id, string password)
        {
            User user = new User();
            UserDa userDa = new UserDa();


            if (CanConvert<long>(id) == true)
            {
                user.Id = long.Parse(id);
                user.Password = encrypt(password);
                return userDa.login(user);
            }
            return false;
        }
        
        private bool generalValidator(string id, string name, string lastname, string mail, string password, string confirmPassword)
        {
            if(emptyValidator(id, name, lastname, mail, password, confirmPassword) == false)
            {
                return false;
            }
            else if(passwordValidator(password, confirmPassword) == false)
            {
                return false;
            }
            else if(expressionsValidator(id, name, lastname, mail) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private User fillUser(string id, string name, string lastname, string mail, string password)
        {
            User user = new User();

            if (CanConvert<long>(id) == false)
            {
                user.Id = 0;
            }
            else
            {
                user.Id = long.Parse(id);
            }
            user.Name = name;
            user.Lastname = lastname;
            user.Mail = mail;
            user.Password = password;
            return user;
        }

        private bool emptyValidator(string id, string name, string lastname, string mail, string password, string confirmPassword)
        {
     
            if (id == "")
            {
                this.msgError = "Por favor rellena *Cédula";
                return false;
            }
            else if (name == "")
            {
                this.msgError = "Por favor rellenar *Nombre";
                return false;
            }
            else if (lastname == "")
            {
                this.msgError = "Por favor rellenar *Apellido";
                return false;
            }
            else if (mail == "")
            {
                this.msgError = "Por favor rellenar *Correo";
                return false;
            }
            else if (password == "")
            {
                this.msgError = "Por favor rellenar *Contraseña";
                return false;
            }
            else if (confirmPassword == "")
            {
                this.msgError = "Por favor rellenar *Repetir Contraseña";
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool passwordValidator(string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                this.msgError = "Las contraseñas no coinciden";
                return false;
            }
            return true;
        }

        public bool  expressionsValidator(string id, string name, string lastname, string mail)
        {
            string patternNumbers = "^(0|[1-9][0-9]*)$";
            //string patternLettersNumbers = "^[a-zA-Z0-9]*$";
            string patternEmail = "^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$";

            if (Regex.IsMatch(id, patternNumbers) == false)
            {
                this.msgError = "Por favor use solamente números para el campo cédula";
                return false;
            }
            else if (Regex.IsMatch(mail, patternEmail) == false)
            {
                this.msgError = "Por favor ingrese un correo valido";
                return false;
            }
            return true;
        }

        private bool charactersValidator(string id, string name, string lastname, string mail, string password)
        {
            if (CanConvert<long>(id) == false)
            {
                this.msgError = "Por favor ingrese un número de cédula valido";
                return false;
            }
            return true;
        }

        public bool CanConvert<T>(string data)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            return converter.IsValid(data);
        }

        public string encrypt(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string decrypt(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public bool recoverPassword(User user)
        {
            user.Password = encrypt(randomString(5));
            UserDa userDa = new UserDa();
            bool resultDB = userDa.recoverPassword(user);

            if(resultDB)
            {
                Email email = new Email("amnetdeluxe@gmail.com", "fibra9206");
                bool resultEmail = email.send(user.Mail, "", "Contraseña Nueva - PrintAdmin", "La nueva contraseña de su cuenta es:  "+ decrypt(user.Password));
                if(resultEmail)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string randomString(int size)
        {
            string letters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            int length = letters.Length;
            string randomString = "";
            Random randomNumber = new Random();

            for (int i = 0; i<size; i++)
            {
                char letter = letters[randomNumber.Next(length)];
                randomString += letter;
            }
            return randomString;
        }

    }
}
