# RichTextBoxExtensions
## Extensions for the default C#-WinForm-RichTextBox-Control

This project extends the default functionality of the C# RichTextBox-Control.
Currently, this project only adds the possibility to use more numbering styles. To my knowledge, there is no way to use anything else other than 
bullet-numbering although the functionality has been implemented in the original RichEditControl. 
My code enables you to use the other numbering styles by extending the RichTextBox-Class by two more methods.

## How to use
1. Compile the project and move the resulting RichTextBoxExtensions.dll to a place where you can find it easily. Alternatively add the project to your own project.
2. Then add a reference to it in your own project.

## RichTextBox
![Screeenshot of RichTextBox-Options](https://github.com/tringelberg/RichTextBoxExtensions/blob/master/Images/demo.png?raw=true)

### Enable/Disable numbering listing
Add  the 'using RichTextBoxExtensions'-directive to your code. After doing this, the RichTextBox-Control now has two more methods:
- EnableListing(option, style, intend)
- DisableListing()

See source code for full description.


### Todo
Fix the method that returns information aboout the currently selected listing. Currently it doesn't work very well. \
For some unknown reason, after a EM_GETPARAFORMAT-Message has been sent to the control, the dwMask always contains a very huge number. \
I have yet to figure out why this is the case.
 
