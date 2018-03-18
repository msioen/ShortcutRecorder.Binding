using System;
using AppKit;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace ShortcutRecorder
{
    // @interface SRKeyCodeTransformer : NSValueTransformer
    [BaseType(typeof(NSValueTransformer))]
    interface SRKeyCodeTransformer
    {
        // -(instancetype)initWithASCIICapableKeyboardInputSource:(BOOL)aUsesASCII plainStrings:(BOOL)aUsesPlainStrings __attribute__((objc_designated_initializer));
        [Export("initWithASCIICapableKeyboardInputSource:plainStrings:")]
        [DesignatedInitializer]
        IntPtr Constructor(bool aUsesASCII, bool aUsesPlainStrings);

        // @property (readonly) BOOL usesASCIICapableKeyboardInputSource;
        [Export("usesASCIICapableKeyboardInputSource")]
        bool UsesASCIICapableKeyboardInputSource { get; }

        // @property (readonly) BOOL usesPlainStrings;
        [Export("usesPlainStrings")]
        bool UsesPlainStrings { get; }

        // +(instancetype)sharedTransformer;
        [Static]
        [Export("sharedTransformer")]
        SRKeyCodeTransformer SharedTransformer();

        // +(instancetype)sharedASCIITransformer;
        [Static]
        [Export("sharedASCIITransformer")]
        SRKeyCodeTransformer SharedASCIITransformer();

        // +(SRKeyCodeTransformer *)sharedPlainTransformer;
        [Static]
        [Export("sharedPlainTransformer")]
        SRKeyCodeTransformer SharedPlainTransformer { get; }

        // +(SRKeyCodeTransformer *)sharedPlainASCIITransformer;
        [Static]
        [Export("sharedPlainASCIITransformer")]
        SRKeyCodeTransformer SharedPlainASCIITransformer { get; }

        // +(NSDictionary *)specialKeyCodesToUnicodeCharactersMapping;
        [Static]
        [Export("specialKeyCodesToUnicodeCharactersMapping")]
        NSDictionary SpecialKeyCodesToUnicodeCharactersMapping { get; }

        // +(NSDictionary *)specialKeyCodesToPlainStringsMapping;
        [Static]
        [Export("specialKeyCodesToPlainStringsMapping")]
        NSDictionary SpecialKeyCodesToPlainStringsMapping { get; }

        // -(BOOL)isKeyCodeSpecial:(unsigned short)aKeyCode;
        [Export("isKeyCodeSpecial:")]
        bool IsKeyCodeSpecial(ushort aKeyCode);

        // -(NSString *)transformedSpecialKeyCode:(NSNumber *)aKeyCode withExplicitModifierFlags:(NSNumber *)aModifierFlags;
        [Export("transformedSpecialKeyCode:withExplicitModifierFlags:")]
        string TransformedSpecialKeyCode(NSNumber aKeyCode, NSNumber aModifierFlags);

        // -(NSString *)transformedValue:(NSNumber *)aValue withModifierFlags:(NSNumber *)aModifierFlags;
        [Export("transformedValue:withModifierFlags:")]
        string TransformedValue(NSNumber aValue, NSNumber aModifierFlags);

        // -(NSString *)transformedValue:(NSNumber *)aValue withImplicitModifierFlags:(NSNumber *)anImplicitModifierFlags explicitModifierFlags:(NSNumber *)anExplicitModifierFlags;
        [Export("transformedValue:withImplicitModifierFlags:explicitModifierFlags:")]
        string TransformedValue(NSNumber aValue, NSNumber anImplicitModifierFlags, NSNumber anExplicitModifierFlags);
    }

    // @interface SRModifierFlagsTransformer : NSValueTransformer
    [BaseType(typeof(NSValueTransformer))]
    interface SRModifierFlagsTransformer
    {
        // -(instancetype)initWithPlainStrings:(BOOL)aUsesPlainStrings __attribute__((objc_designated_initializer));
        [Export("initWithPlainStrings:")]
        [DesignatedInitializer]
        IntPtr Constructor(bool aUsesPlainStrings);

        // @property (readonly) BOOL usesPlainStrings;
        [Export("usesPlainStrings")]
        bool UsesPlainStrings { get; }

        // +(instancetype)sharedTransformer;
        [Static]
        [Export("sharedTransformer")]
        SRModifierFlagsTransformer SharedTransformer();

        // +(instancetype)sharedPlainTransformer;
        [Static]
        [Export("sharedPlainTransformer")]
        SRModifierFlagsTransformer SharedPlainTransformer();
    }

    // @interface SRKeyEquivalentTransformer : NSValueTransformer
    [BaseType(typeof(NSValueTransformer))]
    interface SRKeyEquivalentTransformer
    {
    }

    // @interface SRKeyEquivalentModifierMaskTransformer : NSValueTransformer
    [BaseType(typeof(NSValueTransformer))]
    interface SRKeyEquivalentModifierMaskTransformer
    {
    }

    // @interface SRValidator : NSObject
    [BaseType(typeof(NSObject))]
    public interface SRValidator
    {
        [Wrap("WeakDelegate")]
        SRValidatorDelegate Delegate { get; set; }

        // @property (assign) NSObject<SRValidatorDelegate> * delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // -(instancetype)initWithDelegate:(NSObject<SRValidatorDelegate> *)aDelegate __attribute__((objc_designated_initializer));
        [Export("initWithDelegate:")]
        [DesignatedInitializer]
        IntPtr Constructor(ISRValidatorDelegate aDelegate);

        // -(BOOL)isKeyCode:(unsigned short)aKeyCode andFlagsTaken:(NSEventModifierFlags)aFlags error:(NSError **)outError;
        [Export("isKeyCode:andFlagsTaken:error:")]
        bool IsKeyCode(ushort aKeyCode, NSEventModifierMask aFlags, out NSError outError);

        // -(BOOL)isKeyCode:(unsigned short)aKeyCode andFlagTakenInDelegate:(NSEventModifierFlags)aFlags error:(NSError **)outError;
        [Export("isKeyCode:andFlagTakenInDelegate:error:")]
        bool IsKeyCodeUsedByDelegate(ushort aKeyCode, NSEventModifierMask aFlags, out NSError outError);

        // -(BOOL)isKeyCode:(unsigned short)aKeyCode andFlagsTakenInSystemShortcuts:(NSEventModifierFlags)aFlags error:(NSError **)outError;
        [Export("isKeyCode:andFlagsTakenInSystemShortcuts:error:")]
        bool IsKeyCodeUsedBySystem(ushort aKeyCode, NSEventModifierMask aFlags, out NSError outError);

        // -(BOOL)isKeyCode:(unsigned short)aKeyCode andFlags:(NSEventModifierFlags)aFlags takenInMenu:(NSMenu *)aMenu error:(NSError **)outError;
        [Export("isKeyCode:andFlags:takenInMenu:error:")]
        bool IsKeyCodeUsedByMenu(ushort aKeyCode, NSEventModifierMask aFlags, NSMenu aMenu, out NSError outError);
    }

    public interface ISRValidatorDelegate
    {
    }

    // @protocol SRValidatorDelegate
    [Model, BaseType(typeof(NSObject))]
    [Protocol]
    public interface SRValidatorDelegate
    {
        // @optional -(BOOL)shortcutValidator:(SRValidator *)aValidator isKeyCode:(unsigned short)aKeyCode andFlagsTaken:(NSEventModifierFlags)aFlags reason:(NSString **)outReason;
        [Abstract]
        [Export("shortcutValidator:isKeyCode:andFlagsTaken:reason:")]
        bool ShortcutValidator(SRValidator aValidator, ushort aKeyCode, NSEventModifierMask aFlags, out string outReason);

        // @optional -(BOOL)shortcutValidatorShouldCheckMenu:(SRValidator *)aValidator;
        [Abstract]
        [Export("shortcutValidatorShouldCheckMenu:")]
        bool ShortcutValidatorShouldCheckMenu(SRValidator aValidator);

        // @optional -(BOOL)shortcutValidatorShouldCheckSystemShortcuts:(SRValidator *)aValidator;
        [Abstract]
        [Export("shortcutValidatorShouldCheckSystemShortcuts:")]
        bool ShortcutValidatorShouldCheckSystemShortcuts(SRValidator aValidator);

        // @optional -(BOOL)shortcutValidatorShouldUseASCIIStringForKeyCodes:(SRValidator *)aValidator;
        [Abstract]
        [Export("shortcutValidatorShouldUseASCIIStringForKeyCodes:")]
        bool ShortcutValidatorShouldUseASCIIStringForKeyCodes(SRValidator aValidator);
    }

    // @interface SRValidator (NSMenuItem)
    [Category]
    [BaseType(typeof(NSMenuItem))]
    interface NSMenuItem_SRValidator
    {
        // -(NSString *)SR_path;
        [Export("SR_path")]
        string SR_path();
    }

    // @interface SRRecorderControl : NSView
    [BaseType(typeof(NSView))]
    interface SRRecorderControl
    {
        [Wrap("WeakDelegate")]
        SRRecorderControlDelegate Delegate { get; set; }

        // @property (assign) NSObject<SRRecorderControlDelegate> * delegate __attribute__((iboutlet));
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly) NSEventModifierFlags allowedModifierFlags;
        [Export("allowedModifierFlags")]
        NSEventModifierMask AllowedModifierFlags { get; }

        // @property (readonly) NSEventModifierFlags requiredModifierFlags;
        [Export("requiredModifierFlags")]
        NSEventModifierMask RequiredModifierFlags { get; }

        // @property (readonly) BOOL allowsEmptyModifierFlags;
        [Export("allowsEmptyModifierFlags")]
        bool AllowsEmptyModifierFlags { get; }

        // @property BOOL drawsASCIIEquivalentOfShortcut;
        [Export("drawsASCIIEquivalentOfShortcut")]
        bool DrawsASCIIEquivalentOfShortcut { get; set; }

        // @property BOOL allowsEscapeToCancelRecording;
        [Export("allowsEscapeToCancelRecording")]
        bool AllowsEscapeToCancelRecording { get; set; }

        // @property BOOL allowsDeleteToClearShortcutAndEndRecording;
        [Export("allowsDeleteToClearShortcutAndEndRecording")]
        bool AllowsDeleteToClearShortcutAndEndRecording { get; set; }

        // @property (getter = isEnabled, nonatomic) BOOL enabled;
        [Export("enabled")]
        bool Enabled { [Bind("isEnabled")] get; set; }

        // @property (readonly, nonatomic) BOOL isRecording;
        [Export("isRecording")]
        bool IsRecording { get; }

        // @property (copy, nonatomic) NSDictionary * objectValue;
        [Export("objectValue", ArgumentSemantic.Copy)]
        NSDictionary ObjectValue { get; set; }

        // -(void)setAllowedModifierFlags:(NSEventModifierFlags)newAllowedModifierFlags requiredModifierFlags:(NSEventModifierFlags)newRequiredModifierFlags allowsEmptyModifierFlags:(BOOL)newAllowsEmptyModifierFlags;
        [Export("setAllowedModifierFlags:requiredModifierFlags:allowsEmptyModifierFlags:")]
        void SetAllowedModifierFlags(NSEventModifierMask newAllowedModifierFlags, NSEventModifierMask newRequiredModifierFlags, bool newAllowsEmptyModifierFlags);

        // -(void)_initInternalState;
        [Export("_initInternalState")]
        void _initInternalState();

        // -(BOOL)beginRecording;
        [Export("beginRecording")]
        bool BeginRecording { get; }

        // -(void)endRecording;
        [Export("endRecording")]
        void EndRecording();

        // -(void)clearAndEndRecording;
        [Export("clearAndEndRecording")]
        void ClearAndEndRecording();

        // -(void)endRecordingWithObjectValue:(NSDictionary *)anObjectValue;
        [Export("endRecordingWithObjectValue:")]
        void EndRecordingWithObjectValue(NSDictionary anObjectValue);

        // -(NSBezierPath *)controlShape;
        [Export("controlShape")]
        NSBezierPath ControlShape { get; }

        // -(NSRect)rectForLabel:(NSString *)aLabel withAttributes:(NSDictionary *)anAttributes;
        [Export("rectForLabel:withAttributes:")]
        CGRect RectForLabel(string aLabel, NSDictionary anAttributes);

        // -(NSRect)snapBackButtonRect;
        [Export("snapBackButtonRect")]
        CGRect SnapBackButtonRect { get; }

        // -(NSRect)clearButtonRect;
        [Export("clearButtonRect")]
        CGRect ClearButtonRect { get; }

        // -(NSString *)label;
        [Export("label")]
        string Label { get; }

        // -(NSString *)accessibilityLabel;
        [Export("accessibilityLabel")]
        string AccessibilityLabel { get; }

        // -(NSString *)stringValue;
        [Export("stringValue")]
        string StringValue { get; }

        // -(NSString *)accessibilityStringValue;
        [Export("accessibilityStringValue")]
        string AccessibilityStringValue { get; }

        // -(NSDictionary *)labelAttributes;
        [Export("labelAttributes")]
        NSDictionary LabelAttributes { get; }

        // -(NSDictionary *)normalLabelAttributes;
        [Export("normalLabelAttributes")]
        NSDictionary NormalLabelAttributes { get; }

        // -(NSDictionary *)recordingLabelAttributes;
        [Export("recordingLabelAttributes")]
        NSDictionary RecordingLabelAttributes { get; }

        // -(NSDictionary *)disabledLabelAttributes;
        [Export("disabledLabelAttributes")]
        NSDictionary DisabledLabelAttributes { get; }

        // -(void)drawBackground:(NSRect)aDirtyRect;
        [Export("drawBackground:")]
        void DrawBackground(CGRect aDirtyRect);

        // -(void)drawInterior:(NSRect)aDirtyRect;
        [Export("drawInterior:")]
        void DrawInterior(CGRect aDirtyRect);

        // -(void)drawLabel:(NSRect)aDirtyRect;
        [Export("drawLabel:")]
        void DrawLabel(CGRect aDirtyRect);

        // -(void)drawSnapBackButton:(NSRect)aDirtyRect;
        [Export("drawSnapBackButton:")]
        void DrawSnapBackButton(CGRect aDirtyRect);

        // -(void)drawClearButton:(NSRect)aDirtyRect;
        [Export("drawClearButton:")]
        void DrawClearButton(CGRect aDirtyRect);

        // -(BOOL)isMainButtonHighlighted;
        [Export("isMainButtonHighlighted")]
        bool IsMainButtonHighlighted { get; }

        // -(BOOL)isSnapBackButtonHighlighted;
        [Export("isSnapBackButtonHighlighted")]
        bool IsSnapBackButtonHighlighted { get; }

        // -(BOOL)isClearButtonHighlighted;
        [Export("isClearButtonHighlighted")]
        bool IsClearButtonHighlighted { get; }

        // -(BOOL)areModifierFlagsValid:(NSEventModifierFlags)aModifierFlags forKeyCode:(unsigned short)aKeyCode;
        [Export("areModifierFlagsValid:forKeyCode:")]
        bool AreModifierFlagsValid(NSEventModifierMask aModifierFlags, ushort aKeyCode);

        // -(void)propagateValue:(id)aValue forBinding:(NSString *)aBinding;
        [Export("propagateValue:forBinding:")]
        void PropagateValue(NSObject aValue, string aBinding);
    }

    public interface ISRRecorderControlDelegate  { }

    // @protocol SRRecorderControlDelegate <NSObject>
    [Model, BaseType(typeof(NSObject))]
    [Protocol]
    interface SRRecorderControlDelegate
    {
        // @optional -(BOOL)shortcutRecorderShouldBeginRecording:(SRRecorderControl *)aRecorder;
        [Abstract]
        [Export("shortcutRecorderShouldBeginRecording:")]
        bool ShortcutRecorderShouldBeginRecording(SRRecorderControl aRecorder);

        // @optional -(BOOL)shortcutRecorder:(SRRecorderControl *)aRecorder shouldUnconditionallyAllowModifierFlags:(NSEventModifierFlags)aModifierFlags forKeyCode:(unsigned short)aKeyCode;
        [Abstract]
        [Export("shortcutRecorder:shouldUnconditionallyAllowModifierFlags:forKeyCode:")]
        bool ShortcutRecorderShouldUnconditionallyAllowModifierFlags(SRRecorderControl aRecorder, NSEventModifierMask aModifierFlags, ushort aKeyCode);

        // @optional -(BOOL)shortcutRecorder:(SRRecorderControl *)aRecorder canRecordShortcut:(NSDictionary *)aShortcut;
        [Abstract]
        [Export("shortcutRecorder:canRecordShortcut:")]
        bool ShortcutRecorderCanRecordShortcut(SRRecorderControl aRecorder, NSDictionary aShortcut);

        // @optional -(void)shortcutRecorderDidEndRecording:(SRRecorderControl *)aRecorder;
        [Abstract]
        [Export("shortcutRecorderDidEndRecording:")]
        void ShortcutRecorderDidEndRecording(SRRecorderControl aRecorder);
    }
}
