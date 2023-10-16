Feature: CheckBox

@CheckBox
Scenario: Select and unselect all checkboxes and verify status
	Given Setup browser <Browser>
	Then Launch DemoQA webpage
	And Navigate to checkbox section	
	And Expand all checkboxes
	And Select check box "Notes"
	And Select check box "React"
	And Print which items are half checked
	And Print which items remain unchecked
	And Unselect already selected items
	And Quit Browser

	Examples:
	| Browser |
	| chrome  |