# WPF ToolWindow Test

Test DPI change of ToolWindow. On Windows 11 23H2, a Window set to be ToolWindow will not receive WM_DPICHANGED message and DpiChanged event will not be fired when the monitor DPI changes but when it is moved after the change.
