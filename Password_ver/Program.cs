using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_ver
{
    public class PasswordValidator
    {
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool Verify(string Password, object usertype)
        {
            if (usertype.GetType()==typeof(InternalPwdValidator))
            {
                InternalPwdValidator ipv = (InternalPwdValidator)usertype;
                return ipv.IntVerifyPwd(Password);
            }
            else
            {
                ExternalPwdValidator ipv = (ExternalPwdValidator)usertype;
                return ipv.ExtVerifyPwd(Password);
            }          
        }
    }

    public class ExternalPwdValidator : PasswordValidator
    {
        public bool ExtVerifyPwd(string Password)
        {
            int condition = 0;
            bool check = true;

            //check for null
            if (string.IsNullOrEmpty(Password))
                throw new Exception("Password cannot be Null.");
            else
                condition++;

            //check for minimum length
            if (Password.Length < 8)
                throw new Exception("Password length should be greater than 8 characters");
            else
                condition++;

            //check for upper case letter
            if ((Password.Any(x => char.IsUpper(x))))
                condition++;
            else
            {
                check = false;
                throw new Exception("Password should have one uppercase character.");

            }

            //check for lower case letter
            if ((Password.Any(x => char.IsLower(x))))
                condition++;
            else
                throw new Exception("Password should have one lowercase character.");

            //check for number
            if ((Password.Any(x => char.IsNumber(x))))
                condition++;
            else
                throw new Exception("Password should have one number character.");

            //to return value
            if (condition >= 3 && check == true)
                return true;
            else
                return false;
        }
    }

    public class InternalPwdValidator : PasswordValidator
    {
        public bool IntVerifyPwd(string Password)
        {
            bool check = true;
            //check for minimum length
            if (Password.Length <8 )
            { 
                check = false;
                throw new Exception("Password length should be greater than 8 characters");
            }
            return check;
        }
     }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
