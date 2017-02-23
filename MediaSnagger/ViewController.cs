using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var specificDesiredNames = new List<string> { "Bloom.caf", "Calypso.caf", "Choo_Choo.caf", "Fanfare.caf", "Ladder.caf", "Noir.caf", "Sherwood_Forest.caf", "Telegraph.caf", "Tiptoes.caf" };
            var soundFiles = new List<string>();

            using (var fileManager = new NSFileManager())
            {
                var enumerator = fileManager.GetEnumerator(soundDirectory);

                while (true)
                {
                    var item = enumerator.NextObject();
                    if (item == null) break;
                    var itemName = item.ToString();
                    if ((itemName.Contains("sms") && !itemName.Contains("received")) || specificDesiredNames.Any(n => itemName.Contains(n)))
                    {
                        soundFiles.Add(itemName);
                    }
                }

                NSError error;
                var destPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                foreach (var fileNameAndPath in soundFiles)
                {
                    var src = $"{soundDirectory}/{fileNameAndPath}";
                    var fileName = fileNameAndPath;
                    if (fileNameAndPath.Contains('/'))
                    {
                        fileName = fileNameAndPath.Split('/').Last();
                    }

                    var dst = $"{destPath}/{fileName}";


                    fileManager.Copy(src, dst, out error);
                    if (error != null)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
            }

            Console.WriteLine("***************** DONE *******************");
            Console.WriteLine("***************** DONE *******************");
            Console.WriteLine("***************** DONE *******************");
            Console.WriteLine("***************** DONE *******************");
            Console.WriteLine("***************** DONE *******************");
            Console.WriteLine("***************** DONE *******************");
            Console.WriteLine("***************** DONE *******************");
            Console.WriteLine("***************** DONE *******************");
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}