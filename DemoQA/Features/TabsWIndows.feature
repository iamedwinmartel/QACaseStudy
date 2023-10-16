Feature: TabsWIndows

@TabsWindows
Scenario: Perform operations on available tabs and windows and verify the status
	Given Setup browser <Browser>
	Then Launch DemoQA webpage
	And Navigate to browser windows section
	And click on new tab and switch
	And click on new window and switch
	And click on new window and print message
	And Quit Browser

	Examples:
	| Browser |
	| chrome  |

	@TabsWindows
Scenario: Open new window with message and switch
	Given Setup browser <Browser>
	Then Launch DemoQA webpage
	And Navigate to browser windows section
	And click on new window and print message
	And Quit Browser

	Examples:
	| Browser |
	| chrome  |