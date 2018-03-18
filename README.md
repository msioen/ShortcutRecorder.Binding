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

Includes framework to set global shortcuts (PTHotKey).

```c#
// bind item hotkey to key in userdefaults
public static void BindHotKey(this NSObject target, NSObject observable, string keyPath)
{
	var keyOptions = new NSMutableDictionary();
	keyOptions.SetValueForKey(new SRKeyEquivalentTransformer(), Constants.NSValueTransformerBindingOption);
	target.Bind("keyEquivalent", observable, keyPath, keyOptions);

	var keyModifierOptions = new NSMutableDictionary();
	keyModifierOptions.SetValueForKey(new SRKeyEquivalentModifierMaskTransformer(), Constants.NSValueTransformerBindingOption);
	target.Bind("keyEquivalentModifierMask", observable, keyPath, keyModifierOptions);
}


public override void AwakeFromNib()
{
	base.AwakeFromNib();
	pingItem.BindHotKey(NSUserDefaultsController.SharedUserDefaultsController, "values.ping");
}
```