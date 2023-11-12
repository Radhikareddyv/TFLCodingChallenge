using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFLCodingChallenge.Utilities;

namespace TFLCodingChallenge.PageObjects
{
    public class JourneyResultsPage : BaseClass
    {
        private IWebDriver driver;

        public JourneyResultsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private By _journyResults = By.XPath("//div[@class='summary-results publictransport not-cycle-hire']");
        private readonly By _options_Departure = By.XPath("//span[@class='place-name']");
        public void VerifyResults()
        {
            Assert.IsTrue(IsElementExist(_journyResults, 50000));
        }

        public void GetAllJourneyResults()
        {
            ReturnMultipleElements(_options_Departure).First().Click();
        }
    }
}
