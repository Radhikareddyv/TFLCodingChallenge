using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TFLCodingChallenge.Utilities;

namespace TFLCodingChallenge.PageObjects
{
    public class JourneyResultsPage : BaseClass
    {
        private IWebDriver driver;
        private ScenarioContext scenarioContext;

        public JourneyResultsPage(IWebDriver driver,ScenarioContext context) : base(driver)
        {
            this.driver = driver;
            this.scenarioContext = context;
        }

        private By _journeyResults = By.XPath("//div[@class='summary-results publictransport not-cycle-hire']");
        private  By _options_Departure(string departure) =>  By.XPath($"//span[contains(text(),'{departure}')]");
        private  By _options_Arrival(string arrival) => By.XPath($"//span[contains(text(),'{arrival}')]");
        private readonly By _editJourneyButton = By.CssSelector(".edit-journey");
        private readonly By _clearLocation = By.XPath("//a[text()='Clear From location']");
        private readonly By _departureStation = By.XPath("//input[@id='InputFrom']");
        private readonly By _updateJourneyButton = By.Id("plan-journey-button");

        private By _noResultsfound = By.CssSelector(".field-validation-errors");
        private readonly By _updatedFromLocation = By.XPath("//span[@class='notranslate']");
        public void VerifyResults()
        {
            Assert.IsTrue(IsElementExist(_journeyResults, 50000));
            var elementText = ReturnMultipleElements(_updatedFromLocation).First().Text;

            var text = scenarioContext.Get<string>("departurePoint");

         
        }

        public void GetAllJourneyResults_departure(string departure)
        {
            WaitForAllElementsBy(_options_Departure(departure));
            Thread.Sleep(10000);
            ReturnMultipleElements(_options_Departure(departure)).First().Click();
           
        }
        public void GetAllJourneyResults_arrival(string arrival)
        {
            ReturnMultipleElements(_options_Departure(arrival)).First().Click();

        }

        public void NoSearchResults()
        {
            Assert.IsTrue(IsElementExist(_noResultsfound, 5000));
            string errorMessage = GetElement(_noResultsfound).Text;
            string actualText = "Sorry, we can't find a journey matching your criteria";
            Assert.AreEqual(errorMessage,actualText);
        }

        public void ClickEditJourneyButton()
        {
            ClickElementJS(_editJourneyButton);
        }

        public void FromLocation(string departure)
        {
            ClickElement(GetElement(_clearLocation));
            GetElement(_departureStation).SendKeys(departure);
            //ScenarioContext.Current[departure] = "departure";
        }

        public void ClickUpdateJourney()
        {
            ClickElement(GetElement(_updateJourneyButton));
        }

        public void VerifyUpdatedJourney(string updatedLocation)
        {
            var elementText=ReturnMultipleElements(_updatedFromLocation).First().Text;
            Assert.AreEqual(updatedLocation, elementText);
        }
    }
    }


