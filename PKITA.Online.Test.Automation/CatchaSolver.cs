using System;
using System.Drawing;

using OpenQA.Selenium.Firefox;

using System.IO;


namespace PKITA.Online.Test.Automation
{
    class CatchaSolver
    {
         public static void Main(string[] args)
        {
        

         static void Main(string[] args)
        {
            Console.WriteLine("Initializing the Firefox webdriver...");
            using (var driver = new FirefoxDriver())
            {
                Console.WriteLine("Opening the page...");
                driver.Navigate().GoToUrl("http://testing-ground.scraping.pro/captcha");

                var arrScreen = driver.GetScreenshot().AsByteArray;
                using (var msScreen = new MemoryStream(arrScreen))
                {
                    var bmpScreen = new Bitmap(msScreen);
                    var cap = driver.FindElementById("captcha");
                    var rcCrop = new Rectangle (cap.Location, cap.Size);
                    Image imgCap = bmpScreen.Clone(rcCrop, bmpScreen.PixelFormat);

                    using (var msCaptcha = new MemoryStream())
                    {
                        imgCap.Save(msCaptcha, ImageFormat.Png);

                        // put your DeathByCaptcha credentials here
                        var client = new SocketClient("user", "password");

                        Console.WriteLine("Sending request to DeathByCaptcha...");
                        var res = client.Decode(msCaptcha.GetBuffer(), 20);
                        if (res!=null && res.Solved && res.Correct)
                        {
                            driver.FindElementByXPath ( "//input[@name='captcha_code']" ).SendKeys(res.Text);

                            driver.FindElementByXPath ( "//input[@name='submit']" ).Click ();

                            var h4 = driver.FindElementByXPath("//div[@id='case_captcha']//h4");
                            if (!h4.Text.Contains("SUCCESSFULLY"))
                            {
                                Console.WriteLine("The captcha has been solved incorrectly!");
                                client.Report(res);
                            }
                            else
                                Console.WriteLine("The captcha has been solved correctly!");
                        }
                        else
                            Console.WriteLine("Captcha recognition error occured");
                    }
                }
            }
            Console.ReadKey();
        }


        
    }
}
