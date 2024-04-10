using System;
using Foundation;

namespace ShortcutRecorder.Binding.Test
{
    public static class Extensions
    {
        public static void BindHotKey(this NSObject target, NSObject observable, string keyPath)
        {
            var keyOptions = new NSMutableDictionary();
            keyOptions.SetValueForKey(new SRKeyEquivalentTransformer(), Constants.NSValueTransformerBindingOption);
            target.Bind(new NSString("keyEquivalent"), observable, keyPath, keyOptions);

            var keyModifierOptions = new NSMutableDictionary();
            keyModifierOptions.SetValueForKey(new SRKeyEquivalentModifierMaskTransformer(), Constants.NSValueTransformerBindingOption);
            target.Bind(new NSString("keyEquivalentModifierMask"), observable, keyPath, keyModifierOptions);
        }
    }
}
