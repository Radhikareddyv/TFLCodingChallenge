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
	When I click first journey from the journey results
	Then verify the journey results for the valid locations

	 Examples::
	| FromLocation	   | ToLocation	 |
	| Waterloo         | Paddington      |
	
Scenario: Verify Journey Planner Widget with Invalid locations
	When I enter the journey criteria from 'xxx' to 'yyy'
	And I click plan my journey
	