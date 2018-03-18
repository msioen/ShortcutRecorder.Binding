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
	partial class AppDelegate
	{
		[Outlet]
		AppKit.NSMenuItem pingItem { get; set; }

		[Action ("ping:")]
		partial void ping (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (pingItem != null) {
				pingItem.Dispose ();
				pingItem = null;
			}
		}
	}
}
