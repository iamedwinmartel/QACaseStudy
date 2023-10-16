Feature: Webtable

@Webtable
Scenario: Select and unselect all checkboxes and verify status
	Given Setup browser <Browser>
	Then Launch DemoQA webpage
	And Navigate to webtable section
	And Read the values in row 3
	And Edit the values in row 3
	Then Verify if values were updated in row 3
	And Quit Browser

	Examples: 
	| Browser |
	| chrome  |
