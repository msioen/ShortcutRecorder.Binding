using ObjCRuntime;

[assembly: LinkWith("ShortcutRecorder.framework", LinkTarget.x86_64, IsCxx = true, SmartLink = true, ForceLoad = true, Frameworks = "Carbon Cocoa", WeakFrameworks = "", LinkerFlags = "")]
