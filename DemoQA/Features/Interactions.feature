Feature: Interactions

Scenario: Verify sortable and droppable actions
	Given Setup browser <Browser>
	Then Launch DemoQA webpage
	And Navigate to sortable section
	And Sort the blocks in descending order
	And Navigate to Droppable section
	And drag and drop a block
	And Quit Browser

	Examples:
	| Browser |
	| chrome  |
