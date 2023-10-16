Feature: Login

@RegisterLogin
Scenario: Register random and login
	Given Setup browser <Browser>
	Then Navigate to register section
	And Register User
	When Login user after registration
	And Verify user login
	Then Quit Browser

	Examples:
	| Browser |
	| chrome  |
