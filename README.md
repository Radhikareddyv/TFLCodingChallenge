# TFLCodingChallenge

 The goal is to test https://tfl.gov.uk/ using the template provided on https://github.com/Radhikareddyv/TFLCodingChallenge

# Following tools are used:
1. SpecFlow
2. Specflow.NUnit
3. Selenium (WebDriver)
4. NUnit 3.13.3
5. Utilises Page Object Model pattern

# The tasks are:
1. Verify that a valid journey can be planned using the widget. (A valid journey will
consist of valid locations entered into the widget).

3. Verify that the widget is unable to provide results when an invalid journey is
planned. (An invalid journey will consist of 1 or more invalid locations entered into
the widget).

5. Verify that the widget is unable to plan a journey if no locations are entered into the
widget.

7. Verify change time link on the journey planner displays “Arriving” option and plan a
journey based on arrival time.

9. On the Journey results page, verify that a journey can be amended by using the “Edit
Journey” button.

# Running the Tests
Open the Test Explorer in Visual Studio (View -> Test Explorer).
Run all tests or select specific tests to run.

# Project Structure
Features: Contains Gherkin syntax files defining the scenarios.

StepDefinitions: Holds the C# code that maps Gherkin steps to actions.

PageObjects: Defines page objects that represent web pages, providing a clear separation of concerns.

Utilities: Contains Hooks classes and utility functions.

# Writing Tests
Add new Gherkin scenarios in the Features directory.

Implement step definitions in the StepDefinitions directory.

Leverage page objects from the PageObjects directory for better maintainability.

# Configuration
Modify configuration.json for environment-specific settings.
