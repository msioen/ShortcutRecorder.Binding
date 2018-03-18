using AppKit;
using Foundation;

namespace ShortcutRecorder.Binding.Test
{
    [Register("AppDelegate")]
    public partial class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }

        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender)
        {
            return true;
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            pingItem.Activated += PingItem_Activated;

            pingItem.BindHotKey(NSUserDefaultsController.SharedUserDefaultsController, "values.pingItem");
        }

        void PingItem_Activated(object sender, System.EventArgs e)
        {
            NSSound.FromName("Ping").Play();
        }

    }
}
