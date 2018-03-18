using System.Runtime.InteropServices;
using AppKit;
using Foundation;

namespace ShortcutRecorder
{
    public static partial class CFunctions
    {
        // extern NSBundle * SRBundle ();
        [DllImport ("__Internal")]
        public static extern NSBundle SRBundle ();

        // extern NSString * SRLoc (NSString *aKey);
        [DllImport ("__Internal")]
        public static extern NSString SRLoc (NSString aKey);

        // extern NSImage * SRImage (NSString *anImageName);
        [DllImport ("__Internal")]
        public static extern NSImage SRImage (NSString anImageName);

        // extern NSString * SRReadableStringForCocoaModifierFlagsAndKeyCode (NSEventModifierFlags aModifierFlags, unsigned short aKeyCode);
        [DllImport ("__Internal")]
        public static extern NSString SRReadableStringForCocoaModifierFlagsAndKeyCode (NSEventModifierMask aModifierFlags, ushort aKeyCode);

        // extern NSString * SRReadableASCIIStringForCocoaModifierFlagsAndKeyCode (NSEventModifierFlags aModifierFlags, unsigned short aKeyCode);
        [DllImport ("__Internal")]
        public static extern NSString SRReadableASCIIStringForCocoaModifierFlagsAndKeyCode (NSEventModifierMask aModifierFlags, ushort aKeyCode);

        // extern BOOL SRKeyCodeWithFlagsEqualToKeyEquivalentWithFlags (unsigned short aKeyCode, NSEventModifierFlags aKeyCodeFlags, NSString *aKeyEquivalent, NSEventModifierFlags aKeyEquivalentModifierFlags);
        [DllImport ("__Internal")]
        public static extern bool SRKeyCodeWithFlagsEqualToKeyEquivalentWithFlags (ushort aKeyCode, NSEventModifierMask aKeyCodeFlags, NSString aKeyEquivalent, NSEventModifierMask aKeyEquivalentModifierFlags);
    }

	public enum SRKeyCodeGlyph
	{
		TabRight = 8677,
		TabLeft = 8676,
		Return = 8965,
		ReturnR2L = 8617,
		DeleteLeft = 9003,
		DeleteRight = 8998,
		PadClear = 8999,
		LeftArrow = 8592,
		RightArrow = 8594,
		UpArrow = 8593,
		DownArrow = 8595,
		PageDown = 8671,
		PageUp = 8670,
		NorthwestArrow = 8598,
		SoutheastArrow = 8600,
		Escape = 9099,
		Space = 32
	}
}
