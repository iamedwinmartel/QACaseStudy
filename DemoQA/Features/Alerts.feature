Feature: Alerts

@Alerts
Scenario: Verify alert operations
	Given Setup browser <Browser>
	Then Launch DemoQA webpage
	And Navigate to alerts section
	And Click button for alert and click ok
	And Click button for 5 second delay alert and click ok
	And Click button for alert click ok and verify status
	And Click button for alert click cancel and verify status
	And Click button for alert and enter name in prompted alert
	And Quit Browser

	Examples:
	| Browser |
	| chrome  |