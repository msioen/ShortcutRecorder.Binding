using System;
using Foundation;
using ObjCRuntime;
using PTHotKey;

namespace PTHotKey
{
	// @interface PTKeyCombo : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface PTKeyCombo : INSCopying
	{
		// +(id)clearKeyCombo;
		[Static]
		[Export ("clearKeyCombo")]
		NSObject ClearKeyCombo { get; }

		// +(id)keyComboWithKeyCode:(NSInteger)keyCode modifiers:(NSUInteger)modifiers;
		[Static]
		[Export ("keyComboWithKeyCode:modifiers:")]
		NSObject KeyComboWithKeyCode (nint keyCode, nuint modifiers);

		// -(id)initWithKeyCode:(NSInteger)keyCode modifiers:(NSUInteger)modifiers;
		[Export ("initWithKeyCode:modifiers:")]
		IntPtr Constructor (nint keyCode, nuint modifiers);

		// -(id)initWithPlistRepresentation:(id)plist;
		[Export ("initWithPlistRepresentation:")]
		IntPtr Constructor (NSObject plist);

		// -(id)plistRepresentation;
		[Export ("plistRepresentation")]
		NSObject PlistRepresentation { get; }

		// -(BOOL)isEqual:(PTKeyCombo *)combo;
		[Export ("isEqual:")]
		bool IsEqual (PTKeyCombo combo);

		// -(NSInteger)keyCode;
		[Export ("keyCode")]
		nint KeyCode { get; }

		// -(NSUInteger)modifiers;
		[Export ("modifiers")]
		nuint Modifiers { get; }

		// -(BOOL)isClearCombo;
		[Export ("isClearCombo")]
		bool IsClearCombo { get; }

		// -(BOOL)isValidHotKeyCombo;
		[Export ("isValidHotKeyCombo")]
		bool IsValidHotKeyCombo { get; }
	}

	// @interface PTHotKey : NSObject
	[BaseType (typeof(NSObject))]
	interface PTHotKey
	{
		// -(id)initWithIdentifier:(id)identifier keyCombo:(PTKeyCombo *)combo;
		[Export ("initWithIdentifier:keyCombo:")]
		IntPtr Constructor (NSObject identifier, PTKeyCombo combo);

		// -(id)initWithIdentifier:(id)identifier keyCombo:(PTKeyCombo *)combo withObject:(id)object;
		[Export ("initWithIdentifier:keyCombo:withObject:")]
		IntPtr Constructor (NSObject identifier, PTKeyCombo combo, NSObject @object);

		// -(id)identifier;
		// -(void)setIdentifier:(id)ident;
		[Export ("identifier")]
		NSObject Identifier { get; set; }

		// -(NSString *)name;
		// -(void)setName:(NSString *)name;
		[Export ("name")]
		string Name { get; set; }

		// -(PTKeyCombo *)keyCombo;
		// -(void)setKeyCombo:(PTKeyCombo *)combo;
		[Export ("keyCombo")]
		PTKeyCombo KeyCombo { get; set; }

		// -(id)target;
		// -(void)setTarget:(id)target;
		[Export ("target")]
		NSObject Target { get; set; }

		// -(id)object;
		// -(void)setObject:(id)object;
		[Export ("object")]
		NSObject Object { get; set; }

		// -(SEL)action;
		// -(void)setAction:(SEL)action;
		[Export ("action")]
		Selector Action { get; set; }

		// -(SEL)keyUpAction;
		// -(void)setKeyUpAction:(SEL)action;
		[Export ("keyUpAction")]
		Selector KeyUpAction { get; set; }

		// -(UInt32)carbonHotKeyID;
		// -(void)setCarbonHotKeyID:(UInt32)hotKeyID;
		[Export ("carbonHotKeyID")]
		uint CarbonHotKeyID { get; set; }

		// -(void)invoke;
		[Export ("invoke")]
		void Invoke ();

		// -(void)uninvoke;
		[Export ("uninvoke")]
		void Uninvoke ();

        // +(PTHotKey *)hotKeyWithIdentifier:(id)anIdentifier keyCombo:(NSDictionary *)aKeyCombo target:(id)aTarget action:(SEL)anAction;
        [Static]
        [Export("hotKeyWithIdentifier:keyCombo:target:action:")]
        PTHotKey HotKeyWithIdentifier(NSObject anIdentifier, NSDictionary aKeyCombo, NSObject aTarget, Selector anAction);

        // +(PTHotKey *)hotKeyWithIdentifier:(id)anIdentifier keyCombo:(NSDictionary *)aKeyCombo target:(id)aTarget action:(SEL)anAction keyUpAction:(SEL)aKeyUpAction;
        [Static]
        [Export("hotKeyWithIdentifier:keyCombo:target:action:keyUpAction:")]
        PTHotKey HotKeyWithIdentifier(NSObject anIdentifier, NSDictionary aKeyCombo, NSObject aTarget, Selector anAction, Selector aKeyUpAction);

        // +(PTHotKey *)hotKeyWithIdentifier:(id)anIdentifier keyCombo:(NSDictionary *)aKeyCombo target:(id)aTarget action:(SEL)anAction withObject:(id)anObject;
        [Static]
        [Export("hotKeyWithIdentifier:keyCombo:target:action:withObject:")]
        PTHotKey HotKeyWithIdentifier(NSObject anIdentifier, NSDictionary aKeyCombo, NSObject aTarget, Selector anAction, NSObject anObject);
	}

    // @interface PTHotKeyCenter : NSObject
    [BaseType(typeof(NSObject))]
    interface PTHotKeyCenter
    {
        // +(PTHotKeyCenter *)sharedCenter;
        [Static]
        [Export("sharedCenter")]
        PTHotKeyCenter SharedCenter { get; }

        // -(BOOL)registerHotKey:(PTHotKey *)hotKey;
        [Export("registerHotKey:")]
        bool RegisterHotKey(PTHotKey hotKey);

        // -(void)unregisterHotKey:(PTHotKey *)hotKey;
        [Export("unregisterHotKey:")]
        void UnregisterHotKey(PTHotKey hotKey);

        // -(NSArray *)allHotKeys;
        //[Export("allHotKeys")]
        //NSObject[] AllHotKeys { get; }

        // -(PTHotKey *)hotKeyWithIdentifier:(id)ident;
        [Export("hotKeyWithIdentifier:")]
        PTHotKey HotKeyWithIdentifier(NSObject ident);

        // -(void)sendEvent:(NSEvent *)event;
        [Export("sendEvent:")]
        void SendEvent(AppKit.NSEvent @event);

        // -(void)pause;
        [Export("pause")]
        void Pause();

        // -(void)resume;
        [Export("resume")]
        void Resume();

        // -(BOOL)isPaused;
        [Export("isPaused")]
        bool IsPaused { get; }
    }
}
