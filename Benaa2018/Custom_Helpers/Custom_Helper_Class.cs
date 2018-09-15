using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace Benaa2018.Custom_Helpers
{
    public static class Custom_Helper_Class
    {
        public static HtmlString Create_Lable(string Content)
            {
                string LableStr = "<label class=\"lblStatus\" style=\"background-color:gray;color:yellow;font-size:24px\">{Content}</label>";
                return new HtmlString(LableStr);
            }

        //public static HtmlString Create_DropDown(string Content)
        //{
        //    //string LableStr = "<label class=\"lblStatus\" style=\"background-color:gray;color:yellow;font-size:24px\">{Content}</label>";
        //   // string ddlUser= "<select asp-for="lstCheckListDetail[Model.lstCheckListDetail.IndexOf(item)].ToDoCheckListUserId" class="ddldropdown">"
        //    return new HtmlString(LableStr);
        //}

    }
}
