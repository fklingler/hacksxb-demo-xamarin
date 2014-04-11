using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using HackSXB.Core;
using System.Collections.Generic;

namespace HackSXB.App.iOS
{
    public class QuestionTableViewSource : UITableViewSource
    {
        public List<Question> Questions { get; set; }

        public QuestionTableViewSource()
        {
            Questions = new List<Question>();
        }

        public override int NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return Questions.Count;
        }

//        public override string TitleForHeader(UITableView tableView, int section)
//        {
//            return "Header";
//        }
//
//        public override string TitleForFooter(UITableView tableView, int section)
//        {
//            return "Footer";
//        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(QuestionTableViewCell.Key) as QuestionTableViewCell;
            if (cell == null)
                cell = new QuestionTableViewCell();
			
            // TODO: populate the cell with the appropriate data based on the indexPath
            cell.TextLabel.Text = Questions[indexPath.Item].Title;
			
            return cell;
        }
    }
}

