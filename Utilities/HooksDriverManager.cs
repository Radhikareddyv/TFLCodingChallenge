using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TFLCodingChallenge.Utilities
{
    public partial class Hooks
    {
        private bool StartDriver()
        {
            try
            {
                StartLocalDriver();
                return true;
            }
            catch (WebDriverException e)
            {
                throw new WebDriverException(e.Message + "\n");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "\n");
            }
        }

        private void StartLocalDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--no-sandbox");
            //chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--incognito");
            _driver = new ChromeDriver(chromeOptions);
            _driver.Manage().Window.Maximize();
        }
    }
}
