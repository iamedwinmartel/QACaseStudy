Feature: Buttons

@Buttons
Scenario: Perform operations on available buttons and verify the status
	Given Setup browser <Browser>
	Then Launch DemoQA webpage
	And Navigate to buttons section
	And on page perform a double click on relevant button and verify status
	And perform a right click on relevant button and verify status
	And perform a click on relevant button and verify status
	And Quit Browser

	Examples:
	| Browser |
	| chrome  |
