using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeathByCaptcha;
using System.IO;

namespace SeleniumAutomation.Automation.Record.Utilities
{
    public class CaptchaSolver
    {

        private string _userName;
        private string _password;
        private string _balance;

        private Captcha _captcha;
        private Client _client;

        public CaptchaSolver(string userName, string password)
        {
            _userName = userName;
            _password = password;

            _client = (Client)new SocketClient(_userName, password);
        }

        public string SolveCaptcha(MemoryStream stream)
        {
            Console.WriteLine("Your balance is {0:F2} US cents", _client.Balance);
            

            _captcha = _client.Decode(stream.GetBuffer(), Client.DefaultTimeout);


            if (_captcha != null && _captcha.Solved && _captcha.Correct)
            {
                Console.WriteLine("Captcha Solved!");
                return _captcha.Text;
            }
            else
            {
                Console.WriteLine("Captcha Failed!");
                return string.Empty;
            }
        }

        public static string GetBalance(string userName,string password)
        {
           return new SocketClient(userName, password).Balance.ToString();
        }

        public string Balance
        {
            get
            {
                if (_client != null)
                {
                    _client = (Client)new SocketClient(_userName, _password);
                }
                return _client.Balance.ToString();
            }
        }
    }
}
