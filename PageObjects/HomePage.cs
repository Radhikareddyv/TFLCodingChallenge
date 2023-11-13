using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.Debugger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TFLCodingChallenge.Utilities;

namespace TFLCodingChallenge.PageObjects
{
    public class HomePage :BaseClass
    {
        private IWebDriver driver;
        private ScenarioContext scenarioContext;

        public HomePage(IWebDriver driver,ScenarioContext context) : base(driver)
        {
            this.driver = driver;
            this.scenarioContext = context;
        }

        private readonly By _departureStation = By.Id("InputFrom");
        private readonly By _arrivalStation = By.Id("InputTo");
        private readonly By _planMyJourney = By.Id("plan-journey-button");
        private readonly By _options_DropdownLocations_Departure = By.XPath("//span[contains(@id,'stop-points-search-suggestion')]");
        private readonly By _options_dropdownLocations_arrival = By.XPath("//span[contains(@id,'stop-points-search-suggestion')]");
        private readonly By _departureInputErrorMessage = By.XPath("//span[@id='InputFrom-error']");
        private readonly By _arrivalInputErrorMessage = By.XPath("//span[@id='InputTo-error']");
        private readonly By _ChangeTime = By.XPath("//a[@class='change-departure-time']");
        private readonly By _arrivingOption = By.XPath("//label[text()='Arriving']");
        private readonly By _options_dropdownLocations_Time = By.XPath("//select[@id='Time']//option");

        public void ClickPlanMyJourney()
        {
            ClickElementJS((_planMyJourney));
        }

        public void AddFromLocation(string departure)
        {
            var departurePoint = string.Empty;
            GetElement(_departureStation).SendKeys(departure);
            IList<IWebElement> options_dropdownLocations_Departure = WaitForAllElementsBy(_options_DropdownLocations_Departure);
            var numofsuggestions = options_dropdownLocations_Departure.Count;
            if (numofsuggestions > 0)
            {
                departurePoint = options_dropdownLocations_Departure.First().Text;
                options_dropdownLocations_Departure.First().Click();

            }

            scenarioContext.Add("departurePoint", departurePoint);
            GetElement(_departureStation).SendKeys(Keys.Enter);
        }

        public void AddToLocation(string arrival)
        {
            var arrivalPoint = "";
            GetElement(_arrivalStation).SendKeys(arrival);
            IList<IWebElement> options_dropdownLocations_arrival = WaitForAllElementsBy(_options_dropdownLocations_arrival);
            var numofsuggestions = options_dropdownLocations_arrival.Count;
            if (numofsuggestions > 0)
            {
                arrivalPoint = options_dropdownLocations_arrival.First().Text;
                options_dropdownLocations_arrival.First().Click();
            }

            scenarioContext.Add("arrivalPoint", arrivalPoint);
        }

        public void VerifyTheErrorMessage()
        {
            string actualErrorText;
            string errorMessage;

            errorMessage = GetElement(_departureInputErrorMessage).Text;
            actualErrorText = "The From field is required.";
            Assert.IsTrue(errorMessage.Contains(actualErrorText));

            errorMessage = GetElement(_arrivalInputErrorMessage).Text;
            actualErrorText = "The To field is required.";
            Assert.IsTrue(errorMessage.Contains(actualErrorText));
        }

        public void ClickChangeTime()
        {
            ClickElement(GetElement(_ChangeTime));
        }

        public void VerifyArrivalOption()
        {
            Assert.IsTrue(GetElement(_arrivingOption).Displayed);
            ClickElement(GetElement(_arrivingOption));
        }

        public void EditArrivingTime()
        {
            IList<IWebElement> options_dropdownLocations_Time = WaitForAllElementsBy(_options_dropdownLocations_Time);
            var updatedTime = options_dropdownLocations_Time[3].Text;
            scenarioContext.Add("updatedTime", updatedTime);
            options_dropdownLocations_Time[3].Click();
        }
    }
}
