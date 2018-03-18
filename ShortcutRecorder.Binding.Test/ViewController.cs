using System;

using AppKit;
using Foundation;

namespace ShortcutRecorder.Binding.Test
{
    public partial class ViewController : NSViewController, ISRValidatorDelegate
    {
        SRValidator _validator;
        MySRRecorderControlDelegate _controlDelegate;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            _validator = new SRValidator(this);
            _controlDelegate = new MySRRecorderControlDelegate(_validator, x => PresentError(x));

            pingShortcutRecorder.Delegate = _controlDelegate;
            globalPingShortcutRecorder.Delegate = _controlDelegate;
            pingItemShortcutRecorder.Delegate = _controlDelegate;

            var defaults = NSUserDefaultsController.SharedUserDefaultsController;

            pingShortcutRecorder.Bind(Constants.NSValueBinding, defaults, "values.ping", null);
            pingShortcutRecorder.Bind(Constants.NSEnabledBinding, defaults, "values.isPingItemEnabled", null);

            pingShortcutRecorder.SetAllowedModifierFlags(
                newAllowedModifierFlags: NSEventModifierMask.ShiftKeyMask | NSEventModifierMask.AlternateKeyMask | NSEventModifierMask.CommandKeyMask,
                newRequiredModifierFlags: (NSEventModifierMask)0,
                newAllowsEmptyModifierFlags: true);

            globalPingShortcutRecorder.Bind(Constants.NSValueBinding, defaults, "values.globalPing", null);
            pingItemShortcutRecorder.Bind(Constants.NSValueBinding, defaults, "values.pingItem", null);
        }

        #region ISRValidatorDelegate

        public bool ShortcutValidator(SRValidator aValidator, ushort aKeyCode, NSEventModifierMask aFlags, out string outReason)
        {
            outReason = string.Empty;

            var recorder = View.Window.FirstResponder as SRRecorderControl;
            if (recorder == null)
                return false;

            var shortcut = CFunctions.SRShortcutWithCocoaModifierFlagsAndKeyCode(aFlags, aKeyCode);
            if (IsTaken(pingShortcutRecorder, shortcut) ||
                IsTaken(globalPingShortcutRecorder, shortcut) ||
                IsTaken(pingItemShortcutRecorder, shortcut))
            {
                outReason = "it's already used. To use this shortcut, first remove or change the other shortcut";
                return true;
            }
            else
            {
                return false;
            }
        }

        bool IsTaken(SRRecorderControl recorder, NSDictionary shortcut)
        {
            return CFunctions.SRShortcutEqualToShortcut(shortcut, recorder.ObjectValue);
        }

        public bool ShortcutValidatorShouldCheckMenu(SRValidator aValidator)
        {
            return true;
        }

        public bool ShortcutValidatorShouldCheckSystemShortcuts(SRValidator aValidator)
        {
            return false;
        }

        public bool ShortcutValidatorShouldUseASCIIStringForKeyCodes(SRValidator aValidator)
        {
            return false;
        }

        #endregion
    }

    public class MySRRecorderControlDelegate : SRRecorderControlDelegate
    {
        SRValidator _validator;
        Action<NSError> _onError;

        public MySRRecorderControlDelegate(SRValidator validator, Action<NSError> onError)
        {
            _validator = validator;
            _onError = onError;
        }

        public override bool ShortcutRecorderCanRecordShortcut(SRRecorderControl aRecorder, NSDictionary aShortcut)
        {
            NSError error;
            var isTaken = _validator.IsKeyCode(
                ((NSNumber)aShortcut[Constants.SRShortcutKeyCode]).UInt16Value,
                (NSEventModifierMask)((NSNumber)aShortcut[Constants.SRShortcutModifierFlagsKey]).UInt64Value,
                out error);

            if (isTaken)
            {
                AppKitFramework.NSBeep();
                _onError?.Invoke(error);
            }
            return !isTaken;
        }

        public override bool ShortcutRecorderShouldBeginRecording(SRRecorderControl aRecorder)
        {
            return true;
        }

        public override void ShortcutRecorderDidEndRecording(SRRecorderControl aRecorder)
        {
        }

        public override bool ShortcutRecorderShouldUnconditionallyAllowModifierFlags(SRRecorderControl aRecorder, NSEventModifierMask aModifierFlags, ushort aKeyCode)
        {
            // Keep required flags required.
            if ((aModifierFlags & aRecorder.RequiredModifierFlags) != aRecorder.RequiredModifierFlags)
                return false;

            // Don't allow disallowed flags.
            if ((aModifierFlags & aRecorder.AllowedModifierFlags) != aModifierFlags)
                return false;

            switch (aKeyCode)
            {
                case (ushort)EKeyCode.kVK_F1:
                case (ushort)EKeyCode.kVK_F2:
                case (ushort)EKeyCode.kVK_F3:
                case (ushort)EKeyCode.kVK_F4:
                case (ushort)EKeyCode.kVK_F5:
                case (ushort)EKeyCode.kVK_F6:
                case (ushort)EKeyCode.kVK_F7:
                case (ushort)EKeyCode.kVK_F8:
                case (ushort)EKeyCode.kVK_F9:
                case (ushort)EKeyCode.kVK_F10:
                case (ushort)EKeyCode.kVK_F11:
                case (ushort)EKeyCode.kVK_F12:
                case (ushort)EKeyCode.kVK_F13:
                case (ushort)EKeyCode.kVK_F14:
                case (ushort)EKeyCode.kVK_F15:
                case (ushort)EKeyCode.kVK_F16:
                case (ushort)EKeyCode.kVK_F17:
                case (ushort)EKeyCode.kVK_F18:
                case (ushort)EKeyCode.kVK_F19:
                case (ushort)EKeyCode.kVK_F20:
                    return true;
                default:
                    return false;
            }
        }
    }
}
