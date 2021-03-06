﻿using System.Web;
using System.Web.Mvc;

namespace HowMvcWorks
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CRM.NLog.StatisticsTrackerAttribute());
        }
    }
}