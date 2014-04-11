using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HackSXB.App.iOS
{
    public class QuestionTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("QuestionTableViewControllerCell");

        public QuestionTableViewCell() : base(UITableViewCellStyle.Value1, Key)
        {
            // TODO: add subviews to the ContentView, set various colors, etc.
        }
    }
}

