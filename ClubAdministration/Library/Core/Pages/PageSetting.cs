using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubAdministration.Library.Core.Pages
{
    public class PageSetting
    {
        private BaseController parent;
        public string ReturnUrl { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }
        public string SortField { get; set; }
        public string SearchItem
        {
            get
            {
                return this.parent.ViewBag.search;
            }
        }
        public string SortType { get; set; }
        public ControllerSetting Parent { get; set; }
        public PageSetting(BaseController prn)
        {
            parent = prn;
            parent.ViewBag.search = (parent.Request.Form["search"] != null)? parent.Request.Form["search"] : "";
            this.PageNumber = "1";
            this.PageSize = "5";
            this.SortField = "";
            this.SortType = "asc";
        }
        public int getIntPageNumber()
        {
            if (this.PageNumber == "")
                return 1;
            else
                return Int32.Parse(this.PageNumber);
        }
        public int getIntPageSize()
        {
            if (this.PageSize == "")
                return 1;
            else
                return Int32.Parse(this.PageSize);
        }

    }
}