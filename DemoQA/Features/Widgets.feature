Feature: Widgets

@AutoComplete
Scenario: Verify autocomplete
	Given Setup browser <Browser>
	Then Launch DemoQA webpage
	And Navigate to autocomplete section
	And Enter wildcard search text and select value
	And Quit Browser

	Examples:
	| Browser |
	| chrome  |

@DatePicker
Scenario: Verify DatePicker
	Given Setup browser <Browser>
	Then Launch DemoQA webpage
	And Navigate to datepicker section
	And Select Year "2023"
	And Select Momth and Date "October" and "20"
	And Verify Selected date "10/20/2023"
	And Quit Browser

	Examples:
	| Browser |
	| chrome  |

@DatePicker
Scenario: Verify DateAndTimePicker
	Given Setup browser <Browser>
	Then Launch DemoQA webpage
	And Navigate to datepicker section
	And Select Year "2023" month "October" date "20" and time "00:00" 
	And Verify Selected value in date and time picker "October 16, 2023 12:00 AM"
	And Quit Browser

	Examples:
	| Browser |
	| chrome  |


@DatePicker
Scenario: Verify tooltip
	Given Setup browser <Browser>
	Then Launch DemoQA webpage
	And Navigate to tooltip section
	And Hover over the button and Read the tool tip
	And Quit Browser

	Examples:
	| Browser |
	| chrome  |