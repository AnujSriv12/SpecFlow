Feature: SampleFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@SmokeTest
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

Scenario: Create a new employee with mandatory details
	#Given I have opened up my application
	#Then I should see the Employee details page
	When I fill the mandatory details in form
	| Name    | Age | Phone       | Email         |
	| Anuj | 28  | 9102128912 | test@test.com |
	| Sam | 30  | 9102128913 | test@test1.com |
	| John | 29  | 9102128914 | test@test2.com |
	#And I click the save button
	#Then I should see all the details saved in my application and DB

Scenario Outline: Create a new employee with mandatory details(Outline)
	#Given I have opened up my application
	#Then I should see the Employee details page
	When I fill the mandatory details in form <Name>, <Age> and <Phone>
	#And I click the save button
	#Then I should see all the details saved in my application and DB
Examples: 	
	| Name | Age | Phone      |
	| Anuj | 28  | 9102128912 |
	| Sam  | 30  | 9102128913 |
	| John | 29  | 9102128914 |