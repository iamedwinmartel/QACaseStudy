Feature: TextBox

@TextBox
Scenario: Enter values in text box and verify after submission
	Given Setup browser <Browser>
	Then Launch DemoQA webpage
	And Navigate to textbox section
	Then Enter Fullname <FullName>
	And Enter Email <Email>
	And Enter Current Address <Current Address>
	And Enter Permanent Address <Permanent Address>
	And Click Submit button
	Then Verify Fullname after submission <FullName>
	Then Verify Email after submission <Email>
	Then Verify Current Address after submission <Current Address>
	Then Verify Permanent Address after submission <Permanent Address>
	And Quit Browser

	Examples:
	| Browser | FullName     | Email         | Current Address            | Permanent Address            |
	| chrome  | Edwin Martel | test@test.com | 123, Current Street, India | 111, Permanent Street, India |