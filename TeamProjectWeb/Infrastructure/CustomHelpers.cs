using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamProject.Common;
using TeamProjectWeb.Models;

namespace TeamProjectWeb.Infrastructure
{
    public static class CustomHelpers
    {

        public static MvcHtmlString WorkItemCounter(this HtmlHelper html, int status, int counter)
        {
            StatusEnum wStatus = (StatusEnum)status;
            TagBuilder tag = new TagBuilder("span");

            switch (wStatus)
            {
                case StatusEnum.ToDo:
                    tag.SetInnerText("To Do");
                    break;
                case StatusEnum.InProgress:
                    tag.SetInnerText("In Progress");
                    break;
                case StatusEnum.Done:
                    tag.SetInnerText("Done");
                    break;
                case StatusEnum.OnHold:
                    tag.SetInnerText("On Hold");
                    break;
                case StatusEnum.Cancelled:
                    tag.SetInnerText("Cancelled");
                    break;
                case StatusEnum.Deleted:
                    tag.SetInnerText("Deleted");
                    break;
            }

            string result=tag.ToString();
            if (counter > 0)
            {
                TagBuilder countTag = new TagBuilder("span");
                countTag.AddCssClass("label label-warning pull-right");
                countTag.SetInnerText(counter.ToString());
                result+=countTag.ToString();
            }

            return new MvcHtmlString(result);

        }
        public static MvcHtmlString StatusTitle(this HtmlHelper html, int status, WorkItemsMenuItemsCounterViewModel statusCounter)
        {
            string result=null;
            TagBuilder tag = new TagBuilder("h2");
            StatusEnum wStatus = (StatusEnum)status;

            string statusText=null;
            int counter = 0;
            switch (wStatus)
            {
                case StatusEnum.ToDo:
                    statusText="To Do";
                    counter = statusCounter.ToDoCounter;
                    break;
                case StatusEnum.InProgress:
                    statusText="In Progress";
                    counter = statusCounter.InProgressCounter;
                    break;
                case StatusEnum.Done:
                    statusText="Done";
                    counter = statusCounter.DoneCounter;
                    break;
                case StatusEnum.OnHold:
                    statusText="On Hold";
                    counter = statusCounter.OnHoldCounter;
                    break;
                case StatusEnum.Cancelled:
                    statusText="Cancelled";
                    counter = statusCounter.CancelledCounter;
                    break;
                case StatusEnum.Deleted:
                    statusText="Deleted";
                    counter = statusCounter.DeletedCounter;
                    break;
            }
            result = statusText;
            if (counter > 0)
            {
                result = String.Format("{0} ({1})", result, counter.ToString());
            }

            tag.SetInnerText(result);

            return new MvcHtmlString(tag.ToString());

            
        }


        public static MvcHtmlString WorkItemIdFormated(this HtmlHelper html, int workItemId)
        {

            string formatedId = workItemId.ToString("00000");
            return new MvcHtmlString(formatedId);
        }
    }
}