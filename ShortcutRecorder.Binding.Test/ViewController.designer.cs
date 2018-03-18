// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ShortcutRecorder.Binding.Test
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		ShortcutRecorder.SRRecorderControl globalPingShortcutRecorder { get; set; }

		[Outlet]
		AppKit.NSButton pingButton { get; set; }

		[Outlet]
		ShortcutRecorder.SRRecorderControl pingItemShortcutRecorder { get; set; }

		[Outlet]
		ShortcutRecorder.SRRecorderControl pingShortcutRecorder { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (globalPingShortcutRecorder != null) {
				globalPingShortcutRecorder.Dispose ();
				globalPingShortcutRecorder = null;
			}

			if (pingItemShortcutRecorder != null) {
				pingItemShortcutRecorder.Dispose ();
				pingItemShortcutRecorder = null;
			}

			if (pingShortcutRecorder != null) {
				pingShortcutRecorder.Dispose ();
				pingShortcutRecorder = null;
			}

			if (pingButton != null) {
				pingButton.Dispose ();
				pingButton = null;
			}
		}
	}
}
