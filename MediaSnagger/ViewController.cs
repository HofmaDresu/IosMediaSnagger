using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace MediaSnagger
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            LoadAudioFileList();
        }

        private void LoadAudioFileList()
        {
            var soundDirectory = "/System/Library/Audio/UISounds";
            var soundFiles = new List<string> { "Bloom.caf", "Calypso.caf", "Choo_Choo.caf", "Fanfare.caf", "Ladder.caf", "Noir.caf", "Sherwood_Forest.caf", "Telegraph.caf", "Tiptoes.caf" };

            using (var fileManager = new NSFileManager())
            {
                var enumerator = fileManager.GetEnumerator(soundDirectory);

                while (true)
                {
                    var item = enumerator.NextObject();
                    if (item == null) break;
                    var itemNameAndDirectory = item.ToString().Split('/');
                    var itemName = "";
                    if (itemNameAndDirectory.Length <2)
                    {
                        itemName = itemNameAndDirectory[0];
                    }
                    else
                    {
                        itemName = itemNameAndDirectory[itemNameAndDirectory.Length - 1];
                    }
                    if (itemName.StartsWith("sms"))
                    {
                        soundFiles.Add(item.ToString());
                    }
                }

                NSError error;
                //fileManager.Copy(soundDirectory, "./", out error);
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}