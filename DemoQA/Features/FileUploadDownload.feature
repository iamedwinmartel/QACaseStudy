Feature: FileUploadDownload

@FileUploadDownload
Scenario: Upload and download file and verify the status
	Given Setup browser <Browser>
	Then Launch DemoQA webpage
	And Navigate to File Upload section
	And Upload the file and verify status
	And Download file and verify status
	And Quit Browser

	Examples:
	| Browser |
	| chrome  |

