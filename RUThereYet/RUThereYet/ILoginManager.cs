using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RUThereYet
{
    public interface ILoginManager
    {
        void ShowMainPage();
        void ShowCreateAccountPage();
        void ShowForgotPassword();
        void Logout();
        void Login();
        //string Login(string username, string password)
        //{
        //    // Call the API and log the user in
        //    string loginUser = username;
        //    string loginPass = password;

        //    return "success";
        //}
    }
}
