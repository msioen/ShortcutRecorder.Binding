[![NuGet Status](http://img.shields.io/nuget/v/ShortcutRecorder.Binding.svg?style=flat)](https://www.nuget.org/packages/ShortcutRecorder.Binding/)

# ShortcutRecorder.Binding

Xamarin binding for the [ShortcutRecorder library](https://github.com/Kentzo/ShortcutRecorder)

# ShortcutRecorder

Mac user interface control to record shortcuts.

## Usage

In your layout add Custom View and set its class to SRRecorderControl. Alternatively add SRRecorderControl instance to your layout by code.

```c#
// bind SRRecorderControl value to key in userdefaults
var defaults = NSUserDefaultsController.SharedUserDefaultsController;
pingShortcutRecorder.Bind(Constants.NSValueBinding, defaults, "values.ping", null);

// set allowed flags on a SRRecorderControl instance
pingShortcutRecorder.SetAllowedModifierFlags(
    newAllowedModifierFlags: NSEventModifierMask.ShiftKeyMask | NSEventModifierMask.AlternateKeyMask | NSEventModifierMask.CommandKeyMask,
    newRequiredModifierFlags: (NSEventModifierMask)0,
    newAllowsEmptyModifierFlags: true);
```