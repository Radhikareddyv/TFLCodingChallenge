Feature: JourneyPlanner
Useful for users to find out all next trains from a given Destination
As Traveller
I can see next departures from my chosen departure point 
So that I can find the route I need to start my journey

Background: 
	Given I navigated to TFL website

Scenario Outline: Verify Journey Planner Widget with valid locations
	When I enter a valid departure location <FromLocation>
	And I enter a valid arrival location <ToLocation>
	And I click plan my journey
	Then verify the journey results for the valid locations
	Examples::
	| FromLocation	   | ToLocation	 |
	| Waterloo         | Paddington  |
	
Scenario Outline: Verify Journey Planner Widget with Invalid locations
	When I enter a valid departure location <FromLocation>
	And I enter a valid arrival location <ToLocation>
	And I click plan my journey
	Then No Search results message displayed
	Examples:	
	| FromLocation | ToLocation |
	| 123          | 123        |

Scenario: Verify Journey Planner Widget with empty locations
	When I click plan my journey
	Then Journey results are not displayed

Scenario Outline:Verify Edit Journey on the Journey results page
 	When I enter a valid departure location <FromLocation>
	And I enter a valid arrival location <ToLocation>
	And I click plan my journey
	And I click Edit Journey button
	When I edit departure location to <UpdatedLocation> 
	And I click Update Journey button
	Then I verify the <UpdatedLocation>  is updated
	Examples::
	| FromLocation | ToLocation | UpdatedLocation               |
	| Waterloo     | Paddington | Bayswater Underground Station |

Scenario Outline: Verify ChangeTime link on the journey Planner page
	When I enter a valid departure location <FromLocation>
	And I enter a valid arrival location <ToLocation>
	When I click change time link
	Then  Arriving option is disaplayed
	And I edit the Arriving time
	When I click plan my journey
	Then verify the journey results for the valid locations
	Then Verify Arriving time on Journey results page
	Examples::
	| FromLocation	   | ToLocation	 |
	| Waterloo         | Paddington  |