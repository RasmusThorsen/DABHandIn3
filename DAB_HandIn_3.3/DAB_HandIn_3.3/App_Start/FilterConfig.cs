﻿using System.Web;
using System.Web.Mvc;

namespace DAB_HandIn_3._3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
