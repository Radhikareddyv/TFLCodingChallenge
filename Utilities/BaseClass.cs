using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TFLCodingChallenge.Utilities
{
    [Binding]
    public class BaseClass
    {
        private readonly IWebDriver _driver;
        public const double defaultWait = 3000;
      

        public BaseClass(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToPage(string pageUrl)
        {
            try
            {
                _driver.Navigate().GoToUrl(pageUrl);
            }
            catch (WebDriverException e)
            {

                throw new WebDriverException($"Error when navigating to URL: {pageUrl}\n" + e.Message);
            }
        }

        public WebDriverWait BaseWebDriverWait(double time)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(time));

            return webDriverWait;
        }

        public IWebElement WaitForAndGetElement(By locator, double timeToWait = defaultWait)
        {
            try
            {
                IWebElement element = BaseWebDriverWait(timeToWait).Until(ExpectedConditions.ElementExists(locator));
                return element;
            }
            catch (WebDriverTimeoutException)
            {
                return null; // this is to give the same behaviour as GetElement  -- just return null if no element found
            }
        }

        public void ClickElementJS(By locator, double defaultWait = defaultWait)
        {
            WaitUntilElementToBeClickable(locator, defaultWait);
            var element = _driver.FindElement(locator);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public void ClickElement(IWebElement element, double defaultWait = defaultWait)
        {
            try
            {
                WaitUntilElementToBeClickable(element, defaultWait);
                element.Click();
            }
            catch (WebDriverException e)
            {
                throw new WebDriverException("Error when trying to click on element \n" + e);
            }
        }

        public void WaitUntilElementToBeClickable(By locator, double waitTime = defaultWait)
        {
            BaseWebDriverWait(waitTime).Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void WaitUntilElementToBeClickable(IWebElement element, double waitTime = defaultWait)
        {
            BaseWebDriverWait(waitTime).Until(ExpectedConditions.ElementToBeClickable(element));
        }


        public IWebElement GetElement(By locator, double waitTime = defaultWait)
        {
            IWebElement element;
            try
            {
                WaitUntilElementExists(locator, waitTime);
                element = _driver.FindElement(locator);
                return element;
            }
            catch (WebDriverException)
            {
                return null;
            }
        }

        public void WaitUntilVisibilityOfAllElementsLocatedBy(By locator, double waitTime = defaultWait)
        {
            BaseWebDriverWait(waitTime).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public ReadOnlyCollection<IWebElement> ReturnMultipleElements(By locator, double waitTime = defaultWait)
        {
            ReadOnlyCollection<IWebElement> element;
            try
            {
                WaitUntilPresenceOfAllElementsLocatedBy(locator, waitTime);
                element = _driver.FindElements(locator);
            }
            catch (WebDriverException e)
            {
                throw new WebDriverException("Error when trying to get elements \n" + e);
            }
            return element;
        }

        public void WaitUntilPresenceOfAllElementsLocatedBy(By locator, double waitTime = defaultWait)
        {
            BaseWebDriverWait(waitTime).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        }
        public void WaitUntilElementExists(By locator, double waitTime = defaultWait)
        {
            BaseWebDriverWait(waitTime).Until(ExpectedConditions.ElementExists(locator));
        }

        public ReadOnlyCollection<IWebElement> WaitForAllElementsBy(By locator, double timeOut = defaultWait)
        {
            try
            {
                return BaseWebDriverWait(timeOut).Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            }
            catch (Exception)
            {
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            }
        }

        public bool IsElementExist(By locator, double waitTime = defaultWait)
        {
            try
            {
                BaseWebDriverWait(waitTime).Until(ExpectedConditions.ElementExists(locator));
                return true;
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine("Error when trying to find element by locator" + locator + "\n" + e);
                return false;
            }
        }

        public string GetElementLabelText(IWebElement element, double waitTime = defaultWait)
        {
            try
            {
                string elementLabelText = element.Text;
                return elementLabelText;
            }
            catch (WebDriverException)
            {
                return null;
            }
        }
    }


}
