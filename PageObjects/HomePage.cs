using OpenQA.Selenium;
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

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        private readonly By _departureStation = By.Id("InputFrom");
        private readonly By _arrivalStation = By.Id("InputTo");
        private readonly By _planMyJourney = By.Id("plan-journey-button");
        private readonly By _options_dropdownLocations_Departure = By.Id("stop-points-search-suggestion");
        public void JourneyPlanner(string departure,string arrival)
        {
            GetElement(_departureStation).SendKeys(departure);
            //ScenarioContext.Current["departure"] = departure;
            //string deptInput =options_dropdownLocations_Departure()[1].Text.ToString();
            //IList<IWebElement> options_dropdownLocations_Departure = WaitForAllElementsBy(_options_dropdownLocations_Departure);
            GetElement(_departureStation).SendKeys(Keys.Enter);
            GetElement(_arrivalStation).SendKeys(arrival);
        }


        public void ClickPlanMyJourney()
        {
            ClickElement(WaitForAndGetElement(_planMyJourney));
        }

        public void AddFromLocation(string departure)
        {
           
            GetElement(_departureStation).SendKeys(departure);
            //Thread.Sleep(10000);
           // GetDropDownOptionElements(_options_dropdownLocations_Departure).First().Click();
            GetElement(_departureStation).SendKeys(Keys.Enter);
        }

        public void AddToLocation(string arrival)
        {
            GetElement(_arrivalStation).SendKeys(arrival);
           // GetDropDownOptionElements(_options_dropdownLocations_Departure).First().Click();
        }
    }
}
